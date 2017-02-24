using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITogglePattern : IPattern
    {
        ITogglePatternProperties Properties { get; }
        ToggleState ToggleState { get; }
        void Toggle();
    }

    public interface ITogglePatternProperties
    {
        PropertyId ToggleStateProperty { get; }
    }
}
