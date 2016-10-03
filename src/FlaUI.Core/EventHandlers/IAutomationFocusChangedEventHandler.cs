using FlaUI.Core.Elements.Infrastructure;

namespace FlaUI.Core.EventHandlers
{
    public interface IAutomationFocusChangedEventHandler
    {
        void HandleFocusChangedEvent(Element sender);
    }
}
