using System;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    /// <summary>
    /// Interface for methods to subscribe to events on an <see cref="AutomationElement"/>.
    /// </summary>
    public interface IAutomationElementEventSubscriber
    {
        /// <summary>
        /// Registers a active text position changed event.
        /// </summary>
        ActiveTextPositionChangedEventHandlerBase RegisterActiveTextPositionChangedEvent(TreeScope treeScope, Action<AutomationElement, ITextRange> action);

        /// <summary>
        /// Registers the given automation event.
        /// </summary>
        AutomationEventHandlerBase RegisterAutomationEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action);

        /// <summary>
        /// Registers a property changed event with the given property.
        /// </summary>
        PropertyChangedEventHandlerBase RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, PropertyId[] properties);

        /// <summary>
        /// Registers a structure changed event.
        /// </summary>
        StructureChangedEventHandlerBase RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action);

        /// <summary>
        /// Registers a notification event.
        /// </summary>
        NotificationEventHandlerBase RegisterNotificationEvent(TreeScope treeScope,Action<AutomationElement, NotificationKind, NotificationProcessing, string, string> action);

        /// <summary>
        /// Registers a text edit text changed event.
        /// </summary>
        TextEditTextChangedEventHandlerBase RegisterTextEditTextChangedEventHandler(TreeScope treeScope,TextEditChangeType textEditChangeType, Action<AutomationElement, TextEditChangeType, string[]> action);
    }
}
