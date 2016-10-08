using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITableItemPattern :  IPatternWithInformation<ITableItemPatternInformation>
    {
        ITableItemPatternProperties Properties { get; }
    }

    public interface ITableItemPatternInformation : IPatternInformation
    {
        AutomationElement[] ColumnHeaderItems { get; }
        AutomationElement[] RowHeaderItems { get; }
    }

    public interface ITableItemPatternProperties
    {
        PropertyId ColumnHeaderItemsProperty { get; }
        PropertyId RowHeaderItemsProperty { get; }
    }
}
