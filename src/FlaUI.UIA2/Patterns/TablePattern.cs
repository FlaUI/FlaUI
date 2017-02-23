using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Converters;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class TablePattern : PatternBase<UIA.TablePattern>, ITablePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TablePattern.Pattern.Id, "Table", AutomationObjectIds.IsTablePatternAvailableProperty);
        public static readonly PropertyId ColumnHeadersProperty = PropertyId.Register(AutomationType.UIA2, UIA.TablePattern.ColumnHeadersProperty.Id, "ColumnHeaders");
        public static readonly PropertyId RowHeadersProperty = PropertyId.Register(AutomationType.UIA2, UIA.TablePattern.RowHeadersProperty.Id, "RowHeaders");
        public static readonly PropertyId RowOrColumnMajorProperty = PropertyId.Register(AutomationType.UIA2, UIA.TablePattern.RowOrColumnMajorProperty.Id, "RowOrColumnMajor");

        public TablePattern(BasicAutomationElementBase basicAutomationElement, UIA.TablePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }
        
        public ITablePatternProperties Properties => Automation.PropertyLibrary.Table;

        public AutomationElement[] ColumnHeaders
        {
            get
            {
                var nativeElements = Get<UIA.AutomationElement[]>(ColumnHeadersProperty);
                return AutomationElementConverter.NativeArrayToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeElements);
            }
        }

        public AutomationElement[] RowHeaders
        {
            get
            {
                var nativeElements = Get<UIA.AutomationElement[]>(RowHeadersProperty);
                return AutomationElementConverter.NativeArrayToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeElements);
            }
        }

        public RowOrColumnMajor RowOrColumnMajor => Get<RowOrColumnMajor>(RowOrColumnMajorProperty);
    }

    public class TablePatternProperties : ITablePatternProperties
    {
        public PropertyId ColumnHeadersProperty => TablePattern.ColumnHeadersProperty;
        public PropertyId RowHeadersProperty => TablePattern.RowHeadersProperty;
        public PropertyId RowOrColumnMajorProperty => TablePattern.RowOrColumnMajorProperty;
    }
}
