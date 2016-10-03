using FlaUI.UIA3.Elements;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    internal class FocusChangedEventHandler :EventHandlerBase, UIA.IUIAutomationFocusChangedEventHandler
    {
        private readonly Action<AutomationElement> _callAction;

        public FocusChangedEventHandler(UIA3Automation automation, Action<AutomationElement> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleFocusChangedEvent(UIA.IUIAutomationElement sender)
        {
            var senderElement = new AutomationElement(Automation, sender);
            _callAction(senderElement);
        }
    }
}
