using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class VirtualizedItemPattern : PatternBase<IUIAutomationVirtualizedItemPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_VirtualizedItemPatternId, "VirtualizedItem");

        internal VirtualizedItemPattern(AutomationElement automationElement, IUIAutomationVirtualizedItemPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public void Realize()
        {
            ComCallWrapper.Call(() => NativePattern.Realize());
        }
    }
}
