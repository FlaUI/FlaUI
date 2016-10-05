﻿using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.UIA2.EventHandlers;
using FlaUI.UIA2.Tools;
using System;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public class UIA2AutomationObject : AutomationObjectBase
    {
        public UIA2AutomationObject(UIA2Automation automation, UIA.AutomationElement nativeElement) : base(automation)
        {
            Automation = automation;
            NativeElement = nativeElement;
        }

        /// <summary>
        /// Concrete implementation of the automation object
        /// </summary>
        public new UIA2Automation Automation { get; }

        /// <summary>
        /// Native object for the ui element
        /// </summary>
        public UIA.AutomationElement NativeElement { get; }

        public override void SetFocus()
        {
            NativeElement.SetFocus();
        }

        public override IElementInformation CreateInformation(bool cached)
        {
            return new UIA2ElementInformation(this, cached);
        }

        public override IPatternFactory CreatePatternFactory()
        {
            return new UIA2PatternFactory(this);
        }

        protected override object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported)
        {
            var ignoreDefaultValue = !useDefaultIfNotSupported;
            var property = UIA.AutomationProperty.LookupById(propertyId);
            var returnValue = cached ?
                NativeElement.GetCachedPropertyValue(property, ignoreDefaultValue) :
                NativeElement.GetCurrentPropertyValue(property, ignoreDefaultValue);
            return returnValue;
        }

        public override AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElements = NativeElement.FindAll((UIA.TreeScope)treeScope, NativeConditionConverter.ToNative(condition));
            return NativeValueConverter.NativeArrayToManaged(Automation, nativeFoundElements);
        }

        public override AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElement = NativeElement.FindFirst((UIA.TreeScope)treeScope, NativeConditionConverter.ToNative(condition));
            return NativeValueConverter.NativeToManaged(Automation, nativeFoundElement);
        }

        public override bool TryGetClickablePoint(out Point point)
        {
            System.Windows.Point outPoint;
            var success = NativeElement.TryGetClickablePoint(out outPoint);
            point = success ? new Point(outPoint.X, outPoint.Y) : null;
            return success;
        }

        public override IElementProperties CreateProperties()
        {
            return new UIA2ElementProperties();
        }

        public override IAutomationEventHandler RegisterEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action)
        {
            var eventHandler = new UIA2BasicEventHandler(Automation, action);
            UIA.Automation.AddAutomationEventHandler(UIA.AutomationEvent.LookupById(@event.Id), NativeElement, (UIA.TreeScope)treeScope, eventHandler.EventHandler);
            return eventHandler;
        }

        public override IAutomationPropertyChangedEventHandler RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, PropertyId[] properties)
        {
            var eventHandler = new UIA2PropertyChangedEventHandler(Automation, action);
            UIA.Automation.AddAutomationPropertyChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, eventHandler.EventHandler);
            return eventHandler;
        }

        public override IAutomationStructureChangedEventHandler RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action)
        {
            var eventHandler = new UIA2StructureChangedEventHandler(Automation, action);
            UIA.Automation.AddStructureChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, eventHandler.EventHandler);
            return eventHandler;
        }

        public override void RemoveAutomationEventHandler(EventId @event, IAutomationEventHandler eventHandler)
        {
            UIA.Automation.RemoveAutomationEventHandler(UIA.AutomationEvent.LookupById(@event.Id), NativeElement, ((UIA2BasicEventHandler)eventHandler).EventHandler);
        }

        public override void RemovePropertyChangedEventHandler(IAutomationPropertyChangedEventHandler eventHandler)
        {
            UIA.Automation.RemoveAutomationPropertyChangedEventHandler(NativeElement, ((UIA2PropertyChangedEventHandler)eventHandler).EventHandler);
        }

        public override void RemoveStructureChangedEventHandler(IAutomationStructureChangedEventHandler eventHandler)
        {
            UIA.Automation.RemoveStructureChangedEventHandler(NativeElement, ((UIA2StructureChangedEventHandler)eventHandler).EventHandler);
        }
    }
}
