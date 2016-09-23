using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class RadioButton : SelectionItem
    {
        public RadioButton(UIA3Automation automation, UIA.IUIAutomationElement nativeElement)
            : base(automation, nativeElement) { }
    }
}
