using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ScrollItemPattern : PatternBase<UIA.ScrollItemPattern>, IScrollItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ScrollItemPattern.Pattern.Id, "ScrollItem", AutomationObjectIds.IsScrollItemPatternAvailableProperty);

        public ScrollItemPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.ScrollItemPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public void ScrollIntoView()
        {
            NativePattern.ScrollIntoView();
        }
    }
}
