using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    public class Label : Element
    {
        public Label(UIA3Automation automation, UIA.IUIAutomationElement nativeElement)
            : base(automation, nativeElement)
        {
        }

        public string Text
        {
            get
            {
                return Current.Name;
            }
        }
    }
}
