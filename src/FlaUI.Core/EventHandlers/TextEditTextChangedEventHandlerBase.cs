using System;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.EventHandlers
{
    public abstract class TextEditTextChangedEventHandlerBase : EventHandlerBase, ITextEditTextChangedEventHandler
    {
        public TextEditTextChangedEventHandlerBase(AutomationBase automation) : base(automation)
        {
        }

        public void HandleTextEditTextChangedEvent(AutomationElement sender, TextEditChangeType textEditChangeType, string[] eventStrings)
        {
            throw new NotImplementedException();
        }
    }
}
