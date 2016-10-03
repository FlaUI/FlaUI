using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Elements;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    internal class PropertyChangedEventHandler : EventHandlerBase, UIA.IUIAutomationPropertyChangedEventHandler
    {
        private readonly Action<AutomationElement, PropertyId, object> _callAction;

        public PropertyChangedEventHandler(UIA3Automation automation, Action<AutomationElement, PropertyId, object> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandlePropertyChangedEvent(UIA.IUIAutomationElement sender, int propertyId, object newValue)
        {
            var senderElement = new AutomationElement(Automation, sender);
            var property = PropertyId.Find(AutomationType.UIA3, propertyId);
            _callAction(senderElement, property, newValue);
        }
    }
}
