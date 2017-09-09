using System;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    /// <summary>
    /// Class for an element that supports the <see cref="ITogglePattern"/>.
    /// </summary>
    public class ToggleAutomationElement : AutomationElement
    {
        /// <summary>
        /// Creates an element with a <see cref="ITogglePattern"/>.
        /// </summary>
        public ToggleAutomationElement(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// The toggle pattern.
        /// </summary>
        public ITogglePattern TogglePattern => Patterns.Toggle.Pattern;

        /// <summary>
        /// Gets or sets the current toggle state.
        /// </summary>
        public ToggleState State
        {
            get => TogglePattern.ToggleState.Value;
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

        /// <summary>
        /// Toggles the element.
        /// </summary>
        public virtual void Toggle()
        {
            TogglePattern.Toggle();
        }
    }
}
