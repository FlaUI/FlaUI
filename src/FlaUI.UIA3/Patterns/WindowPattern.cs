using FlaUI.Core;
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
        public WindowPattern(AutomationObjectBase automationObject, UIA.IUIAutomationWindowPattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        IWindowPatternInformation IPatternWithInformation<IWindowPatternInformation>.Cached
        {
            get { return Cached; }
        }

        IWindowPatternInformation IPatternWithInformation<IWindowPatternInformation>.Current
        {
            get { return Current; }
        }

        public PropertyId CanMaximizeProperty
        {
            get { return WindowPatternIds.CanMinimizeProperty; }
        }

        public PropertyId CanMinimizeProperty
        {
            get { return WindowPatternIds.CanMinimizeProperty; }
        }

        public PropertyId IsModalProperty
        {
            get { return WindowPatternIds.IsModalProperty; }
        }

        public PropertyId IsTopmostProperty
        {
            get { return WindowPatternIds.IsTopmostProperty; }
        }

        public PropertyId WindowInteractionStateProperty
        {
            get { return WindowPatternIds.WindowInteractionStateProperty; }
        }

        public PropertyId WindowVisualStateProperty
        {
            get { return WindowPatternIds.WindowVisualStateProperty; }
        }

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
}
