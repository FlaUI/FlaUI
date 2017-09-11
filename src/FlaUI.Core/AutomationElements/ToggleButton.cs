using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a toggle button element.
    /// </summary>
    public class ToggleButton : ToggleAutomationElement
    {
        /// <summary>
        /// Creates a <see cref="ToggleButton"/> element.
        /// </summary>
        public ToggleButton(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// Gets the current ToggleState 
        /// </summary>
        public ToggleState ToggleState => base.State;

        /// <summary>
        /// Toggles the toggle button.
        /// Note: In some WPF scenarios, the bounded command might not be fired. Use <see cref="AutomationElement.Click"/> instead in that case.
        /// </summary>
        public override void Toggle()
        {
            base.Toggle();
        }
    }
}
