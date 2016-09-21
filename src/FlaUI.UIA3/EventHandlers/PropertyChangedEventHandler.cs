using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    internal class PropertyChangedEventHandler : EventHandlerBase, UIA.IUIAutomationPropertyChangedEventHandler
    {
        private readonly Action<AutomationElement, PropertyId, object> _callAction;

        public PropertyChangedEventHandler(Automation automation, Action<AutomationElement, PropertyId, object> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandlePropertyChangedEvent(UIA.IUIAutomationElement sender, int propertyId, object newValue)
        {
            var senderElement = new AutomationElement(Automation, sender);
            var property = PropertyId.Find(propertyId);
            _callAction(senderElement, property, newValue);
        }
    }
}
