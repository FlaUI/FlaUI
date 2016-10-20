using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;

namespace FlaUI.Core.Patterns
{
    public interface ITextPattern
    {
        ITextPatternEvents Events { get; }
        ITextRange DocumentRange { get; }
        SupportedTextSelection SupportedTextSelection { get; }
        ITextRange[] GetSelection();
        ITextRange[] GetVisibleRanges();
        ITextRange RangeFromChild(AutomationElement child);
        ITextRange RangeFromPoint(Point point);
    }

    public interface ITextPatternEvents
    {
        EventId TextChangedEvent { get; }
        EventId TextSelectionChangedEvent { get; }
    }
}
