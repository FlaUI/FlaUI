using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ValuePattern : PatternBaseWithInformation<UIA.ValuePattern, ValuePatternInformation>, IValuePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ValuePattern.Pattern.Id, "Value");
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA2, UIA.ValuePattern.IsReadOnlyProperty.Id, "IsReadOnly");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA2, UIA.ValuePattern.ValueProperty.Id, "Value");

        public ValuePattern(BasicAutomationElementBase basicAutomationElement, UIA.ValuePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Cached => Cached;

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Current => Current;

        public IValuePatternProperties Properties => Automation.PropertyLibrary.Value;

        protected override ValuePatternInformation CreateInformation(bool cached)
        {
            return new ValuePatternInformation(BasicAutomationElement, cached);
        }

        public void SetValue(string value)
        {
            NativePattern.SetValue(value);
        }
    }

    public class ValuePatternInformation : InformationBase, IValuePatternInformation
    {
        public ValuePatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public bool IsReadOnly => Get<bool>(ValuePattern.IsReadOnlyProperty);

        public string Value => Get<string>(ValuePattern.ValueProperty);
    }

    public class ValuePatternProperties : IValuePatternProperties
    {
        public PropertyId IsReadOnlyProperty => ValuePattern.IsReadOnlyProperty;

        public PropertyId ValueProperty => ValuePattern.ValueProperty;
    }
}
