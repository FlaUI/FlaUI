using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Patterns
{
    public class SpreadsheetPattern : PatternBase<UIA.IUIAutomationSpreadsheetPattern>, ISpreadsheetPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SpreadsheetPatternId, "Spreadsheet", AutomationObjectIds.IsSpreadsheetPatternAvailableProperty);

        public SpreadsheetPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationSpreadsheetPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public AutomationElement GetItemByName(string name)
        {
            var nativeElement = Com.Call(() => NativePattern.GetItemByName(name));
            return AutomationElementConverter.NativeToManaged((UIA3Automation)FrameworkAutomationElement.Automation, nativeElement);
        }
    }
}
