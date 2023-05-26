using System;
using System.Drawing;
using System.Numerics;
using GameStarter.Debugging;
using DotGLFW;
using static GameStarter.Display.GL;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GameStarter.Display;

public static class DisplayManager
{
    public static Window WindowHandle { get; set; }
    public static event EventHandler<Vector2> OnFramebufferResize;
    public static event EventHandler<bool> OnToggleFullscreen;
    private static bool manuallySetClose;
    public static int TargetFPS { get; set; }
    public static float FrameTime
    {
        get
        {
            return 1.0f / TargetFPS;
        }
    }

    private static void PrepareContext(bool maximized)
    {
        Glfw.Init();

        // Set some common hints for the OpenGL profile creation
        Glfw.WindowHint(Hint.ClientAPI, ClientAPI.OpenGLAPI);
        Glfw.WindowHint(Hint.ContextVersionMajor, GL.GetProjectOpenGLVersionMajor());
        Glfw.WindowHint(Hint.ContextVersionMinor, GL.GetProjectOpenGLVersionMinor());
        Glfw.WindowHint(Hint.OpenGLForwardCompat, true);

        Glfw.WindowHint(Hint.CocoaRetinaFramebuffer, false);
        Glfw.WindowHint(Hint.ScaleToMonitor, false);

        string projectProfileString = GL.GetProjectOpenGLProfile();
        OpenGLProfile profile = projectProfileString == "CORE" ? OpenGLProfile.CoreProfile : OpenGLProfile.CompatProfile;

        Glfw.WindowHint(Hint.OpenGLProfile, profile);
        Glfw.WindowHint(Hint.DoubleBuffer, true);
        Glfw.WindowHint(Hint.Decorated, true);
        Glfw.WindowHint(Hint.Maximized, maximized);
        Glfw.WindowHint(Hint.Samples, 4);

        manuallySetClose = false;
    }

    public static void SetTargetFPS(int fps)
    {
        TargetFPS = fps;
    }

    private static Window CreateWindow(int width, int height, string title, int minWidth = 1280, int minHeight = 720)
    {
        // Create window, make the OpenGL context current on the thread, and import graphics functions
        Window window = Glfw.CreateWindow(width, height, title, Monitor.NULL, Window.NULL);

        Monitor primaryMonitor = Glfw.GetPrimaryMonitor();
        Glfw.GetMonitorWorkarea(primaryMonitor, out int x, out int y, out int w, out int h);

        // Center window
        int wx = w / 2 - width / 2;
        int wy = h / 2 - height / 2;
        Glfw.SetWindowPos(window, wx, wy);

        Glfw.MakeContextCurrent(window);
        GL.Import(Glfw.GetProcAddress);

        var version = GL.glGetStringSafe(GL_VERSION);
        var vendor = GL.glGetStringSafe(GL_VENDOR);
        var renderer = GL.glGetStringSafe(GL_RENDERER);
        var glslVersion = GL.glGetStringSafe(GL_SHADING_LANGUAGE_VERSION);

        Logging.Log(LogLevel.Info, $"OpenGL version: {version}");
        Logging.Log(LogLevel.Info, $"OpenGL vendor: {vendor}");
        Logging.Log(LogLevel.Info, $"OpenGL renderer: {renderer}");
        Logging.Log(LogLevel.Info, $"GLSL version: {glslVersion}");

        Glfw.SetWindowSizeLimits(window, minWidth, minHeight, Glfw.DontCare, Glfw.DontCare);
        return window;
    }

    public static float GetAspectRatio()
    {
        var size = GetWindowSizeInPixels();
        return size.X / size.Y;
    }

    public static void ReleaseGLContext()
    {
        Glfw.MakeContextCurrent(Window.NULL);
    }

    public static void AcquireGLContext()
    {
        Glfw.MakeContextCurrent(WindowHandle);
    }

    private static readonly object _glLock = new object();

    public static void LockedGLContext(Action action)
    {
        if (HasGLContext())
        {
            action();
            return;
        }

        lock (_glLock)
        {
            var oldContext = Glfw.GetCurrentContext();

            if (oldContext == WindowHandle)
            {
                action();
                return;
            }

            Glfw.MakeContextCurrent(WindowHandle);
            action();
            Glfw.MakeContextCurrent(oldContext);
        }
    }

    public static bool HasGLContext()
    {
        return Glfw.GetCurrentContext() == WindowHandle;
    }

