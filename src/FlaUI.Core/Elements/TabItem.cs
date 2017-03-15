using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class TabItem : SelectionItem
    {
        public TabItem(Automation automation, UIA.IUIAutomationElement nativeElement)
            : base(automation, nativeElement) { }
    }
}
