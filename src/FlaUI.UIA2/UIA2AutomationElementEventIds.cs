using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Identifiers;

namespace FlaUI.UIA2
{
    public partial class UIA2AutomationElementEventIds : IAutomationElementEventIds
    {
        public EventId AsyncContentLoadedEvent => AutomationObjectIds.AsyncContentLoadedEvent;
        public EventId ChangesEvent => EventId.NotSupportedByFramework;
        public EventId FocusChangedEvent => AutomationObjectIds.FocusChangedEvent;
        public EventId PropertyChangedEvent => AutomationObjectIds.PropertyChangedEvent;
        public EventId HostedFragmentRootsInvalidatedEvent => EventId.NotSupportedByFramework;
        public EventId LayoutInvalidatedEvent => AutomationObjectIds.LayoutInvalidatedEvent;
        public EventId MenuClosedEvent => AutomationObjectIds.MenuClosedEvent;
        public EventId MenuModeEndEvent => EventId.NotSupportedByFramework;
        public EventId MenuModeStartEvent => EventId.NotSupportedByFramework;
        public EventId MenuOpenedEvent => AutomationObjectIds.MenuOpenedEvent;
        public EventId NotificationEvent => EventId.NotSupportedByFramework;
        public EventId StructureChangedEvent => AutomationObjectIds.StructureChangedEvent;
        public EventId SystemAlertEvent => EventId.NotSupportedByFramework;
        public EventId ToolTipClosedEvent => AutomationObjectIds.ToolTipClosedEvent;
        public EventId ToolTipOpenedEvent => AutomationObjectIds.ToolTipOpenedEvent;
    }

    /// <summary>
    /// Partial class with additions from .NET 4.7.1
    /// </summary>
    public partial class UIA2AutomationElementEventIds
    {
#if NET471
        public EventId LiveRegionChangedEvent => AutomationObjectIds.LiveRegionChangedEvent;
#else
        public EventId LiveRegionChangedEvent => EventId.NotSupportedByFramework;
#endif
    }
}
