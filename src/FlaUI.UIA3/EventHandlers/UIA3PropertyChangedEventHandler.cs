using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.EventHandlers
{
    /// <summary>
    /// UIA3 implementation of a property changed event handler.
    /// </summary>
    public class UIA3PropertyChangedEventHandler : PropertyChangedEventHandlerBase, UIA.IUIAutomationPropertyChangedEventHandler
    {
        public UIA3PropertyChangedEventHandler(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, PropertyId, object> callAction) : base(frameworkElement, callAction)
        {
        }

        public void HandlePropertyChangedEvent(UIA.IUIAutomationElement sender, int propertyId, object newValue)
        {
            var frameworkElement = new UIA3FrameworkAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(frameworkElement);
            var property = PropertyId.Find(Automation.AutomationType, propertyId);
            HandlePropertyChangedEvent(senderElement, property, newValue);
        }
    }
}
