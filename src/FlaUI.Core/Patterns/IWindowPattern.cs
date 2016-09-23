using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IWindowPattern : IPatternWithInformation<IWindowPatternInformation>
    {
        PropertyId CanMaximizeProperty { get; }
        PropertyId CanMinimizeProperty { get; }
        PropertyId IsModalProperty { get; }
        PropertyId IsTopmostProperty { get; }
        PropertyId WindowInteractionStateProperty { get; }
        PropertyId WindowVisualStateProperty { get; }

        void Close();

        void SetWindowVisualState(WindowVisualState state);

        int WaitForInputIdle(int milliseconds);
    }
}
