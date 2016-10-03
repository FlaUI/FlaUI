using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Elements;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    internal class BasicEventHandler : EventHandlerBase, UIA.IUIAutomationEventHandler
    {
        private readonly Action<AutomationElement, EventId> _callAction;

        public BasicEventHandler(UIA3Automation automation, Action<AutomationElement, EventId> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleAutomationEvent(UIA.IUIAutomationElement sender, int eventId)
        {
            var senderElement = new AutomationElement(Automation, sender);
            var @event = EventId.Find(AutomationType.UIA3, eventId);
            _callAction(senderElement, @event);
        }
    }
}