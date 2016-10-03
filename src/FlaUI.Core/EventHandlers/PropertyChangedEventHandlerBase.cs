﻿using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using System;

namespace FlaUI.Core.EventHandlers
{
    public abstract class PropertyChangedEventHandlerBase : EventHandlerBase, IAutomationPropertyChangedEventHandler
    {
        private readonly Action<AutomationElement, PropertyId, object> _callAction;

        protected PropertyChangedEventHandlerBase(AutomationBase automation, Action<AutomationElement, PropertyId, object> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandlePropertyChangedEvent(AutomationElement sender, PropertyId propertyId, object newValue)
        {
            _callAction(sender, propertyId, newValue);
        }
    }
}
