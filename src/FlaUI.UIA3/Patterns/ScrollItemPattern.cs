using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ScrollItemPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_ScrollItemPatternId, "ScrollItem");

        internal ScrollItemPattern(Element automationElement, UIA.IUIAutomationScrollItemPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public new UIA.IUIAutomationScrollItemPattern NativePattern
        {
            get { return (UIA.IUIAutomationScrollItemPattern)base.NativePattern; }
        }

        public void ScrollIntoView()
        {
            ComCallWrapper.Call(() => NativePattern.ScrollIntoView());
        }
    }
}
