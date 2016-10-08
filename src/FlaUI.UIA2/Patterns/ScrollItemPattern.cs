using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ScrollItemPattern : PatternBase<UIA.ScrollItemPattern>, IScrollItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ScrollItemPattern.Pattern.Id, "ScrollItem");

        public ScrollItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.ScrollItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public void ScrollIntoView()
        {
            NativePattern.ScrollIntoView();
        }
    }
}
