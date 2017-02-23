using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IValuePattern : IPattern
    {
        IValuePatternProperties Properties { get; }
        bool IsReadOnly { get; }
        string Value { get; }
        void SetValue(string value);
    }

    public interface IValuePatternProperties
    {
        PropertyId IsReadOnlyProperty { get; }
        PropertyId ValueProperty { get; }
    }
}
