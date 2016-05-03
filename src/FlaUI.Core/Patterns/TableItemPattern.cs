using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class TableItemPattern : PatternBaseWithInformation<IUIAutomationTableItemPattern, TableItemPatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_TableItemPatternId, "TableItem");
        public static readonly AutomationProperty ColumnHeaderItemsProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_TableItemColumnHeaderItemsPropertyId, "ColumnHeaderItems");
        public static readonly AutomationProperty RowHeaderItemsProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_TableItemRowHeaderItemsPropertyId, "RowHeaderItems");

        internal TableItemPattern(AutomationElement automationElement, IUIAutomationTableItemPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new TableItemPatternInformation(element, cached))
        {
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
