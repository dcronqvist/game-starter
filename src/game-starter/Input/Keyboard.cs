using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using DotGLFW;
using GameStarter.Display;

namespace GameStarter.Input;

public static class Keyboard
{
    public static Dictionary<Keys, bool> currentKeyboardState;
    public static Dictionary<Keys, bool> previousKeyboardState;

    public static event EventHandler<char> OnChar;
    public static event EventHandler OnBackspace;
    public static event EventHandler<Tuple<char, ModifierKeys>> OnCharMods;
    public static event EventHandler OnEnterPressed;
    public static event EventHandler<Tuple<Keys, ModifierKeys>> OnKeyPressOrRepeat;
    public static event EventHandler<Tuple<Keys, ModifierKeys>> OnKeyRelease;
    public static event EventHandler<int> OnKeyPressOrRepeatScanCode;
    public static event EventHandler<int> OnKeyReleaseScanCode;

    public static void Init()
    {
        currentKeyboardState = GetKeyboardState();
        previousKeyboardState = currentKeyboardState;

        Glfw.SetCharCallback(DisplayManager.WindowHandle, (Window, codePoint) =>
        {
            OnChar?.Invoke(null, (char)codePoint);
        });

        Glfw.SetKeyCallback(DisplayManager.WindowHandle, (Window, key, scanCode, state, mods) =>
        {
            if ((state.HasFlag(InputState.Press) || state.HasFlag(InputState.Repeat)))
            {
                OnKeyPressOrRepeatScanCode?.Invoke(null, scanCode);
            }
            else if (state.HasFlag(InputState.Release))
            {
                OnKeyReleaseScanCode?.Invoke(null, scanCode);
            }

            if (key == Keys.Backspace)
            {
                if (state != InputState.Release)
                {
                    OnBackspace?.Invoke(null, EventArgs.Empty);
                }
            }
            else if (key == Keys.Enter)
            {
                if (state != InputState.Release)
                {
                    OnEnterPressed?.Invoke(null, EventArgs.Empty);
                }
            }

            string s = Glfw.GetKeyName(key, scanCode);
            if (s != "" && mods != 0 && (state.HasFlag(InputState.Press) || state.HasFlag(InputState.Repeat)))
            {
                OnCharMods?.Invoke(null, new Tuple<char, ModifierKeys>(s[0], mods));
            }

            if ((state.HasFlag(InputState.Press) || state.HasFlag(InputState.Repeat)))
            {
                OnKeyPressOrRepeat?.Invoke(null, new Tuple<Keys, ModifierKeys>(key, mods));
            }
            else if (state.HasFlag(InputState.Release))
            {
                OnKeyRelease?.Invoke(null, new Tuple<Keys, ModifierKeys>(key, mods));
            }
        });
    }

    public static Dictionary<Keys, bool> GetKeyboardState()
    {
        Keys[] keys = Enum.GetValues<Keys>();
        Dictionary<Keys, bool> dic = new Dictionary<Keys, bool>();
        foreach (Keys key in keys)
        {
            if (key != Keys.Unknown)
            {
                dic.Add(key, Glfw.GetKey(DisplayManager.WindowHandle, key) == InputState.Press);
            }
        }
        return dic;
    }

    public static void Begin()
    {
        currentKeyboardState = GetKeyboardState();

    }

    public static void End()
    {
        previousKeyboardState = currentKeyboardState;
    }

    public static bool IsKeyDown(Keys key)
    {
        return currentKeyboardState[key];
    }

    public static bool IsKeyPressed(Keys key)
    {
        return currentKeyboardState[key] && !previousKeyboardState[key];
    }

    public static bool IsKeyReleased(Keys key)
    {
        return !currentKeyboardState[key] && previousKeyboardState[key];
    }

    public static bool IsKeyComboPressed(params Keys[] keys)
    {
        foreach (var key in keys.Take(keys.Length - 1))
        {
            if (!IsKeyDown(key))
            {
                return false;
            }
        }

        var lastPressed = IsKeyPressed(keys.Last());
        var current = currentKeyboardState.Where(kvp => kvp.Value == true).Select(kvp => kvp.Key);

        // Return lastPressed & NO OTHER KEY IS PRESSED
        return lastPressed && current.Except(keys).Count() == 0;
    }

    public static bool TryGetNextKeyPressed(out Keys key)
    {
        if (currentKeyboardState.Any(kvp => kvp.Value == true && previousKeyboardState[kvp.Key] == false))
        {
            key = currentKeyboardState.First(kvp => kvp.Value == true && previousKeyboardState[kvp.Key] == false).Key;
            return true;
        }
        key = Keys.Unknown;
        return false;
    }
}