using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.EventHandlers
{
    public class UIA3NotificationEventHandler : NotificationEventHandlerBase, UIA.IUIAutomationNotificationEventHandler
    {
        public UIA3NotificationEventHandler(AutomationBase automation) : base(automation)
        {
        }

        public void HandleNotificationEvent(UIA.IUIAutomationElement sender, UIA.NotificationKind notificationKind,
            UIA.NotificationProcessing notificationProcessing, string displayString, string activityId)
        {
            var frameworkElement = new UIA3FrameworkAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(frameworkElement);
            HandleNotificationEvent(senderElement, (NotificationKind)notificationKind, (NotificationProcessing)notificationProcessing, displayString, activityId);
        }
    }
}
