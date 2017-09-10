using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Patterns;

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
        /// Toggles the toggle button. Uses <see cref="AutomationElement.Click"/> as <see cref="ITogglePattern.Toggle"/> does not fire commands.
        /// </summary>
        public override void Toggle()
        {
            Click();
        }
    }
}
