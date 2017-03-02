using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Converters;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Identifiers
{
    public static class AutomationObjectIds
    {
        #region Property Identifiers
        // Base element properties
        public static readonly PropertyId AcceleratorKeyProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.AcceleratorKeyProperty.Id, "AcceleratorKey");
        public static readonly PropertyId AccessKeyProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.AccessKeyProperty.Id, "AccessKey");
        public static readonly PropertyId AutomationIdProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.AutomationIdProperty.Id, "AutomationId");
        public static readonly PropertyId BoundingRectangleProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.BoundingRectangleProperty.Id, "BoundingRectangle").SetConverter((a, o) => ValueConverter.ToRectangle(o));
        public static readonly PropertyId ClassNameProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.ClassNameProperty.Id, "ClassName");
        public static readonly PropertyId ClickablePointProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.ClickablePointProperty.Id, "ClickablePoint").SetConverter((a, o) => ValueConverter.ToPoint(o));
        public static readonly PropertyId ControlTypeProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.ControlTypeProperty.Id, "ControlType").SetConverter((a, o) => ControlTypeConverter.ToControlType(o));
        public static readonly PropertyId CultureProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.CultureProperty.Id, "Culture").SetConverter((a, o) => ValueConverter.ToCulture(o));
        public static readonly PropertyId FrameworkIdProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.FrameworkIdProperty.Id, "FrameworkId");
        public static readonly PropertyId HasKeyboardFocusProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.HasKeyboardFocusProperty.Id, "HasKeyboardFocus");
        public static readonly PropertyId HelpTextProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.HelpTextProperty.Id, "HelpText");
        public static readonly PropertyId IsContentElementProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.IsContentElementProperty.Id, "IsContentElement");
        public static readonly PropertyId IsControlElementProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.IsControlElementProperty.Id, "IsControlElement");
        public static readonly PropertyId IsEnabledProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.IsEnabledProperty.Id, "IsEnabled");
        public static readonly PropertyId IsKeyboardFocusableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.IsKeyboardFocusableProperty.Id, "IsKeyboardFocusable");
        public static readonly PropertyId IsOffscreenProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.IsOffscreenProperty.Id, "IsOffscreen");
        public static readonly PropertyId IsPasswordProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.IsPasswordProperty.Id, "IsPassword");
        public static readonly PropertyId IsRequiredForFormProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.IsRequiredForFormProperty.Id, "IsRequiredForForm");
        public static readonly PropertyId ItemStatusProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.ItemStatusProperty.Id, "ItemStatus");
        public static readonly PropertyId ItemTypeProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.ItemTypeProperty.Id, "ItemType");
        public static readonly PropertyId LabeledByProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.LabeledByProperty.Id, "LabeledBy");
        public static readonly PropertyId LocalizedControlTypeProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.LocalizedControlTypeProperty.Id, "LocalizedControlType");
        public static readonly PropertyId NameProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.NameProperty.Id, "Name");
        public static readonly PropertyId NativeWindowHandleProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.NativeWindowHandleProperty.Id, "NativeWindowHandle").SetConverter((a, o) => ValueConverter.IntToIntPtr(o));
        public static readonly PropertyId OrientationProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.OrientationProperty.Id, "Orientation");
        public static readonly PropertyId ProcessIdProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.ProcessIdProperty.Id, "ProcessId");
        public static readonly PropertyId RuntimeIdProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.RuntimeIdProperty.Id, "RuntimeId");
        // Pattern availability properties
        public static readonly PropertyId IsDockPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsDockPatternAvailableProperty.Id, "IsDockPatternAvailable");
        public static readonly PropertyId IsExpandCollapsePatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsExpandCollapsePatternAvailableProperty.Id, "IsExpandCollapsePatternAvailable");
        public static readonly PropertyId IsGridItemPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsGridItemPatternAvailableProperty.Id, "IsGridItemPatternAvailable");
        public static readonly PropertyId IsGridPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsGridPatternAvailableProperty.Id, "IsGridPatternAvailable");
        public static readonly PropertyId IsInvokePatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsInvokePatternAvailableProperty.Id, "IsInvokePatternAvailable");
