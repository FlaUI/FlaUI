using FlaUI.Core.AutomationElements;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a label element.
    /// </summary>
    public class Label : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="Label"/> element.
        /// </summary>
        public Label(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Gets the text of the element.
        /// </summary>
        public string Text => Properties.Name.Value;
    }
}
