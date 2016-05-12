using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class GridPattern : PatternBaseWithInformation<GridPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_GridPatternId, "Grid");
        public static readonly PropertyId ColumnCountProperty = PropertyId.Register(UIA_PropertyIds.UIA_GridColumnCountPropertyId, "ColumnCount");
        public static readonly PropertyId RowCountProperty = PropertyId.Register(UIA_PropertyIds.UIA_GridRowCountPropertyId, "RowCount");

        internal GridPattern(AutomationElement automationElement, IUIAutomationGridPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new GridPatternInformation(element, cached))
        {
        }

        public IUIAutomationGridPattern NativePattern
        {
            get { return (IUIAutomationGridPattern)base.NativePattern; }
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
