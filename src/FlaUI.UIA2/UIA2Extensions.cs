using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using System;
using System.Linq;
using LegacyUIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public static class UIA2Extensions
    {
        public static LegacyUia GetUIA2(this AutomationElement automationElement)
        {
            return new LegacyUia(automationElement);
        }

        public class LegacyUia
        {
            private readonly AutomationElement _element;
            public LegacyUia(AutomationElement element) { _element = element; }

            public void RegisterEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action)
            {
                var legacyEvent = LegacyUIA.AutomationEvent.LookupById(@event.Id);
                if (legacyEvent == null) { return; }
                LegacyUIA.Automation.AddAutomationEventHandler(legacyEvent, GetLegacyElement(), (LegacyUIA.TreeScope)treeScope,
                    (sender, e) =>
                    {
                        var legacyElement = (LegacyUIA.AutomationElement)sender;
                        var senderElement = GetNewElement(legacyElement);
                        action(senderElement, EventId.Find(e.EventId.Id));
                    }
                );
            }

            public void RegisterFocusChangedEvent(Action<AutomationElement> action)
            {
                LegacyUIA.Automation.AddAutomationFocusChangedEventHandler(
                    (sender, e) =>
                    {
                        // TODO: Any way to get the element?
                        action(null);
                    }
                );
            }

            public void RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action)
            {
                LegacyUIA.Automation.AddStructureChangedEventHandler(
                    GetLegacyElement(), (LegacyUIA.TreeScope)treeScope,
                    (sender, e) =>
                    {
                        var legacyElement = (LegacyUIA.AutomationElement)sender;
                        var senderElement = GetNewElement(legacyElement);
                        action(senderElement, (StructureChangeType)e.StructureChangeType, e.GetRuntimeId());
                    }
                );
            }

            public void RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, params PropertyId[] properties)
            {
                var propertyIds = properties.Select(p => LegacyUIA.AutomationProperty.LookupById(p.Id)).Where(p => p != null).ToArray();
                LegacyUIA.Automation.AddAutomationPropertyChangedEventHandler(
                    GetLegacyElement(), (LegacyUIA.TreeScope)treeScope,
                    (sender, e) =>
                    {
                        var legacyElement = (LegacyUIA.AutomationElement)sender;
                        var senderElement = GetNewElement(legacyElement);
                        var property = PropertyId.Find(e.Property.Id);
                        action(senderElement, property, e.NewValue);
                    }, propertyIds
                );
            }

            public void UnregisterAllEvents()
            {
                LegacyUIA.Automation.RemoveAllEventHandlers();
            }

            private LegacyUIA.AutomationElement GetLegacyElement()
            {
                return LegacyUIA.AutomationElement.FromHandle(_element.NativeElement.CurrentNativeWindowHandle);
            }

            private AutomationElement GetNewElement(LegacyUIA.AutomationElement legacyElement)
            {
                return _element.Automation.FromHandle(new IntPtr(legacyElement.Current.NativeWindowHandle));
            }
        }
    }
}
