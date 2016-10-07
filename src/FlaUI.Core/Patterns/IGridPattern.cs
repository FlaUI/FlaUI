using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IGridPattern : IPatternWithInformation<IGridPatternInformation>
    {
        IGridPatternProperties Properties { get; }
        AutomationElement GetItem(int row, int column);
    }

    public interface IGridPatternInformation : IPatternInformation
    {
        int ColumnCount { get; }
        int RowCount { get; }
    }

    public interface IGridPatternProperties
    {
        PropertyId ColumnCountProperty { get; }
        PropertyId RowCountProperty { get; }
    }
}
