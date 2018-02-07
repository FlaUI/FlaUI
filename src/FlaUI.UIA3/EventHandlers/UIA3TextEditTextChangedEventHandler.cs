using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.EventHandlers
{
    /// <summary>
    /// UIA3 implementation of a text edit text changed event handler.
    /// </summary>
    public class UIA3TextEditTextChangedEventHandler : TextEditTextChangedEventHandlerBase, UIA.IUIAutomationTextEditTextChangedEventHandler
    {
        public UIA3TextEditTextChangedEventHandler(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, TextEditChangeType, string[]> callAction) : base(frameworkElement, callAction)
        {
        }

        public void HandleTextEditTextChangedEvent(UIA.IUIAutomationElement sender, UIA.TextEditChangeType textEditChangeType, string[] eventStrings)
        {
            var frameworkElement = new UIA3FrameworkAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(frameworkElement);
            HandleTextEditTextChangedEvent(senderElement, (TextEditChangeType)textEditChangeType, eventStrings);
        }
    }
}
