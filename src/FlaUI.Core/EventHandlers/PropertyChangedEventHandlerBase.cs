using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using System;

namespace FlaUI.Core.EventHandlers
{
    public abstract class PropertyChangedEventHandlerBase : EventHandlerBase, IAutomationPropertyChangedEventHandler
    {
        private readonly Action<Element, PropertyId, object> _callAction;

        protected PropertyChangedEventHandlerBase(AutomationBase automation, Action<Element, PropertyId, object> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandlePropertyChangedEvent(Element sender, PropertyId propertyId, object newValue)
        {
            _callAction(sender, propertyId, newValue);
        }
    }
}
