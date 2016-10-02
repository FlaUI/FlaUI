using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IWindowPattern : IPatternWithInformation<IWindowPatternInformation>
    {
        IWindowPatternProperties Properties { get; }
        IWindowPatternEvents Events { get; }
        void Close();
        void SetWindowVisualState(WindowVisualState state);
        bool WaitForInputIdle(int milliseconds);
    }

    public interface IWindowPatternProperties
    {
        PropertyId CanMaximizeProperty { get; }
        PropertyId CanMinimizeProperty { get; }
        PropertyId IsModalProperty { get; }
        PropertyId IsTopmostProperty { get; }
        PropertyId WindowInteractionStateProperty { get; }
        PropertyId WindowVisualStateProperty { get; }
    }

    public interface IWindowPatternEvents
    {
        EventId WindowClosedEvent { get; }
        EventId WindowOpenedEvent { get; }
    }

    public interface IWindowPatternInformation : IPatternInformation
    {
        bool CanMaximize { get; }
        bool CanMinimize { get; }
        bool IsModal { get; }
        bool IsTopmost { get; }
        WindowInteractionState WindowInteractionState { get; }
        WindowVisualState WindowVisualState { get; }
    }
}
