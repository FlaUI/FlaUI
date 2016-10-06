using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ExpandCollapsePattern : PatternBaseWithInformation<UIA.IUIAutomationExpandCollapsePattern, ExpandCollapsePatternInformation>, IExpandCollapsePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ExpandCollapsePatternId, "ExpandCollapse");
        public static readonly PropertyId ExpandCollapseStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ExpandCollapseExpandCollapseStatePropertyId, "ExpandCollapseState");

        public ExpandCollapsePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationExpandCollapsePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        IExpandCollapsePatternInformation IPatternWithInformation<IExpandCollapsePatternInformation>.Cached => Cached;

        IExpandCollapsePatternInformation IPatternWithInformation<IExpandCollapsePatternInformation>.Current => Current;

        protected override ExpandCollapsePatternInformation CreateInformation(bool cached)
        {
            return new ExpandCollapsePatternInformation(BasicAutomationElement, cached);
        }

        public void Collapse()
        {
            ComCallWrapper.Call(() => NativePattern.Collapse());
        }

        public void Expand()
        {
            ComCallWrapper.Call(() => NativePattern.Expand());
        }
    }

    public class ExpandCollapsePatternInformation : InformationBase, IExpandCollapsePatternInformation
    {
        public ExpandCollapsePatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public ExpandCollapseState ExpandCollapseState => Get<ExpandCollapseState>(ExpandCollapsePattern.ExpandCollapseStateProperty);
    }
}
