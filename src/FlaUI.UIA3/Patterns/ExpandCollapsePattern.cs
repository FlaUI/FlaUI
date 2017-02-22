using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ExpandCollapsePattern : PatternBaseWithInformation<UIA.IUIAutomationExpandCollapsePattern, ExpandCollapsePatternInformation>, IExpandCollapsePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ExpandCollapsePatternId, "ExpandCollapse", AutomationObjectIds.IsExpandCollapsePatternAvailableProperty);
        public static readonly PropertyId ExpandCollapseStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ExpandCollapseExpandCollapseStatePropertyId, "ExpandCollapseState");

        public ExpandCollapsePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationExpandCollapsePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        IExpandCollapsePatternInformation IPatternWithInformation<IExpandCollapsePatternInformation>.Cached => Cached;

        IExpandCollapsePatternInformation IPatternWithInformation<IExpandCollapsePatternInformation>.Current => Current;

        public IExpandCollapsePatternProperties Properties => Automation.PropertyLibrary.ExpandCollapse;

        protected override ExpandCollapsePatternInformation CreateInformation()
        {
            return new ExpandCollapsePatternInformation(BasicAutomationElement);
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
        public ExpandCollapsePatternInformation(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public ExpandCollapseState ExpandCollapseState => Get<ExpandCollapseState>(ExpandCollapsePattern.ExpandCollapseStateProperty);
    }

    public class ExpandCollapsePatternProperties : IExpandCollapsePatternProperties
    {
        public PropertyId ExpandCollapseStateProperty => ExpandCollapsePattern.ExpandCollapseStateProperty;
    }
}
