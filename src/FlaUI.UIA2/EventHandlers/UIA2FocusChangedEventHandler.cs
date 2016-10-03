using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.EventHandlers;
using System;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.EventHandlers
{
    public class UIA2FocusChangedEventHandler : FocusChangedEventHandlerBase
    {
        public UIA.AutomationFocusChangedEventHandler EventHandler { get; private set; }

        public UIA2FocusChangedEventHandler(AutomationBase automation, Action<AutomationElement> callAction) : base(automation, callAction)
        {
            EventHandler = HandleFocusChangedEvent;
        }

        private void HandleFocusChangedEvent(object sender, UIA.AutomationFocusChangedEventArgs automationFocusChangedEventArgs)
        {
            var automationObject = new UIA2AutomationObject((UIA2Automation)Automation, (UIA.AutomationElement)sender);
            var senderElement = new AutomationElement(automationObject);
            HandleFocusChangedEvent(senderElement);
        }
    }
}
