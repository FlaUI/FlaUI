namespace FlaUI.Core.Patterns.Infrastructure
{
    public abstract class PatternBase<TNativePattern> : IPattern
    {
        public BasicAutomationElementBase BasicAutomationElement { get; private set; }

        public TNativePattern NativePattern { get; private set; }

        protected PatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern)
        {
            BasicAutomationElement = basicAutomationElement;
            NativePattern = nativePattern;
        }
    }
}
