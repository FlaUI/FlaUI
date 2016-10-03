using FlaUI.Core.Exceptions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using interop.UIAutomationCore;
using System;
using System.Linq;

namespace FlaUI.UIA3.Elements
{
    public class TextBox : AutomationElement
    {
        public TextBox(UIA3Automation automation, IUIAutomationElement nativeElement) : base(automation, nativeElement)
        {
        }

        public string Text
        {
            get
            {
                if (Current.IsPassword)
                {
                    throw new MethodNotSupportedException(String.Format("Text from element '{0}' cannot be retrieved because it is set as password.", ToString()));
                }
                var valuePattern = PatternFactory.GetValuePattern();
                if (valuePattern != null)
                {
                    return valuePattern.Current.Value;
                }
                var textPattern = PatternFactory.GetTextPattern();
                if (textPattern != null)
                {
                    return textPattern.DocumentRange.GetText(Int32.MaxValue);
                }                
                throw new MethodNotSupportedException(String.Format("AutomationElement '{0}' supports neither ValuePattern or TextPattern", ToString()));
            }
            set
            {
                var valuePattern = PatternFactory.GetValuePattern();
                if (valuePattern != null)
                {
                    valuePattern.SetValue(value);
                }
                else
                {
                    Enter(value);
                }
            }
        }

        public void Enter(string value)
        {
            var valuePattern = PatternFactory.GetValuePattern();
            if (valuePattern != null)
            {
                valuePattern.SetValue(String.Empty);
            }
            if (String.IsNullOrEmpty(value)) return;

            var lines = value.Replace("\r\n", "\n").Split('\n');
            Keyboard.Instance.Write(lines[0]);
            foreach (var line in lines.Skip(1))
            {
                Keyboard.Instance.TypeVirtualKeyCode(VirtualKeyShort.RETURN);
                Keyboard.Instance.Write(line);
            }
            Helpers.WaitUntilInputIsProcessed();
        }
    }
}
