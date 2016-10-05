using FlaUI.Core.Elements.PatternElements;
using FlaUI.Core.Input;

namespace FlaUI.Core.Elements
{
    public class Button : InvokeElement
    {
        public Button(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public void Click(bool moveMouse = true)
        {
            var clickablePoint = GetClickablePoint();
            if (moveMouse)
            {
                Mouse.Instance.MoveTo(clickablePoint);
            }
            else
            {
                Mouse.Instance.Position = clickablePoint;
            }
            Mouse.Instance.Click(MouseButton.Left);
        }
    }
}
