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

        internal TableItemPattern(Element automationElement, UIA.IUIAutomationTableItemPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new TableItemPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationTableItemPattern NativePattern
        {
            get { return (UIA.IUIAutomationTableItemPattern)base.NativePattern; }
        }
    }

    public class TableItemPatternInformation : InformationBase
    {
        public TableItemPatternInformation(Element automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public Element[] ColumnHeaderItems
        {
            get { return NativeElementArrayToElements(TableItemPattern.ColumnHeaderItemsProperty); }
        }

        public Element[] RowHeaderItems
        {
            get { return NativeElementArrayToElements(TableItemPattern.RowHeaderItemsProperty); }
        }
    }
}