    public unsafe static void InitWindow(int width, int height, string title, bool maximized, int minWidth = 1280, int minHeight = 720)
    {
        PrepareContext(maximized);
        WindowHandle = CreateWindow(width, height, title, minWidth, minHeight);

        if (OperatingSystem.IsWindows())
        {
            Icon icon = Icon.ExtractAssociatedIcon(Environment.ProcessPath);
            var iconBitmap = icon.ToBitmap();
            var pixelData = iconBitmap.LockBits(new Rectangle(0, 0, iconBitmap.Width, iconBitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, iconBitmap.PixelFormat);

            byte[] pixels = new byte[iconBitmap.Width * iconBitmap.Height * 4];

            // Reverse the color channels
            for (int i = 0; i < pixelData.Stride * pixelData.Height; i += 4)
            {
                byte r = *(byte*)(pixelData.Scan0 + i);
                byte b = *(byte*)(pixelData.Scan0 + i + 2);
                *(byte*)(pixelData.Scan0 + i) = b;
                *(byte*)(pixelData.Scan0 + i + 2) = r;
            }

            Marshal.Copy(pixelData.Scan0, pixels, 0, pixels.Length);

            DotGLFW.Image image = new DotGLFW.Image() { Width = iconBitmap.Width, Height = iconBitmap.Height, Pixels = pixels };
            Glfw.SetWindowIcon(WindowHandle, new DotGLFW.Image[] { image });
        }

        Glfw.SetWindowMaximizeCallback(WindowHandle, (window, maximized) =>
        {
            Vector2 windowSize = GetWindowSizeInPixels();
            OnFramebufferResize?.Invoke(null, windowSize);
            Logging.Log(LogLevel.Info, $"Window size changed to {windowSize.X}x{windowSize.Y} because of {(maximized ? "maximization" : "minimization")}");
            OnToggleFullscreen?.Invoke(null, maximized);
        });

        Glfw.SetFramebufferSizeCallback(WindowHandle, (Window, w, h) =>
        {
            OnFramebufferResize?.Invoke(null, new Vector2(w, h));
            Logging.Log(LogLevel.Info, $"Framebuffer size changed to {w}x{h}");
        });

        //GL.glEnable(GL_DEBUG_OUTPUT);

        // GL.glDebugMessageCallback((source, type, id, severity, length, message, param) =>
        // {
        //     Console.WriteLine($"OpenGL: {message}");
        // }, (void*)0);
    }

    public static void CloseWindow()
    {
        Glfw.Terminate();
    }

    public static Vector2 GetWindowSizeInPixels()
    {
        Glfw.GetFramebufferSize(WindowHandle,
                                out int width,
                                out int height);

        return new Vector2(width, height);
    }

    public static void SetWindowSizeInPixels(Vector2 size)
    {
        Glfw.SetWindowSize(WindowHandle, (int)size.X, (int)size.Y);
    }

    public static bool IsWindowFocused()
    {
        return Glfw.GetWindowAttrib(WindowHandle, WindowAttrib.Focused);
    }

    // public unsafe static void SetWindowIcon(Texture2D texture)
    // {
    //     Glfw.SetWindowIcon(WindowHandle, 1, new Image[] { texture.GetAsGLFWImage() });
    // }

    public unsafe static void SetCursorToPlatformStandard(CursorShape cursorType)
    {
        var cursor = Glfw.CreateStandardCursor(cursorType);
        Glfw.SetCursor(WindowHandle, cursor);
    }

    // public unsafe static void SetCursorToTexture(Texture2D texture, int xHotspot, int yHotspot)
    // {
    //     Glfw.SetCursor(WindowHandle, Glfw.CreateCursor(texture.GetAsGLFWImage(), xHotspot, yHotspot));
    // }

    public static void SetWindowShouldClose(bool value)
    {
        manuallySetClose = value;
    }

    public static bool GetWindowShouldClose()
    {
        return Glfw.WindowShouldClose(WindowHandle) || manuallySetClose;
    }

    public static void SwapBuffers(int swapInterval = 0)
    {
        Glfw.SwapInterval(swapInterval);
        Glfw.SwapBuffers(WindowHandle);
    }

    public static void PollEvents()
    {
        Glfw.PollEvents();
    }

    public static void SetWindowTitle(string title)
    {
        Glfw.SetWindowTitle(WindowHandle, title);
    }

    // public static Vector2 GetViewSize(Camera2D camera)
    // {
    //     Vector2 windowSize = GetWindowSizeInPixels();
    //     return new Vector2(windowSize.X / camera.Zoom, windowSize.Y / camera.Zoom);
    // }
}