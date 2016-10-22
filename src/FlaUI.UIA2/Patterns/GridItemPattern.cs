using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Converters;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class GridItemPattern : PatternBaseWithInformation<UIA.GridItemPattern, GridItemPatternInformation>, IGridItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.GridItemPattern.Pattern.Id, "GridItem");
        public static readonly PropertyId ColumnProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridItemPattern.ColumnProperty.Id, "Column");
        public static readonly PropertyId ColumnSpanProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridItemPattern.ColumnSpanProperty.Id, "ColumnSpan");
        public static readonly PropertyId ContainingGridProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridItemPattern.ContainingGridProperty.Id, "ContainingGrid");
        public static readonly PropertyId RowProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridItemPattern.RowProperty.Id, "Row");
        public static readonly PropertyId RowSpanProperty = PropertyId.Register(AutomationType.UIA2, UIA.GridItemPattern.RowSpanProperty.Id, "RowSpan");

        public GridItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.GridItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        IGridItemPatternInformation IPatternWithInformation<IGridItemPatternInformation>.Cached => Cached;

        IGridItemPatternInformation IPatternWithInformation<IGridItemPatternInformation>.Current => Current;

        public IGridItemPatternProperties Properties => Automation.PropertyLibrary.GridItem;

        protected override GridItemPatternInformation CreateInformation(bool cached)
        {
            return new GridItemPatternInformation(BasicAutomationElement, cached);
        }
    }

    public class GridItemPatternInformation : InformationBase, IGridItemPatternInformation
    {
        public GridItemPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public int Column => Get<int>(GridItemPattern.ColumnProperty);

        public int ColumnSpan => Get<int>(GridItemPattern.ColumnSpanProperty);

        public AutomationElement ContainingGrid
        {
            get
            {
                var nativeElement = Get<UIA.AutomationElement>(GridItemPattern.ContainingGridProperty);
                return AutomationElementConverter.NativeToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeElement);
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
