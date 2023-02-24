using System;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using GameStarter.Content.Loading;
using GameStarter.Debugging;
using GameStarter.Display;
using GameStarter.Graphics;
using GameStarter.Graphics.Rendering;
using LogiX.Rendering;
using Symphony;
using static GameStarter.Display.GL;

namespace GameStarter;

class MainGame : Game
{
    public static ContentManager<ContentMeta> ContentManager { get; private set; }
    bool _coreDone = false;

    public override void Initialize(string[] args)
    {
        Logging.StartLogging();
        Logging.SetLogLevel(LogLevel.Debug);
        Logging.Log(LogLevel.Info, "Initializing...");
    }

    public override void LoadContent(string[] args)
    {
        Logging.Log(LogLevel.Info, "Loading content...");

#if DEBUG
        var basePath = @"..\..\";
#elif RELEASE
        var basePath = Path.GetDirectoryName(System.AppContext.BaseDirectory);
#endif
        basePath = Path.GetFullPath(basePath);
        Logging.Log(LogLevel.Debug, $"Base path: {basePath}");

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

#if DEBUG   // Only apply hot reload in debug builds
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    await ContentManager.PollForSourceUpdates();
                    await Task.Delay(1000);
                }
            });
#endif
        };

        ContentManager.StartedLoadingStage += (sender, e) =>
        {
            Logging.Log(LogLevel.Info, $"Started loading stage {e.Stage.StageName}");
        };

        ContentManager.FinishedLoadingStage += (sender, e) =>
        {
            Logging.Log(LogLevel.Info, $"Finished loading stage {e.Stage.StageName}");
            if (e.Stage is CoreLoadingStage)
            {
                this._coreDone = true;
            }
        };

        ContentManager.ContentItemReloaded += (sender, e) =>
        {
            Logging.Log(LogLevel.Info, $"Reloaded {e.Item.Identifier}");
        };

        ContentManager.ContentItemSuccessfullyLoaded += (sender, e) =>
        {
            Logging.Log(LogLevel.Info, $"Loaded {e.Item.Identifier} from {loader.GetIdentifierForSource(e.ContentFrom)}");
        };

        ContentManager.ContentFailedToLoadError += (sender, e) =>
        {
            Logging.Log(LogLevel.Error, $"Failed to load {e.Error}");
        };

        glEnable(GL_BLEND);
        glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
        TextureRenderer.InitGL();
        Framebuffer.InitQuad();
        TextRenderer.InitGL();

        DisplayManager.ReleaseGLContext();
        _ = ContentManager.LoadAsync();

    }

    public override void Update()
    {

    }

    public void InnerRender()
    {
        Framebuffer.Clear(ColorF.Darken(ColorF.CycleHue(GameTime.TotalElapsedSeconds * 30f), 0.5f));

        var shader = ContentManager.GetContentItem<ShaderProgram>("resources:core/shaders/textures/texture.shader");
        var font = ContentManager.GetContentItem<Font>("resources:core/fonts/inconsolata.font");
        var texture = ContentManager.GetContentItem<Texture2D>("resources:core/textures/bomb.png");

        TextureRenderer.Render(shader, texture, new Vector2(50, 100), Vector2.One, 0f, ColorF.White, new Vector2(0.5f, 0.5f), Framebuffer.GetDefaultCamera());

        TextRenderer.RenderText(font, "Hello, World!", new Vector2(50, 100), Vector2.One * (MathF.Sin(GameTime.TotalElapsedSeconds) + 2f), Framebuffer.GetDefaultCamera());

        DisplayManager.SwapBuffers(-1);
    }

    public override void Render()
    {
        DisplayManager.LockedGLContext(() =>
        {
            if (this._coreDone)
            {
                this.InnerRender();
            }
        });
    }

    public override void Unload()
    {
        ContentManager.UnloadAllContent();
    }
}