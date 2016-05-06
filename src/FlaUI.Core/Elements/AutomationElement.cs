using FlaUI.Core.Conditions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;
using System;
using System.Linq;
using System.Windows.Media;

namespace FlaUI.Core.Elements
{
    /// <summary>
    /// Basic class for a wrapped ui element
    /// </summary>
    public class AutomationElement
    {
        /// <summary>
        /// Native object for the ui element
        /// </summary>
        public IUIAutomationElement NativeElement { get; private set; }

        /// <summary>
        /// Native object for Windows 8 ui element
        /// </summary>
        public IUIAutomationElement NativeElement2
        {
            get { return GetAutomationElementAs<IUIAutomationElement2>(); }
        }

        /// <summary>
        /// Native object for Windows 8.1 ui element
        /// </summary>
        public IUIAutomationElement NativeElement3
        {
            get { return GetAutomationElementAs<IUIAutomationElement3>(); }
        }

        /// <summary>
        /// Underlying <see cref="Automation"/> object where this element belongs to
        /// </summary>
        public Automation Automation { get; private set; }

        /// <summary>
        /// A factory object for patterns
        /// </summary>
        public PatternFactory PatternFactory { get; private set; }

        /// <summary>
        /// Basic information about this element (cached)
        /// </summary>
        public AutomationElementInformation Cached { get; private set; }

        /// <summary>
        /// Basic information about this element (realtime)
        /// </summary>
        public AutomationElementInformation Current { get; private set; }

        /// <summary>
        /// Constructor for a basic ui element
        /// </summary>
        /// <param name="automation">The automation instance where this element belongs to</param>
        /// <param name="nativeElement">The native element this instance wrapps</param>
        public AutomationElement(Automation automation, IUIAutomationElement nativeElement)
        {
            Automation = automation;
            NativeElement = nativeElement;
            PatternFactory = new PatternFactory(this);
            Cached = new AutomationElementInformation(this, true);
            Current = new AutomationElementInformation(this, false);
        }

        /// <summary>
        /// Gets the desired property value. Ends in an exception if the property is not supported.
        /// </summary>
        public object GetPropertyValue(PropertyId property, bool cached)
        {
            return GetPropertyValue<object>(property, cached);
        }

        public T GetPropertyValue<T>(PropertyId property, bool cached)
        {
            var value = InternalGetPropertyValue(property.Id, cached, false);
            if (value == Automation.NativeAutomation.ReservedNotSupportedValue)
            {
                throw new PropertyNotSupportedException(String.Format("Property '{0}' not supported", property.Name), property);
            }
            return ConvertValue<T>(property, value);
        }

        /// <summary>
        /// Gets the desired property value or the default value, if the property is not supported
        /// </summary>
        public object SafeGetPropertyValue(PropertyId property, bool cached)
        {
            return SafeGetPropertyValue<object>(property, cached);
        }

        public T SafeGetPropertyValue<T>(PropertyId property, bool cached)
        {
            var value = InternalGetPropertyValue(property.Id, cached, true);
            return ConvertValue<T>(property, value);
        }

        /// <summary>
        /// Tries to get the property value. Fails if the property is not supported.
        /// </summary>
        public bool TryGetPropertyValue(PropertyId property, bool cached, out object value)
        {
            return TryGetPropertyValue<object>(property, cached, out value);
        }

        public bool TryGetPropertyValue<T>(PropertyId property, bool cached, out T value)
        {
            var tmp = InternalGetPropertyValue(property.Id, cached, false);
            if (tmp == Automation.NativeAutomation.ReservedNotSupportedValue)
            {
                value = default(T);
                return false;
            }
            value = ConvertValue<T>(property, tmp);
            return true;
        }

        /// <summary>
        /// Register for a specific event
        /// </summary>
        /// <param name="event">The event to register to</param>
        /// <param name="treeScope">The treescope in which the event should be registered</param>
        /// <param name="action">The action to execute when the event fires</param>
        public void RegisterEvent(EventId @event, Definitions.TreeScope treeScope, Action<AutomationElement, EventId> action)
        {
            Automation.NativeAutomation.AddAutomationEventHandler(@event.Id, NativeElement, (TreeScope)treeScope, null, new BasicEventHandler(Automation, action));
        }

