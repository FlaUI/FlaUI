using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IValuePatternInformation : IPatternInformation
    {
        bool IsReadOnly { get; }

        string Value { get; }
    }
}
