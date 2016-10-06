using FlaUI.Core.AutomationElements.PatternElements;
using FlaUI.Core.Input;

namespace FlaUI.Core.AutomationElements
{
    public class Button : InvokeAutomationElement
    {
        public Button(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
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
