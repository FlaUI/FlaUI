using System;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.EventHandlers
{
    public abstract class BasicEventHandlerBase : EventHandlerBase, IAutomationEventHandler
    {
        private readonly Action<AutomationElement, EventId> _callAction;

        protected BasicEventHandlerBase(AutomationBase automation, Action<AutomationElement, EventId> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleAutomationEvent(AutomationElement sender, EventId eventId)
        {
            _callAction(sender, eventId);
        }
    }
}
