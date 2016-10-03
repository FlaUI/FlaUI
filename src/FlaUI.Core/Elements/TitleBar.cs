using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;

namespace FlaUI.Core.Elements
{
    public class TitleBar : AutomationElement
    {
        public TitleBar(AutomationObjectBase automationObject) : base(automationObject)
        {
        }

        public Button MinimizeButton => FindButton("Minimize");

        public Button MaximizeButton => FindButton("Maximize");

        public Button RestoreButton => FindButton("Restore");

        public Button CloseButton => FindButton("Close");

        private Button FindButton(string automationId)
        {
            var buttonElement = FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.Button).And(ConditionFactory.ByAutomationId(automationId)));
            return buttonElement.AsButton();
        }
    }
}
