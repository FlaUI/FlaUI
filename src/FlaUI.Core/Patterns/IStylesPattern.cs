using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IStylesPattern : IPatternWithInformation<IStylesPatternInformation>
    {
        IStylesPatternProperties Properties { get; }
    }

    public interface IStylesPatternInformation : IPatternInformation
    {
        string ExtendedProperties { get; }
        int FillColor { get; }
        int FillPatternColor { get; }
        string FillPatternStyle { get; }
        string Shape { get; }
        StyleType Style { get; }
        string StyleName { get; }
    }

    public interface IStylesPatternProperties
    {
        PropertyId ExtendedPropertiesProperty { get; }
        PropertyId FillColorProperty { get; }
        PropertyId FillPatternColorProperty { get; }
        PropertyId FillPatternStyleProperty { get; }
        PropertyId ShapeProperty { get; }
        PropertyId StyleIdProperty { get; }
        PropertyId StyleNameProperty { get; }
    }
}
