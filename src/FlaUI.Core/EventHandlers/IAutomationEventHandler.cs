using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.EventHandlers
{
    public interface IAutomationEventHandler
    {
        void HandleAutomationEvent(AutomationElement sender, EventId eventId);
    }
}
