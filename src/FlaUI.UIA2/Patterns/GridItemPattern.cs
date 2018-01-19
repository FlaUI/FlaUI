using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Converters;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class GridItemPattern : GridItemPatternBase<UIA.GridItemPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.GridItemPattern.Pattern.Id, "GridItem", AutomationObjectIds.IsGridItemPatternAvailableProperty);
        public static readonly PropertyId ColumnProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridItemPattern.ColumnProperty.Id, "Column");
        public static readonly PropertyId ColumnSpanProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridItemPattern.ColumnSpanProperty.Id, "ColumnSpan");
        public static readonly PropertyId ContainingGridProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridItemPattern.ContainingGridProperty.Id, "ContainingGrid").SetConverter(AutomationElementConverter.NativeToManaged);
        public static readonly PropertyId RowProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridItemPattern.RowProperty.Id, "Row");
        public static readonly PropertyId RowSpanProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridItemPattern.RowSpanProperty.Id, "RowSpan");

        public GridItemPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.GridItemPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }
    }

    public class GridItemPatternPropertyIds : IGridItemPatternPropertyIds
    {
        public PropertyId Column => GridItemPattern.ColumnProperty;
        public PropertyId ColumnSpan => GridItemPattern.ColumnSpanProperty;
        public PropertyId ContainingGrid => GridItemPattern.ContainingGridProperty;
        public PropertyId Row => GridItemPattern.RowProperty;
        public PropertyId RowSpan => GridItemPattern.RowSpanProperty;
    }
}
