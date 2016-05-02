using FlaUI.Core.Elements;
using interop.UIAutomationCore;
using System;

namespace FlaUI.Core.EventHandlers
{
    internal class PropertyChangedEventHandler : EventHandlerBase, IUIAutomationPropertyChangedEventHandler
    {
        private readonly Action<AutomationElement, AutomationProperty, object> _callAction;

        public PropertyChangedEventHandler(Automation automation, Action<AutomationElement, AutomationProperty, object> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandlePropertyChangedEvent(IUIAutomationElement sender, int propertyId, object newValue)
        {
            var senderElement = new AutomationElement(Automation, sender);
            var property = AutomationProperty.Find(propertyId);
            _callAction(senderElement, property, newValue);
        }
    }
}
