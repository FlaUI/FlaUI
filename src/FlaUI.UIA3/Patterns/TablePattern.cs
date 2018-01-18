using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Patterns
{
    public class TablePattern : TablePatternBase<UIA.IUIAutomationTablePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TablePatternId, "Table", AutomationObjectIds.IsTablePatternAvailableProperty);
        public static readonly PropertyId ColumnHeadersProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableColumnHeadersPropertyId, "ColumnHeaders").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly PropertyId RowHeadersProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableRowHeadersPropertyId, "RowHeaders").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly PropertyId RowOrColumnMajorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableRowOrColumnMajorPropertyId, "RowOrColumnMajor");

        public TablePattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationTablePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }
    }

    public class TablePatternProperties : ITablePatternProperties
    {
        public PropertyId ColumnHeaders => TablePattern.ColumnHeadersProperty;
        public PropertyId RowHeaders => TablePattern.RowHeadersProperty;
        public PropertyId RowOrColumnMajor => TablePattern.RowOrColumnMajorProperty;
    }
}
