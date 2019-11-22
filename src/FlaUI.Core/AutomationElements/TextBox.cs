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
        internal class Win32Constants
        {
            public static IntPtr TRUE = new IntPtr(1);
            public static IntPtr FALSE = new IntPtr(0);
        }
        
        internal class WindowMessages
        {
            public static UInt32 WM_SETTEXT = 0x000C;
            public static UInt32 WM_GETTEXT = 0x000D;
            public static UInt32 WM_GETTEXTLENGTH = 0x000E;
        }

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
		string textWin32 = GetTextWin32();
		if (textWin32 != null)
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
				IntPtr textPtr = IntPtr.Zero;
				try
				{
					textPtr = Marshal.StringToBSTR(text);
				}
				catch { }

				try
				{
					if (textPtr != IntPtr.Zero)
					{
						if (SendMessage(windowHandle, WindowMessages.WM_SETTEXT, IntPtr.Zero, textPtr) ==
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
	
	private string GetTextWin32()
	{
		// try with native Win32 function SetWindowText
		if (Properties.NativeWindowHandle.IsSupported)
		{
			var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
			if (windowHandle != IntPtr.Zero)
			{
				IntPtr textLengthPtr = SendMessage(hwnd, WindowMessages.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
				if (textLengthPtr.ToInt32() > 0)
				{
					int textLength = textLengthPtr.ToInt32() + 1;
					StringBuilder text = new StringBuilder(textLength);
					SendMessage(hwnd, WindowMessages.WM_GETTEXT, textLength, text);
					return text.ToString();
				}
			}
		}
		return null;
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
