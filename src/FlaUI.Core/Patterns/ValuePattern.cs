using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public abstract class ValuePattern<TNativePattern, TInfo> : PatternBaseWithInformation<TNativePattern, TInfo>, IValuePattern where TInfo : IValuePatternInformation
    {
        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Cached
        {
            get { return Cached; }
        }

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Current
        {
            get { return Current; }
        }

        protected ValuePattern(AutomationObjectBase automationObject, TNativePattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        public abstract void SetValue(string value);
    }
}
