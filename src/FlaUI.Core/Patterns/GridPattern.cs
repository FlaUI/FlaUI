using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IGridPattern : IPattern
    {
        IGridPatternProperties Properties { get; }

        AutomationProperty<int> ColumnCount { get; }
        AutomationProperty<int> RowCount { get; }

        AutomationElement GetItem(int row, int column);
    }

    public interface IGridPatternProperties
    {
        PropertyId ColumnCount { get; }
        PropertyId RowCount { get; }
    }

    public abstract class GridPatternBase<TNativePattern> : PatternBase<TNativePattern>, IGridPattern
    {
        private AutomationProperty<int> _columnCount;
        private AutomationProperty<int> _rowCount;

        protected GridPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IGridPatternProperties Properties => Automation.PropertyLibrary.Grid;

        public AutomationProperty<int> ColumnCount => GetOrCreate(ref _columnCount, Properties.ColumnCount);
        public AutomationProperty<int> RowCount => GetOrCreate(ref _rowCount, Properties.RowCount);

        public abstract AutomationElement GetItem(int row, int column);
    }
}
