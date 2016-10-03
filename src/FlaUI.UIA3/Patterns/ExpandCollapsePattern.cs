using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
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

        public ExpandCollapsePattern(AutomationObjectBase automationObject, UIA.IUIAutomationExpandCollapsePattern nativePattern) : base(automationObject, nativePattern)
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
            ComCallWrapper.Call(() => NativePattern.Collapse());
        }

        public void Expand()
        {
            ComCallWrapper.Call(() => NativePattern.Expand());
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
