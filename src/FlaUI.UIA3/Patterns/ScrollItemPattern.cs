using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ScrollItemPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ScrollItemPatternId, "ScrollItem");

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
