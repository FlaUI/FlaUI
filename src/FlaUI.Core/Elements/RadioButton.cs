using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class RadioButton : SelectionItem
    {
        public RadioButton(Automation automation, UIA.IUIAutomationElement nativeElement)
            : base(automation, nativeElement) { }
    }
}
