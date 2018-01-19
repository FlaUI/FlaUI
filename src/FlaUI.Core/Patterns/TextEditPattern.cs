using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Patterns
{
    public interface ITextEditPattern : ITextPattern
    {
        new ITextEditPatternEventIds EventIds { get; }

        ITextRange GetActiveComposition();
        ITextRange GetConversionTarget();
    }

    public interface ITextEditPatternEventIds : ITextPatternEventIds
    {
        EventId ConversionTargetChangedEvent { get; }
        EventId TextChangedEvent2 { get; }
    }
}
