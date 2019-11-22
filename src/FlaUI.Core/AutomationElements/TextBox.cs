using System;
using System.Linq;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using System.Runtime.InteropServices;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a textbox element.
    /// </summary>
    public class TextBox : AutomationElement
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        internal static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        /// <summary>
        /// Creates a <see cref="TextBox"/> element.
        /// </summary>
        public TextBox(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Gets or sets the text of the element.
        /// </summary>
        public string Text
        {
            get
            {
                if (Properties.IsPassword.TryGetValue(out var isPassword) && isPassword)
                {
                    throw new MethodNotSupportedException($"Text from element '{ToString()}' cannot be retrieved because it is set as password.");
                }
                if (Patterns.Value.TryGetPattern(out var valuePattern) &&
                    valuePattern.Value.TryGetValue(out var value))
                {
                    return value;
                }
                if (Patterns.Text.TryGetPattern(out var textPattern))
                {
                    return textPattern.DocumentRange.GetText(Int32.MaxValue);
                }
                if (GetTextWin32(out string textWin32) == true)
                {
                    return textWin32;
                }
                throw new MethodNotSupportedException($"AutomationElement '{ToString()}' supports neither ValuePattern or TextPattern");
            }
            set
            {
                if (Patterns.Value.TryGetPattern(out var valuePattern))
                {
                    valuePattern.SetValue(value);
                }
                else
                {
                    if (SetTextWin32(value) == false)
                    {
                        Enter(value);
                    }
                }
            }
        }
        
        private bool SetTextWin32(string text)
        {
            // try with native Win32 function SetWindowText
            if (Properties.NativeWindowHandle.IsSupported)
            {
	        var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != IntPtr.Zero)
                {
                    IntPtr textPtr = Marshal.StringToBSTR(text);
                
                    try
                    {
                        if (textPtr != IntPtr.Zero)
                        {
                            if (SendMessage(windowHandle, WindowsMessages.WM_SETTEXT, IntPtr.Zero, textPtr) ==
                                Win32Constants.TRUE)
                            {
                                return true; // text successfully set
                            }
                        }
                    }
                    catch { }
                    finally
                    {
                        Marshal.FreeBSTR(textPtr);
                    }
                }
            }
            return false;
        }

        private bool GetTextWin32(out textOut)
        {
            // try with native Win32 function SetWindowText
            if (Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != IntPtr.Zero)
                {
                    IntPtr textLengthPtr = SendMessage(hwnd, WindowsMessages.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
                    if (textLengthPtr.ToInt32() > 0)
                    {
                        int textLength = textLengthPtr.ToInt32() + 1;
                        StringBuilder text = new StringBuilder(textLength);
                        SendMessage(hwnd, WindowsMessages.WM_GETTEXT, textLength, text);
                        textOut = text.ToString();
                        return true; // success
                    }
                }
            }
            textOut = string.Empty;
            return false;
        }

        /// <summary>
        /// Gets if the element is read only or not.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                if (Patterns.Value.TryGetPattern(out var valuePattern) &&
                    valuePattern.IsReadOnly.TryGetValue(out var value))
                {
                    return value;
                }
                return true;
            }
        }

        /// <summary>
        /// Simulate typing in text. This is slower than setting <see cref="Text"/> but raises more events.
        /// </summary>
        public void Enter(string value)
        {
            Focus();
            var valuePattern = Patterns.Value.PatternOrDefault;
            valuePattern?.SetValue(String.Empty);
            if (String.IsNullOrEmpty(value)) return;

            var lines = value.Replace("\r\n", "\n").Split('\n');
            Keyboard.Type(lines[0]);
            foreach (var line in lines.Skip(1))
            {
                Keyboard.Type(VirtualKeyShort.RETURN);
                Keyboard.Type(line);
            }
            Wait.UntilInputIsProcessed();
        }
    }
}
