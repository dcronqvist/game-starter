using DotGLFW;
using GameStarter.Input;

namespace GameStarter.Display;

abstract class Game
{
    public abstract void Initialize(string[] args);
    public abstract void LoadContent(string[] args);
    public abstract void Update();
    public abstract void Render();
    public abstract void Unload();

    public void Run(int winWidth, int winHeight, string winTitle, bool maximized, string[] args)
    {
        bool macMove = false;

        Initialize(args);

        DisplayManager.InitWindow(winWidth, winHeight, winTitle, maximized);

        LoadContent(args);

        Keyboard.Init();
        Mouse.Init();

        GameTime.DeltaTime = 0;
        GameTime.TotalElapsedSeconds = 0;

        while (!DisplayManager.GetWindowShouldClose())
        {
            GameTime.DeltaTime = (float)Glfw.GetTime() - GameTime.TotalElapsedSeconds;
            GameTime.TotalElapsedSeconds = (float)Glfw.GetTime();

            DisplayManager.PollEvents();

            Keyboard.Begin();
            Mouse.Begin();

            Update();

            Render();

            if (!macMove)
            {
                Glfw.SetWindowSize(DisplayManager.WindowHandle, winWidth + 1, winHeight + 1);
                Glfw.SetWindowSize(DisplayManager.WindowHandle, winWidth, winHeight);
                macMove = true;
            }

            Keyboard.End();
            Mouse.End();

            if (DisplayManager.TargetFPS != 0)
            {
                float waitTime = DisplayManager.FrameTime;
                while (Glfw.GetTime() < GameTime.TotalElapsedSeconds + waitTime) { }
            }
        }

        Unload();

        DisplayManager.CloseWindow();
    }
}
