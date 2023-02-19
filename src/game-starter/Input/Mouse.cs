using System;
using System.Collections.Generic;
using System.Numerics;
using GameStarter.Display;
using GameStarter.Display.GLFW;

namespace GameStarter.Input;

public static class Mouse
{
    public static Dictionary<MouseButton, bool> currentMouseState;
    public static Dictionary<MouseButton, bool> previousMouseState;

    public static double currentMouseScroll;
    public static double previousMouseScroll;

    public static Vector2 currentMousePosition;
    public static Vector2 previousMousePosition;

    public static event EventHandler<float> OnScroll;

    public static void Init()
    {
        currentMouseState = GetMouseState();
        previousMouseState = currentMouseState;

        currentMousePosition = GetMousePositionInWindow();
        previousMousePosition = currentMousePosition;

        Glfw.SetScrollCallback(DisplayManager.WindowHandle, (window, x, y) =>
        {
            currentMouseScroll += y;
            OnScroll?.Invoke(null, (float)y);
        });
    }

    public static void Begin()
    {
        currentMouseState = GetMouseState();
        currentMousePosition = GetMousePositionInWindow();
    }

    public static void End()
    {
        previousMouseState = currentMouseState;
        previousMouseScroll = currentMouseScroll;
        previousMousePosition = currentMousePosition;
    }

    public static Dictionary<MouseButton, bool> GetMouseState()
    {
        MouseButton[] mouseButtons = Enum.GetValues<MouseButton>();
        Dictionary<MouseButton, bool> dic = new Dictionary<MouseButton, bool>();

        foreach (MouseButton button in mouseButtons)
        {
            if (!dic.ContainsKey(button))
            {
                dic.Add(button, Glfw.GetMouseButton(DisplayManager.WindowHandle, button) == InputState.Press);
            }
        }

        return dic;
    }

    public static bool IsMouseButtonDown(MouseButton button)
    {
        return currentMouseState[button];
    }

    public static bool IsMouseButtonPressed(MouseButton button)
    {
        return currentMouseState[button] && !previousMouseState[button];
    }

    public static bool IsMouseButtonReleased(MouseButton button)
    {
        return !currentMouseState[button] && previousMouseState[button];
    }

    public static Vector2 GetMousePositionInWindow()
    {
        Glfw.GetCursorPosition(DisplayManager.WindowHandle, out double x, out double y);
        return new Vector2((float)x, (float)y);
    }

    // public static Vector2 GetMousePosition(Camera2D offsetCamera)
    // {
    //     Vector2 windowSize = DisplayManager.GetWindowSizeInPixels();
    //     Vector2 topLeft = offsetCamera.TopLeft;

    //     Glfw.GetCursorPosition(DisplayManager.WindowHandle, out double x, out double y);

    //     return topLeft + (new Vector2((float)x, (float)y)) / offsetCamera.Zoom;
    // }

    public static void SetMousePosition(int x, int y)
    {
        Glfw.SetCursorPosition(DisplayManager.WindowHandle, x, y);
    }

    public static Vector2 GetMouseWindowDelta()
    {
        return currentMousePosition - previousMousePosition;
    }

    public static int GetScroll()
    {
        return (int)(currentMouseScroll - previousMouseScroll);
    }
}