using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.Core.AutomationElements
{
    public class ComboBox : AutomationElement
    {
        public ComboBox(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public AutomationElement EditAutomationElement { get; set; }
    }
}
