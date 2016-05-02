using FlaUI.Core.Elements;
using interop.UIAutomationCore;
using System;

namespace FlaUI.Core.EventHandlers
{
    internal class FocusChangedEventHandler :EventHandlerBase, IUIAutomationFocusChangedEventHandler
    {
        private readonly Action<AutomationElement> _callAction;

        public FocusChangedEventHandler(Automation automation, Action<AutomationElement> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleFocusChangedEvent(IUIAutomationElement sender)
        {
            var senderElement = new AutomationElement(Automation, sender);
            _callAction(senderElement);
        }
    }
}
