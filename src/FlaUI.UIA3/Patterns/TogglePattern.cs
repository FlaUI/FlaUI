using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Patterns
{
    public class TogglePattern : TogglePatternBase<UIA.IUIAutomationTogglePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TogglePatternId, "Toggle", AutomationObjectIds.IsTogglePatternAvailableProperty);
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ToggleToggleStatePropertyId, "ToggleState");

        public TogglePattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationTogglePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override void Toggle()
        {
            Com.Call(() => NativePattern.Toggle());
        }
    }

    public class TogglePatternProperties : ITogglePatternProperties
    {
        public PropertyId ToggleState => TogglePattern.ToggleStateProperty;
    }
}
