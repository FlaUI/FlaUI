using FlaUI.Core.Elements;
using interop.UIAutomationCore;
using System;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.EventHandlers
{
    internal class PropertyChangedEventHandler : EventHandlerBase, IUIAutomationPropertyChangedEventHandler
    {
        private readonly Action<AutomationElement, PropertyId, object> _callAction;

        public PropertyChangedEventHandler(Automation automation, Action<AutomationElement, PropertyId, object> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandlePropertyChangedEvent(IUIAutomationElement sender, int propertyId, object newValue)
        {
            var senderElement = new AutomationElement(Automation, sender);
            var property = PropertyId.Find(propertyId);
            _callAction(senderElement, property, newValue);
        }
    }
}
