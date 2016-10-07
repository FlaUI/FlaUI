using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    public class UIA3BasicEventHandler : BasicEventHandlerBase, UIA.IUIAutomationEventHandler
    {
        public UIA3BasicEventHandler(AutomationBase automation, Action<AutomationElement, EventId> callAction) : base(automation, callAction)
        {
        }

        public void HandleAutomationEvent(UIA.IUIAutomationElement sender, int eventId)
        {
            var basicAutomationElement = new UIA3BasicAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(basicAutomationElement);
            var @event = EventId.Find(AutomationType.UIA3, eventId);
            HandleAutomationEvent(senderElement, @event);
        }
    }
}
