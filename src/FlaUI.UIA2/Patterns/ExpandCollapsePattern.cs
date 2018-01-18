using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ExpandCollapsePattern : ExpandCollapsePatternBase<UIA.ExpandCollapsePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ExpandCollapsePattern.Pattern.Id, "ExpandCollapse", AutomationObjectIds.IsExpandCollapsePatternAvailableProperty);
        public static readonly PropertyId ExpandCollapseStateProperty = PropertyId.Register(AutomationType.UIA2, UIA.ExpandCollapsePattern.ExpandCollapseStateProperty.Id, "ExpandCollapseState");

        public ExpandCollapsePattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.ExpandCollapsePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override void Collapse()
        {
            NativePattern.Collapse();
        }

        public override void Expand()
        {
            NativePattern.Expand();
        }
    }

    public class ExpandCollapsePatternProperties : IExpandCollapsePatternProperties
    {
        public PropertyId ExpandCollapseState => ExpandCollapsePattern.ExpandCollapseStateProperty;
    }
}
