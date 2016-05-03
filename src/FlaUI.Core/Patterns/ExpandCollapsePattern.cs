using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class ExpandCollapsePattern : PatternBaseWithInformation<IUIAutomationExpandCollapsePattern, ExpandCollapsePatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_ExpandCollapsePatternId, "ExpandCollapse");
        public static readonly AutomationProperty ExpandCollapseStateProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ExpandCollapseExpandCollapseStatePropertyId, "ExpandCollapseState");

        internal ExpandCollapsePattern(AutomationElement automationElement, IUIAutomationExpandCollapsePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new ExpandCollapsePatternInformation(element, cached))
        {
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

    public class ExpandCollapsePatternInformation : InformationBase
    {
        public ExpandCollapsePatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public Definitions.ExpandCollapseState ExpandCollapseState
        {
            get { return Get<Definitions.ExpandCollapseState>(ExpandCollapsePattern.ExpandCollapseStateProperty); }
        }
    }
}
