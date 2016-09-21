using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    internal class BasicEventHandler : EventHandlerBase, UIA.IUIAutomationEventHandler
    {
        private readonly Action<Element, EventId> _callAction;

        public BasicEventHandler(UIA3Automation automation, Action<Element, EventId> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleAutomationEvent(UIA.IUIAutomationElement sender, int eventId)
        {
            var senderElement = new Element(Automation, sender);
            var @event = EventId.Find(eventId);
            _callAction(senderElement, @event);
        }
    }
}