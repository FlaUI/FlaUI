using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.EventHandlers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    public class UIA3FocusChangedEventHandler : FocusChangedEventHandlerBase, UIA.IUIAutomationFocusChangedEventHandler
    {
        public UIA3FocusChangedEventHandler(AutomationBase automation, Action<AutomationElement> callAction) : base(automation, callAction)
        {
        }

        public void HandleFocusChangedEvent(UIA.IUIAutomationElement sender)
        {
            var basicAutomationElement = new UIA3BasicAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(basicAutomationElement);
            HandleFocusChangedEvent(senderElement);
        }
    }
}
