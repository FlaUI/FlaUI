﻿using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ValuePattern : PatternBaseWithInformation<UIA.ValuePattern, ValuePatternInformation>, IValuePattern
    {
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

        public bool IsReadOnly => Get<bool>(ValuePatternIds.IsReadOnlyProperty);

        public string Value => Get<string>(ValuePatternIds.ValueProperty);
    }
}