using FlaUI.Core.Input;
using interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class Button : AutomationElement
    {
        public Button(Automation automation, IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public void Invoke()
        {
            var invokePattern = PatternFactory.GetInvokePattern();
            if (invokePattern != null)
            {
               invokePattern.Invoke();
            }
        }

        public void Click(bool moveMouse = true)
        {
            if (moveMouse)
            {
                Automation.Mouse.MoveTo(Current.ClickablePoint);
            }
            Automation.Mouse.Click(MouseButton.Left);
        }
    }
}
