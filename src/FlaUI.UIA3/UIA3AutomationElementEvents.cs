using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Identifiers;

namespace FlaUI.UIA3
{
    public class UIA3AutomationElementEvents : IAutomationElementEvents
    {
        public EventId AsyncContentLoadedEvent => AutomationObjectIds.AsyncContentLoadedEvent;
        public EventId FocusChangedEvent => AutomationObjectIds.FocusChangedEvent;
        public EventId PropertyChangedEvent => AutomationObjectIds.PropertyChangedEvent;
        public EventId HostedFragmentRootsInvalidatedEvent => AutomationObjectIds.HostedFragmentRootsInvalidatedEvent;
        public EventId LayoutInvalidatedEvent => AutomationObjectIds.LayoutInvalidatedEvent;
        public EventId LiveRegionChangedEvent => AutomationObjectIds.LiveRegionChangedEvent;
        public EventId MenuClosedEvent => AutomationObjectIds.MenuClosedEvent;
        public EventId MenuModeEndEvent => AutomationObjectIds.MenuModeEndEvent;
        public EventId MenuModeStartEvent => AutomationObjectIds.MenuModeStartEvent;
        public EventId MenuOpenedEvent => AutomationObjectIds.MenuOpenedEvent;
        public EventId StructureChangedEvent => AutomationObjectIds.StructureChangedEvent;
        public EventId SystemAlertEvent => AutomationObjectIds.SystemAlertEvent;
        public EventId ToolTipClosedEvent => AutomationObjectIds.ToolTipClosedEvent;
        public EventId ToolTipOpenedEvent => AutomationObjectIds.ToolTipOpenedEvent;
    }
}
