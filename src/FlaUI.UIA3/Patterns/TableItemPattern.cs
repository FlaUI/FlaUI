using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TableItemPattern : PatternBaseWithInformation<UIA.IUIAutomationTableItemPattern, TableItemPatternInformation>, ITableItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TableItemPatternId, "TableItem");
        public static readonly PropertyId ColumnHeaderItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableItemColumnHeaderItemsPropertyId, "ColumnHeaderItems");
        public static readonly PropertyId RowHeaderItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableItemRowHeaderItemsPropertyId, "RowHeaderItems");

        public TableItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTableItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        ITableItemPatternInformation IPatternWithInformation<ITableItemPatternInformation>.Cached => Cached;

        ITableItemPatternInformation IPatternWithInformation<ITableItemPatternInformation>.Current => Current;

        public ITableItemPatternProperties Properties => Automation.PropertyLibrary.TableItem;

        protected override TableItemPatternInformation CreateInformation(bool cached)
        {
            return new TableItemPatternInformation(BasicAutomationElement, cached);
        }
    }

    public class TableItemPatternInformation : InformationBase, ITableItemPatternInformation
    {
        public TableItemPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public AutomationElement[] ColumnHeaderItems
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(TableItemPattern.ColumnHeaderItemsProperty);
                return ValueConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public AutomationElement[] RowHeaderItems
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(TableItemPattern.RowHeaderItemsProperty);
                return ValueConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }
    }

    public class TableItemPatternProperties : ITableItemPatternProperties
    {
        public PropertyId ColumnHeaderItemsProperty => TableItemPattern.ColumnHeaderItemsProperty;
        public PropertyId RowHeaderItemsProperty => TableItemPattern.RowHeaderItemsProperty;
    }
}
