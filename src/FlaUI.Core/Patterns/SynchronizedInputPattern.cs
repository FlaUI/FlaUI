using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ISynchronizedInputPattern : IPattern
    {
        ISynchronizedInputPatternEvents Events { get; }

        void Cancel();
        void StartListening(SynchronizedInputType inputType);
    }

    public interface ISynchronizedInputPatternEvents
    {
        EventId DiscardedEvent { get; }
        EventId ReachedOtherElementEvent { get; }
        EventId ReachedTargetEvent { get; }
    }

    public abstract class SynchronizedInputPatternBase<TNativePattern> : PatternBase<TNativePattern>, ISynchronizedInputPattern
        where TNativePattern : class
    {
        protected SynchronizedInputPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ISynchronizedInputPatternEvents Events => Automation.EventLibrary.SynchronizedInput;

        public abstract void Cancel();
        public abstract void StartListening(SynchronizedInputType inputType);
    }
}
