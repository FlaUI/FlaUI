using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.EventHandlers
{
    public class UIA2BasicEventHandler : BasicEventHandlerBase
    {
        public UIA.AutomationEventHandler EventHandler { get; private set; }

        public UIA2BasicEventHandler(AutomationBase automation, Action<AutomationElement, EventId> callAction) : base(automation, callAction)
        {
            EventHandler = HandleAutomationEvent;
        }

        private void HandleAutomationEvent(object sender, UIA.AutomationEventArgs automationEventArgs)
        {
            var frameworkElement = new UIA2FrameworkAutomationElement((UIA2Automation)Automation, (UIA.AutomationElement)sender);
            var senderElement = new AutomationElement(frameworkElement);
            var @event = EventId.Find(AutomationType.UIA2, automationEventArgs.EventId.Id);
            HandleAutomationEvent(senderElement, @event);
        }
    }
}
