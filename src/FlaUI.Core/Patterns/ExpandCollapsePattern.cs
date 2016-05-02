using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class ExpandCollapsePattern : PatternBase<IUIAutomationExpandCollapsePattern>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_ExpandCollapsePatternId, "ExpandCollapse");
        public static readonly AutomationProperty ExpandCollapseStateProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ExpandCollapseExpandCollapseStatePropertyId, "ExpandCollapseState");

        public ExpandCollapsePatternInformation Cached { get; private set; }

        public ExpandCollapsePatternInformation Current { get; private set; }

        internal ExpandCollapsePattern(AutomationElement automationElement, IUIAutomationExpandCollapsePattern nativePattern)
            : base(automationElement, nativePattern)
        {
            Cached = new ExpandCollapsePatternInformation(AutomationElement, true);
            Current = new ExpandCollapsePatternInformation(AutomationElement, false);
        }

        public class ExpandCollapsePatternInformation : InformationBase
        {
            public ExpandCollapsePatternInformation(AutomationElement automationElement, bool cached)
                : base(automationElement, cached)
            {
            }

            public Definitions.ExpandCollapseState ExpandCollapseState
            {
                get { return AutomationElement.SafeGetPropertyValue<Definitions.ExpandCollapseState>(ExpandCollapseStateProperty, Cached); }
            }
        }
    }
}
