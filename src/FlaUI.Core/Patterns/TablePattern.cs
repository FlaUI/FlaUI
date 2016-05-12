using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class TablePattern : PatternBaseWithInformation<TablePatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_TablePatternId, "Table");
        public static readonly PropertyId ColumnHeadersProperty = PropertyId.Register(UIA_PropertyIds.UIA_TableColumnHeadersPropertyId, "ColumnHeaders");
        public static readonly PropertyId RowHeadersProperty = PropertyId.Register(UIA_PropertyIds.UIA_TableRowHeadersPropertyId, "RowHeaders");
        public static readonly PropertyId RowOrColumnMajorProperty = PropertyId.Register(UIA_PropertyIds.UIA_TableRowOrColumnMajorPropertyId, "RowOrColumnMajor");

        internal TablePattern(AutomationElement automationElement, IUIAutomationTablePattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new TablePatternInformation(element, cached))
        {
        }

        public IUIAutomationTablePattern NativePattern
        {
            get { return (IUIAutomationTablePattern)base.NativePattern; }
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
