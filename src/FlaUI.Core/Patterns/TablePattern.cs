using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class TablePattern : PatternBaseWithInformation<IUIAutomationTablePattern, TablePatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_TablePatternId, "Table");
        public static readonly AutomationProperty ColumnHeadersProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_TableColumnHeadersPropertyId, "ColumnHeaders");
        public static readonly AutomationProperty RowHeadersProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_TableRowHeadersPropertyId, "RowHeaders");
        public static readonly AutomationProperty RowOrColumnMajorProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_TableRowOrColumnMajorPropertyId, "RowOrColumnMajor");

        internal TablePattern(AutomationElement automationElement, IUIAutomationTablePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new TablePatternInformation(element, cached))
        {
        }
    }

    public class TablePatternInformation : InformationBase
    {
        public TablePatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public AutomationElement[] ColumnHeaders
        {
            get { return NativeElementArrayToElements(TablePattern.ColumnHeadersProperty); }
        }

        public AutomationElement[] RowHeaders
        {
            get { return NativeElementArrayToElements(TablePattern.RowHeadersProperty); }
        }

        public RowOrColumnMajor RowOrColumnMajor
        {
            get { return Get<RowOrColumnMajor>(TablePattern.RowOrColumnMajorProperty); }
        }
    }
}
