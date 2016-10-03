using FlaUI.Core;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class GridPattern : PatternBaseWithInformation<GridPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_GridPatternId, "Grid");
        public static readonly PropertyId ColumnCountProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_GridColumnCountPropertyId, "ColumnCount");
        public static readonly PropertyId RowCountProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_GridRowCountPropertyId, "RowCount");

        internal GridPattern(AutomationElement automationAutomationElement, UIA.IUIAutomationGridPattern nativePattern)
            : base(automationAutomationElement, nativePattern, (element, cached) => new GridPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationGridPattern NativePattern
        {
            get { return (UIA.IUIAutomationGridPattern)base.NativePattern; }
        }

        public AutomationElement GetItem(int row, int column)
        {
            var nativeItem = ComCallWrapper.Call(() => NativePattern.GetItem(row, column));
            return ToAutomationElement(nativeItem);
        }
    }

    public class GridPatternInformation : InformationBase
    {
        public GridPatternInformation(AutomationElement automationAutomationElement, bool cached)
            : base(automationAutomationElement, cached)
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
