using FlaUI.Core.AutomationElements.PatternElements;

namespace FlaUI.Core.AutomationElements
{
    public class CheckBox : ToggleAutomationElement
    {
        public CheckBox(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public string Text => Properties.Name.Value;
    }
}
