using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TableItemPattern : PatternBase<UIA.IUIAutomationTableItemPattern>, ITableItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TableItemPatternId, "TableItem", AutomationObjectIds.IsTableItemPatternAvailableProperty);
        public static readonly PropertyId ColumnHeaderItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableItemColumnHeaderItemsPropertyId, "ColumnHeaderItems");
        public static readonly PropertyId RowHeaderItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableItemRowHeaderItemsPropertyId, "RowHeaderItems");

        public TableItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTableItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ITableItemPatternProperties Properties => Automation.PropertyLibrary.TableItem;

        public AutomationElement[] ColumnHeaderItems
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(ColumnHeaderItemsProperty);
                return AutomationElementConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public AutomationElement[] RowHeaderItems
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(RowHeaderItemsProperty);
                return AutomationElementConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }
    }

    public class TableItemPatternProperties : ITableItemPatternProperties
    {
        public PropertyId ColumnHeaderItemsProperty => TableItemPattern.ColumnHeaderItemsProperty;
        public PropertyId RowHeaderItemsProperty => TableItemPattern.RowHeaderItemsProperty;
    }
}
