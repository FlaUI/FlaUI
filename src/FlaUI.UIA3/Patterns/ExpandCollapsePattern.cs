using FlaUI.Core;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ExpandCollapsePattern : PatternBaseWithInformation<ExpandCollapsePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_ExpandCollapsePatternId, "ExpandCollapse");
        public static readonly PropertyId ExpandCollapseStateProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_ExpandCollapseExpandCollapseStatePropertyId, "ExpandCollapseState");

        internal ExpandCollapsePattern(AutomationElement automationElement, UIA.IUIAutomationExpandCollapsePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new ExpandCollapsePatternInformation(element, cached))
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
        public ExpandCollapsePatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public ExpandCollapseState ExpandCollapseState
        {
            get { return Get<ExpandCollapseState>(ExpandCollapsePattern.ExpandCollapseStateProperty); }
        }
    }
}
