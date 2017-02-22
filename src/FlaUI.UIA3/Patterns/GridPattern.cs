using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class GridPattern : PatternBaseWithInformation<UIA.IUIAutomationGridPattern, GridPatternInformation>, IGridPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_GridPatternId, "Grid", AutomationObjectIds.IsGridPatternAvailableProperty);
        public static readonly PropertyId ColumnCountProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_GridColumnCountPropertyId, "ColumnCount");
        public static readonly PropertyId RowCountProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_GridRowCountPropertyId, "RowCount");

        public GridPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationGridPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        IGridPatternInformation IPatternWithInformation<IGridPatternInformation>.Cached => Cached;

        IGridPatternInformation IPatternWithInformation<IGridPatternInformation>.Current => Current;

        public IGridPatternProperties Properties => Automation.PropertyLibrary.Grid;

        protected override GridPatternInformation CreateInformation()
        {
            return new GridPatternInformation(BasicAutomationElement);
        }

        public AutomationElement GetItem(int row, int column)
        {
            var nativeItem = ComCallWrapper.Call(() => NativePattern.GetItem(row, column));
            return AutomationElementConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeItem);
        }
    }

    public class GridPatternInformation : InformationBase, IGridPatternInformation
    {
        public GridPatternInformation(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public int ColumnCount => Get<int>(GridPattern.ColumnCountProperty);

        public int RowCount => Get<int>(GridPattern.RowCountProperty);
    }

    public class GridPatternProperties : IGridPatternProperties
    {
        public PropertyId ColumnCountProperty => GridPattern.ColumnCountProperty;

        public PropertyId RowCountProperty => GridPattern.RowCountProperty;
    }
}
