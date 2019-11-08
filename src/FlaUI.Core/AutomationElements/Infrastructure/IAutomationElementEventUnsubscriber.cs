using FlaUI.Core.EventHandlers;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    /// <summary>
    /// Interface for methods to unsubscribe to events on an <see cref="AutomationElement"/>.
    /// </summary>
    public interface IAutomationElementEventUnsubscriber
    {
        /// <summary>
        /// Unregisters the given active text position changed event handler.
        /// </summary>
        void UnregisterActiveTextPositionChangedEventHandler(ActiveTextPositionChangedEventHandlerBase eventHandler);

        /// <summary>
        /// Unregisters the given automation event handler.
        /// </summary>
        void UnregisterAutomationEventHandler(AutomationEventHandlerBase eventHandler);

        /// <summary>
        /// Unregisters the given property changed event handler.
        /// </summary>
        void UnregisterPropertyChangedEventHandler(PropertyChangedEventHandlerBase eventHandler);

        /// <summary>
        /// Unregisters the given structure changed event handler.
        /// </summary>
        void UnregisterStructureChangedEventHandler(StructureChangedEventHandlerBase eventHandler);

        /// <summary>
        /// Unregisters the given notification event handler.
        /// </summary>
        void UnregisterNotificationEventHandler(NotificationEventHandlerBase eventHandler);

        /// <summary>
        /// Unregisters the given text edit text changed event handler.
        /// </summary> 
        void UnregisterTextEditTextChangedEventHandler(TextEditTextChangedEventHandlerBase eventHandler);
    }
}
