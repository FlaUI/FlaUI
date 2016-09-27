using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
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
