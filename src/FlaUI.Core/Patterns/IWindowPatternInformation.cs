using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
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
