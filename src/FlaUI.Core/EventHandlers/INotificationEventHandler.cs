using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.EventHandlers
{
    public interface INotificationEventHandler
    {
        void HandleNotificationEvent(AutomationElement sender, NotificationKind notificationKind,
            NotificationProcessing notificationProcessing, string displayString, string activityId);
    }
}
