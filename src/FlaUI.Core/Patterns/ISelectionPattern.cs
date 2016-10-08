using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ISelectionPattern : IPatternWithInformation<ISelectionPatternInformation>
    {
        ISelectionPatternProperties Properties { get; }
        ISelectionPatternEvents Events { get; }
    }

    public interface ISelectionPatternInformation : IPatternInformation
    {
        bool CanSelectMultiple { get; }
        bool IsSelectionRequired { get; }
        AutomationElement[] Selection { get; }
    }

    public interface ISelectionPatternProperties
    {
        PropertyId CanSelectMultipleProperty { get; }
        PropertyId IsSelectionRequiredProperty { get; }
        PropertyId SelectionProperty { get; }
    }

    public interface ISelectionPatternEvents
    {
        EventId InvalidatedEvent { get; }
    }
}
