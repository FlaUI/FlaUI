using System;
using FlaUI.Core;
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

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Cached
        {
            get { throw new NotImplementedException(); }
        }

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Current
        {
            get { throw new NotImplementedException(); }
        }

        public ValuePattern(AutomationObjectBase automationObject, UIA.ValuePattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        protected override ValuePatternInformation CreateInformation(bool cached)
        {
            return new ValuePatternInformation(AutomationObject, cached);
        }

        public void SetValue(string value)
        {
            NativePattern.SetValue(value);
        }

        void IValuePattern.SetValue(string value)
        {
            throw new NotImplementedException();
        }
    }
}
