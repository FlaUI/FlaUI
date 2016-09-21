using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class VirtualizedItemPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_VirtualizedItemPatternId, "VirtualizedItem");

        internal VirtualizedItemPattern(AutomationElement automationElement, UIA.IUIAutomationVirtualizedItemPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public new UIA.IUIAutomationVirtualizedItemPattern NativePattern
        {
            get { return (UIA.IUIAutomationVirtualizedItemPattern)base.NativePattern; }
        }

        public void Realize()
        {
            ComCallWrapper.Call(() => NativePattern.Realize());
        }
    }
}
