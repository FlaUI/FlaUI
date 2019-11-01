using System;
using FlaUI.Core.AutomationElements;

namespace FlaUI.Core.EventHandlers
{
    public abstract class ActiveTextPositionChangedEventHandlerBase : ElementEventHandlerBase
    {
        private readonly Action<AutomationElement, ITextRange> _callAction;

        protected ActiveTextPositionChangedEventHandlerBase(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, ITextRange> callAction)
            : base(frameworkElement)
        {
            _callAction = callAction;
        }

        protected void HandleActiveTextPositionChangedEvent(AutomationElement sender, ITextRange range)
        {
            _callAction(sender, range);
        }

        /// <inheritdoc />
        protected override void UnregisterEventHandler()
        {
            FrameworkElement.UnregisterActiveTextPositionChangedEventHandler(this);
        }
    }
}
