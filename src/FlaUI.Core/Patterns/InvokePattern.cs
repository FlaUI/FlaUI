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
}
