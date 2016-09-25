using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public static class ValuePatternIds
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ValuePattern.Pattern.Id, "Value");
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA2, UIA.ValuePattern.IsReadOnlyProperty.Id, "IsReadOnly");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA2, UIA.ValuePattern.ValueProperty.Id, "Value");
    }

    public class ValuePatternProperties : IValuePatternProperties
    {
        public PropertyId IsReadOnlyProperty
        {
            get { return ValuePatternIds.IsReadOnlyProperty; }
        }

        public PropertyId ValueProperty
        {
            get { return ValuePatternIds.ValueProperty; }
        }
    }
}
