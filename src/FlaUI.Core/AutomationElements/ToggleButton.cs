using FlaUI.Core.AutomationElements.PatternElements;

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
        public ToggleButton(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

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
