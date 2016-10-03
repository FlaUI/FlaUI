using FlaUI.Core.Elements.Infrastructure;
using System;

namespace FlaUI.Core.EventHandlers
{
    public abstract class FocusChangedEventHandlerBase : EventHandlerBase, IAutomationFocusChangedEventHandler
    {
        private readonly Action<Element> _callAction;

        protected FocusChangedEventHandlerBase(AutomationBase automation, Action<Element> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleFocusChangedEvent(Element sender)
        {
            _callAction(sender);
        }
    }
}
