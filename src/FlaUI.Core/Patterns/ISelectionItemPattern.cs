using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ISelectionItemPattern : IPatternWithInformation<ISelectionItemPatternInformation>
    {
        ISelectionItemPatternProperties Properties { get; }
        ISelectionItemPatternEvents Events { get; }
        void AddToSelection();
        void RemoveFromSelection();
        void Select();
    }

    public interface ISelectionItemPatternProperties
    {
        PropertyId IsSelectedProperty { get; }
        PropertyId SelectionContainerProperty { get; }
    }

    public interface ISelectionItemPatternEvents
    {
        EventId ElementAddedToSelectionEvent { get; }
        EventId ElementRemovedFromSelectionEvent { get; }
        EventId ElementSelectedEvent { get; }
    }

    public interface ISelectionItemPatternInformation : IPatternInformation
    {
        bool IsSelected { get; }
        Element SelectionContainer { get; }
    }
}
