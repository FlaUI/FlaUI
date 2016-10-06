using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    public class UIA3PropertyChangedEventHandler : PropertyChangedEventHandlerBase, UIA.IUIAutomationPropertyChangedEventHandler
    {
        public UIA3PropertyChangedEventHandler(AutomationBase automation, Action<AutomationElement, PropertyId, object> callAction) : base(automation, callAction)
        {
        }

        public void HandlePropertyChangedEvent(UIA.IUIAutomationElement sender, int propertyId, object newValue)
        {
            var automationObject = new UIA3AutomationObject((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(automationObject);
            var property = PropertyId.Find(AutomationType.UIA3, propertyId);
            HandlePropertyChangedEvent(senderElement, property, newValue);
        }
    }
}
