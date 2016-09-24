using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.UIA3.Patterns
{
    public class ValuePatternInformation : ElementInformationBase, IValuePatternInformation
    {
        public ValuePatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool IsReadOnly { get { return Get<bool>(ValuePatternIds.IsReadOnlyProperty); } }

        public string Value { get { return Get<string>(ValuePatternIds.ValueProperty); } }
    }
}
