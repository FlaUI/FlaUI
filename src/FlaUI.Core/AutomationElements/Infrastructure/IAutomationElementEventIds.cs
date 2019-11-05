using FlaUI.Core.Identifiers;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    /// <summary>
    /// Interface for a class that contains all automation element event ids.
    /// </summary>
    public interface IAutomationElementEventIds
    {
#pragma warning disable 1591
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
#pragma warning restore 1591
    }
}
