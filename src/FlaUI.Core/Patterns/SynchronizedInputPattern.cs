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
}
