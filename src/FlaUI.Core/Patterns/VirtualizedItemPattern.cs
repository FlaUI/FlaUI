using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class VirtualizedItemPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_VirtualizedItemPatternId, "VirtualizedItem");

        internal VirtualizedItemPattern(AutomationElement automationElement, IUIAutomationVirtualizedItemPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public IUIAutomationVirtualizedItemPattern NativePattern
        {
            get { return (IUIAutomationVirtualizedItemPattern)base.NativePattern; }
        }

        public void Realize()
        {
            ComCallWrapper.Call(() => NativePattern.Realize());
        }
    }
}