        /// <summary>
        /// Registers for a focus changed event
        /// </summary>
        /// <param name="action">The action to execute when the event fires</param>
        public void RegisterFocusChangedEvent(Action<AutomationElement> action)
        {
            Automation.NativeAutomation.AddFocusChangedEventHandler(null, new FocusChangedEventHandler(Automation, action));
        }

        /// <summary>
        /// Registers for a structure changed event
        /// </summary>
        /// <param name="treeScope">The treescope in which the event should be registered</param>
        /// <param name="action">The action to execute when the event fires</param>
        public void RegisterStructureChangedEvent(Definitions.TreeScope treeScope, Action<AutomationElement, Definitions.StructureChangeType, int[]> action)
        {
            Automation.NativeAutomation.AddStructureChangedEventHandler(NativeElement, (TreeScope)treeScope, null, new StructureChangedEventHandler(Automation, action));
        }

        /// <summary>
        /// Registers for a property changed event
        /// </summary>
        /// <param name="treeScope">The treescope in which the event should be registered</param>
        /// <param name="action">The action to execute when the event fires</param>
        /// <param name="properties">The properties to listen to for a change</param>
        public void RegisterPropertyChangedEvent(Definitions.TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, params PropertyId[] properties)
        {
            var propertyIds = properties.Select(p => p.Id).ToArray();
            Automation.NativeAutomation.AddPropertyChangedEventHandler(NativeElement,
                (TreeScope)treeScope, null, new PropertyChangedEventHandler(Automation, action), propertyIds);
        }

        /// <summary>
        /// Draws a red highlight around the ui element
        /// </summary>
        public AutomationElement DrawHighlight()
        {
            return DrawHighlight(Colors.Red);
        }

        /// <summary>
        /// Draws a manually colored highlight around the ui element
        /// </summary>
        public AutomationElement DrawHighlight(Color color)
        {
            var rectangle = Current.BoundingRectangle;
            if (!rectangle.IsEmpty)
            {
                Automation.OverlayManager.ShowBlocking(rectangle, color);
            }
            return this;
        }

        /// <summary>
        /// Finds all elements in the given treescope and condition
        /// </summary>
        public AutomationElement[] FindAll(Definitions.TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElements = NativeElement.FindAll((TreeScope)treeScope, condition.ToNative(Automation));
            return NativeValueConverter.NativeArrayToManaged(Automation, nativeFoundElements);
        }

        /// <summary>
        /// Finds the first element which is in the given treescope and matches the condition
        /// </summary>
        public AutomationElement FindFirst(Definitions.TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElement = NativeElement.FindFirst((TreeScope)treeScope, condition.ToNative(Automation));
            return NativeValueConverter.NativeToManaged(Automation, nativeFoundElement);
        }

        /// <summary>
        /// Tries to cast the automation element to a specific interface.
        /// Throws an exception if that is not possible.
        /// </summary>
        private T GetAutomationElementAs<T>() where T : class, IUIAutomationElement
        {
            var element = NativeElement as T;
            if (element == null)
            {
                throw new NotSupportedException(String.Format("OS does not have {0} support.", typeof(T).Name));
            }
            return element;
        }

        /// <summary>
        /// Gets the desired property value
        /// </summary>
        /// <param name="propertyId">The id of the property to get</param>
        /// <param name="cached">Flag to indicate if the cached or current value should be fetched</param>
        /// <param name="useDefaultIfNotSupported">Flag to indicate, if the default value should be used if the property is not supported</param>
        /// <returns>The value / default value of the property or <see cref="IUIAutomation.ReservedNotSupportedValue" /></returns>
        private object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported)
        {
            var ignoreDefaultValue = useDefaultIfNotSupported ? 0 : 1;
            var returnValue = cached ?
                NativeElement.GetCachedPropertyValueEx(propertyId, ignoreDefaultValue) :
                NativeElement.GetCurrentPropertyValueEx(propertyId, ignoreDefaultValue);
            return returnValue;
        }

