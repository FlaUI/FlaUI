using FlaUI.Core.Elements;
using interop.UIAutomationCore;
using System;

namespace FlaUI.Core.EventHandlers
{
    internal class BasicEventHandler : EventHandlerBase, IUIAutomationEventHandler
    {
        private readonly Action<AutomationElement, AutomationEvent> _callAction;

        public BasicEventHandler(Automation automation, Action<AutomationElement, AutomationEvent> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleAutomationEvent(IUIAutomationElement sender, int eventId)
        {
            var senderElement = new AutomationElement(Automation, sender);
            var @event = AutomationEvent.Find(eventId);
            _callAction(senderElement, @event);
        }
    }
}