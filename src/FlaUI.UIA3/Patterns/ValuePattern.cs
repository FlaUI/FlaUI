using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ValuePattern : PatternBaseWithInformation<UIA.IUIAutomationValuePattern, ValuePatternInformation>, IValuePattern
    {
        public ValuePattern(AutomationObjectBase automationObject, UIA.IUIAutomationValuePattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Cached
        {
            get { return Cached; }
        }

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Current
        {
            get { return Current; }
        }

        public void SetValue(string value)
        {
            ComCallWrapper.Call(() => NativePattern.SetValue(value));
        }

        protected override ValuePatternInformation CreateInformation(bool cached)
        {
            return new ValuePatternInformation(AutomationObject, cached);
        }
    }
}
