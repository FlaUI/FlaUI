using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ValuePattern : ValuePatternBase<UIA.ValuePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ValuePattern.Pattern.Id, "Value", AutomationObjectIds.IsValuePatternAvailableProperty);
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA2, UIA.ValuePattern.IsReadOnlyProperty.Id, "IsReadOnly");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA2, UIA.ValuePattern.ValueProperty.Id, "Value");

        public ValuePattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.ValuePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        /// <inheritdoc />
        public override void SetValue(string value)
        {
            NativePattern.SetValue(value);
        }
    }

    public class ValuePatternProperties : IValuePatternProperties
    {
        public PropertyId IsReadOnly => ValuePattern.IsReadOnlyProperty;

        public PropertyId Value => ValuePattern.ValueProperty;
    }
}
