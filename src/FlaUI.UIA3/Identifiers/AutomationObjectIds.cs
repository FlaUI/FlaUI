using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Converters;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Identifiers
{
    public static class AutomationObjectIds
    {
        #region Property Identifiers
        // Base element properties
        public static readonly PropertyId AcceleratorKeyProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AcceleratorKeyPropertyId, "AcceleratorKey");
        public static readonly PropertyId AccessKeyProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AccessKeyPropertyId, "AccessKey");
        public static readonly PropertyId AnnotationObjectsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationObjectsPropertyId, "AnnotationObjects");
        public static readonly PropertyId AnnotationTypesProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationTypesPropertyId, "AnnotationTypes");
        public static readonly PropertyId AriaPropertiesProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AriaPropertiesPropertyId, "AriaProperties");
        public static readonly PropertyId AriaRoleProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AriaRolePropertyId, "AriaRole");
        public static readonly PropertyId AutomationIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AutomationIdPropertyId, "AutomationId");
        public static readonly PropertyId BoundingRectangleProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_BoundingRectanglePropertyId, "BoundingRectangle").SetConverter((a, o) => ValueConverter.ToRectangle(o));
        public static readonly PropertyId CenterPointProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_CenterPointPropertyId, "CenterPoint");
        public static readonly PropertyId ClassNameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ClassNamePropertyId, "ClassName");
        public static readonly PropertyId ClickablePointProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ClickablePointPropertyId, "ClickablePoint").SetConverter((a, o) => ValueConverter.ToPoint(o));
        public static readonly PropertyId ControllerForProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ControllerForPropertyId, "ControllerFor").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly PropertyId ControlTypeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ControlTypePropertyId, "ControlType").SetConverter((a, o) => ControlTypeConverter.ToControlType(o));
        public static readonly PropertyId CultureProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_CulturePropertyId, "Culture").SetConverter((a, o) => ValueConverter.ToCulture(o));
        public static readonly PropertyId DescribedByProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DescribedByPropertyId, "DescribedBy");
        public static readonly PropertyId FillColorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_FillColorPropertyId, "FillColor");
        public static readonly PropertyId FillTypeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_FillTypePropertyId, "FillType");
        public static readonly PropertyId FlowsFromProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_FlowsFromPropertyId, "FlowsFrom");
        public static readonly PropertyId FlowsToProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_FlowsToPropertyId, "FlowsTo");
        public static readonly PropertyId FrameworkIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_FrameworkIdPropertyId, "FrameworkId");
        public static readonly PropertyId FullDescriptionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_FullDescriptionPropertyId, "FullDescription");
        public static readonly PropertyId HasKeyboardFocusProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_HasKeyboardFocusPropertyId, "HasKeyboardFocus");
        public static readonly PropertyId HelpTextProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_HelpTextPropertyId, "HelpText");
        public static readonly PropertyId IsContentElementProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsContentElementPropertyId, "IsContentElement");
        public static readonly PropertyId IsControlElementProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsControlElementPropertyId, "IsControlElement");
        public static readonly PropertyId IsDataValidForFormProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsDataValidForFormPropertyId, "IsDataValidForForm");
        public static readonly PropertyId IsEnabledProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsEnabledPropertyId, "IsEnabled");
        public static readonly PropertyId IsKeyboardFocusableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsKeyboardFocusablePropertyId, "IsKeyboardFocusable");
        public static readonly PropertyId IsOffscreenProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsOffscreenPropertyId, "IsOffscreen");
        public static readonly PropertyId IsPasswordProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsPasswordPropertyId, "IsPassword");
        public static readonly PropertyId IsPeripheralProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsPeripheralPropertyId, "IsPeripheral");
        public static readonly PropertyId IsRequiredForFormProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsRequiredForFormPropertyId, "IsRequiredForForm");
        public static readonly PropertyId ItemStatusProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ItemStatusPropertyId, "ItemStatus");
        public static readonly PropertyId ItemTypeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ItemTypePropertyId, "ItemType");
        public static readonly PropertyId LabeledByProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LabeledByPropertyId, "LabeledBy");
        public static readonly PropertyId LandmarkTypeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LandmarkTypePropertyId, "LandmarkType");
        public static readonly PropertyId LevelProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LevelPropertyId, "Level");
        public static readonly PropertyId LiveSettingProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LiveSettingPropertyId, "LiveSetting");
        public static readonly PropertyId LocalizedControlTypeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LocalizedControlTypePropertyId, "LocalizedControlType");
        public static readonly PropertyId LocalizedLandmarkTypeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_LocalizedLandmarkTypePropertyId, "LocalizedLandmarkType");
        public static readonly PropertyId NameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_NamePropertyId, "Name");
        public static readonly PropertyId NativeWindowHandleProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_NativeWindowHandlePropertyId, "NativeWindowHandle").SetConverter((a, o) => ValueConverter.IntToIntPtr(o));
        public static readonly PropertyId OptimizeForVisualContentProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_OptimizeForVisualContentPropertyId, "OptimizeForVisualContent");
        public static readonly PropertyId OrientationProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_OrientationPropertyId, "Orientation");
        public static readonly PropertyId OutlineColorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_OutlineColorPropertyId, "OutlineColor");
        public static readonly PropertyId OutlineThicknessProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_OutlineThicknessPropertyId, "OutlineThickness");
        public static readonly PropertyId PositionInSetProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_PositionInSetPropertyId, "PositionInSet");
        public static readonly PropertyId ProcessIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ProcessIdPropertyId, "ProcessId");
        public static readonly PropertyId ProviderDescriptionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ProviderDescriptionPropertyId, "ProviderDescription");
        public static readonly PropertyId RotationProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_RotationPropertyId, "Rotation");
        public static readonly PropertyId RuntimeIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_RuntimeIdPropertyId, "RuntimeId");
        public static readonly PropertyId SizeOfSetProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SizeOfSetPropertyId, "SizeOfSet");
        public static readonly PropertyId SizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SizePropertyId, "Size");
        public static readonly PropertyId VisualEffectsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_VisualEffectsPropertyId, "VisualEffects");
        // Pattern availability properties
        public static readonly PropertyId IsAnnotationPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsAnnotationPatternAvailablePropertyId, "IsAnnotationPatternAvailable");
        public static readonly PropertyId IsDockPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsDockPatternAvailablePropertyId, "IsDockPatternAvailable");
        public static readonly PropertyId IsDragPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsDragPatternAvailablePropertyId, "IsDragPatternAvailable");
        public static readonly PropertyId IsDropTargetPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsDropTargetPatternAvailablePropertyId, "IsDropTargetPatternAvailable");
        public static readonly PropertyId IsExpandCollapsePatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsExpandCollapsePatternAvailablePropertyId, "IsExpandCollapsePatternAvailable");
        public static readonly PropertyId IsGridItemPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsGridItemPatternAvailablePropertyId, "IsGridItemPatternAvailable");
        public static readonly PropertyId IsGridPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsGridPatternAvailablePropertyId, "IsGridPatternAvailable");
        public static readonly PropertyId IsInvokePatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsInvokePatternAvailablePropertyId, "IsInvokePatternAvailable");
        public static readonly PropertyId IsItemContainerPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsItemContainerPatternAvailablePropertyId, "IsItemContainerPatternAvailable");
        public static readonly PropertyId IsLegacyIAccessiblePatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsLegacyIAccessiblePatternAvailablePropertyId, "IsLegacyIAccessiblePatternAvailable");
        public static readonly PropertyId IsMultipleViewPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsMultipleViewPatternAvailablePropertyId, "IsMultipleViewPatternAvailable");
        public static readonly PropertyId IsObjectModelPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsObjectModelPatternAvailablePropertyId, "IsObjectModelPatternAvailable");
        public static readonly PropertyId IsRangeValuePatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsRangeValuePatternAvailablePropertyId, "IsRangeValuePatternAvailable");
        public static readonly PropertyId IsScrollItemPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsScrollItemPatternAvailablePropertyId, "IsScrollItemPatternAvailable");
        public static readonly PropertyId IsScrollPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsScrollPatternAvailablePropertyId, "IsScrollPatternAvailable");
        public static readonly PropertyId IsSelectionItemPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsSelectionItemPatternAvailablePropertyId, "IsSelectionItemPatternAvailable");
        public static readonly PropertyId IsSelectionPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsSelectionPatternAvailablePropertyId, "IsSelectionPatternAvailable");
        public static readonly PropertyId IsSelectionPattern2AvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsSelectionPattern2AvailablePropertyId, "IsSelectionPattern2Available");
        public static readonly PropertyId IsSpreadsheetPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsSpreadsheetPatternAvailablePropertyId, "IsSpreadsheetPatternAvailable");
        public static readonly PropertyId IsSpreadsheetItemPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsSpreadsheetItemPatternAvailablePropertyId, "IsSpreadsheetItemPatternAvailable");
        public static readonly PropertyId IsStylesPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsStylesPatternAvailablePropertyId, "IsStylesPatternAvailable");
        public static readonly PropertyId IsSynchronizedInputPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsSynchronizedInputPatternAvailablePropertyId, "IsSynchronizedInputPatternAvailable");
        public static readonly PropertyId IsTableItemPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsTableItemPatternAvailablePropertyId, "IsTableItemPatternAvailable");
        public static readonly PropertyId IsTablePatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsTablePatternAvailablePropertyId, "IsTablePatternAvailable");
        public static readonly PropertyId IsTextChildPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsTextChildPatternAvailablePropertyId, "IsTextChildPatternAvailable");
        public static readonly PropertyId IsTextEditPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsTextEditPatternAvailablePropertyId, "IsTextEditPatternAvailable");
        public static readonly PropertyId IsTextPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsTextPatternAvailablePropertyId, "IsTextPatternAvailable");
        public static readonly PropertyId IsTextPattern2AvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsTextPattern2AvailablePropertyId, "IsTextPattern2Available");
        public static readonly PropertyId IsTogglePatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsTogglePatternAvailablePropertyId, "IsTogglePatternAvailable");
        public static readonly PropertyId IsTransformPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsTransformPatternAvailablePropertyId, "IsTransformPatternAvailable");
        public static readonly PropertyId IsTransformPattern2AvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsTransformPattern2AvailablePropertyId, "IsTransformPattern2Available");
        public static readonly PropertyId IsValuePatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsValuePatternAvailablePropertyId, "IsValuePatternAvailable");
        public static readonly PropertyId IsVirtualizedItemPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsVirtualizedItemPatternAvailablePropertyId, "IsVirtualizedItemPatternAvailable");
        public static readonly PropertyId IsWindowPatternAvailableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_IsWindowPatternAvailablePropertyId, "IsWindowPatternAvailable");
        #endregion Property Identifiers

        #region Event identifiers
        public static readonly EventId AsyncContentLoadedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_AsyncContentLoadedEventId, "AsyncContentLoaded");
        public static readonly EventId ChangesEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_ChangesEventId, "Changes");
        public static readonly EventId FocusChangedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_AutomationFocusChangedEventId, "AutomationFocusChanged");
        public static readonly EventId PropertyChangedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_AutomationPropertyChangedEventId, "AutomationPropertyChanged");
        public static readonly EventId HostedFragmentRootsInvalidatedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_HostedFragmentRootsInvalidatedEventId, "HostedFragmentRootsInvalidated");
        public static readonly EventId LayoutInvalidatedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_LayoutInvalidatedEventId, "LayoutInvalidated");
        public static readonly EventId LiveRegionChangedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_LiveRegionChangedEventId, "LiveRegionChanged");
        public static readonly EventId MenuClosedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_MenuClosedEventId, "MenuClosed");
        public static readonly EventId MenuModeEndEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_MenuModeEndEventId, "MenuModeEnd");
        public static readonly EventId MenuModeStartEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_MenuModeStartEventId, "MenuModeStart");
        public static readonly EventId MenuOpenedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_MenuOpenedEventId, "MenuOpened");
        public static readonly EventId NotificationEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_NotificationEventId, "Notification");
        public static readonly EventId StructureChangedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_StructureChangedEventId, "StructureChanged");
        public static readonly EventId SystemAlertEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_SystemAlertEventId, "SystemAlert");
        public static readonly EventId ToolTipClosedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_ToolTipClosedEventId, "ToolTipClosed");
        public static readonly EventId ToolTipOpenedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_ToolTipOpenedEventId, "ToolTipOpened");
        #endregion Event identifiers
    }
}
