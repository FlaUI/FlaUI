using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class VirtualizedItemPattern : PatternBase<UIA.VirtualizedItemPattern>, IVirtualizedItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.VirtualizedItemPattern.Pattern.Id, "VirtualizedItem");

        public VirtualizedItemPattern(AutomationObjectBase automationObject, UIA.VirtualizedItemPattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        public void Realize()
        {
            NativePattern.Realize();
        }
    }
}
