using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Tools;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class TablePattern : PatternBaseWithInformation<UIA.TablePattern, TablePatternInformation>, ITablePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TablePattern.Pattern.Id, "Table");
        public static readonly PropertyId ColumnHeadersProperty = PropertyId.Register(AutomationType.UIA2, UIA.TablePattern.ColumnHeadersProperty.Id, "ColumnHeaders");
        public static readonly PropertyId RowHeadersProperty = PropertyId.Register(AutomationType.UIA2, UIA.TablePattern.RowHeadersProperty.Id, "RowHeaders");
        public static readonly PropertyId RowOrColumnMajorProperty = PropertyId.Register(AutomationType.UIA2, UIA.TablePattern.RowOrColumnMajorProperty.Id, "RowOrColumnMajor");

        public TablePattern(BasicAutomationElementBase basicAutomationElement, UIA.TablePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Properties = new TablePatternProperties();
        }

        ITablePatternInformation IPatternWithInformation<ITablePatternInformation>.Cached => Cached;

        ITablePatternInformation IPatternWithInformation<ITablePatternInformation>.Current => Current;

        public ITablePatternProperties Properties { get; }

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
                var nativeElement = Get<UIA.AutomationElementCollection>(TablePattern.ColumnHeadersProperty);
                return NativeValueConverter.NativeArrayToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }

        public AutomationElement[] RowHeaders
        {
            get
            {
                var nativeElement = Get<UIA.AutomationElementCollection>(TablePattern.RowHeadersProperty);
                return NativeValueConverter.NativeArrayToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeElement);
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
