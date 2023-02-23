using System;
using System.IO;
using System.Threading.Tasks;
using GameStarter.Content.Loading;
using GameStarter.Debugging;
using GameStarter.Display;
using Symphony;

namespace GameStarter;

class MainGame : Game
{
    public static ContentManager<ContentMeta> ContentManager { get; private set; }

    public override void Initialize(string[] args)
    {
        Logging.StartLogging();
        Logging.SetLogLevel(LogLevel.Debug);
        Logging.Log(LogLevel.Info, "Initializing...");
    }

    public override void LoadContent(string[] args)
    {
        Logging.Log(LogLevel.Info, "Loading content...");

        var basePath = @"C:\Users\RichieZ\repos\game-starter";

        Func<string, IContentSource> pathFactory = (string path) =>
        {
            if (Path.GetExtension(path) == ".zip")
            {
                return new Symphony.Common.ZipFileContentSource(path);
            }
            else if (Directory.Exists(path))
            {
                return new Symphony.Common.DirectoryContentSource(path);
            }

            return null;
        };

        var baseGameContent = new Symphony.Common.DirectoryContentSource($"{basePath}\\resources");
        var mods = new Symphony.Common.DirectoryCollectionProvider($"{basePath}\\mods", pathFactory);
        var collectionProvider = new Symphony.Common.ContentCollectionCombiner(IContentCollectionProvider.FromListOfSources(baseGameContent), mods);
        var validator = new ContentValidator();

        var loader = new ContentLoader();

        var config = new ContentManagerConfiguration<ContentMeta>(validator, collectionProvider, loader);
        ContentManager = new ContentManager<ContentMeta>(config);

        ContentManager.StartedLoading += (sender, e) =>
        {
            Logging.Log(LogLevel.Info, "Started loading content.");
        };

        ContentManager.FinishedLoading += (sender, e) =>
        {
            Logging.Log(LogLevel.Info, "Finished loading content.");

            _ = Task.Run(async () =>
            {
                while (true)
                {
                    await ContentManager.PollForSourceUpdates();
                    await Task.Delay(1000);
                }
            });
        };

        ContentManager.ContentItemReloaded += (sender, e) =>
        {
            Logging.Log(LogLevel.Info, $"Reloaded {e.Item.Identifier}");
        };

        ContentManager.ContentItemSuccessfullyLoaded += (sender, e) =>
        {
            Logging.Log(LogLevel.Info, $"Loaded {e.Item.Identifier} from {loader.GetIdentifierForSource(e.ContentFrom)}");
        };

        ContentManager.Load();
    }

    public override void Update()
    {

    }

    public override void Render()
    {
        DisplayManager.SwapBuffers();
    }

    public override void Unload()
    {
        ContentManager.UnloadAllContent();
    }
}