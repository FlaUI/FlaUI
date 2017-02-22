using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.Core.AutomationElements
{
    public class Label : AutomationElement
    {
        public Label(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public string Text => Information.Name;
    }
}
