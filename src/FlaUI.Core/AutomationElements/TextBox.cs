using System;
using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.AutomationElements
{
    public class TextBox : AutomationElement
    {
        public TextBox(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public string Text
        {
            get
            {
                if (Properties.IsPassword)
                {
                    throw new MethodNotSupportedException($"Text from element '{ToString()}' cannot be retrieved because it is set as password.");
                }
                var valuePattern = Patterns.Value.PatternOrDefault;
                if (valuePattern != null)
                {
                    return valuePattern.Value;
                }
                var textPattern = Patterns.Text.PatternOrDefault;
                if (textPattern != null)
                {
                    return textPattern.DocumentRange.GetText(Int32.MaxValue);
                }
                throw new MethodNotSupportedException($"AutomationElement '{ToString()}' supports neither ValuePattern or TextPattern");
            }
            set
            {
                var valuePattern = Patterns.Value.PatternOrDefault;
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
