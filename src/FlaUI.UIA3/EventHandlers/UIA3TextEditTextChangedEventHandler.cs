using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.EventHandlers
{
    public class UIA3TextEditTextChangedEventHandler : TextEditTextChangedEventHandlerBase, UIA.IUIAutomationTextEditTextChangedEventHandler
    {
        public UIA3TextEditTextChangedEventHandler(AutomationBase automation) : base(automation)
        {
        }

        public void HandleTextEditTextChangedEvent(UIA.IUIAutomationElement sender, UIA.TextEditChangeType textEditChangeType, string[] eventStrings)
        {
            var frameworkElement = new UIA3FrameworkAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(frameworkElement);
            HandleTextEditTextChangedEvent(senderElement, (TextEditChangeType)textEditChangeType, eventStrings);
        }
    }
}
