using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Tools;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public static class AutomationObjectIds
    {
        // Base element properties
        public static readonly PropertyId AcceleratorKeyProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.AcceleratorKeyProperty.Id, "AcceleratorKey");
        public static readonly PropertyId AccessKeyProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.AccessKeyProperty.Id, "AccessKey");
        public static readonly PropertyId AutomationIdProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.AutomationIdProperty.Id, "AutomationId");
        public static readonly PropertyId BoundingRectangleProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.BoundingRectangleProperty.Id, "BoundingRectangle").SetConverter(NativeValueConverter.ToRectangle);
        public static readonly PropertyId ClassNameProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.ClassNameProperty.Id, "ClassName");
        public static readonly PropertyId ClickablePointProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.ClickablePointProperty.Id, "ClickablePoint").SetConverter(NativeValueConverter.ToPoint);
        public static readonly PropertyId ControlTypeProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.ControlTypeProperty.Id, "ControlType");
        public static readonly PropertyId CultureProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.CultureProperty.Id, "Culture").SetConverter(NativeValueConverter.ToCulture);
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
        public static readonly PropertyId NativeWindowHandleProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.NativeWindowHandleProperty.Id, "NativeWindowHandle").SetConverter(NativeValueConverter.IntToIntPtr);
        public static readonly PropertyId OrientationProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.OrientationProperty.Id, "Orientation");
        public static readonly PropertyId ProcessIdProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.ProcessIdProperty.Id, "ProcessId");
        public static readonly PropertyId RuntimeIdProperty = PropertyId.Register(AutomationType.UIA2, UIA.AutomationElementIdentifiers.RuntimeIdProperty.Id, "RuntimeId");
    }
}
