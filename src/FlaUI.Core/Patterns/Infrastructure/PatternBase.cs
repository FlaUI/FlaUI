namespace FlaUI.Core.Patterns.Infrastructure
{
    public abstract class PatternBase<TNativePattern> : IPattern
    {
        public AutomationObjectBase AutomationObject { get; private set; }

        public TNativePattern NativePattern { get; private set; }

        protected PatternBase(AutomationObjectBase automationObject, TNativePattern nativePattern)
        {
            AutomationObject = automationObject;
            NativePattern = nativePattern;
        }
    }
}
