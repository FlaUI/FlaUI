using FlaUI.Core.Elements;
using interop.UIAutomationCore;
using System;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.EventHandlers
{
    internal class BasicEventHandler : EventHandlerBase, IUIAutomationEventHandler
    {
        private readonly Action<AutomationElement, EventId> _callAction;

        public BasicEventHandler(Automation automation, Action<AutomationElement, EventId> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleAutomationEvent(IUIAutomationElement sender, int eventId)
        {
            var senderElement = new AutomationElement(Automation, sender);
            var @event = EventId.Find(eventId);
            _callAction(senderElement, @event);
        }
    }
}