using System;
using System.Drawing;
using System.Linq;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using FlaUI.UIA2.Converters;
using FlaUI.UIA2.EventHandlers;
using FlaUI.UIA2.Extensions;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public partial class UIA2FrameworkAutomationElement : FrameworkAutomationElementBase
    {
        public UIA2FrameworkAutomationElement(UIA2Automation automation, UIA.AutomationElement nativeElement) : base(automation)
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

        /// <inheritdoc />
        public override void SetFocus()
        {
            NativeElement.SetFocus();
        }

        /// <inheritdoc />
        protected override object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported)
        {
            var property = UIA.AutomationProperty.LookupById(propertyId);
            var ignoreDefaultValue = !useDefaultIfNotSupported;
            var returnValue = cached ?
                NativeElement.GetCachedPropertyValue(property, ignoreDefaultValue) :
                NativeElement.GetCurrentPropertyValue(property, ignoreDefaultValue);
            return returnValue;
        }

        /// <inheritdoc />
        protected override object InternalGetPattern(int patternId, bool cached)
        {
            var pattern = UIA.AutomationPattern.LookupById(patternId);
            var returnedValue = cached
                ? NativeElement.GetCachedPattern(pattern)
                : NativeElement.GetCurrentPattern(pattern);
            return returnedValue;
        }

        /// <inheritdoc />
        public override AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition)
        {
            var cacheRequest = CacheRequest.IsCachingActive ? CacheRequest.Current.ToNative() : null;
            cacheRequest?.Push();
            var nativeFoundElements = NativeElement.FindAll((UIA.TreeScope)treeScope, ConditionConverter.ToNative(condition));
            cacheRequest?.Pop();
            return AutomationElementConverter.NativeArrayToManaged(Automation, nativeFoundElements);
        }

        /// <inheritdoc />
        public override AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition)
        {
            var cacheRequest = CacheRequest.IsCachingActive ? CacheRequest.Current.ToNative() : null;
            cacheRequest?.Push();
            var nativeFoundElement = NativeElement.FindFirst((UIA.TreeScope)treeScope, ConditionConverter.ToNative(condition));
            cacheRequest?.Pop();
            return AutomationElementConverter.NativeToManaged(Automation, nativeFoundElement);
        }

        /// <inheritdoc />
        public override AutomationElement[] FindAllWithOptions(TreeScope treeScope, ConditionBase condition,
            TreeTraversalOptions traversalOptions, AutomationElement root)
        {
            throw new NotSupportedByFrameworkException();
        }

        /// <inheritdoc />
        public override AutomationElement FindFirstWithOptions(TreeScope treeScope, ConditionBase condition,
            TreeTraversalOptions traversalOptions, AutomationElement root)
        {
            throw new NotSupportedByFrameworkException();
        }

        /// <inheritdoc />
        public override AutomationElement FindAt(TreeScope treeScope, int index, ConditionBase condition)
        {
            var cacheRequest = CacheRequest.IsCachingActive ? CacheRequest.Current.ToNative() : null;
            cacheRequest?.Push();
            var nativeFoundElements = NativeElement.FindAll((UIA.TreeScope)treeScope, ConditionConverter.ToNative(condition));
            cacheRequest?.Pop();
            var nativeElement = nativeFoundElements.Count > index ? nativeFoundElements[index] : null;
            return nativeElement == null ? null : AutomationElementConverter.NativeToManaged(Automation, nativeElement);
        }

        /// <inheritdoc />
        public override bool TryGetClickablePoint(out Point point)
        {
            try
            {
                // Variant 1: Directly try getting the point
                if (NativeElement.TryGetClickablePoint(out System.Windows.Point outPoint))
                {
                    point = new Point(outPoint.X.ToInt(), outPoint.Y.ToInt());
                    return true;
                }
                // Variant 2: Try to get it from the property
                if (Properties.ClickablePoint.TryGetValue(out point))
                {
                    return true;
                }
                // Variant 3: Get the center of the bounding rectangle
                if (Properties.BoundingRectangle.TryGetValue(out var br))
                {
                    point = br.Center();
                    return true;
                }
            }
            catch
            {
                // Noop
            }
            point = Point.Empty;
            return false;
        }

        /// <inheritdoc />
        public override ActiveTextPositionChangedEventHandlerBase RegisterActiveTextPositionChangedEvent(TreeScope treeScope, Action<AutomationElement, ITextRange> action)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override AutomationEventHandlerBase RegisterAutomationEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action)
        {
            var eventHandler = new UIA2AutomationEventHandler(this, @event, action);
            UIA.Automation.AddAutomationEventHandler(UIA.AutomationEvent.LookupById(@event.Id), NativeElement, (UIA.TreeScope)treeScope, eventHandler.EventHandler);
            return eventHandler;
        }

        /// <inheritdoc />
        public override PropertyChangedEventHandlerBase RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, PropertyId[] properties)
        {
            var eventHandler = new UIA2PropertyChangedEventHandler(this, action);
            UIA.Automation.AddAutomationPropertyChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, eventHandler.EventHandler, properties.Select(p => UIA.AutomationProperty.LookupById(p.Id)).ToArray());
            return eventHandler;
        }

        /// <inheritdoc />
        public override StructureChangedEventHandlerBase RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action)
        {
            var eventHandler = new UIA2StructureChangedEventHandler(this, action);
            UIA.Automation.AddStructureChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, eventHandler.EventHandler);
            return eventHandler;
        }

        /// <inheritdoc />
        public override NotificationEventHandlerBase RegisterNotificationEvent(TreeScope treeScope, Action<AutomationElement, NotificationKind, NotificationProcessing, string, string> action)
        {
            throw new NotSupportedByFrameworkException();
        }

        /// <inheritdoc />
        public override TextEditTextChangedEventHandlerBase RegisterTextEditTextChangedEventHandler(TreeScope treeScope, TextEditChangeType textEditChangeType, Action<AutomationElement, TextEditChangeType, string[]> action)
        {
            throw new NotSupportedByFrameworkException();
        }

        /// <inheritdoc />
        public override void UnregisterActiveTextPositionChangedEventHandler(ActiveTextPositionChangedEventHandlerBase eventHandler)
        {
            throw new NotSupportedByFrameworkException();
        }

        /// <inheritdoc />
        public override void UnregisterAutomationEventHandler(AutomationEventHandlerBase eventHandler)
        {
            var frameworkEventHandler = (UIA2AutomationEventHandler)eventHandler;
            UIA.Automation.RemoveAutomationEventHandler(UIA.AutomationEvent.LookupById(frameworkEventHandler.Event.Id), NativeElement, frameworkEventHandler.EventHandler);
        }

        /// <inheritdoc />
        public override void UnregisterPropertyChangedEventHandler(PropertyChangedEventHandlerBase eventHandler)
        {
            UIA.Automation.RemoveAutomationPropertyChangedEventHandler(NativeElement, ((UIA2PropertyChangedEventHandler)eventHandler).EventHandler);
        }

        /// <inheritdoc />
        public override void UnregisterStructureChangedEventHandler(StructureChangedEventHandlerBase eventHandler)
        {
            UIA.Automation.RemoveStructureChangedEventHandler(NativeElement, ((UIA2StructureChangedEventHandler)eventHandler).EventHandler);
        }

        /// <inheritdoc />
        public override void UnregisterNotificationEventHandler(NotificationEventHandlerBase eventHandler)
        {
            throw new NotSupportedByFrameworkException();
        }

        /// <inheritdoc />
        public override void UnregisterTextEditTextChangedEventHandler(TextEditTextChangedEventHandlerBase eventHandler)
        {
            throw new NotSupportedByFrameworkException();
        }

        public override PatternId[] GetSupportedPatterns()
        {
            var raw = NativeElement.GetSupportedPatterns();
            return raw.Select(r => PatternId.Find(Automation.AutomationType, r.Id)).ToArray();
        }

        public override PropertyId[] GetSupportedProperties()
        {
            var raw = NativeElement.GetSupportedProperties();
            return raw.Select(r => PropertyId.Find(Automation.AutomationType, r.Id)).ToArray();
        }

        public override AutomationElement GetUpdatedCache()
        {
            if (CacheRequest.Current != null)
            {
                var updatedElement = NativeElement.GetUpdatedCache(CacheRequest.Current.ToNative());
                return AutomationElementConverter.NativeToManaged(Automation, updatedElement);
            }
            return null;
        }

        public override AutomationElement[] GetCachedChildren()
        {
            var cachedChildren = NativeElement.CachedChildren;
            return AutomationElementConverter.NativeArrayToManaged(Automation, cachedChildren);
        }

        public override AutomationElement GetCachedParent()
        {
            var cachedParent = NativeElement.CachedParent;
            return AutomationElementConverter.NativeToManaged(Automation, cachedParent);
        }

        public override object GetCurrentMetadataValue(PropertyId targetId, int metadataId)
        {
            throw new NotSupportedByFrameworkException();
        }

        public override int GetHashCode()
        {
            return NativeElement.GetHashCode();
        }
    }
}
