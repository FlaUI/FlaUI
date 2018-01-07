using System;
using System.Linq;
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
using FlaUI.UIA3.Extensions;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3
{
    public class UIA3BasicAutomationElement : BasicAutomationElementBase
    {
        public UIA3BasicAutomationElement(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation)
        {
            Automation = automation;
            NativeElement = nativeElement;
            Patterns = new UIA3AutomationElementPatternValues(this);
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

        /// <summary>
        /// Native object for Windows 10 ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement4 => GetAutomationElementAs<UIA.IUIAutomationElement4>();

        /// <summary>
        /// Native object for second Windows 10 ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement5 => GetAutomationElementAs<UIA.IUIAutomationElement5>();

        /// <summary>
        /// Native object for third Windows 10 ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement6 => GetAutomationElementAs<UIA.IUIAutomationElement6>();

        /// <summary>
        /// Native object fourth for Windows 10 ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement7 => GetAutomationElementAs<UIA.IUIAutomationElement7>();

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
        public override AutomationElement FindIndexed(TreeScope treeScope, int index, ConditionBase condition)
        {
            var nativeFoundElements = CacheRequest.IsCachingActive
                ? NativeElement.FindAllBuildCache((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition), CacheRequest.Current.ToNative(Automation))
                : NativeElement.FindAll((UIA.TreeScope)treeScope, ConditionConverter.ToNative(Automation, condition));
            var nativeElement = nativeFoundElements.GetElement(index);
            return nativeElement == null ? null : AutomationElementConverter.NativeToManaged(Automation, nativeElement);
        }

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
