using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITogglePattern : IPatternWithInformation<ITogglePatternInformation>
    {
        ITogglePatternProperties Properties { get; }
        void Toggle();
    }

    public interface ITogglePatternProperties
    {
        PropertyId ToggleStateProperty { get; }
    }

    public interface ITogglePatternInformation : IPatternInformation
    {
        ToggleState ToggleState { get; }
    }
}
