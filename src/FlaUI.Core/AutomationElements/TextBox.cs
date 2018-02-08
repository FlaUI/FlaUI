using System;
using System.Linq;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a textbox element.
    /// </summary>
    public class TextBox : AutomationElement
    {
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
                    Enter(value);
                }
            }
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
