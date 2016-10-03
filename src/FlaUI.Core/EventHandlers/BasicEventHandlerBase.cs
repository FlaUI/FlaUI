using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using System;

namespace FlaUI.Core.EventHandlers
{
    public abstract class BasicEventHandlerBase : EventHandlerBase, IAutomationEventHandler
    {
        private readonly Action<Element, EventId> _callAction;

        protected BasicEventHandlerBase(AutomationBase automation, Action<Element, EventId> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleAutomationEvent(Element sender, EventId eventId)
        {
            _callAction(sender, eventId);
        }
    }
}