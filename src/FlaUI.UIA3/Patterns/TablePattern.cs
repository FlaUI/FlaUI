using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TablePattern : PatternBaseWithInformation<UIA.IUIAutomationTablePattern, TablePatternInformation>, ITablePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TablePatternId, "Table");
        public static readonly PropertyId ColumnHeadersProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableColumnHeadersPropertyId, "ColumnHeaders");
        public static readonly PropertyId RowHeadersProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableRowHeadersPropertyId, "RowHeaders");
        public static readonly PropertyId RowOrColumnMajorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableRowOrColumnMajorPropertyId, "RowOrColumnMajor");

        public TablePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTablePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        ITablePatternInformation IPatternWithInformation<ITablePatternInformation>.Cached => Cached;

        ITablePatternInformation IPatternWithInformation<ITablePatternInformation>.Current => Current;

        public ITablePatternProperties Properties => Automation.PropertyLibrary.Table;

        protected override TablePatternInformation CreateInformation(bool cached)
        {
            return new TablePatternInformation(BasicAutomationElement, cached);
        }
    }

    public class TablePatternInformation : InformationBase,ITablePatternInformation
    {
        public TablePatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public AutomationElement[] ColumnHeaders
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(TablePattern.ColumnHeadersProperty);
                return AutomationElementConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public AutomationElement[] RowHeaders
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(TablePattern.RowHeadersProperty);
                return AutomationElementConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public RowOrColumnMajor RowOrColumnMajor => Get<RowOrColumnMajor>(TablePattern.RowOrColumnMajorProperty);
    }

    public class TablePatternProperties : ITablePatternProperties
    {
        public PropertyId ColumnHeadersProperty => TablePattern.ColumnHeadersProperty;
        public PropertyId RowHeadersProperty => TablePattern.RowHeadersProperty;
        public PropertyId RowOrColumnMajorProperty => TablePattern.RowOrColumnMajorProperty;
    }
}
