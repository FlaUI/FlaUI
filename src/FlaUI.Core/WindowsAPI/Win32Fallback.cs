using System;
using System.Runtime.InteropServices;
using System.Text;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.WindowsAPI
{
    /// <summary>
    /// This class wraps the various win32 fallback methods which are used in case UIA fails.
    /// </summary>
    internal static class Win32Fallback
    {
        // ReSharper disable InconsistentNaming
        internal static class ButtonMessages
        {
            public const uint BM_SETCHECK = 0x00F1;
            public const uint BM_GETCHECK = 0x00F0;
        }

        internal static class ButtonStates
        {
            public const uint BST_UNCHECKED = 0x0000;
            public const uint BST_CHECKED = 0x0001;
            public const uint BST_INDETERMINATE = 0x0002;
        }
        // ReSharper restore InconsistentNaming

        internal static bool GetTextWin32(AutomationElement automationElement, out string textOut)
        {
            // try with native Win32 function SetWindowText
            if (automationElement.Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = automationElement.Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != IntPtr.Zero)
                {
                    var textLengthPtr = User32.SendMessage(windowHandle, WindowsMessages.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
                    if (textLengthPtr.ToInt32() > 0)
                    {
                        var textLength = textLengthPtr.ToInt32() + 1;
                        var text = new StringBuilder(textLength);
                        User32.SendMessage(windowHandle, WindowsMessages.WM_GETTEXT, textLength, text);
                        textOut = text.ToString();
                        return true;
                    }
                }
            }
            textOut = string.Empty;
            return false;
        }

        internal static bool SetTextWin32(AutomationElement automationElement, string text)
        {
            // try with native Win32 function SetWindowText
            if (automationElement.Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = automationElement.Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != IntPtr.Zero)
                {
                    var textPtr = Marshal.StringToBSTR(text);
                    try
                    {
                        if (textPtr != IntPtr.Zero)
                        {
                            if (User32.SendMessage(windowHandle, WindowsMessages.WM_SETTEXT, IntPtr.Zero, textPtr) == Win32Constants.TRUE)
                            {
                                return true;
                            }
                        }
                    }
                    catch
                    {
                        // ignored
                    }
                    finally
                    {
                        Marshal.FreeBSTR(textPtr);
                    }
                }
            }
            return false;
        }

        internal static ToggleState? GetToggleStateWin32(AutomationElement automationElement)
        {
            if (automationElement.Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = automationElement.Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != IntPtr.Zero)
                {
                    var className = new StringBuilder(256);
                    User32.GetClassName(windowHandle, className, 256);

                    if (className.ToString() == "Button")  // common Win32 checkbox window
                    {
                        var result = User32.SendMessage(windowHandle, ButtonMessages.BM_GETCHECK, IntPtr.Zero, IntPtr.Zero);

                        if (result.ToInt32() == ButtonStates.BST_UNCHECKED)
                        {
                            return ToggleState.Off;
                        }
                        if (result.ToInt32() == ButtonStates.BST_CHECKED)
                        {
                            return ToggleState.On;
                        }
                        if (result.ToInt32() == ButtonStates.BST_INDETERMINATE)
                        {
                            return ToggleState.Indeterminate;
                        }
                    }
                }
            }
            return null;
        }

        internal static void SetToggleStateWin32(AutomationElement automationElement, ToggleState state)
        {
            if (automationElement.Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = automationElement.Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != IntPtr.Zero)
                {
                    var className = new StringBuilder(256);
                    User32.GetClassName(windowHandle, className, 256);

                    if (className.ToString() == "Button") // Common Win32 Checkbox window
                    {
                        var result = User32.SendMessage(windowHandle, ButtonMessages.BM_GETCHECK, IntPtr.Zero, IntPtr.Zero);

                        if (state == ToggleState.On)
                        {
                            if (result.ToInt32() != (int)ButtonStates.BST_CHECKED)
                            {
                                User32.SendMessage(windowHandle, ButtonMessages.BM_SETCHECK, new IntPtr(ButtonStates.BST_CHECKED), IntPtr.Zero);
                            }
                        }
                        else if (state == ToggleState.Off)
                        {
                            if (result.ToInt32() != (int)ButtonStates.BST_UNCHECKED)
                            {
                                User32.SendMessage(windowHandle, ButtonMessages.BM_SETCHECK, new IntPtr(ButtonStates.BST_UNCHECKED), IntPtr.Zero);
                            }
                        }
                        else // indeterminate state
                        {
                            if (result.ToInt32() != (int)ButtonStates.BST_INDETERMINATE)
                            {
                                User32.SendMessage(windowHandle, ButtonMessages.BM_SETCHECK, new IntPtr(ButtonStates.BST_INDETERMINATE), IntPtr.Zero);
                            }
                        }
                    }
                }
            }
        }
        
        // get the edit window inside the spinner for Windows Forms
        internal static IntPtr GetSpinnerEditWindow(AutomationElement automationElement)
        {
            if (!automationElement.Properties.NativeWindowHandle.IsSupported)
            {
                return IntPtr.Zero;
            }
            var windowHandle = automationElement.Properties.NativeWindowHandle.ValueOrDefault;
            if (windowHandle == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }

            IntPtr hwndEdit = IntPtr.Zero;
            IntPtr hwndChild = User32.FindWindowEx(windowHandle, IntPtr.Zero, null, null);
            
            while (hwndChild != IntPtr.Zero)
            {
                StringBuilder childClassName = new StringBuilder(256);
                User32.GetClassName(hwndChild, childClassName, 256);
                if (childClassName.ToString().ToLower().Contains("edit"))
                {
                    hwndEdit = hwndChild;
                    break;
                }

                hwndChild = User32.FindWindowEx(windowHandle, hwndChild, null, null);
            }
            return hwndEdit;
        }
    }
}
