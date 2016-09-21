using FlaUI.Core;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    public class RadioButton : SelectionItem
    {
        public RadioButton(UIA3Automation automation, UIA.IUIAutomationElement nativeElement)
            : base(automation, nativeElement) { }
    }
}
