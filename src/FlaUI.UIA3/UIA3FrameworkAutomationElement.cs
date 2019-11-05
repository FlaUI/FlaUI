using System;
using System.Drawing;
using System.Linq;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.EventHandlers;
using FlaUI.UIA3.Extensions;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3
{
    public partial class UIA3FrameworkAutomationElement : FrameworkAutomationElementBase
    {
        public UIA3FrameworkAutomationElement(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation)
        {
            Automation = automation;
            NativeElement = nativeElement;
        }

        /// <summary>
        /// Concrete implementation of the automation object.
        /// </summary>
        public new UIA3Automation Automation { get; }

        /// <summary>
        /// Native object for the ui element.
        /// </summary>
        public UIA.IUIAutomationElement NativeElement { get; }

        /// <summary>
        /// Native object for Windows 8 ui element.
        /// </summary>
        public UIA.IUIAutomationElement2 NativeElement2 => GetAutomationElementAs<UIA.IUIAutomationElement2>();

        /// <summary>
        /// Native object for Windows 8.1 ui element.
        /// </summary>
        public UIA.IUIAutomationElement3 NativeElement3 => GetAutomationElementAs<UIA.IUIAutomationElement3>();

        /// <summary>
        /// Native object for Windows 10 ui element.
        /// </summary>
        public UIA.IUIAutomationElement4 NativeElement4 => GetAutomationElementAs<UIA.IUIAutomationElement4>();

        /// <summary>
        /// Native object for the second Windows 10 ui element.
        /// </summary>
        public UIA.IUIAutomationElement5 NativeElement5 => GetAutomationElementAs<UIA.IUIAutomationElement5>();

        /// <summary>
        /// Native object for the third Windows 10 ui element.
        /// </summary>
        public UIA.IUIAutomationElement6 NativeElement6 => GetAutomationElementAs<UIA.IUIAutomationElement6>();

        /// <summary>
        /// Native object for the fourth for Windows 10 ui element.
        /// </summary>
        public UIA.IUIAutomationElement7 NativeElement7 => GetAutomationElementAs<UIA.IUIAutomationElement7>();

        /// <summary>
        /// Native object for the fifth for Windows 10 ui element.
        /// </summary>
        public UIA.IUIAutomationElement8 NativeElement8 => GetAutomationElementAs<UIA.IUIAutomationElement8>();

        /// <summary>
        /// Native object for the sixth for Windows 10 ui element.
        /// </summary>
        public UIA.IUIAutomationElement9 NativeElement9 => GetAutomationElementAs<UIA.IUIAutomationElement9>();

        public override void SetFocus()
        {
            NativeElement.SetFocus();
        }

        protected override object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported)
        {
            var ignoreDefaultValue = useDefaultIfNotSupported ? 0 : 1;
            var returnValue = cached ?
                NativeElement.GetCachedPropertyValueEx(propertyId, ignoreDefaultValue) :
                NativeElement.GetCurrentPropertyValueEx(propertyId, ignoreDefaultValue);
            return returnValue;
        }

        protected override object InternalGetPattern(int patternId, bool cached)
        {
            var returnedValue = cached
                ? NativeElement.GetCachedPattern(patternId)
                : NativeElement.GetCurrentPattern(patternId);
            return returnedValue;
        }

        /// <inheritdoc />
        public override AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElements = CacheRequest.IsCachingActive
                ? NativeElement.FindAllBuildCache((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition), CacheRequest.Current.ToNative(Automation))
                : NativeElement.FindAll((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition));
            return AutomationElementConverter.NativeArrayToManaged(Automation, nativeFoundElements);
        }

        /// <inheritdoc />
        public override AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElement = CacheRequest.IsCachingActive
                ? NativeElement.FindFirstBuildCache((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition), CacheRequest.Current.ToNative(Automation))
                : NativeElement.FindFirst((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition));
            return AutomationElementConverter.NativeToManaged(Automation, nativeFoundElement);
        }

        /// <inheritdoc />
        public override AutomationElement[] FindAllWithOptions(TreeScope treeScope, ConditionBase condition,
            TreeTraversalOptions traversalOptions, AutomationElement root)
        {
            var nativeFoundElements = CacheRequest.IsCachingActive
                ? NativeElement7.FindAllWithOptionsBuildCache((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition), CacheRequest.Current.ToNative(Automation), (UIA.TreeTraversalOptions)traversalOptions, root.ToNative())
                : NativeElement7.FindAllWithOptions((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition), (UIA.TreeTraversalOptions)traversalOptions, root.ToNative());
            return AutomationElementConverter.NativeArrayToManaged(Automation, nativeFoundElements);
        }

        /// <inheritdoc />
        public override AutomationElement FindFirstWithOptions(TreeScope treeScope, ConditionBase condition,
            TreeTraversalOptions traversalOptions, AutomationElement root)
        {
            var nativeFoundElement = CacheRequest.IsCachingActive
                ? NativeElement7.FindFirstWithOptionsBuildCache((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition), CacheRequest.Current.ToNative(Automation), (UIA.TreeTraversalOptions)traversalOptions, root.ToNative())
                : NativeElement7.FindFirstWithOptions((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition), (UIA.TreeTraversalOptions)traversalOptions, root.ToNative());
            return AutomationElementConverter.NativeToManaged(Automation, nativeFoundElement);
        }

        /// <inheritdoc />
        public override AutomationElement FindIndexed(TreeScope treeScope, int index, ConditionBase condition)
        {
            var nativeFoundElements = CacheRequest.IsCachingActive
                ? NativeElement.FindAllBuildCache((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition), CacheRequest.Current.ToNative(Automation))
                : NativeElement.FindAll((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition));
            var nativeElement = nativeFoundElements.GetElement(index);
            return nativeElement == null ? null : AutomationElementConverter.NativeToManaged(Automation, nativeElement);
        }

        /// <inheritdoc />
        public override bool TryGetClickablePoint(out Point point)
        {
            var tagPoint = new UIA.tagPOINT { x = 0, y = 0 };
            var success = Com.Call(() => NativeElement.GetClickablePoint(out tagPoint)) != 0;
            if (success)
            {
                point = new Point(tagPoint.x, tagPoint.y);
            }
            else
            {
                success = Properties.ClickablePoint.TryGetValue(out point);
            }
            return success;
        }

        /// <inheritdoc />
        public override ActiveTextPositionChangedEventHandlerBase RegisterActiveTextPositionChangedEvent(TreeScope treeScope, Action<AutomationElement, ITextRange> action)
        {
            var eventHandler = new UIA3ActiveTextPositionChangedEventHandler(this, action);
            Automation.NativeAutomation6.AddActiveTextPositionChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, null, eventHandler);
            return eventHandler;
        }

        public override AutomationEventHandlerBase RegisterAutomationEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action)
        {
            var eventHandler = new UIA3AutomationEventHandler(this, @event, action);
            Automation.NativeAutomation.AddAutomationEventHandler(@event.Id, NativeElement, (UIA.TreeScope)treeScope, null, eventHandler);
            return eventHandler;
        }

        /// <inheritdoc />
        public override PropertyChangedEventHandlerBase RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, PropertyId[] properties)
        {
            var eventHandler = new UIA3PropertyChangedEventHandler(this, action);
            var propertyIds = properties.Select(p => p.Id).ToArray();
            Automation.NativeAutomation.AddPropertyChangedEventHandler(NativeElement,
                (UIA.TreeScope)treeScope, null, eventHandler, propertyIds);
            return eventHandler;
        }

        /// <inheritdoc />
        public override StructureChangedEventHandlerBase RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action)
        {
            var eventHandler = new UIA3StructureChangedEventHandler(this, action);
            Automation.NativeAutomation.AddStructureChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, null, eventHandler);
            return eventHandler;
        }

        /// <inheritdoc />
        public override NotificationEventHandlerBase RegisterNotificationEvent(TreeScope treeScope, Action<AutomationElement, NotificationKind, NotificationProcessing, string, string> action)
        {
            var eventHandler = new UIA3NotificationEventHandler(this, action);
            Automation.NativeAutomation5.AddNotificationEventHandler(NativeElement, (UIA.TreeScope)treeScope, null, eventHandler);
            return eventHandler;
        }

        /// <inheritdoc />
        public override TextEditTextChangedEventHandlerBase RegisterTextEditTextChangedEventHandler(TreeScope treeScope, TextEditChangeType textEditChangeType, Action<AutomationElement, TextEditChangeType, string[]> action)
        {
            var eventHandler = new UIA3TextEditTextChangedEventHandler(this, action);
            Automation.NativeAutomation3.AddTextEditTextChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, (UIA.TextEditChangeType)textEditChangeType, null, eventHandler);
            return eventHandler;
        }

        /// <inheritdoc />
        public override void UnregisterActiveTextPositionChangedEventHandler(ActiveTextPositionChangedEventHandlerBase eventHandler)
        {
            Automation.NativeAutomation6.RemoveActiveTextPositionChangedEventHandler(NativeElement, (UIA3ActiveTextPositionChangedEventHandler)eventHandler);
        }

        /// <inheritdoc />
        public override void UnregisterAutomationEventHandler(AutomationEventHandlerBase eventHandler)
        {
            var frameworkEventHandler = (UIA3AutomationEventHandler)eventHandler;
            Automation.NativeAutomation.RemoveAutomationEventHandler(frameworkEventHandler.Event.Id, NativeElement, frameworkEventHandler);
        }

        /// <inheritdoc />
        public override void UnregisterPropertyChangedEventHandler(PropertyChangedEventHandlerBase eventHandler)
        {
            Automation.NativeAutomation.RemovePropertyChangedEventHandler(NativeElement, (UIA3PropertyChangedEventHandler)eventHandler);
        }

        /// <inheritdoc />
        public override void UnregisterStructureChangedEventHandler(StructureChangedEventHandlerBase eventHandler)
        {
            Automation.NativeAutomation.RemoveStructureChangedEventHandler(NativeElement, (UIA3StructureChangedEventHandler)eventHandler);
        }

        /// <inheritdoc />
        public override void UnregisterNotificationEventHandler(NotificationEventHandlerBase eventHandler)
        {
            Automation.NativeAutomation5.RemoveNotificationEventHandler(NativeElement, (UIA3NotificationEventHandler)eventHandler);
        }

        /// <inheritdoc />
        public override void UnregisterTextEditTextChangedEventHandler(TextEditTextChangedEventHandlerBase eventHandler)
        {
            Automation.NativeAutomation3.RemoveTextEditTextChangedEventHandler(NativeElement, (UIA3TextEditTextChangedEventHandler)eventHandler);
        }

        public override PatternId[] GetSupportedPatterns()
        {
            Automation.NativeAutomation.PollForPotentialSupportedPatterns(NativeElement, out int[] rawIds, out string[] _);
            return rawIds.Select(id => PatternId.Find(Automation.AutomationType, id)).ToArray();
        }

        public override PropertyId[] GetSupportedProperties()
        {
            Automation.NativeAutomation.PollForPotentialSupportedProperties(NativeElement, out int[] rawIds, out string[] _);
            return rawIds.Select(id => PropertyId.Find(Automation.AutomationType, id)).ToArray();
        }

        public override AutomationElement GetUpdatedCache()
        {
            if (CacheRequest.Current != null)
            {
                var updatedElement = NativeElement.BuildUpdatedCache(CacheRequest.Current.ToNative(Automation));
                return AutomationElementConverter.NativeToManaged(Automation, updatedElement);
            }
            return null;
        }

        public override AutomationElement[] GetCachedChildren()
        {
            var cachedChildren = NativeElement.GetCachedChildren();
            return AutomationElementConverter.NativeArrayToManaged(Automation, cachedChildren);
        }

        public override AutomationElement GetCachedParent()
        {
            var cachedParent = NativeElement.GetCachedParent();
            return AutomationElementConverter.NativeToManaged(Automation, cachedParent);
        }

        public override object GetCurrentMetadataValue(PropertyId targetId, int metadataId)
        {
            return NativeElement7.GetCurrentMetadataValue(targetId.Id, metadataId);
        }

        public override int GetHashCode()
        {
            return NativeElement.GetHashCode();
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
                throw new NotSupportedException($"OS does not have {typeof(T).Name} support.");
            }
            return element;
        }
    }
}
