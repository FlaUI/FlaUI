using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Patterns
{
    public interface ITextEditPattern
    {
        ITextEditPatternEvents Events { get; }
        ITextRange GetActiveComposition();
        ITextRange GetConversionTarget();
    }

    public interface ITextEditPatternEvents
    {
        EventId ConversionTargetChangedEvent { get; }
        EventId TextChangedEvent2 { get; }
    }
}
