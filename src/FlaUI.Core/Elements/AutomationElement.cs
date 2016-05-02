using FlaUI.Core.EventHandlers;
using FlaUI.Core.Exceptions;
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
        public object GetPropertyValue(AutomationProperty property, bool cached)
        {
            return GetPropertyValue<object>(property, cached);
        }

        public T GetPropertyValue<T>(AutomationProperty property, bool cached)
        {
            var value = InternalGetPropertyValue(property.Id, cached, false);
            if (value == Automation.NativeAutomation.ReservedNotSupportedValue)
            {
                throw new PropertyNotSupportedException(String.Format("Property '{0}' not supported", property.Name), property);
            }
            return (T)value;
        }

        /// <summary>
        /// Gets the desired property value or the default value, if the property is not supported
        /// </summary>
        public object SafeGetPropertyValue(AutomationProperty property, bool cached)
        {
            return SafeGetPropertyValue<object>(property, cached);
        }

        public T SafeGetPropertyValue<T>(AutomationProperty property, bool cached)
        {
            var value = InternalGetPropertyValue(property.Id, cached, true);
            return (T)value;
        }

        /// <summary>
        /// Tries to get the property value. Fails if the property is not supported.
        /// </summary>
        public bool TryGetPropertyValue(AutomationProperty property, bool cached, out object value)
        {
            return TryGetPropertyValue<object>(property, cached, out value);
        }

        public bool TryGetPropertyValue<T>(AutomationProperty property, bool cached, out T value)
        {
            var tmp = InternalGetPropertyValue(property.Id, cached, false);
            if (tmp == Automation.NativeAutomation.ReservedNotSupportedValue)
            {
                value = default(T);
                return false;
            }
            value = (T)tmp;
            return true;
        }

        /// <summary>
        /// Register for a specific event
        /// </summary>
        /// <param name="event">The event to register to</param>
        /// <param name="treeScope">The treescope in which the event should be registered</param>
        /// <param name="action">The action to execute when the event fires</param>
        public void RegisterEvent(AutomationEvent @event, Definitions.TreeScope treeScope, Action<AutomationElement, AutomationEvent> action)
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
        public void RegisterPropertyChangedEvent(Definitions.TreeScope treeScope, Action<AutomationElement, AutomationProperty, object> action, params AutomationProperty[] properties)
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

        #region Property Identifiers
        // Base element properties
        public static readonly AutomationProperty AcceleratorKeyProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AcceleratorKeyPropertyId, "AcceleratorKey");
        public static readonly AutomationProperty AccessKeyProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AccessKeyPropertyId, "AccessKey");
        public static readonly AutomationProperty AriaPropertiesProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AriaPropertiesPropertyId, "AriaProperties");
        public static readonly AutomationProperty AriaRoleProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AriaRolePropertyId, "AriaRole");
        public static readonly AutomationProperty AutomationIdProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AutomationIdPropertyId, "AutomationId");
        public static readonly AutomationProperty BoundingRectangleProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_BoundingRectanglePropertyId, "BoundingRectangle");
        public static readonly AutomationProperty ClassNameProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ClassNamePropertyId, "ClassName");
        public static readonly AutomationProperty ClickablePointProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ClickablePointPropertyId, "ClickablePoint");
        public static readonly AutomationProperty ControllerForProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ControllerForPropertyId, "ControllerFor");
        public static readonly AutomationProperty ControlTypeProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ControlTypePropertyId, "ControlType");
        public static readonly AutomationProperty CultureProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_CulturePropertyId, "Culture");
        public static readonly AutomationProperty DescribedByProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DescribedByPropertyId, "DescribedBy");
        public static readonly AutomationProperty FlowsFromProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_FlowsFromPropertyId, "FlowsFrom");
        public static readonly AutomationProperty FlowsToProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_FlowsToPropertyId, "FlowsTo");
        public static readonly AutomationProperty FrameworkIdProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_FrameworkIdPropertyId, "FrameworkId");
        public static readonly AutomationProperty HasKeyboardFocusProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_HasKeyboardFocusPropertyId, "HasKeyboardFocus");
        public static readonly AutomationProperty HelpTextProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_HelpTextPropertyId, "HelpText");
        public static readonly AutomationProperty IsContentElementProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsContentElementPropertyId, "IsContentElement");
        public static readonly AutomationProperty IsControlElementProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsControlElementPropertyId, "IsControlElement");
        public static readonly AutomationProperty IsDataValidForFormProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsDataValidForFormPropertyId, "IsDataValidForForm");
        public static readonly AutomationProperty IsEnabledProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsEnabledPropertyId, "IsEnabled");
        public static readonly AutomationProperty IsKeyboardFocusableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsKeyboardFocusablePropertyId, "IsKeyboardFocusable");
        public static readonly AutomationProperty IsOffscreenProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsOffscreenPropertyId, "IsOffscreen");
        public static readonly AutomationProperty IsPasswordProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsPasswordPropertyId, "IsPassword");
        public static readonly AutomationProperty IsPeripheralProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsPeripheralPropertyId, "IsPeripheral");
        public static readonly AutomationProperty IsRequiredForFormProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsRequiredForFormPropertyId, "IsRequiredForForm");
        public static readonly AutomationProperty ItemStatusProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ItemStatusPropertyId, "ItemStatus");
        public static readonly AutomationProperty ItemTypeProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ItemTypePropertyId, "ItemType");
        public static readonly AutomationProperty LabeledByProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LabeledByPropertyId, "LabeledBy");
        public static readonly AutomationProperty LiveSettingProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LiveSettingPropertyId, "LiveSetting");
        public static readonly AutomationProperty LocalizedControlTypeProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_LocalizedControlTypePropertyId, "LocalizedControlType");
        public static readonly AutomationProperty NameProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_NamePropertyId, "Name");
        public static readonly AutomationProperty NativeWindowHandleProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_NativeWindowHandlePropertyId, "NativeWindowHandle");
        public static readonly AutomationProperty OptimizeForVisualContentProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_OptimizeForVisualContentPropertyId, "OptimizeForVisualContent");
        public static readonly AutomationProperty OrientationProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_OrientationPropertyId, "Orientation");
        public static readonly AutomationProperty ProcessIdProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ProcessIdPropertyId, "ProcessId");
        public static readonly AutomationProperty ProviderDescriptionProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_ProviderDescriptionPropertyId, "ProviderDescription");
        public static readonly AutomationProperty RuntimeIdProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_RuntimeIdPropertyId, "RuntimeId");
        // Pattern availability properties
        public static readonly AutomationProperty IsAnnotationPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsAnnotationPatternAvailablePropertyId, "IsAnnotationPatternAvailable");
        public static readonly AutomationProperty IsDockPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsDockPatternAvailablePropertyId, "IsDockPatternAvailable");
        public static readonly AutomationProperty IsDragPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsDragPatternAvailablePropertyId, "IsDragPatternAvailable");
        public static readonly AutomationProperty IsDropTargetPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsDropTargetPatternAvailablePropertyId, "IsDropTargetPatternAvailable");
        public static readonly AutomationProperty IsExpandCollapsePatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsExpandCollapsePatternAvailablePropertyId, "IsExpandCollapsePatternAvailable");
        public static readonly AutomationProperty IsGridItemPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsGridItemPatternAvailablePropertyId, "IsGridItemPatternAvailable");
        public static readonly AutomationProperty IsGridPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsGridPatternAvailablePropertyId, "IsGridPatternAvailable");
        public static readonly AutomationProperty IsInvokePatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsInvokePatternAvailablePropertyId, "IsInvokePatternAvailable");
        public static readonly AutomationProperty IsItemContainerPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsItemContainerPatternAvailablePropertyId, "IsItemContainerPatternAvailable");
        public static readonly AutomationProperty IsLegacyIAccessiblePatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsLegacyIAccessiblePatternAvailablePropertyId, "IsLegacyIAccessiblePatternAvailable");
        public static readonly AutomationProperty IsMultipleViewPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsMultipleViewPatternAvailablePropertyId, "IsMultipleViewPatternAvailable");
        public static readonly AutomationProperty IsObjectModelPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsObjectModelPatternAvailablePropertyId, "IsObjectModelPatternAvailable");
        public static readonly AutomationProperty IsRangeValuePatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsRangeValuePatternAvailablePropertyId, "IsRangeValuePatternAvailable");
        public static readonly AutomationProperty IsScrollItemPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsScrollItemPatternAvailablePropertyId, "IsScrollItemPatternAvailable");
        public static readonly AutomationProperty IsScrollPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsScrollPatternAvailablePropertyId, "IsScrollPatternAvailable");
        public static readonly AutomationProperty IsSelectionItemPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsSelectionItemPatternAvailablePropertyId, "IsSelectionItemPatternAvailable");
        public static readonly AutomationProperty IsSelectionPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsSelectionPatternAvailablePropertyId, "IsSelectionPatternAvailable");
        public static readonly AutomationProperty IsSpreadsheetPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsSpreadsheetPatternAvailablePropertyId, "IsSpreadsheetPatternAvailable");
        public static readonly AutomationProperty IsSpreadsheetItemPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsSpreadsheetItemPatternAvailablePropertyId, "IsSpreadsheetItemPatternAvailable");
        public static readonly AutomationProperty IsStylesPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsStylesPatternAvailablePropertyId, "IsStylesPatternAvailable");
        public static readonly AutomationProperty IsSynchronizedInputPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsSynchronizedInputPatternAvailablePropertyId, "IsSynchronizedInputPatternAvailable");
        public static readonly AutomationProperty IsTableItemPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsTableItemPatternAvailablePropertyId, "IsTableItemPatternAvailable");
        public static readonly AutomationProperty IsTablePatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsTablePatternAvailablePropertyId, "IsTablePatternAvailable");
        public static readonly AutomationProperty IsTextChildPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsTextChildPatternAvailablePropertyId, "IsTextChildPatternAvailable");
        public static readonly AutomationProperty IsTextEditPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsTextEditPatternAvailablePropertyId, "IsTextEditPatternAvailable");
        public static readonly AutomationProperty IsTextPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsTextPatternAvailablePropertyId, "IsTextPatternAvailable");
        public static readonly AutomationProperty IsTextPattern2AvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsTextPattern2AvailablePropertyId, "IsTextPattern2Available");
        public static readonly AutomationProperty IsTogglePatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsTogglePatternAvailablePropertyId, "IsTogglePatternAvailable");
        public static readonly AutomationProperty IsTransformPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsTransformPatternAvailablePropertyId, "IsTransformPatternAvailable");
        public static readonly AutomationProperty IsTransformPattern2AvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsTransformPattern2AvailablePropertyId, "IsTransformPattern2Available");
        public static readonly AutomationProperty IsValuePatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsValuePatternAvailablePropertyId, "IsValuePatternAvailable");
        public static readonly AutomationProperty IsVirtualizedItemPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsVirtualizedItemPatternAvailablePropertyId, "IsVirtualizedItemPatternAvailable");
        public static readonly AutomationProperty IsWindowPatternAvailableProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_IsWindowPatternAvailablePropertyId, "IsWindowPatternAvailable");
        #endregion Property Identifiers
        #region Event identifiers
        public static readonly AutomationEvent AsyncContentLoadedEvent = AutomationEvent.Register(UIA_EventIds.UIA_AsyncContentLoadedEventId, "AsyncContentLoaded");
        public static readonly AutomationEvent AutomationFocusChangedEvent = AutomationEvent.Register(UIA_EventIds.UIA_AutomationFocusChangedEventId, "AutomationFocusChanged");
        public static readonly AutomationEvent AutomationPropertyChangedEvent = AutomationEvent.Register(UIA_EventIds.UIA_AutomationPropertyChangedEventId, "AutomationPropertyChanged");
        public static readonly AutomationEvent HostedFragmentRootsInvalidatedEvent = AutomationEvent.Register(UIA_EventIds.UIA_HostedFragmentRootsInvalidatedEventId, "HostedFragmentRootsInvalidated");
        public static readonly AutomationEvent LayoutInvalidatedEvent = AutomationEvent.Register(UIA_EventIds.UIA_LayoutInvalidatedEventId, "LayoutInvalidated");
        public static readonly AutomationEvent LiveRegionChangedEvent = AutomationEvent.Register(UIA_EventIds.UIA_LiveRegionChangedEventId, "LiveRegionChanged");
        public static readonly AutomationEvent MenuClosedEvent = AutomationEvent.Register(UIA_EventIds.UIA_MenuClosedEventId, "MenuClosed");
        public static readonly AutomationEvent MenuModeEndEvent = AutomationEvent.Register(UIA_EventIds.UIA_MenuModeEndEventId, "MenuModeEnd");
        public static readonly AutomationEvent MenuModeStartEvent = AutomationEvent.Register(UIA_EventIds.UIA_MenuModeStartEventId, "MenuModeStart");
        public static readonly AutomationEvent MenuOpenedEvent = AutomationEvent.Register(UIA_EventIds.UIA_MenuOpenedEventId, "MenuOpened");
        public static readonly AutomationEvent StructureChangedEvent = AutomationEvent.Register(UIA_EventIds.UIA_StructureChangedEventId, "StructureChanged");
        public static readonly AutomationEvent SystemAlertEvent = AutomationEvent.Register(UIA_EventIds.UIA_SystemAlertEventId, "SystemAlert");
        public static readonly AutomationEvent ToolTipClosedEvent = AutomationEvent.Register(UIA_EventIds.UIA_ToolTipClosedEventId, "ToolTipClosed");
        public static readonly AutomationEvent ToolTipOpenedEvent = AutomationEvent.Register(UIA_EventIds.UIA_ToolTipOpenedEventId, "ToolTipOpened");
        #endregion Event identifiers
    }
}
