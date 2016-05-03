using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class GridPattern : PatternBaseWithInformation<IUIAutomationGridPattern, GridPatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_GridPatternId, "Grid");
        public static readonly AutomationProperty ColumnCountProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_GridColumnCountPropertyId, "ColumnCount");
        public static readonly AutomationProperty RowCountProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_GridRowCountPropertyId, "RowCount");

        internal GridPattern(AutomationElement automationElement, IUIAutomationGridPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new GridPatternInformation(element, cached))
        {
        }

        public AutomationElement GetItem(int row, int column)
        {
            var nativeItem = ComCallWrapper.Call(() => NativePattern.GetItem(row, column));
            return ToAutomationElement(nativeItem);
        }
    }

    public class GridPatternInformation : InformationBase
    {
        public GridPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public int ColumnCount
        {
            get { return Get<int>(GridPattern.ColumnCountProperty); }
        }

        public int RowCount
        {
            get { return Get<int>(GridPattern.RowCountProperty); }
        }
    }
}
