using FlaUI.Core.Identifiers;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    public interface IAutomationElementEvents
    {
        EventId AsyncContentLoadedEvent { get; }
        EventId ChangesEvent { get; }
        EventId FocusChangedEvent { get; }
        EventId PropertyChangedEvent { get; }
        EventId HostedFragmentRootsInvalidatedEvent { get; }
        EventId LayoutInvalidatedEvent { get; }
        EventId LiveRegionChangedEvent { get; }
        EventId MenuClosedEvent { get; }
        EventId MenuModeEndEvent { get; }
        EventId MenuModeStartEvent { get; }
        EventId MenuOpenedEvent { get; }
        EventId NotificationEvent { get; }
        EventId StructureChangedEvent { get; }
        EventId SystemAlertEvent { get; }
        EventId ToolTipClosedEvent { get; }
        EventId ToolTipOpenedEvent { get; }
    }
}
