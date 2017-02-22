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
    public class TableItemPattern : PatternBaseWithInformation<UIA.IUIAutomationTableItemPattern, TableItemPatternInformation>, ITableItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TableItemPatternId, "TableItem", AutomationObjectIds.IsTableItemPatternAvailableProperty);
        public static readonly PropertyId ColumnHeaderItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableItemColumnHeaderItemsPropertyId, "ColumnHeaderItems");
        public static readonly PropertyId RowHeaderItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableItemRowHeaderItemsPropertyId, "RowHeaderItems");

        public TableItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTableItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        ITableItemPatternInformation IPatternWithInformation<ITableItemPatternInformation>.Cached => Cached;

        ITableItemPatternInformation IPatternWithInformation<ITableItemPatternInformation>.Current => Current;

        public ITableItemPatternProperties Properties => Automation.PropertyLibrary.TableItem;

        protected override TableItemPatternInformation CreateInformation()
        {
            return new TableItemPatternInformation(BasicAutomationElement);
        }
    }

    public class TableItemPatternInformation : InformationBase, ITableItemPatternInformation
    {
        public TableItemPatternInformation(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public AutomationElement[] ColumnHeaderItems
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(TableItemPattern.ColumnHeaderItemsProperty);
                return AutomationElementConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public AutomationElement[] RowHeaderItems
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(TableItemPattern.RowHeaderItemsProperty);
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
