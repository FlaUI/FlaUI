using FlaUI.Core;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using System;
using FlaUI.Core.AutomationElements.Infrastructure;
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
            var basicAutomationElement = new UIA3BasicAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(basicAutomationElement);
            var property = PropertyId.Find(AutomationType.UIA3, propertyId);
            HandlePropertyChangedEvent(senderElement, property, newValue);
        }
    }
}
