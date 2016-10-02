using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ExpandCollapsePattern : PatternBaseWithInformation<UIA.ExpandCollapsePattern, ExpandCollapsePatternInformation>, IExpandCollapsePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ExpandCollapsePattern.Pattern.Id, "ExpandCollapse");
        public static readonly PropertyId ExpandCollapseStateProperty = PropertyId.Register(AutomationType.UIA2, UIA.ExpandCollapsePattern.ExpandCollapseStateProperty.Id, "ExpandCollapseState");

        public ExpandCollapsePattern(AutomationObjectBase automationObject, UIA.ExpandCollapsePattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        IExpandCollapsePatternInformation IPatternWithInformation<IExpandCollapsePatternInformation>.Cached => Cached;

        IExpandCollapsePatternInformation IPatternWithInformation<IExpandCollapsePatternInformation>.Current => Current;

        protected override ExpandCollapsePatternInformation CreateInformation(bool cached)
        {
            return new ExpandCollapsePatternInformation(AutomationObject, cached);
        }

        public void Collapse()
        {
            NativePattern.Collapse();
        }

        public void Expand()
        {
            NativePattern.Expand();
        }
    }

    public class ExpandCollapsePatternInformation : ElementInformationBase, IExpandCollapsePatternInformation
    {
        public ExpandCollapsePatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public ExpandCollapseState ExpandCollapseState => Get<ExpandCollapseState>(ExpandCollapsePattern.ExpandCollapseStateProperty);
    }
}
