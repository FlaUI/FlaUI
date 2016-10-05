using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using System;
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
            var automationObject = new UIA3AutomationObject((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(automationObject);
            var @event = EventId.Find(AutomationType.UIA3, eventId);
            HandleAutomationEvent(senderElement, @event);
        }
    }
}
