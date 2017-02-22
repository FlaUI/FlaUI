using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class TogglePattern : PatternBaseWithInformation<UIA.TogglePattern, TogglePatternInformation>, ITogglePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TogglePattern.Pattern.Id, "Toggle", AutomationObjectIds.IsTogglePatternAvailableProperty);
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(AutomationType.UIA2, UIA.TogglePattern.ToggleStateProperty.Id, "ToggleState");

        public TogglePattern(BasicAutomationElementBase basicAutomationElement, UIA.TogglePattern nativePattern) : base(basicAutomationElement, nativePattern)
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
            NativePattern.Toggle();
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
