using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SpreadsheetPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SpreadsheetPatternId, "Spreadsheet");

        internal SpreadsheetPattern(AutomationElement automationAutomationElement, UIA.IUIAutomationSpreadsheetPattern nativePattern)
            : base(automationAutomationElement, nativePattern)
        {
        }

        public new UIA.IUIAutomationSpreadsheetPattern NativePattern
        {
            get { return (UIA.IUIAutomationSpreadsheetPattern)base.NativePattern; }
        }

        public AutomationElement GetItemByName(string name)
        {
            var nativeElement = ComCallWrapper.Call(() => NativePattern.GetItemByName(name));
            return ToAutomationElement(nativeElement);
        }
    }
}
