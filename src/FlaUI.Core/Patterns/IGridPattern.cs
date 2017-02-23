using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IGridPattern : IPattern
    {
        IGridPatternProperties Properties { get; }
        int ColumnCount { get; }
        int RowCount { get; }
        AutomationElement GetItem(int row, int column);
    }

    public interface IGridPatternProperties
    {
        PropertyId ColumnCountProperty { get; }
        PropertyId RowCountProperty { get; }
    }
}
