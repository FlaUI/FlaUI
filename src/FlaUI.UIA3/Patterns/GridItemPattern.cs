using FlaUI.Core;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class GridItemPattern : PatternBaseWithInformation<GridItemPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_GridItemPatternId, "GridItem");
        public static readonly PropertyId ColumnProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_GridItemColumnPropertyId, "Column");
        public static readonly PropertyId ColumnSpanProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_GridItemColumnSpanPropertyId, "ColumnSpan");
        public static readonly PropertyId ContainingGridProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_GridItemContainingGridPropertyId, "ContainingGrid");
        public static readonly PropertyId RowProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_GridItemRowPropertyId, "Row");
        public static readonly PropertyId RowSpanProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_GridItemRowSpanPropertyId, "RowSpan");

        internal GridItemPattern(AutomationElement automationElement, UIA.IUIAutomationGridItemPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new GridItemPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationGridItemPattern NativePattern
        {
            get { return (UIA.IUIAutomationGridItemPattern)base.NativePattern; }
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
