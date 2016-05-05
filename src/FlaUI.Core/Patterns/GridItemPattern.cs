using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class GridItemPattern : PatternBaseWithInformation<IUIAutomationGridItemPattern, GridItemPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_GridItemPatternId, "GridItem");
        public static readonly PropertyId ColumnProperty = PropertyId.Register(UIA_PropertyIds.UIA_GridItemColumnPropertyId, "Column");
        public static readonly PropertyId ColumnSpanProperty = PropertyId.Register(UIA_PropertyIds.UIA_GridItemColumnSpanPropertyId, "ColumnSpan");
        public static readonly PropertyId ContainingGridProperty = PropertyId.Register(UIA_PropertyIds.UIA_GridItemContainingGridPropertyId, "ContainingGrid");
        public static readonly PropertyId RowProperty = PropertyId.Register(UIA_PropertyIds.UIA_GridItemRowPropertyId, "Row");
        public static readonly PropertyId RowSpanProperty = PropertyId.Register(UIA_PropertyIds.UIA_GridItemRowSpanPropertyId, "RowSpan");

        internal GridItemPattern(AutomationElement automationElement, IUIAutomationGridItemPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new GridItemPatternInformation(element, cached))
        {
        }
    }

    public class GridItemPatternInformation : InformationBase
    {
        public GridItemPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public int Column
        {
            get { return Get<int>(GridItemPattern.ColumnProperty); }
        }

        public int ColumnSpan
        {
            get { return Get<int>(GridItemPattern.ColumnSpanProperty); }
        }

        public AutomationElement ContainingGrid
        {
            get { return NativeElementToElement(GridItemPattern.ContainingGridProperty); }
        }

        public int Row
        {
            get { return Get<int>(GridItemPattern.RowProperty); }
        }

        public int RowSpan
        {
            get { return Get<int>(GridItemPattern.RowSpanProperty); }
        }
    }
}
