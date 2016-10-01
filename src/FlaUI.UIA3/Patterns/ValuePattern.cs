using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ValuePattern : PatternBaseWithInformation<UIA.IUIAutomationValuePattern, ValuePatternInformation>, IValuePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PatternIds.UIA_ValuePatternId, "Value");
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_ValueIsReadOnlyPropertyId, "IsReadOnly");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_ValueValuePropertyId, "Value");

        public ValuePattern(AutomationObjectBase automationObject, UIA.IUIAutomationValuePattern nativePattern) : base(automationObject, nativePattern)
        {
            Properties = new ValuePatternProperties();
        }

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Cached => Cached;

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Current => Current;

        public IValuePatternProperties Properties { get; }

        public void SetValue(string value)
        {
            ComCallWrapper.Call(() => NativePattern.SetValue(value));
        }

        protected override ValuePatternInformation CreateInformation(bool cached)
        {
            return new ValuePatternInformation(AutomationObject, cached);
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
