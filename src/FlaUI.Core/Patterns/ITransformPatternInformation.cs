using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITransformPatternInformation : IPatternInformation
    {
        bool CanMove { get; }

        bool CanResize { get; }

        bool CanRotate { get; }
    }
}
