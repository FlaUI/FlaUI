using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITablePattern : IPatternWithInformation<ITablePatternInformation>
    {
        ITablePatternProperties Properties { get; }
    }

    public interface ITablePatternInformation : IPatternInformation
    {
        AutomationElement[] ColumnHeaders { get; }
        AutomationElement[] RowHeaders { get; }
        RowOrColumnMajor RowOrColumnMajor { get; }
    }

    public interface ITablePatternProperties
    {
        PropertyId ColumnHeadersProperty { get; }
        PropertyId RowHeadersProperty { get; }
        PropertyId RowOrColumnMajorProperty { get; }
    }
}
