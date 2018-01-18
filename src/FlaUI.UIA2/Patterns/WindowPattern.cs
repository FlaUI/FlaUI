using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class WindowPattern : WindowPatternBase<UIA.WindowPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.WindowPattern.Pattern.Id, "Window", AutomationObjectIds.IsWindowPatternAvailableProperty);
        public static readonly PropertyId CanMaximizeProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.CanMaximizeProperty.Id, "CanMaximize");
        public static readonly PropertyId CanMinimizeProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.CanMinimizeProperty.Id, "CanMinimize");
        public static readonly PropertyId IsModalProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.IsModalProperty.Id, "IsModal");
        public static readonly PropertyId IsTopmostProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.IsTopmostProperty.Id, "IsTopmost");
        public static readonly PropertyId WindowInteractionStateProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.WindowInteractionStateProperty.Id, "WindowInteractionState");
        public static readonly PropertyId WindowVisualStateProperty = PropertyId.Register(AutomationType.UIA2, UIA.WindowPattern.WindowVisualStateProperty.Id, "WindowVisualState");
        public static readonly EventId WindowClosedEvent = EventId.Register(AutomationType.UIA2, UIA.WindowPattern.WindowClosedEvent.Id, "WindowClosed");
        public static readonly EventId WindowOpenedEvent = EventId.Register(AutomationType.UIA2, UIA.WindowPattern.WindowOpenedEvent.Id, "WindowOpened");

        public WindowPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.WindowPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override void Close()
        {
            NativePattern.Close();
        }

        public override void SetWindowVisualState(WindowVisualState state)
        {
            NativePattern.SetWindowVisualState((UIA.WindowVisualState)state);
        }

        public override bool WaitForInputIdle(int milliseconds)
        {
            return NativePattern.WaitForInputIdle(milliseconds);
        }
    }

    public class WindowPatternProperties : IWindowPatternProperties
    {
        public PropertyId CanMaximize => WindowPattern.CanMaximizeProperty;

        public PropertyId CanMinimize => WindowPattern.CanMinimizeProperty;

        public PropertyId IsModal => WindowPattern.IsModalProperty;

        public PropertyId IsTopmost => WindowPattern.IsTopmostProperty;

        public PropertyId WindowInteractionState => WindowPattern.WindowInteractionStateProperty;

        public PropertyId WindowVisualState => WindowPattern.WindowVisualStateProperty;
    }

    public class WindowPatternEvents : IWindowPatternEvents
    {
        public EventId WindowClosedEvent => WindowPattern.WindowClosedEvent;

        public EventId WindowOpenedEvent => WindowPattern.WindowOpenedEvent;
    }
}
