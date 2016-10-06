using System;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    public class ToggleAutomationElement : AutomationElement
    {
        public ToggleAutomationElement(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public ITogglePattern TogglePattern => PatternFactory.GetTogglePattern();

        public ToggleState State
        {
            get { return TogglePattern.Current.ToggleState; }
            set
            {
                // Loop for all states
                for (var i = 0; i < Enum.GetNames(typeof(ToggleState)).Length; i++)
                {
                    // Break if we're in the correct state
                    if (State == value) return;
                    // Toggle to the next state
                    Toggle();
                }
            }
        }

        public void Toggle()
        {
            var togglePattern = TogglePattern;
            if (togglePattern != null)
            {
                togglePattern.Toggle();
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
