using System;
using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.Core.EventHandlers
{
    /// <summary>
    /// Base event handler for focus changed event handlers.
    /// </summary>
    public abstract class FocusChangedEventHandlerBase : EventHandlerBase
    {
        private readonly Action<AutomationElement> _callAction;

        protected FocusChangedEventHandlerBase(AutomationBase automation, Action<AutomationElement> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        protected void HandleFocusChangedEvent(AutomationElement sender)
        {
            _callAction(sender);
        }

        /// <inheritdoc />
        protected override void UnregisterEventHandler()
        {
            Automation.UnregisterFocusChangedEvent(this);
        }
    }
}
