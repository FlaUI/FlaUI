using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Input;

namespace FlaUI.Core.Elements
{
    public class Button : Element
    {
        public Button(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

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
