using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITablePattern : IPattern
    {
        ITablePatternProperties Properties { get; }
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
