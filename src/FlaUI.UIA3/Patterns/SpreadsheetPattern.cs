using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SpreadsheetPattern : PatternBase<UIA.IUIAutomationSpreadsheetPattern>, ISpreadsheetPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SpreadsheetPatternId, "Spreadsheet");

        public SpreadsheetPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationSpreadsheetPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public AutomationElement GetItemByName(string name)
        {
            var nativeElement = ComCallWrapper.Call(() => NativePattern.GetItemByName(name));
            return NativeValueConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation,nativeElement);
        }
    }
}
