using FlaUI.Core.AutomationElements;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ISpreadsheetPattern : IPattern
    {
        AutomationElement GetItemByName(string name);
    }
}
