using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;
using System;

namespace FlaUI.Core.Elements
{
    public class CheckBox : Element
    {
        public CheckBox(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public ITogglePattern TogglePattern => PatternFactory.GetTogglePattern();

        public ToggleState State
        {
            get { return AutomationObject.GetPropertyValue<ToggleState>(TogglePattern.Properties.ToggleStateProperty, false); }
            set
            {
                // Loop for all states
                for (int i = 0; i < Enum.GetNames(typeof(ToggleState)).Length; i++)
                {
                    // Break if we're in the correct state
                    if (State == value) break;
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
        }
    }
}
