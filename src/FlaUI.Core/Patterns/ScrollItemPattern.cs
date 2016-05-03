using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class ScrollItemPattern : PatternBase<IUIAutomationScrollItemPattern>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_ScrollItemPatternId, "ScrollItem");

        internal ScrollItemPattern(AutomationElement automationElement, IUIAutomationScrollItemPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public void ScrollIntoView()
        {
            ComCallWrapper.Call(() => NativePattern.ScrollIntoView());
        }
    }
}
