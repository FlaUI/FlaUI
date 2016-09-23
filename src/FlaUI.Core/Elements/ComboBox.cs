using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class ComboBox : Element
    {
        public ComboBox(UIA3Automation automation, UIA.IUIAutomationElement nativeElement)
            : base(automation, nativeElement)
        {
        }

        public Element EditElement { get; set; }
    }
}
