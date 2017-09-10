using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a titlebar element.
    /// </summary>
    public class TitleBar : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="TitleBar"/> element.
        /// </summary>
        public TitleBar(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// Gets the minimize button element.
        /// </summary>
        public Button MinimizeButton => FindButton("Minimize");

        /// <summary>
        /// Gets the maximize button element.
        /// </summary>
        public Button MaximizeButton => FindButton("Maximize");

        /// <summary>
        /// Gets the restore button element.
        /// </summary>
        public Button RestoreButton => FindButton("Restore");

        /// <summary>
        /// Gets the close button element.
        /// </summary>
        public Button CloseButton => FindButton("Close");

        private Button FindButton(string automationId)
        {
            var buttonElement = FindFirstChild(cf => cf.ByControlType(ControlType.Button).And(cf.ByAutomationId(automationId)));
            return buttonElement?.AsButton();
        }
    }
}
