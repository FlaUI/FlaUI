using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.EventHandlers
{
    public interface ITextEditTextChangedEventHandler
    {
        void HandleTextEditTextChangedEvent(AutomationElement sender, TextEditChangeType textEditChangeType, string[] eventStrings);
    }
}
