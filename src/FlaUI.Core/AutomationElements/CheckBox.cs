using FlaUI.Core.AutomationElements.PatternElements;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a checkbox element.
    /// </summary>
    public class CheckBox : ToggleAutomationElement
    {
        /// <summary>
        /// Creates a <see cref="CheckBox"/> element.
        /// </summary>
        public CheckBox(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// Gets the text of the element.
        /// </summary>
        public string Text => Properties.Name.Value;
    }
}
