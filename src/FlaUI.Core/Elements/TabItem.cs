using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class TabItem : SelectionItem
    {
        public TabItem(UIA3Automation automation, UIA.IUIAutomationElement nativeElement)
            : base(automation, nativeElement) { }
    }
}
