using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class GridItemPattern : PatternBaseWithInformation<IUIAutomationGridItemPattern, GridItemPatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_GridItemPatternId, "GridItem");
        public static readonly AutomationProperty ColumnProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_GridItemColumnPropertyId, "Column");
        public static readonly AutomationProperty ColumnSpanProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_GridItemColumnSpanPropertyId, "ColumnSpan");
        public static readonly AutomationProperty ContainingGridProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_GridItemContainingGridPropertyId, "ContainingGrid");
        public static readonly AutomationProperty RowProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_GridItemRowPropertyId, "Row");
        public static readonly AutomationProperty RowSpanProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_GridItemRowSpanPropertyId, "RowSpan");

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
