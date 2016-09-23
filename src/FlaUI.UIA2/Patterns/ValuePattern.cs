using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ValuePattern : ValuePattern<UIA.ValuePattern, ValuePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ValuePattern.Pattern.Id, "Value");
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA2, UIA.ValuePattern.IsReadOnlyProperty.Id, "IsReadOnly");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA2, UIA.ValuePattern.ValueProperty.Id, "Value");

        public ValuePattern(AutomationObjectBase automationObject, UIA.ValuePattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        protected override ValuePatternInformation CreateInformation(bool cached)
        {
            return new ValuePatternInformation(AutomationObject, cached);
        }

        public override void SetValue(string value)
        {
            NativePattern.SetValue(value);
        }
    }
}
