using System;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.EventHandlers
{
    public abstract class NotificationEventHandlerBase : ElementEventHandlerBase
    {
        private readonly Action<AutomationElement, NotificationKind, NotificationProcessing, string, string> _callAction;

        protected NotificationEventHandlerBase(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, NotificationKind, NotificationProcessing, string, string> callAction) : base(frameworkElement)
        {
            _callAction = callAction;
        }

        protected void HandleNotificationEvent(AutomationElement sender, NotificationKind notificationKind,
            NotificationProcessing notificationProcessing, string displayString, string activityId)
        {
            _callAction(sender, notificationKind, notificationProcessing, displayString, activityId);
        }

        /// <inheritdoc />
        protected override void UnregisterEventHandler()
        {
            FrameworkElement.UnregisterNotificationEventHandler(this);
        }
    }
}
