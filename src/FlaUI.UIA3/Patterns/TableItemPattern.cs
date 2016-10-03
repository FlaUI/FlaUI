using FlaUI.Core;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TableItemPattern : PatternBaseWithInformation<TableItemPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TableItemPatternId, "TableItem");
        public static readonly PropertyId ColumnHeaderItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableItemColumnHeaderItemsPropertyId, "ColumnHeaderItems");
        public static readonly PropertyId RowHeaderItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableItemRowHeaderItemsPropertyId, "RowHeaderItems");

        internal TableItemPattern(AutomationElement automationAutomationElement, UIA.IUIAutomationTableItemPattern nativePattern)
            : base(automationAutomationElement, nativePattern, (element, cached) => new TableItemPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationTableItemPattern NativePattern
        {
            get { return (UIA.IUIAutomationTableItemPattern)base.NativePattern; }
        }
    }

    public class TableItemPatternInformation : InformationBase
    {
        public TableItemPatternInformation(AutomationElement automationAutomationElement, bool cached)
            : base(automationAutomationElement, cached)
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
