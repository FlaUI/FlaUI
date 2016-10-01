using FlaUI.Core.Elements.Infrastructure;

namespace FlaUI.Core.Elements
{
    public class Label : Element
    {
        public Label(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public string Text => Current.Name;
    }
}
