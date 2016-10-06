using FlaUI.Core.Elements.Infrastructure;

namespace FlaUI.Core.Elements
{
    public class ComboBox : AutomationElement
    {
        public ComboBox(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public AutomationElement EditAutomationElement { get; set; }
    }
}
