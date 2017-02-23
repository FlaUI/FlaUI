using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class WindowPattern : PatternBase<UIA.WindowPattern>, IWindowPattern
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

        public WindowPattern(BasicAutomationElementBase basicAutomationElement, UIA.WindowPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IWindowPatternProperties Properties => Automation.PropertyLibrary.Window;

        public IWindowPatternEvents Events => Automation.EventLibrary.Window;

        public bool CanMaximize => Get<bool>(CanMaximizeProperty);
        public bool CanMinimize => Get<bool>(CanMinimizeProperty);
        public bool IsModal => Get<bool>(IsModalProperty);
        public bool IsTopmost => Get<bool>(IsTopmostProperty);
        public WindowInteractionState WindowInteractionState => Get<WindowInteractionState>(WindowInteractionStateProperty);
        public WindowVisualState WindowVisualState => Get<WindowVisualState>(WindowVisualStateProperty);

        public void Close()
        {
            NativePattern.Close();
        }

        public void SetWindowVisualState(WindowVisualState state)
        {
            NativePattern.SetWindowVisualState((UIA.WindowVisualState)state);
        }

        public bool WaitForInputIdle(int milliseconds)
        {
            return NativePattern.WaitForInputIdle(milliseconds);
        }
    }

    public class WindowPatternProperties : IWindowPatternProperties
    {
        public PropertyId CanMaximizeProperty => WindowPattern.CanMinimizeProperty;

        public PropertyId CanMinimizeProperty => WindowPattern.CanMinimizeProperty;

        public PropertyId IsModalProperty => WindowPattern.IsModalProperty;

        public PropertyId IsTopmostProperty => WindowPattern.IsTopmostProperty;

        public PropertyId WindowInteractionStateProperty => WindowPattern.WindowInteractionStateProperty;

        public PropertyId WindowVisualStateProperty => WindowPattern.WindowVisualStateProperty;
    }

    public class WindowPatternEvents : IWindowPatternEvents
    {
        public EventId WindowClosedEvent => WindowPattern.WindowClosedEvent;

        public EventId WindowOpenedEvent => WindowPattern.WindowOpenedEvent;
    }
}
