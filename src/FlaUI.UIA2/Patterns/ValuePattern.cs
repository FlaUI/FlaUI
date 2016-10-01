using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
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

        public ValuePattern(AutomationObjectBase automationObject, UIA.ValuePattern nativePattern) : base(automationObject, nativePattern)
        {
            Properties = new ValuePatternProperties();
        }

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Cached => Cached;

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Current => Current;

        protected override ValuePatternInformation CreateInformation(bool cached)
        {
            return new ValuePatternInformation(AutomationObject, cached);
        }

        public IValuePatternProperties Properties { get; }

        public void SetValue(string value)
        {
            NativePattern.SetValue(value);
        }
    }

    public class ValuePatternInformation : ElementInformationBase, IValuePatternInformation
    {
        public ValuePatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
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
