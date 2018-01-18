using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class TogglePattern : TogglePatternBase<UIA.TogglePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TogglePattern.Pattern.Id, "Toggle", AutomationObjectIds.IsTogglePatternAvailableProperty);
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(AutomationType.UIA2, UIA.TogglePattern.ToggleStateProperty.Id, "ToggleState");

        public TogglePattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.TogglePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override void Toggle()
        {
            NativePattern.Toggle();
        }
    }
    
    public class TogglePatternProperties : ITogglePatternProperties
    {
        public PropertyId ToggleState => TogglePattern.ToggleStateProperty;
    }
}
