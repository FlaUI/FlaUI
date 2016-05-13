using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using System;
using System.Linq;
using GdiColor = System.Drawing.Color;
using UIA = interop.UIAutomationCore;
using WpfColor = System.Windows.Media.Color;

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
        public UIA.IUIAutomationElement NativeElement { get; private set; }

        /// <summary>
        /// Native object for Windows 8 ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement2
        {
            get { return GetAutomationElementAs<UIA.IUIAutomationElement2>(); }
        }

        /// <summary>
        /// Native object for Windows 8.1 ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement3
        {
            get { return GetAutomationElementAs<UIA.IUIAutomationElement3>(); }
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
        public AutomationElement(Automation automation, UIA.IUIAutomationElement nativeElement)
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
        public void RegisterEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action)
        {
            Automation.NativeAutomation.AddAutomationEventHandler(@event.Id, NativeElement, (UIA.TreeScope)treeScope, null, new BasicEventHandler(Automation, action));
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
        public void RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action)
        {
            Automation.NativeAutomation.AddStructureChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, null, new StructureChangedEventHandler(Automation, action));
        }

        /// <summary>
        /// Registers for a property changed event
        /// </summary>
        /// <param name="treeScope">The treescope in which the event should be registered</param>
        /// <param name="action">The action to execute when the event fires</param>
        /// <param name="properties">The properties to listen to for a change</param>
        public void RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, params PropertyId[] properties)
        {
            var propertyIds = properties.Select(p => p.Id).ToArray();
            Automation.NativeAutomation.AddPropertyChangedEventHandler(NativeElement,
                (UIA.TreeScope)treeScope, null, new PropertyChangedEventHandler(Automation, action), propertyIds);
        }

        /// <summary>
        /// Sets the focus to this element
        /// Warning: This can be unreliable! <see cref="SetForeground"/> should be more reliable
        /// </summary>
        public void Focus()
        {
            NativeElement.SetFocus();
        }

        /// <summary>
        /// Brings the element to the foreground
        /// </summary>
        public void SetForeground()
        {
            User32.SetForegroundWindow(Current.NativeWindowHandle);
        }

        /// <summary>
        /// Gets a clickable point of the element
        /// </summary>
        /// <exception cref="NoClickablePointException">Thrown when no clickable point was found</exception>
        public Point GetClickablePoint()
        {
            Point point;
            if (!TryGetClickablePoint(out point))
            {
                throw new NoClickablePointException();
            }
            return point;
        }

        /// <summary>
        /// Tries to get a clickable point of the element
        /// </summary>
        /// <param name="point">The clickable point or null, if no point was found</param>
        /// <returns>True if a point was found, false otherwise</returns>
        public bool TryGetClickablePoint(out Point point)
        {
            var tagPoint = new UIA.tagPOINT { x = 0, y = 0 };
            var success = ComCallWrapper.Call(() => NativeElement.GetClickablePoint(out tagPoint)) != 0;
            point = success ? new Point(tagPoint.x, tagPoint.y) : null;
            return success;
        }

        /// <summary>
        /// Draws a red highlight around the element
        /// </summary>
        public AutomationElement DrawHighlight()
        {
            return DrawHighlight(System.Windows.Media.Colors.Red);
        }

        /// <summary>
        /// Draws a manually colored highlight around the element
        /// </summary>
        public AutomationElement DrawHighlight(WpfColor color)
        {
            return DrawHighlight(true, color, 2000);
        }

        /// <summary>
        /// Draws a manually colored highlight around the element
        /// </summary>
        public AutomationElement DrawHighlight(GdiColor color)
        {
            return DrawHighlight(true, color, 2000);
        }

        /// <summary>
        /// Draw a highlight around the element with the given settings 
        /// </summary>
        /// <param name="blocking">Flag to indicate if further execution waits until the highlight is removed</param>
        /// <param name="color">The color to draw the highlight</param>
        /// <param name="durationInMs">The duration (im ms) how long the highlight is shown</param>
        /// <remarks>Override for winforms color</remarks>
        public AutomationElement DrawHighlight(bool blocking, GdiColor color, int durationInMs)
        {
            return DrawHighlight(blocking, WpfColor.FromArgb(color.A, color.R, color.G, color.B), durationInMs);
        }

        /// <summary>
        /// Draw a highlight around the element with the given settings
        /// </summary>
        /// <param name="blocking">Flag to indicate if further execution waits until the highlight is removed</param>
        /// <param name="color">The color to draw the highlight</param>
        /// <param name="durationInMs">The duration (im ms) how long the highlight is shown</param>
        public AutomationElement DrawHighlight(bool blocking, WpfColor color, int durationInMs)
        {
            var rectangle = Current.BoundingRectangle;
            if (!rectangle.IsEmpty)
            {
                if (blocking)
                {
                    Automation.OverlayManager.ShowBlocking(rectangle, color, durationInMs);
                }
                else
                {
                    Automation.OverlayManager.Show(rectangle, color, durationInMs);
                }
            }
            return this;
        }

        /// <summary>
        /// Captures the object as screenshot in WinForms format
        /// </summary>
        public System.Drawing.Bitmap Capture()
        {
            return ScreenCapture.CaptureArea(Current.BoundingRectangle);
        }

        /// <summary>
        /// Captures the object as screenshot in WPF format
        /// </summary>
        public System.Windows.Media.Imaging.BitmapImage CaptureWpf()
        {
            return ScreenCapture.CaptureAreaWpf(Current.BoundingRectangle);
        }

        public void CaptureToFile(string filePath)
        {
            ScreenCapture.CaptureAreaToFile(Current.BoundingRectangle, filePath);
        }

        /// <summary>
        /// Finds all elements in the given treescope and condition
        /// </summary>
        public AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElements = NativeElement.FindAll((UIA.TreeScope)treeScope, condition.ToNative(Automation));
            return NativeValueConverter.NativeArrayToManaged(Automation, nativeFoundElements);
        }

        /// <summary>
        /// Finds the first element which is in the given treescope and matches the condition
        /// </summary>
        public AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElement = NativeElement.FindFirst((UIA.TreeScope)treeScope, condition.ToNative(Automation));
            return NativeValueConverter.NativeToManaged(Automation, nativeFoundElement);
        }

        /// <summary>
        /// Overrides the string representation of the element with something usefull
        /// </summary>
        public override string ToString()
        {
            return String.Format("AutomationId:{0}, Name:{1}, ControlType:{2}, FrameworkId:{3}", Current.AutomationId, Current.Name,
                Current.LocalizedControlType, Current.FrameworkId);
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

        /// <summary>
        /// Gets the desired property value
        /// </summary>
        /// <param name="propertyId">The id of the property to get</param>
        /// <param name="cached">Flag to indicate if the cached or current value should be fetched</param>
        /// <param name="useDefaultIfNotSupported">Flag to indicate, if the default value should be used if the property is not supported</param>
        /// <returns>The value / default value of the property or <see cref="UIA.IUIAutomation.ReservedNotSupportedValue" /></returns>
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
        public static readonly PropertyId AcceleratorKeyProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_AcceleratorKeyPropertyId, "AcceleratorKey");
        public static readonly PropertyId AccessKeyProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_AccessKeyPropertyId, "AccessKey");
        public static readonly PropertyId AriaPropertiesProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_AriaPropertiesPropertyId, "AriaProperties");
        public static readonly PropertyId AriaRoleProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_AriaRolePropertyId, "AriaRole");
        public static readonly PropertyId AutomationIdProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_AutomationIdPropertyId, "AutomationId");
        public static readonly PropertyId BoundingRectangleProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_BoundingRectanglePropertyId, "BoundingRectangle").SetConverter(NativeValueConverter.ToRectangle);
        public static readonly PropertyId ClassNameProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_ClassNamePropertyId, "ClassName");
        public static readonly PropertyId ClickablePointProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_ClickablePointPropertyId, "ClickablePoint").SetConverter(NativeValueConverter.ToPoint);
        public static readonly PropertyId ControllerForProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_ControllerForPropertyId, "ControllerFor");
        public static readonly PropertyId ControlTypeProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_ControlTypePropertyId, "ControlType");
        public static readonly PropertyId CultureProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_CulturePropertyId, "Culture").SetConverter(NativeValueConverter.ToCulture);
        public static readonly PropertyId DescribedByProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_DescribedByPropertyId, "DescribedBy");
        public static readonly PropertyId FlowsFromProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_FlowsFromPropertyId, "FlowsFrom");
        public static readonly PropertyId FlowsToProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_FlowsToPropertyId, "FlowsTo");
        public static readonly PropertyId FrameworkIdProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_FrameworkIdPropertyId, "FrameworkId");
        public static readonly PropertyId HasKeyboardFocusProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_HasKeyboardFocusPropertyId, "HasKeyboardFocus");
        public static readonly PropertyId HelpTextProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_HelpTextPropertyId, "HelpText");
        public static readonly PropertyId IsContentElementProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsContentElementPropertyId, "IsContentElement");
        public static readonly PropertyId IsControlElementProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsControlElementPropertyId, "IsControlElement");
        public static readonly PropertyId IsDataValidForFormProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsDataValidForFormPropertyId, "IsDataValidForForm");
        public static readonly PropertyId IsEnabledProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsEnabledPropertyId, "IsEnabled");
        public static readonly PropertyId IsKeyboardFocusableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsKeyboardFocusablePropertyId, "IsKeyboardFocusable");
        public static readonly PropertyId IsOffscreenProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsOffscreenPropertyId, "IsOffscreen");
        public static readonly PropertyId IsPasswordProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsPasswordPropertyId, "IsPassword");
        public static readonly PropertyId IsPeripheralProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsPeripheralPropertyId, "IsPeripheral");
        public static readonly PropertyId IsRequiredForFormProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsRequiredForFormPropertyId, "IsRequiredForForm");
        public static readonly PropertyId ItemStatusProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_ItemStatusPropertyId, "ItemStatus");
        public static readonly PropertyId ItemTypeProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_ItemTypePropertyId, "ItemType");
        public static readonly PropertyId LabeledByProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LabeledByPropertyId, "LabeledBy");
        public static readonly PropertyId LiveSettingProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LiveSettingPropertyId, "LiveSetting");
        public static readonly PropertyId LocalizedControlTypeProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_LocalizedControlTypePropertyId, "LocalizedControlType");
        public static readonly PropertyId NameProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_NamePropertyId, "Name");
        public static readonly PropertyId NativeWindowHandleProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_NativeWindowHandlePropertyId, "NativeWindowHandle").SetConverter(NativeValueConverter.IntToIntPtr);
        public static readonly PropertyId OptimizeForVisualContentProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_OptimizeForVisualContentPropertyId, "OptimizeForVisualContent");
        public static readonly PropertyId OrientationProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_OrientationPropertyId, "Orientation");
        public static readonly PropertyId ProcessIdProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_ProcessIdPropertyId, "ProcessId");
        public static readonly PropertyId ProviderDescriptionProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_ProviderDescriptionPropertyId, "ProviderDescription");
        public static readonly PropertyId RuntimeIdProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_RuntimeIdPropertyId, "RuntimeId");
        // Pattern availability properties
        public static readonly PropertyId IsAnnotationPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsAnnotationPatternAvailablePropertyId, "IsAnnotationPatternAvailable");
        public static readonly PropertyId IsDockPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsDockPatternAvailablePropertyId, "IsDockPatternAvailable");
        public static readonly PropertyId IsDragPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsDragPatternAvailablePropertyId, "IsDragPatternAvailable");
        public static readonly PropertyId IsDropTargetPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsDropTargetPatternAvailablePropertyId, "IsDropTargetPatternAvailable");
        public static readonly PropertyId IsExpandCollapsePatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsExpandCollapsePatternAvailablePropertyId, "IsExpandCollapsePatternAvailable");
        public static readonly PropertyId IsGridItemPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsGridItemPatternAvailablePropertyId, "IsGridItemPatternAvailable");
        public static readonly PropertyId IsGridPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsGridPatternAvailablePropertyId, "IsGridPatternAvailable");
        public static readonly PropertyId IsInvokePatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsInvokePatternAvailablePropertyId, "IsInvokePatternAvailable");
        public static readonly PropertyId IsItemContainerPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsItemContainerPatternAvailablePropertyId, "IsItemContainerPatternAvailable");
        public static readonly PropertyId IsLegacyIAccessiblePatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsLegacyIAccessiblePatternAvailablePropertyId, "IsLegacyIAccessiblePatternAvailable");
        public static readonly PropertyId IsMultipleViewPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsMultipleViewPatternAvailablePropertyId, "IsMultipleViewPatternAvailable");
        public static readonly PropertyId IsObjectModelPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsObjectModelPatternAvailablePropertyId, "IsObjectModelPatternAvailable");
        public static readonly PropertyId IsRangeValuePatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsRangeValuePatternAvailablePropertyId, "IsRangeValuePatternAvailable");
        public static readonly PropertyId IsScrollItemPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsScrollItemPatternAvailablePropertyId, "IsScrollItemPatternAvailable");
        public static readonly PropertyId IsScrollPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsScrollPatternAvailablePropertyId, "IsScrollPatternAvailable");
        public static readonly PropertyId IsSelectionItemPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsSelectionItemPatternAvailablePropertyId, "IsSelectionItemPatternAvailable");
        public static readonly PropertyId IsSelectionPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsSelectionPatternAvailablePropertyId, "IsSelectionPatternAvailable");
        public static readonly PropertyId IsSpreadsheetPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsSpreadsheetPatternAvailablePropertyId, "IsSpreadsheetPatternAvailable");
        public static readonly PropertyId IsSpreadsheetItemPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsSpreadsheetItemPatternAvailablePropertyId, "IsSpreadsheetItemPatternAvailable");
        public static readonly PropertyId IsStylesPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsStylesPatternAvailablePropertyId, "IsStylesPatternAvailable");
        public static readonly PropertyId IsSynchronizedInputPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsSynchronizedInputPatternAvailablePropertyId, "IsSynchronizedInputPatternAvailable");
        public static readonly PropertyId IsTableItemPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsTableItemPatternAvailablePropertyId, "IsTableItemPatternAvailable");
        public static readonly PropertyId IsTablePatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsTablePatternAvailablePropertyId, "IsTablePatternAvailable");
        public static readonly PropertyId IsTextChildPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsTextChildPatternAvailablePropertyId, "IsTextChildPatternAvailable");
        public static readonly PropertyId IsTextEditPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsTextEditPatternAvailablePropertyId, "IsTextEditPatternAvailable");
        public static readonly PropertyId IsTextPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsTextPatternAvailablePropertyId, "IsTextPatternAvailable");
        public static readonly PropertyId IsTextPattern2AvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsTextPattern2AvailablePropertyId, "IsTextPattern2Available");
        public static readonly PropertyId IsTogglePatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsTogglePatternAvailablePropertyId, "IsTogglePatternAvailable");
        public static readonly PropertyId IsTransformPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsTransformPatternAvailablePropertyId, "IsTransformPatternAvailable");
        public static readonly PropertyId IsTransformPattern2AvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsTransformPattern2AvailablePropertyId, "IsTransformPattern2Available");
        public static readonly PropertyId IsValuePatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsValuePatternAvailablePropertyId, "IsValuePatternAvailable");
        public static readonly PropertyId IsVirtualizedItemPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsVirtualizedItemPatternAvailablePropertyId, "IsVirtualizedItemPatternAvailable");
        public static readonly PropertyId IsWindowPatternAvailableProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_IsWindowPatternAvailablePropertyId, "IsWindowPatternAvailable");
        #endregion Property Identifiers
        #region Event identifiers
        public static readonly EventId AsyncContentLoadedEvent = EventId.Register(UIA.UIA_EventIds.UIA_AsyncContentLoadedEventId, "AsyncContentLoaded");
        public static readonly EventId FocusChangedEvent = EventId.Register(UIA.UIA_EventIds.UIA_AutomationFocusChangedEventId, "AutomationFocusChanged");
        public static readonly EventId PropertyChangedEvent = EventId.Register(UIA.UIA_EventIds.UIA_AutomationPropertyChangedEventId, "AutomationPropertyChanged");
        public static readonly EventId HostedFragmentRootsInvalidatedEvent = EventId.Register(UIA.UIA_EventIds.UIA_HostedFragmentRootsInvalidatedEventId, "HostedFragmentRootsInvalidated");
        public static readonly EventId LayoutInvalidatedEvent = EventId.Register(UIA.UIA_EventIds.UIA_LayoutInvalidatedEventId, "LayoutInvalidated");
        public static readonly EventId LiveRegionChangedEvent = EventId.Register(UIA.UIA_EventIds.UIA_LiveRegionChangedEventId, "LiveRegionChanged");
        public static readonly EventId MenuClosedEvent = EventId.Register(UIA.UIA_EventIds.UIA_MenuClosedEventId, "MenuClosed");
        public static readonly EventId MenuModeEndEvent = EventId.Register(UIA.UIA_EventIds.UIA_MenuModeEndEventId, "MenuModeEnd");
        public static readonly EventId MenuModeStartEvent = EventId.Register(UIA.UIA_EventIds.UIA_MenuModeStartEventId, "MenuModeStart");
        public static readonly EventId MenuOpenedEvent = EventId.Register(UIA.UIA_EventIds.UIA_MenuOpenedEventId, "MenuOpened");
        public static readonly EventId StructureChangedEvent = EventId.Register(UIA.UIA_EventIds.UIA_StructureChangedEventId, "StructureChanged");
        public static readonly EventId SystemAlertEvent = EventId.Register(UIA.UIA_EventIds.UIA_SystemAlertEventId, "SystemAlert");
        public static readonly EventId ToolTipClosedEvent = EventId.Register(UIA.UIA_EventIds.UIA_ToolTipClosedEventId, "ToolTipClosed");
        public static readonly EventId ToolTipOpenedEvent = EventId.Register(UIA.UIA_EventIds.UIA_ToolTipOpenedEventId, "ToolTipOpened");
        #endregion Event identifiers
    }

    /// <summary>
    /// Class with extension methods to convert the element to a specific class
    /// </summary>
    public static class AutomationElementConversionExtensions
    {
        public static Button AsButton(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Button(automationElement.Automation, automationElement.NativeElement);
        }

        public static CheckBox AsCheckBox(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new CheckBox(automationElement.Automation, automationElement.NativeElement);
        }

        public static RadioButton AsRadioButton(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new RadioButton(automationElement.Automation, automationElement.NativeElement);
        }

        public static Window AsWindow(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Window(automationElement.Automation, automationElement.NativeElement);
        }

        public static Label AsLabel(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Label(automationElement.Automation, automationElement.NativeElement);
        }

        public static TitleBar AsTitleBar(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new TitleBar(automationElement.Automation, automationElement.NativeElement);
        }

        public static Menu AsMenu(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Menu(automationElement.Automation, automationElement.NativeElement);
        }

        public static MenuItem AsMenuItem(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new MenuItem(automationElement.Automation, automationElement.NativeElement);
        }

        public static Tab AsTab(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Tab(automationElement.Automation, automationElement.NativeElement);
        }

        public static TabItem AsTabItem(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new TabItem(automationElement.Automation, automationElement.NativeElement);
        }

        public static ProgressBar AsProgressBar(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new ProgressBar(automationElement.Automation, automationElement.NativeElement);
        }

        public static Slider AsSlider(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            if (automationElement.Current.FrameworkId == FrameworkIds.Wpf)
            {
                return new WpfSlider(automationElement.Automation, automationElement.NativeElement);
            }
            if (automationElement.Current.FrameworkId == FrameworkIds.WinForms)
            {
                return new WinFormsSlider(automationElement.Automation, automationElement.NativeElement);
            }
            return new Slider(automationElement.Automation, automationElement.NativeElement);
        }

        public static Thumb AsThumb(this AutomationElement automationElement)
        {
            if (automationElement == null) { return null; }
            return new Thumb(automationElement.Automation, automationElement.NativeElement);
        }
    }
}
