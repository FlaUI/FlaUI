using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Converters;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class GridPattern : PatternBase<UIA.GridPattern>, IGridPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.GridPattern.Pattern.Id, "Grid", AutomationObjectIds.IsGridPatternAvailableProperty);
        public static readonly PropertyId ColumnCountProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridPattern.ColumnCountProperty.Id, "ColumnCount");
        public static readonly PropertyId RowCountProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridPattern.RowCountProperty.Id, "RowCount");

        public GridPattern(BasicAutomationElementBase basicAutomationElement, UIA.GridPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IGridPatternProperties Properties => Automation.PropertyLibrary.Grid;

        public int ColumnCount => Get<int>(ColumnCountProperty);

        public int RowCount => Get<int>(RowCountProperty);

        public AutomationElement GetItem(int row, int column)
        {
            var nativeItem = NativePattern.GetItem(row, column);
            return AutomationElementConverter.NativeToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeItem);
        }
    }

    public class GridPatternProperties : IGridPatternProperties
    {
        public PropertyId ColumnCountProperty => GridPattern.ColumnCountProperty;

        public PropertyId RowCountProperty => GridPattern.RowCountProperty;
    }
}
