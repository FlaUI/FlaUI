using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Identifiers;

namespace FlaUI.UIA2
{
    public class UIA2AutomationElementEvents : IAutomationElementEvents
    {
        public EventId AsyncContentLoadedEvent => AutomationObjectIds.AsyncContentLoadedEvent;
        public EventId FocusChangedEvent => AutomationObjectIds.FocusChangedEvent;
        public EventId PropertyChangedEvent => AutomationObjectIds.PropertyChangedEvent;
        public EventId HostedFragmentRootsInvalidatedEvent { get { throw new NotSupportedByUIA2Exception(); } }
        public EventId LayoutInvalidatedEvent => AutomationObjectIds.LayoutInvalidatedEvent;
        public EventId LiveRegionChangedEvent { get { throw new NotSupportedByUIA2Exception(); } }
        public EventId MenuClosedEvent => AutomationObjectIds.MenuClosedEvent;
        public EventId MenuModeEndEvent { get { throw new NotSupportedByUIA2Exception(); } }
        public EventId MenuModeStartEvent { get { throw new NotSupportedByUIA2Exception(); } }
        public EventId MenuOpenedEvent => AutomationObjectIds.MenuOpenedEvent;
        public EventId StructureChangedEvent => AutomationObjectIds.StructureChangedEvent;
        public EventId SystemAlertEvent { get { throw new NotSupportedByUIA2Exception(); } }
        public EventId ToolTipClosedEvent => AutomationObjectIds.ToolTipClosedEvent;
        public EventId ToolTipOpenedEvent => AutomationObjectIds.ToolTipOpenedEvent;
    }
}
