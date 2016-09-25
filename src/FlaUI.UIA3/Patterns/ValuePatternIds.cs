using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;

namespace FlaUI.UIA3.Patterns
{
    public static class ValuePatternIds
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PatternIds.UIA_ValuePatternId, "Value");
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_ValueIsReadOnlyPropertyId, "IsReadOnly");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_ValueValuePropertyId, "Value");
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
