using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    public class TitleBar : Element
    {
        public TitleBar(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public Button MinimizeButton
        {
            get { return FindButton("Minimize"); }
        }

        public Button MaximizeButton
        {
            get { return FindButton("Maximize"); }
        }

        public Button RestoreButton
        {
            get { return FindButton("Restore"); }
        }

        public Button CloseButton
        {
            get { return FindButton("Close"); }
        }

        private Button FindButton(string automationId)
        {
            var buttonElement = FindFirst(TreeScope.Children, ConditionFactory.ByControlType(ControlType.Button).And(ConditionFactory.ByAutomationId(automationId)));
            return buttonElement.AsButton();
        }
    }
}
