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
    public class GridItemPattern : PatternBaseWithInformation<UIA.IUIAutomationGridItemPattern, GridItemPatternInformation>, IGridItemPattern
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

        IGridItemPatternInformation IPatternWithInformation<IGridItemPatternInformation>.Cached => Cached;

        IGridItemPatternInformation IPatternWithInformation<IGridItemPatternInformation>.Current => Current;

        protected override GridItemPatternInformation CreateInformation()
        {
            return new GridItemPatternInformation(BasicAutomationElement);
        }
    }

    public class GridItemPatternInformation : InformationBase, IGridItemPatternInformation
    {
        public GridItemPatternInformation(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public int Column => Get<int>(GridItemPattern.ColumnProperty);

        public int ColumnSpan => Get<int>(GridItemPattern.ColumnSpanProperty);

        public AutomationElement ContainingGrid
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElement>(GridItemPattern.ContainingGridProperty);
                return AutomationElementConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public int Row => Get<int>(GridItemPattern.RowProperty);

        public int RowSpan => Get<int>(GridItemPattern.RowSpanProperty);
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
