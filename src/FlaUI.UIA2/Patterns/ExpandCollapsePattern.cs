using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ExpandCollapsePattern : PatternBase<UIA.ExpandCollapsePattern>, IExpandCollapsePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ExpandCollapsePattern.Pattern.Id, "ExpandCollapse", AutomationObjectIds.IsExpandCollapsePatternAvailableProperty);
        public static readonly PropertyId ExpandCollapseStateProperty = PropertyId.Register(AutomationType.UIA2, UIA.ExpandCollapsePattern.ExpandCollapseStateProperty.Id, "ExpandCollapseState");

        public ExpandCollapsePattern(BasicAutomationElementBase basicAutomationElement, UIA.ExpandCollapsePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IExpandCollapsePatternProperties Properties => Automation.PropertyLibrary.ExpandCollapse;

        public ExpandCollapseState ExpandCollapseState => Get<ExpandCollapseState>(ExpandCollapseStateProperty);

        public void Collapse()
        {
            NativePattern.Collapse();
        }

        public void Expand()
        {
            NativePattern.Expand();
        }
    }

    public class ExpandCollapsePatternProperties : IExpandCollapsePatternProperties
    {
        public PropertyId ExpandCollapseStateProperty => ExpandCollapsePattern.ExpandCollapseStateProperty;
    }
}
