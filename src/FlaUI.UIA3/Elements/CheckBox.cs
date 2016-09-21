using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Patterns;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    public class CheckBox : Element
    {
        public CheckBox(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public TogglePattern TogglePattern
        {
            get { return PatternFactory.GetTogglePattern(); }
        }

        public ToggleState State
        {
            get { return GetPropertyValue<ToggleState>(TogglePattern.ToggleStateProperty, false); }
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

        public virtual void Toggle()
        {
            var togglePattern = TogglePattern;
            if (togglePattern != null)
            {
                togglePattern.Toggle();
            }
        }
    }
}
