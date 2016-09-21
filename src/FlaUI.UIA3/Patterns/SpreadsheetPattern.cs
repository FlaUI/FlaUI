using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SpreadsheetPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_SpreadsheetPatternId, "Spreadsheet");

        internal SpreadsheetPattern(Element automationElement, UIA.IUIAutomationSpreadsheetPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public new UIA.IUIAutomationSpreadsheetPattern NativePattern
        {
            get { return (UIA.IUIAutomationSpreadsheetPattern)base.NativePattern; }
        }

        public Element GetItemByName(string name)
        {
            var nativeElement = ComCallWrapper.Call(() => NativePattern.GetItemByName(name));
            return ToAutomationElement(nativeElement);
        }
    }
}
