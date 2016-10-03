using FlaUI.Core;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ValuePattern : PatternBaseWithInformation<ValuePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ValuePatternId, "Value");
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ValueIsReadOnlyPropertyId, "IsReadOnly");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ValueValuePropertyId, "Value");

        internal ValuePattern(AutomationElement automationAutomationElement, UIA.IUIAutomationValuePattern nativePattern)
            : base(automationAutomationElement, nativePattern, (element, cached) => new ValuePatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationValuePattern NativePattern
        {
            get { return (UIA.IUIAutomationValuePattern)base.NativePattern; }
        }

        public void SetValue(string value)
        {
            ComCallWrapper.Call(() => NativePattern.SetValue(value));
        }
    }

    public class ValuePatternInformation : InformationBase
    {
        public ValuePatternInformation(AutomationElement automationAutomationElement, bool cached)
            : base(automationAutomationElement, cached)
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
