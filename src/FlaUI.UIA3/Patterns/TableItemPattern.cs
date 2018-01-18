using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Patterns
{
    public class TableItemPattern : TableItemPatternBase<UIA.IUIAutomationTableItemPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TableItemPatternId, "TableItem", AutomationObjectIds.IsTableItemPatternAvailableProperty);
        public static readonly PropertyId ColumnHeaderItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableItemColumnHeaderItemsPropertyId, "ColumnHeaderItems").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly PropertyId RowHeaderItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableItemRowHeaderItemsPropertyId, "RowHeaderItems").SetConverter(AutomationElementConverter.NativeArrayToManaged);

        public TableItemPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationTableItemPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }
    }

    public class TableItemPatternProperties : ITableItemPatternProperties
    {
        public PropertyId ColumnHeaderItems => TableItemPattern.ColumnHeaderItemsProperty;
        public PropertyId RowHeaderItems => TableItemPattern.RowHeaderItemsProperty;
    }
}
