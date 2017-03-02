using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IInvokePattern : IPattern
    {
        IInvokePatternEvents Events { get; }

        void Invoke();
    }

    public interface IInvokePatternEvents
    {
        EventId InvokedEvent { get; }
    }

    public abstract class InvokePatternBase<TNativePattern> : PatternBase<TNativePattern>, IInvokePattern
    {
        protected InvokePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IInvokePatternEvents Events => Automation.EventLibrary.Invoke;

        public abstract void Invoke();
    }
}
