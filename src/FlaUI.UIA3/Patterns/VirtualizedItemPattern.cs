using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class VirtualizedItemPattern : PatternBase<UIA.IUIAutomationVirtualizedItemPattern>, IVirtualizedItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_VirtualizedItemPatternId, "VirtualizedItem");

        public VirtualizedItemPattern(AutomationObjectBase automationObject, UIA.IUIAutomationVirtualizedItemPattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        public void Realize()
        {
            ComCallWrapper.Call(() => NativePattern.Realize());
        }
    }
}
