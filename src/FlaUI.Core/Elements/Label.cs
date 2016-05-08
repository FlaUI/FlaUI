using interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class Label : AutomationElement
    {
        public Label(Automation automation, IUIAutomationElement nativeElement) : base(automation, nativeElement)
        {
        }

        public string Text()
        {
            return Current.Name;
        }
    }
}
