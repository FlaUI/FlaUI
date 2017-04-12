#if !NET35
using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class VirtualizedItemPattern : PatternBase<UIA.VirtualizedItemPattern>, IVirtualizedItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.VirtualizedItemPattern.Pattern.Id, "VirtualizedItem", AutomationObjectIds.IsVirtualizedItemPatternAvailableProperty);

        public VirtualizedItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.VirtualizedItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public void Realize()
        {
            NativePattern.Realize();
        }
    }
}
#endif