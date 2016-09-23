using FlaUI.Core.Conditions;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Conditions;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.EventHandlers;
using FlaUI.UIA3.Tools;
using System;
using System.Linq;
using FlaUI.Core.Definitions;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Elements
{
    /// <summary>
    /// Basic class for a wrapped ui element
    /// </summary>
    public class Element
    {
        public  UIA3Automation Automation { get; private set; }
        public  UIA.IUIAutomationElement NativeElement { get; private set; }

        public Element(UIA3Automation automation, UIA.IUIAutomationElement sender)
        {
            Automation = automation;
            NativeElement = sender;
        }

        /// <summary>
        /// Register for a specific event
        /// </summary>
        /// <param name="event">The event to register to</param>
        /// <param name="treeScope">The treescope in which the event should be registered</param>
        /// <param name="action">The action to execute when the event fires</param>
        public void RegisterEvent(EventId @event, TreeScope treeScope, Action<Element, EventId> action)
        {
            Automation.NativeAutomation.AddAutomationEventHandler(@event.Id, NativeElement, (UIA.TreeScope)treeScope, null, new BasicEventHandler(Automation, action));
        }

        /// <summary>
        /// Registers for a focus changed event
        /// </summary>
        /// <param name="action">The action to execute when the event fires</param>
        public void RegisterFocusChangedEvent(Action<Element> action)
        {
            Automation.NativeAutomation.AddFocusChangedEventHandler(null, new FocusChangedEventHandler(Automation, action));
        }

        /// <summary>
        /// Registers for a structure changed event
        /// </summary>
        /// <param name="treeScope">The treescope in which the event should be registered</param>
        /// <param name="action">The action to execute when the event fires</param>
        public void RegisterStructureChangedEvent(TreeScope treeScope, Action<Element, StructureChangeType, int[]> action)
        {
            Automation.NativeAutomation.AddStructureChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, null, new StructureChangedEventHandler(Automation, action));
        }

        /// <summary>
        /// Registers for a property changed event
        /// </summary>
        /// <param name="treeScope">The treescope in which the event should be registered</param>
        /// <param name="action">The action to execute when the event fires</param>
        /// <param name="properties">The properties to listen to for a change</param>
        public void RegisterPropertyChangedEvent(TreeScope treeScope, Action<Element, PropertyId, object> action, params PropertyId[] properties)
        {
            var propertyIds = properties.Select(p => p.Id).ToArray();
            Automation.NativeAutomation.AddPropertyChangedEventHandler(NativeElement,
                (UIA.TreeScope)treeScope, null, new PropertyChangedEventHandler(Automation, action), propertyIds);
        }
    }
}
