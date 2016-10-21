namespace FlaUI.Core.Patterns.Infrastructure
{
    public abstract class PatternBase<TNativePattern> : IPattern
    {
        public BasicAutomationElementBase BasicAutomationElement { get; }

        public AutomationBase Automation => BasicAutomationElement.Automation;

        public TNativePattern NativePattern { get; private set; }

        protected PatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern)
        {
            BasicAutomationElement = basicAutomationElement;
            NativePattern = nativePattern;
        }
    }
}
