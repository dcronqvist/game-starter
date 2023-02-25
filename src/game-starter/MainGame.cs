using System;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using GameStarter.Content.Loading;
using GameStarter.Debugging;
using GameStarter.Display;
using GameStarter.Graphics;
using GameStarter.Graphics.Rendering;
using GameStarter.Input;
using NLua;
using LogiX.Rendering;
using Symphony;
using static GameStarter.Display.GL;
using GameStarter.Scripts;

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

        DisplayManager.OnFramebufferResize += (sender, e) =>
        {
            DisplayManager.LockedGLContext(() =>
            {
                glViewport(0, 0, (int)e.X, (int)e.Y);
            });
        };

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

        // Regex below matches all files that don't have a .lua extension, so .lua scripts NEVER get overwritten by load order
        var config = new ContentManagerConfiguration<ContentMeta>(validator, collectionProvider, loader, false, @"^[^.]+$|\.(?!(lua)$)([^.]+$)");
        ContentManager = new ContentManager<ContentMeta>(config);

        ContentManager.StartedLoading += (sender, e) =>
        {
            Logging.Log(LogLevel.Info, "Started loading content.");
        };

        ContentManager.FinishedLoading += (sender, e) =>
        {
            Logging.Log(LogLevel.Info, "Finished loading content.");
            Scripting.Initialize();

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

            if (e.Item is LuaScript)
            {
                // Need to reload scripting
                Scripting.Unload();
                Scripting.Initialize();
            }
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
        PrimitiveRenderer.InitGL();

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
        var primShader = ContentManager.GetContentItem<ShaderProgram>("resources:core/shaders/primitives/primitives.shader");
        var font1 = ContentManager.GetContentItem<Font>("resources:core/fonts/coders_crux.font");
        var texture = ContentManager.GetContentItem<Texture2D>("resources:core/textures/bomb.png");

        if (!Scripting.IsInitialized)
        {
            return;
        }

        var scale = Vector2.One;

        var pos1 = Mouse.GetMousePosition(Framebuffer.GetDefaultCamera());

        var data = Scripting.LuaState["data"] as LuaTable;

        for (int i = 0; i < data.Values.Count; i++)
        {
            var text = data[i + 1] as string;
            TextRenderer.RenderText(font1, text, pos1 + new Vector2(0, i * 50), scale, Framebuffer.GetDefaultCamera());
        }


        //TextureRenderer.Render(shader, texture, pos1, Vector2.One * 10f, 0f, ColorF.White, new Vector2(0.5f, 0.5f), Framebuffer.GetDefaultCamera());
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
        Scripting.Unload();
        ContentManager.UnloadAllContent();
    }
}