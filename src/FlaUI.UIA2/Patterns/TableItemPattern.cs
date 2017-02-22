using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Converters;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class TableItemPattern : PatternBaseWithInformation<UIA.TableItemPattern, TableItemPatternInformation>, ITableItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TableItemPattern.Pattern.Id, "TableItem", AutomationObjectIds.IsTableItemPatternAvailableProperty);
        public static readonly PropertyId ColumnHeaderItemsProperty = PropertyId.Register(AutomationType.UIA2, UIA.TableItemPattern.ColumnHeaderItemsProperty.Id, "ColumnHeaderItems");
        public static readonly PropertyId RowHeaderItemsProperty = PropertyId.Register(AutomationType.UIA2, UIA.TableItemPattern.RowHeaderItemsProperty.Id, "RowHeaderItems");

        public TableItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.TableItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
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
                var nativeElement = Get<UIA.AutomationElementCollection>(TableItemPattern.ColumnHeaderItemsProperty);
                return AutomationElementConverter.NativeArrayToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public AutomationElement[] RowHeaderItems
        {
            get
            {
                var nativeElement = Get<UIA.AutomationElementCollection>(TableItemPattern.RowHeaderItemsProperty);
                return AutomationElementConverter.NativeArrayToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }
    }

    public class TableItemPatternProperties : ITableItemPatternProperties
    {
        public PropertyId ColumnHeaderItemsProperty => TableItemPattern.ColumnHeaderItemsProperty;
        public PropertyId RowHeaderItemsProperty => TableItemPattern.RowHeaderItemsProperty;
    }
}
