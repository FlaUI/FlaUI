using FlaUI.Core.Elements.Infrastructure;

namespace FlaUI.Core.Elements
{
    public class ComboBox : Element
    {
        public ComboBox(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public Element EditElement { get; set; }
    }
}
