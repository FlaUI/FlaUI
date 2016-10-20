using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.EventHandlers;
using System;
using System.Linq;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3BasicAutomationElement : BasicAutomationElementBase
    {
        public UIA3BasicAutomationElement(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation)
        {
            Automation = automation;
            NativeElement = nativeElement;
        }

        /// <summary>
        /// Concrete implementation of the automation object
        /// </summary>
        public new UIA3Automation Automation { get; }

        /// <summary>
        /// Native object for the ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement { get; }

        /// <summary>
        /// Native object for Windows 8 ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement2 => GetAutomationElementAs<UIA.IUIAutomationElement2>();

        /// <summary>
        /// Native object for Windows 8.1 ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement3 => GetAutomationElementAs<UIA.IUIAutomationElement3>();

        public override void SetFocus()
        {
            NativeElement.SetFocus();
        }

        public override IAutomationElementInformation CreateInformation(bool cached)
        {
            return new UIA3AutomationElementInformation(this, cached);
        }

        public override IPatternFactory CreatePatternFactory()
        {
            return new UIA3PatternFactory(this);
        }

        protected override object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported)
        {
            var ignoreDefaultValue = useDefaultIfNotSupported ? 0 : 1;
            var returnValue = cached ?
                NativeElement.GetCachedPropertyValueEx(propertyId, ignoreDefaultValue) :
                NativeElement.GetCurrentPropertyValueEx(propertyId, ignoreDefaultValue);
            return returnValue;
        }

        public override AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElements = NativeElement.FindAll((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition));
            return ValueConverter.NativeArrayToManaged(Automation, nativeFoundElements);
        }

        public override AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElement = NativeElement.FindFirst((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition));
            return ValueConverter.NativeToManaged(Automation, nativeFoundElement);
        }

        public override bool TryGetClickablePoint(out Point point)
        {
            var tagPoint = new UIA.tagPOINT { x = 0, y = 0 };
            var success = ComCallWrapper.Call(() => NativeElement.GetClickablePoint(out tagPoint)) != 0;
            point = success ? new Point(tagPoint.x, tagPoint.y) : null;
            return success;
        }

        public override IAutomationElementProperties CreateProperties()
        {
            return new UIA3AutomationElementProperties();
        }

        public override IAutomationElementEvents CreateEvents()
        {
            return new UIA3AutomationElementEvents();
        }

        public override IAutomationEventHandler RegisterEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action)
        {
            var eventHandler = new UIA3BasicEventHandler(Automation, action);
            Automation.NativeAutomation.AddAutomationEventHandler(@event.Id, NativeElement, (UIA.TreeScope)treeScope, null, eventHandler);
            return eventHandler;
        }

        public override IAutomationPropertyChangedEventHandler RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, PropertyId[] properties)
        {
            var eventHandler = new UIA3PropertyChangedEventHandler(Automation, action);
            var propertyIds = properties.Select(p => p.Id).ToArray();
            Automation.NativeAutomation.AddPropertyChangedEventHandler(NativeElement,
                (UIA.TreeScope)treeScope, null, eventHandler, propertyIds);
            return eventHandler;
        }

        public override IAutomationStructureChangedEventHandler RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action)
        {
            var eventHandler = new UIA3StructureChangedEventHandler(Automation, action);
            Automation.NativeAutomation.AddStructureChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, null, eventHandler);
            return eventHandler;
        }

        public override void RemoveAutomationEventHandler(EventId @event, IAutomationEventHandler eventHandler)
        {
            Automation.NativeAutomation.RemoveAutomationEventHandler(@event.Id, NativeElement, (UIA3BasicEventHandler)eventHandler);
        }

        public override void RemovePropertyChangedEventHandler(IAutomationPropertyChangedEventHandler eventHandler)
        {
            Automation.NativeAutomation.RemovePropertyChangedEventHandler(NativeElement, (UIA3PropertyChangedEventHandler)eventHandler);
        }

        public override void RemoveStructureChangedEventHandler(IAutomationStructureChangedEventHandler eventHandler)
        {
            Automation.NativeAutomation.RemoveStructureChangedEventHandler(NativeElement, (UIA3StructureChangedEventHandler)eventHandler);
        }

        /// <summary>
        /// Tries to cast the automation element to a specific interface.
        /// Throws an exception if that is not possible.
        /// </summary>
        private T GetAutomationElementAs<T>() where T : class, UIA.IUIAutomationElement
        {
            var element = NativeElement as T;
            if (element == null)
            {
                throw new NotSupportedException(String.Format("OS does not have {0} support.", typeof(T).Name));
            }
            return element;
        }
    }
}