#if !NET35
        public static readonly PropertyId IsItemContainerPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsItemContainerPatternAvailableProperty.Id, "IsItemContainerPatternAvailable");
#endif
        public static readonly PropertyId IsMultipleViewPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsMultipleViewPatternAvailableProperty.Id, "IsMultipleViewPatternAvailable");
        public static readonly PropertyId IsRangeValuePatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsRangeValuePatternAvailableProperty.Id, "IsRangeValuePatternAvailable");
        public static readonly PropertyId IsScrollItemPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsScrollItemPatternAvailableProperty.Id, "IsScrollItemPatternAvailable");
        public static readonly PropertyId IsScrollPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsScrollPatternAvailableProperty.Id, "IsScrollPatternAvailable");
        public static readonly PropertyId IsSelectionItemPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsSelectionItemPatternAvailableProperty.Id, "IsSelectionItemPatternAvailable");
        public static readonly PropertyId IsSelectionPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsSelectionPatternAvailableProperty.Id, "IsSelectionPatternAvailable");
#if !NET35
        public static readonly PropertyId IsSynchronizedInputPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsSynchronizedInputPatternAvailableProperty.Id, "IsSynchronizedInputPatternAvailable");
#endif
        public static readonly PropertyId IsTableItemPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsTableItemPatternAvailableProperty.Id, "IsTableItemPatternAvailable");
        public static readonly PropertyId IsTablePatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsTablePatternAvailableProperty.Id, "IsTablePatternAvailable");
        public static readonly PropertyId IsTextPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsTextPatternAvailableProperty.Id, "IsTextPatternAvailable");
        public static readonly PropertyId IsTogglePatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsTogglePatternAvailableProperty.Id, "IsTogglePatternAvailable");
        public static readonly PropertyId IsTransformPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsTransformPatternAvailableProperty.Id, "IsTransformPatternAvailable");
        public static readonly PropertyId IsValuePatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsValuePatternAvailableProperty.Id, "IsValuePatternAvailable");
#if !NET35
        public static readonly PropertyId IsVirtualizedItemPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsVirtualizedItemPatternAvailableProperty.Id, "IsVirtualizedItemPatternAvailable");
#endif
        public static readonly PropertyId IsWindowPatternAvailableProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElement.IsWindowPatternAvailableProperty.Id, "IsWindowPatternAvailable");
        #endregion Property Identifiers

        #region Event identifiers
        public static readonly EventId AsyncContentLoadedEvent = EventId.Register(AutomationType.UIA2, UIA.AutomationElement.AsyncContentLoadedEvent.Id, "AsyncContentLoaded");
        public static readonly EventId FocusChangedEvent = EventId.Register(AutomationType.UIA2, UIA.AutomationElement.AutomationFocusChangedEvent.Id, "AutomationFocusChanged");
        public static readonly EventId PropertyChangedEvent = EventId.Register(AutomationType.UIA2, UIA.AutomationElement.AutomationPropertyChangedEvent.Id, "AutomationPropertyChanged");
        public static readonly EventId LayoutInvalidatedEvent = EventId.Register(AutomationType.UIA2, UIA.AutomationElement.LayoutInvalidatedEvent.Id, "LayoutInvalidated");
        public static readonly EventId MenuClosedEvent = EventId.Register(AutomationType.UIA2, UIA.AutomationElement.MenuClosedEvent.Id, "MenuClosed");
        public static readonly EventId MenuOpenedEvent = EventId.Register(AutomationType.UIA2, UIA.AutomationElement.MenuOpenedEvent.Id, "MenuOpened");
        public static readonly EventId StructureChangedEvent = EventId.Register(AutomationType.UIA2, UIA.AutomationElement.StructureChangedEvent.Id, "StructureChanged");
        public static readonly EventId ToolTipClosedEvent = EventId.Register(AutomationType.UIA2, UIA.AutomationElement.ToolTipClosedEvent.Id, "ToolTipClosed");
        public static readonly EventId ToolTipOpenedEvent = EventId.Register(AutomationType.UIA2, UIA.AutomationElement.ToolTipOpenedEvent.Id, "ToolTipOpened");
        #endregion Event identifiers
    }
}
