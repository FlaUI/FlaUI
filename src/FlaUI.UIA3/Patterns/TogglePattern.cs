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
    public class TogglePattern : PatternBaseWithInformation<UIA.IUIAutomationTogglePattern, TogglePatternInformation>, ITogglePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TogglePatternId, "Toggle", AutomationObjectIds.IsTogglePatternAvailableProperty);
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ToggleToggleStatePropertyId, "ToggleState");

        public TogglePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTogglePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        ITogglePatternInformation IPatternWithInformation<ITogglePatternInformation>.Cached => Cached;

        ITogglePatternInformation IPatternWithInformation<ITogglePatternInformation>.Current => Current;

        public ITogglePatternProperties Properties => Automation.PropertyLibrary.Toggle;

        protected override TogglePatternInformation CreateInformation()
        {
            return new TogglePatternInformation(BasicAutomationElement);
        }

        public void Toggle()
        {
            ComCallWrapper.Call(() => NativePattern.Toggle());
        }
    }

    public class TogglePatternInformation : InformationBase, ITogglePatternInformation
    {
        public TogglePatternInformation(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public ToggleState ToggleState => Get<ToggleState>(TogglePattern.ToggleStateProperty);
    }

    public class TogglePatternProperties : ITogglePatternProperties
    {
        public PropertyId ToggleStateProperty => TogglePattern.ToggleStateProperty;
    }
}
