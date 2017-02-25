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
        protected GridPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ColumnCount = new AutomationProperty<int>(() => Properties.ColumnCount, BasicAutomationElement);
            RowCount = new AutomationProperty<int>(() => Properties.RowCount, BasicAutomationElement);
        }

        public IGridPatternProperties Properties => Automation.PropertyLibrary.Grid;

        public AutomationProperty<int> ColumnCount { get; }
        public AutomationProperty<int> RowCount { get; }

        public abstract AutomationElement GetItem(int row, int column);
    }
}
