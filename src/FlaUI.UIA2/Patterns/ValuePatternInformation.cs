using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.UIA2.Patterns
{
    public class ValuePatternInformation : ElementInformationBase, IValuePatternInformation
    {
        public ValuePatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool IsReadOnly { get { return Get<bool>(ValuePattern.IsReadOnlyProperty); } }

        public string Value { get { return Get<string>(ValuePattern.ValueProperty); } }
    }
}
