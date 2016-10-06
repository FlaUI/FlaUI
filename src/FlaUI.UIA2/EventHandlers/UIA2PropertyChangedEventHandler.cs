using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using System;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.EventHandlers
{
    public class UIA2PropertyChangedEventHandler : PropertyChangedEventHandlerBase
    {
        public UIA.AutomationPropertyChangedEventHandler EventHandler { get; private set; }

        public UIA2PropertyChangedEventHandler(AutomationBase automation, Action<AutomationElement, PropertyId, object> callAction) : base(automation, callAction)
        {
            EventHandler = HandlePropertyChangedEvent;
        }

        private void HandlePropertyChangedEvent(object sender, UIA.AutomationPropertyChangedEventArgs automationPropertyChangedEventArgs)
        {
            var automationObject = new UIA2AutomationObject((UIA2Automation)Automation, (UIA.AutomationElement)sender);
            var senderElement = new AutomationElement(automationObject);
            var propertyId = PropertyId.Find(AutomationType.UIA2, automationPropertyChangedEventArgs.Property.Id);
            HandlePropertyChangedEvent(senderElement, propertyId, automationPropertyChangedEventArgs.NewValue);
        }
    }
}
