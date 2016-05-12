using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class TableItemPattern : PatternBaseWithInformation<TableItemPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_TableItemPatternId, "TableItem");
        public static readonly PropertyId ColumnHeaderItemsProperty = PropertyId.Register(UIA_PropertyIds.UIA_TableItemColumnHeaderItemsPropertyId, "ColumnHeaderItems");
        public static readonly PropertyId RowHeaderItemsProperty = PropertyId.Register(UIA_PropertyIds.UIA_TableItemRowHeaderItemsPropertyId, "RowHeaderItems");

        internal TableItemPattern(AutomationElement automationElement, IUIAutomationTableItemPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new TableItemPatternInformation(element, cached))
        {
        }

        public IUIAutomationTableItemPattern NativePattern
        {
            get { return (IUIAutomationTableItemPattern)base.NativePattern; }
        }
    }

    public class TableItemPatternInformation : InformationBase
    {
        public TableItemPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public AutomationElement[] ColumnHeaderItems
        {
            get { return NativeElementArrayToElements(TableItemPattern.ColumnHeaderItemsProperty); }
        }

        public AutomationElement[] RowHeaderItems
        {
            get { return NativeElementArrayToElements(TableItemPattern.RowHeaderItemsProperty); }
        }
    }
}
