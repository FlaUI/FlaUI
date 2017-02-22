using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ValuePattern : PatternBaseWithInformation<UIA.IUIAutomationValuePattern, ValuePatternInformation>, IValuePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ValuePatternId, "Value", AutomationObjectIds.IsValuePatternAvailableProperty);
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ValueIsReadOnlyPropertyId, "IsReadOnly");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ValueValuePropertyId, "Value");

        public ValuePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationValuePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Cached => Cached;

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Current => Current;

        public IValuePatternProperties Properties => Automation.PropertyLibrary.Value;

        public void SetValue(string value)
        {
            ComCallWrapper.Call(() => NativePattern.SetValue(value));
        }

        protected override ValuePatternInformation CreateInformation()
        {
            return new ValuePatternInformation(BasicAutomationElement);
        }
    }

    public class ValuePatternInformation : InformationBase, IValuePatternInformation
    {
        public ValuePatternInformation(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
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
