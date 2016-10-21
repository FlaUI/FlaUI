using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class WindowPattern : PatternBaseWithInformation<UIA.IUIAutomationWindowPattern, WindowPatternInformation>, IWindowPattern
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

        public WindowPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationWindowPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        IWindowPatternInformation IPatternWithInformation<IWindowPatternInformation>.Cached => Cached;

        IWindowPatternInformation IPatternWithInformation<IWindowPatternInformation>.Current => Current;

        public IWindowPatternProperties Properties => Automation.PropertyLibrary.Window;

        public IWindowPatternEvents Events => Automation.EventLibrary.Window;

        public void Close()
        {
            ComCallWrapper.Call(() => NativePattern.Close());
        }

        public void SetWindowVisualState(WindowVisualState state)
        {
            ComCallWrapper.Call(() => NativePattern.SetWindowVisualState((UIA.WindowVisualState)state));
        }

        public bool WaitForInputIdle(int milliseconds)
        {
            return ComCallWrapper.Call(() => NativePattern.WaitForInputIdle(milliseconds)) != 0;
        }

        protected override WindowPatternInformation CreateInformation(bool cached)
        {
            return new WindowPatternInformation(BasicAutomationElement, cached);
        }
    }

    public class WindowPatternInformation : InformationBase, IWindowPatternInformation
    {
        public WindowPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public bool CanMaximize => Get<bool>(WindowPattern.CanMaximizeProperty);
        public bool CanMinimize => Get<bool>(WindowPattern.CanMinimizeProperty);
        public bool IsModal => Get<bool>(WindowPattern.IsModalProperty);
        public bool IsTopmost => Get<bool>(WindowPattern.IsTopmostProperty);
        public WindowInteractionState WindowInteractionState => Get<WindowInteractionState>(WindowPattern.WindowInteractionStateProperty);
        public WindowVisualState WindowVisualState => Get<WindowVisualState>(WindowPattern.WindowVisualStateProperty);
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
