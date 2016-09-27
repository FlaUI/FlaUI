using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class VirtualizedItemPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_VirtualizedItemPatternId, "VirtualizedItem");

        internal VirtualizedItemPattern(Element automationElement, UIA.IUIAutomationVirtualizedItemPattern nativePattern)
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
