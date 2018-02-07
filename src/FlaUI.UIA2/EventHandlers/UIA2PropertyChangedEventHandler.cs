using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.EventHandlers
{
    /// <summary>
    /// UIA2 implementation of a property changed event handler.
    /// </summary>
    public class UIA2PropertyChangedEventHandler : PropertyChangedEventHandlerBase
    {
        public UIA.AutomationPropertyChangedEventHandler EventHandler { get; }

        public UIA2PropertyChangedEventHandler(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, PropertyId, object> callAction) : base(frameworkElement, callAction)
        {
            EventHandler = HandlePropertyChangedEvent;
        }

        private void HandlePropertyChangedEvent(object sender, UIA.AutomationPropertyChangedEventArgs automationPropertyChangedEventArgs)
        {
            var frameworkElement = new UIA2FrameworkAutomationElement((UIA2Automation)Automation, (UIA.AutomationElement)sender);
            var senderElement = new AutomationElement(frameworkElement);
            var propertyId = PropertyId.Find(Automation.AutomationType, automationPropertyChangedEventArgs.Property.Id);
            HandlePropertyChangedEvent(senderElement, propertyId, automationPropertyChangedEventArgs.NewValue);
        }
    }
}
