using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.AutomationElements
{
    public class TitleBar : AutomationElement
    {
        public TitleBar(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
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
