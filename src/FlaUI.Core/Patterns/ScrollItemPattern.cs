using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class ScrollItemPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_ScrollItemPatternId, "ScrollItem");

        internal ScrollItemPattern(AutomationElement automationElement, IUIAutomationScrollItemPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public IUIAutomationScrollItemPattern NativePattern
        {
            get { return (IUIAutomationScrollItemPattern)base.NativePattern; }
        }

        public void ScrollIntoView()
        {
            ComCallWrapper.Call(() => NativePattern.ScrollIntoView());
        }
    }
}
