using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IValuePattern : IPatternWithInformation<IValuePatternInformation>
    {
        void SetValue(string value);
    }
}
