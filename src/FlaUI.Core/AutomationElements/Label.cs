using FlaUI.Core.AutomationElements.Infrastructure;

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
        public Label(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// Gets the text of the element.
        /// </summary>
        public string Text => Properties.Name.Value;
    }
}
