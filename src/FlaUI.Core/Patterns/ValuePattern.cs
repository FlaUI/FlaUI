using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class ValuePattern : PatternBaseWithInformation<IUIAutomationValuePattern, ValuePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_ValuePatternId, "Value");
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(UIA_PropertyIds.UIA_ValueIsReadOnlyPropertyId, "IsReadOnly");
        public static readonly PropertyId ValueProperty = PropertyId.Register(UIA_PropertyIds.UIA_ValueValuePropertyId, "Value");

        internal ValuePattern(AutomationElement automationElement, IUIAutomationValuePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new ValuePatternInformation(element, cached))
        {
        }

        public void SetValue(string value)
        {
            ComCallWrapper.Call(() => NativePattern.SetValue(value));
        }
    }

    public class ValuePatternInformation : InformationBase
    {
        public ValuePatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public bool IsReadOnly
        {
            get { return Get<bool>(ValuePattern.IsReadOnlyProperty); }
        }

        public string Value
        {
            get { return Get<string>(ValuePattern.ValueProperty); }
        }
    }
}
