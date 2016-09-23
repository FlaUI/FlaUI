using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
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
