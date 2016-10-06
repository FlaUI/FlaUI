using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class TogglePattern : PatternBaseWithInformation<UIA.TogglePattern, TogglePatternInformation>, ITogglePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TogglePattern.Pattern.Id, "Toggle");
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(AutomationType.UIA2, UIA.TogglePattern.ToggleStateProperty.Id, "ToggleState");

        public TogglePattern(BasicAutomationElementBase basicAutomationElement, UIA.TogglePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Properties = new TogglePatternProperties();
        }

        ITogglePatternInformation IPatternWithInformation<ITogglePatternInformation>.Cached => Cached;

        public ITogglePatternProperties Properties { get; }

        ITogglePatternInformation IPatternWithInformation<ITogglePatternInformation>.Current => Current;

        protected override TogglePatternInformation CreateInformation(bool cached)
        {
            return new TogglePatternInformation(BasicAutomationElement, cached);
        }

        public void Toggle()
        {
            NativePattern.Toggle();
        }
    }

    public class TogglePatternInformation : InformationBase, ITogglePatternInformation
    {
        public TogglePatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public ToggleState ToggleState => Get<ToggleState>(TogglePattern.ToggleStateProperty);
    }

    public class TogglePatternProperties : ITogglePatternProperties
    {
        public PropertyId ToggleStateProperty => TogglePattern.ToggleStateProperty;
    }
}
