using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class GridItemPattern : PatternBase<UIA.IUIAutomationGridItemPattern>, IGridItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_GridItemPatternId, "GridItem", AutomationObjectIds.IsGridItemPatternAvailableProperty);
        public static readonly PropertyId ColumnProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_GridItemColumnPropertyId, "Column");
        public static readonly PropertyId ColumnSpanProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_GridItemColumnSpanPropertyId, "ColumnSpan");
        public static readonly PropertyId ContainingGridProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_GridItemContainingGridPropertyId, "ContainingGrid");
        public static readonly PropertyId RowProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_GridItemRowPropertyId, "Row");
        public static readonly PropertyId RowSpanProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_GridItemRowSpanPropertyId, "RowSpan");

        public GridItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationGridItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IGridItemPatternProperties Properties => Automation.PropertyLibrary.GridItem;

        public int Column => Get<int>(ColumnProperty);

        public int ColumnSpan => Get<int>(ColumnSpanProperty);

        public AutomationElement ContainingGrid
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElement>(ContainingGridProperty);
                return AutomationElementConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public int Row => Get<int>(RowProperty);

        public int RowSpan => Get<int>(RowSpanProperty);
    }

    public class GridItemPatternProperties : IGridItemPatternProperties
    {
        public PropertyId ColumnProperty => GridItemPattern.ColumnProperty;
        public PropertyId ColumnSpanProperty => GridItemPattern.ColumnSpanProperty;
        public PropertyId ContainingGridProperty => GridItemPattern.ContainingGridProperty;
        public PropertyId RowProperty => GridItemPattern.RowProperty;
        public PropertyId RowSpanProperty => GridItemPattern.RowSpanProperty;
    }
}
