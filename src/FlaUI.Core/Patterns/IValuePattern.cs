using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IValuePattern : IPatternWithInformation<IValuePatternInformation>
    {
        IValuePatternProperties Properties { get; }
        void SetValue(string value);
    }

    public interface IValuePatternProperties
    {
        PropertyId IsReadOnlyProperty { get; }
        PropertyId ValueProperty { get; }
    }

    public interface IValuePatternInformation : IPatternInformation
    {
        bool IsReadOnly { get; }
        string Value { get; }
    }
}
