using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    public class TabItem : SelectionItem
    {
        public TabItem(UIA3Automation automation, UIA.IUIAutomationElement nativeElement)
            : base(automation, nativeElement) { }
    }
}
