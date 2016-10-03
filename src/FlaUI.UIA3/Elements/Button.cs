using FlaUI.Core.Input;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    public class Button : AutomationElement
    {
        public Button(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

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
                Mouse.Instance.MoveTo(Current.ClickablePoint);
            }
            else
            {
                Mouse.Instance.Position = Current.ClickablePoint;
            }
            Mouse.Instance.Click(MouseButton.Left);
        }
    }
}
