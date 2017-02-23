using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class TogglePattern : PatternBase<UIA.TogglePattern>, ITogglePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TogglePattern.Pattern.Id, "Toggle", AutomationObjectIds.IsTogglePatternAvailableProperty);
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(AutomationType.UIA2, UIA.TogglePattern.ToggleStateProperty.Id, "ToggleState");

        public TogglePattern(BasicAutomationElementBase basicAutomationElement, UIA.TogglePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ITogglePatternProperties Properties => Automation.PropertyLibrary.Toggle;

        public ToggleState ToggleState => Get<ToggleState>(ToggleStateProperty);

        public void Toggle()
        {
            NativePattern.Toggle();
        }
    }
    
    public class TogglePatternProperties : ITogglePatternProperties
    {
        public PropertyId ToggleStateProperty => TogglePattern.ToggleStateProperty;
    }
}
