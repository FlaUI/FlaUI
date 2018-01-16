using System;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.EventHandlers
{
    public abstract class NotificationEventHandlerBase : EventHandlerBase, INotificationEventHandler
    {
        public NotificationEventHandlerBase(AutomationBase automation) : base(automation)
        {
        }

        public void HandleNotificationEvent(AutomationElement sender, NotificationKind notificationKind,
            NotificationProcessing notificationProcessing, string displayString, string activityId)
        {
            throw new NotImplementedException();
        }
    }
}