        /// <summary>
        /// Converts the given value with the registered converter or simply casts it
        /// </summary>
        private T ConvertValue<T>(PropertyId property, object value)
        {
            return property.Convert<T>(value);
        }
        #region Property Identifiers
        // Base element properties
        public static readonly PropertyId AcceleratorKeyProperty = PropertyId.Register(UIA_PropertyIds.UIA_AcceleratorKeyPropertyId, "AcceleratorKey");
        public static readonly PropertyId AccessKeyProperty = PropertyId.Register(UIA_PropertyIds.UIA_AccessKeyPropertyId, "AccessKey");
        public static readonly PropertyId AriaPropertiesProperty = PropertyId.Register(UIA_PropertyIds.UIA_AriaPropertiesPropertyId, "AriaProperties");
        public static readonly PropertyId AriaRoleProperty = PropertyId.Register(UIA_PropertyIds.UIA_AriaRolePropertyId, "AriaRole");
        public static readonly PropertyId AutomationIdProperty = PropertyId.Register(UIA_PropertyIds.UIA_AutomationIdPropertyId, "AutomationId");
        public static readonly PropertyId BoundingRectangleProperty = PropertyId.Register(UIA_PropertyIds.UIA_BoundingRectanglePropertyId, "BoundingRectangle").SetConverter(NativeValueConverter.ToRectangle);
        public static readonly PropertyId ClassNameProperty = PropertyId.Register(UIA_PropertyIds.UIA_ClassNamePropertyId, "ClassName");
        public static readonly PropertyId ClickablePointProperty = PropertyId.Register(UIA_PropertyIds.UIA_ClickablePointPropertyId, "ClickablePoint").SetConverter(NativeValueConverter.ToPoint);
        public static readonly PropertyId ControllerForProperty = PropertyId.Register(UIA_PropertyIds.UIA_ControllerForPropertyId, "ControllerFor");
        public static readonly PropertyId ControlTypeProperty = PropertyId.Register(UIA_PropertyIds.UIA_ControlTypePropertyId, "ControlType");
        public static readonly PropertyId CultureProperty = PropertyId.Register(UIA_PropertyIds.UIA_CulturePropertyId, "Culture").SetConverter(NativeValueConverter.ToCulture);
        public static readonly PropertyId DescribedByProperty = PropertyId.Register(UIA_PropertyIds.UIA_DescribedByPropertyId, "DescribedBy");
        public static readonly PropertyId FlowsFromProperty = PropertyId.Register(UIA_PropertyIds.UIA_FlowsFromPropertyId, "FlowsFrom");
        public static readonly PropertyId FlowsToProperty = PropertyId.Register(UIA_PropertyIds.UIA_FlowsToPropertyId, "FlowsTo");
        public static readonly PropertyId FrameworkIdProperty = PropertyId.Register(UIA_PropertyIds.UIA_FrameworkIdPropertyId, "FrameworkId");
        public static readonly PropertyId HasKeyboardFocusProperty = PropertyId.Register(UIA_PropertyIds.UIA_HasKeyboardFocusPropertyId, "HasKeyboardFocus");
        public static readonly PropertyId HelpTextProperty = PropertyId.Register(UIA_PropertyIds.UIA_HelpTextPropertyId, "HelpText");
        public static readonly PropertyId IsContentElementProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsContentElementPropertyId, "IsContentElement");
        public static readonly PropertyId IsControlElementProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsControlElementPropertyId, "IsControlElement");
        public static readonly PropertyId IsDataValidForFormProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsDataValidForFormPropertyId, "IsDataValidForForm");
        public static readonly PropertyId IsEnabledProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsEnabledPropertyId, "IsEnabled");
        public static readonly PropertyId IsKeyboardFocusableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsKeyboardFocusablePropertyId, "IsKeyboardFocusable");
        public static readonly PropertyId IsOffscreenProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsOffscreenPropertyId, "IsOffscreen");
        public static readonly PropertyId IsPasswordProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsPasswordPropertyId, "IsPassword");
        public static readonly PropertyId IsPeripheralProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsPeripheralPropertyId, "IsPeripheral");
        public static readonly PropertyId IsRequiredForFormProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsRequiredForFormPropertyId, "IsRequiredForForm");
        public static readonly PropertyId ItemStatusProperty = PropertyId.Register(UIA_PropertyIds.UIA_ItemStatusPropertyId, "ItemStatus");
        public static readonly PropertyId ItemTypeProperty = PropertyId.Register(UIA_PropertyIds.UIA_ItemTypePropertyId, "ItemType");
        public static readonly PropertyId LabeledByProperty = PropertyId.Register(UIA_PropertyIds.UIA_LabeledByPropertyId, "LabeledBy");
        public static readonly PropertyId LiveSettingProperty = PropertyId.Register(UIA_PropertyIds.UIA_LiveSettingPropertyId, "LiveSetting");
        public static readonly PropertyId LocalizedControlTypeProperty = PropertyId.Register(UIA_PropertyIds.UIA_LocalizedControlTypePropertyId, "LocalizedControlType");
        public static readonly PropertyId NameProperty = PropertyId.Register(UIA_PropertyIds.UIA_NamePropertyId, "Name");
        public static readonly PropertyId NativeWindowHandleProperty = PropertyId.Register(UIA_PropertyIds.UIA_NativeWindowHandlePropertyId, "NativeWindowHandle");
        public static readonly PropertyId OptimizeForVisualContentProperty = PropertyId.Register(UIA_PropertyIds.UIA_OptimizeForVisualContentPropertyId, "OptimizeForVisualContent");
        public static readonly PropertyId OrientationProperty = PropertyId.Register(UIA_PropertyIds.UIA_OrientationPropertyId, "Orientation");
        public static readonly PropertyId ProcessIdProperty = PropertyId.Register(UIA_PropertyIds.UIA_ProcessIdPropertyId, "ProcessId");
        public static readonly PropertyId ProviderDescriptionProperty = PropertyId.Register(UIA_PropertyIds.UIA_ProviderDescriptionPropertyId, "ProviderDescription");
        public static readonly PropertyId RuntimeIdProperty = PropertyId.Register(UIA_PropertyIds.UIA_RuntimeIdPropertyId, "RuntimeId");
        // Pattern availability properties
        public static readonly PropertyId IsAnnotationPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsAnnotationPatternAvailablePropertyId, "IsAnnotationPatternAvailable");
        public static readonly PropertyId IsDockPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsDockPatternAvailablePropertyId, "IsDockPatternAvailable");
        public static readonly PropertyId IsDragPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsDragPatternAvailablePropertyId, "IsDragPatternAvailable");
        public static readonly PropertyId IsDropTargetPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsDropTargetPatternAvailablePropertyId, "IsDropTargetPatternAvailable");
        public static readonly PropertyId IsExpandCollapsePatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsExpandCollapsePatternAvailablePropertyId, "IsExpandCollapsePatternAvailable");
        public static readonly PropertyId IsGridItemPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsGridItemPatternAvailablePropertyId, "IsGridItemPatternAvailable");
        public static readonly PropertyId IsGridPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsGridPatternAvailablePropertyId, "IsGridPatternAvailable");
        public static readonly PropertyId IsInvokePatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsInvokePatternAvailablePropertyId, "IsInvokePatternAvailable");
        public static readonly PropertyId IsItemContainerPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsItemContainerPatternAvailablePropertyId, "IsItemContainerPatternAvailable");
        public static readonly PropertyId IsLegacyIAccessiblePatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsLegacyIAccessiblePatternAvailablePropertyId, "IsLegacyIAccessiblePatternAvailable");
        public static readonly PropertyId IsMultipleViewPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsMultipleViewPatternAvailablePropertyId, "IsMultipleViewPatternAvailable");
        public static readonly PropertyId IsObjectModelPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsObjectModelPatternAvailablePropertyId, "IsObjectModelPatternAvailable");
        public static readonly PropertyId IsRangeValuePatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsRangeValuePatternAvailablePropertyId, "IsRangeValuePatternAvailable");
        public static readonly PropertyId IsScrollItemPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsScrollItemPatternAvailablePropertyId, "IsScrollItemPatternAvailable");
        public static readonly PropertyId IsScrollPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsScrollPatternAvailablePropertyId, "IsScrollPatternAvailable");
        public static readonly PropertyId IsSelectionItemPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsSelectionItemPatternAvailablePropertyId, "IsSelectionItemPatternAvailable");
        public static readonly PropertyId IsSelectionPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsSelectionPatternAvailablePropertyId, "IsSelectionPatternAvailable");
        public static readonly PropertyId IsSpreadsheetPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsSpreadsheetPatternAvailablePropertyId, "IsSpreadsheetPatternAvailable");
        public static readonly PropertyId IsSpreadsheetItemPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsSpreadsheetItemPatternAvailablePropertyId, "IsSpreadsheetItemPatternAvailable");
        public static readonly PropertyId IsStylesPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsStylesPatternAvailablePropertyId, "IsStylesPatternAvailable");
        public static readonly PropertyId IsSynchronizedInputPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsSynchronizedInputPatternAvailablePropertyId, "IsSynchronizedInputPatternAvailable");
        public static readonly PropertyId IsTableItemPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsTableItemPatternAvailablePropertyId, "IsTableItemPatternAvailable");
        public static readonly PropertyId IsTablePatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsTablePatternAvailablePropertyId, "IsTablePatternAvailable");
        public static readonly PropertyId IsTextChildPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsTextChildPatternAvailablePropertyId, "IsTextChildPatternAvailable");
        public static readonly PropertyId IsTextEditPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsTextEditPatternAvailablePropertyId, "IsTextEditPatternAvailable");
        public static readonly PropertyId IsTextPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsTextPatternAvailablePropertyId, "IsTextPatternAvailable");
        public static readonly PropertyId IsTextPattern2AvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsTextPattern2AvailablePropertyId, "IsTextPattern2Available");
        public static readonly PropertyId IsTogglePatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsTogglePatternAvailablePropertyId, "IsTogglePatternAvailable");
        public static readonly PropertyId IsTransformPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsTransformPatternAvailablePropertyId, "IsTransformPatternAvailable");
        public static readonly PropertyId IsTransformPattern2AvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsTransformPattern2AvailablePropertyId, "IsTransformPattern2Available");
        public static readonly PropertyId IsValuePatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsValuePatternAvailablePropertyId, "IsValuePatternAvailable");
        public static readonly PropertyId IsVirtualizedItemPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsVirtualizedItemPatternAvailablePropertyId, "IsVirtualizedItemPatternAvailable");
        public static readonly PropertyId IsWindowPatternAvailableProperty = PropertyId.Register(UIA_PropertyIds.UIA_IsWindowPatternAvailablePropertyId, "IsWindowPatternAvailable");
        #endregion Property Identifiers
        #region Event identifiers
        public static readonly EventId AsyncContentLoadedEvent = EventId.Register(UIA_EventIds.UIA_AsyncContentLoadedEventId, "AsyncContentLoaded");
        public static readonly EventId FocusChangedEvent = EventId.Register(UIA_EventIds.UIA_AutomationFocusChangedEventId, "AutomationFocusChanged");
        public static readonly EventId PropertyChangedEvent = EventId.Register(UIA_EventIds.UIA_AutomationPropertyChangedEventId, "AutomationPropertyChanged");
        public static readonly EventId HostedFragmentRootsInvalidatedEvent = EventId.Register(UIA_EventIds.UIA_HostedFragmentRootsInvalidatedEventId, "HostedFragmentRootsInvalidated");
        public static readonly EventId LayoutInvalidatedEvent = EventId.Register(UIA_EventIds.UIA_LayoutInvalidatedEventId, "LayoutInvalidated");
        public static readonly EventId LiveRegionChangedEvent = EventId.Register(UIA_EventIds.UIA_LiveRegionChangedEventId, "LiveRegionChanged");
        public static readonly EventId MenuClosedEvent = EventId.Register(UIA_EventIds.UIA_MenuClosedEventId, "MenuClosed");
        public static readonly EventId MenuModeEndEvent = EventId.Register(UIA_EventIds.UIA_MenuModeEndEventId, "MenuModeEnd");
        public static readonly EventId MenuModeStartEvent = EventId.Register(UIA_EventIds.UIA_MenuModeStartEventId, "MenuModeStart");
        public static readonly EventId MenuOpenedEvent = EventId.Register(UIA_EventIds.UIA_MenuOpenedEventId, "MenuOpened");
        public static readonly EventId StructureChangedEvent = EventId.Register(UIA_EventIds.UIA_StructureChangedEventId, "StructureChanged");
        public static readonly EventId SystemAlertEvent = EventId.Register(UIA_EventIds.UIA_SystemAlertEventId, "SystemAlert");
        public static readonly EventId ToolTipClosedEvent = EventId.Register(UIA_EventIds.UIA_ToolTipClosedEventId, "ToolTipClosed");
        public static readonly EventId ToolTipOpenedEvent = EventId.Register(UIA_EventIds.UIA_ToolTipOpenedEventId, "ToolTipOpened");
        #endregion Event identifiers
    }
}
