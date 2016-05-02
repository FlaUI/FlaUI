using FlaUI.Core.Elements;

namespace FlaUI.Core.Patterns
{
    public abstract class PatternBase<T>
    {
        public AutomationElement AutomationElement { get; private set; }
        public T NativePattern { get; private set; }

        protected PatternBase(AutomationElement automationElement, T nativePattern)
        {
            AutomationElement = automationElement;
            NativePattern = nativePattern;
        }
    }
}
