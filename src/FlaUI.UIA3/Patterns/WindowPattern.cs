using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class WindowPattern : PatternBaseWithInformation<UIA.IUIAutomationWindowPattern, WindowPatternInformation>, IWindowPattern
    {
        public WindowPattern(AutomationObjectBase automationObject, UIA.IUIAutomationWindowPattern nativePattern) : base(automationObject, nativePattern)
        {
            Properties = new WindowPatternProperties();
            Events = new WindowPatternEvents();
        }

        IWindowPatternInformation IPatternWithInformation<IWindowPatternInformation>.Cached => Cached;

        IWindowPatternInformation IPatternWithInformation<IWindowPatternInformation>.Current => Current;

        public IWindowPatternProperties Properties { get; }

        public IWindowPatternEvents Events { get; }

        public void Close()
        {
            ComCallWrapper.Call(() => NativePattern.Close());
        }

        public void SetWindowVisualState(WindowVisualState state)
        {
            ComCallWrapper.Call(() => NativePattern.SetWindowVisualState((interop.UIAutomationCore.WindowVisualState)state));
        }

        public int WaitForInputIdle(int milliseconds)
        {
            return ComCallWrapper.Call(() => NativePattern.WaitForInputIdle(milliseconds));
        }

        protected override WindowPatternInformation CreateInformation(bool cached)
        {
            return new WindowPatternInformation(AutomationObject, cached);
        }
    }

    public class WindowPatternInformation : ElementInformationBase, IWindowPatternInformation
    {
        public WindowPatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool CanMaximize => Get<bool>(WindowPatternIds.CanMaximizeProperty);
        public bool CanMinimize => Get<bool>(WindowPatternIds.CanMinimizeProperty);
        public bool IsModal => Get<bool>(WindowPatternIds.IsModalProperty);
        public bool IsTopmost => Get<bool>(WindowPatternIds.IsTopmostProperty);
        public WindowInteractionState WindowInteractionState => Get<WindowInteractionState>(WindowPatternIds.WindowInteractionStateProperty);
        public WindowVisualState WindowVisualState => Get<WindowVisualState>(WindowPatternIds.WindowVisualStateProperty);
    }
}
