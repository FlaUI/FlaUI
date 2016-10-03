using FlaUI.Core;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ExpandCollapsePattern : PatternBaseWithInformation<ExpandCollapsePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ExpandCollapsePatternId, "ExpandCollapse");
        public static readonly PropertyId ExpandCollapseStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ExpandCollapseExpandCollapseStatePropertyId, "ExpandCollapseState");

        internal ExpandCollapsePattern(AutomationElement automationAutomationElement, UIA.IUIAutomationExpandCollapsePattern nativePattern)
            : base(automationAutomationElement, nativePattern, (element, cached) => new ExpandCollapsePatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationExpandCollapsePattern NativePattern
        {
            get { return (UIA.IUIAutomationExpandCollapsePattern)base.NativePattern; }
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
        public ExpandCollapsePatternInformation(AutomationElement automationAutomationElement, bool cached)
            : base(automationAutomationElement, cached)
        {
        }

        public ExpandCollapseState ExpandCollapseState
        {
            get { return Get<ExpandCollapseState>(ExpandCollapsePattern.ExpandCollapseStateProperty); }
        }
    }
}
