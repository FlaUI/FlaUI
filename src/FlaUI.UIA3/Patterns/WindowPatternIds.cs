using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public static class WindowPatternIds
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_WindowPatternId, "Window");
        public static readonly PropertyId CanMaximizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_WindowCanMaximizePropertyId, "CanMaximize");
        public static readonly PropertyId CanMinimizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_WindowCanMinimizePropertyId, "CanMinimize");
        public static readonly PropertyId IsModalProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_WindowIsModalPropertyId, "IsModal");
        public static readonly PropertyId IsTopmostProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_WindowIsTopmostPropertyId, "IsTopmost");
        public static readonly PropertyId WindowInteractionStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_WindowWindowInteractionStatePropertyId, "WindowInteractionState");
        public static readonly PropertyId WindowVisualStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_WindowWindowVisualStatePropertyId, "WindowVisualState");
        public static readonly EventId WindowClosedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Window_WindowClosedEventId, "WindowClosed");
        public static readonly EventId WindowOpenedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Window_WindowOpenedEventId, "WindowOpened");
    }

    public class WindowPatternProperties : IWindowPatternProperties
    {
        public PropertyId CanMaximizeProperty => WindowPatternIds.CanMinimizeProperty;

        public PropertyId CanMinimizeProperty => WindowPatternIds.CanMinimizeProperty;

        public PropertyId IsModalProperty => WindowPatternIds.IsModalProperty;

        public PropertyId IsTopmostProperty => WindowPatternIds.IsTopmostProperty;

        public PropertyId WindowInteractionStateProperty => WindowPatternIds.WindowInteractionStateProperty;

        public PropertyId WindowVisualStateProperty => WindowPatternIds.WindowVisualStateProperty;
    }

    public class WindowPatternEvents : IWindowPatternEvents
    {
        public EventId WindowClosedEvent => WindowPatternIds.WindowClosedEvent;

        public EventId WindowOpenedEvent => WindowPatternIds.WindowOpenedEvent;
    }
}
