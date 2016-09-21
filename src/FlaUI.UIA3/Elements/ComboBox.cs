using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    public class ComboBox : AutomationElement
    {
        public ComboBox(Automation automation, UIA.IUIAutomationElement nativeElement)
            : base(automation, nativeElement)
        {
        }

        public AutomationElement EditElement { get; set; }
    }
}
