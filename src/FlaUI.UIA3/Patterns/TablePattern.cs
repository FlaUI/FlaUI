using FlaUI.Core;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TablePattern : PatternBaseWithInformation<TablePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TablePatternId, "Table");
        public static readonly PropertyId ColumnHeadersProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableColumnHeadersPropertyId, "ColumnHeaders");
        public static readonly PropertyId RowHeadersProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableRowHeadersPropertyId, "RowHeaders");
        public static readonly PropertyId RowOrColumnMajorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableRowOrColumnMajorPropertyId, "RowOrColumnMajor");

        internal TablePattern(Element automationElement, UIA.IUIAutomationTablePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new TablePatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationTablePattern NativePattern
        {
            get { return (UIA.IUIAutomationTablePattern)base.NativePattern; }
        }
    }

    public class TablePatternInformation : InformationBase
    {
        public TablePatternInformation(Element automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public Element[] ColumnHeaders
        {
            get { return NativeElementArrayToElements(TablePattern.ColumnHeadersProperty); }
        }

        public Element[] RowHeaders
        {
            get { return NativeElementArrayToElements(TablePattern.RowHeadersProperty); }
        }

        public RowOrColumnMajor RowOrColumnMajor
        {
            get { return Get<RowOrColumnMajor>(TablePattern.RowOrColumnMajorProperty); }
        }
    }
}
