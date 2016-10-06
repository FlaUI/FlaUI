using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.Core.EventHandlers
{
    public interface IAutomationFocusChangedEventHandler
    {
        void HandleFocusChangedEvent(AutomationElement sender);
    }
}
