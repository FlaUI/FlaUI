using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.EventHandlers;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    public class UIA3FocusChangedEventHandler : FocusChangedEventHandlerBase, UIA.IUIAutomationFocusChangedEventHandler
    {
        public UIA3FocusChangedEventHandler(AutomationBase automation, Action<Element> callAction) : base(automation, callAction)
        {
        }

        public void HandleFocusChangedEvent(UIA.IUIAutomationElement sender)
        {
            var automationObject = new UIA3AutomationObject((UIA3Automation)Automation, sender);
            var senderElement = new Element(automationObject);
            HandleFocusChangedEvent(senderElement);
        }
    }
}
