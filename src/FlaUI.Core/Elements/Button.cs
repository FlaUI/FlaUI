using FlaUI.Core.Elements.PatternElements;
using FlaUI.Core.Input;

namespace FlaUI.Core.Elements
{
    public class Button : InvokeAutomationElement
    {
        public Button(AutomationObjectBase automationObject) : base(automationObject)
        {
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
