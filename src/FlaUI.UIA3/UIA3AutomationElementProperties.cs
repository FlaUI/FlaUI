using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Identifiers;

namespace FlaUI.UIA3
{
    public class UIA3AutomationElementProperties : IAutomationElementProperties
    {
        public PropertyId AcceleratorKey => AutomationObjectIds.AcceleratorKeyProperty;
        public PropertyId AccessKey => AutomationObjectIds.AccessKeyProperty;
        public PropertyId AriaProperties => AutomationObjectIds.AriaPropertiesProperty;
        public PropertyId AriaRole => AutomationObjectIds.AriaRoleProperty;
        public PropertyId AutomationId => AutomationObjectIds.AutomationIdProperty;
        public PropertyId BoundingRectangle => AutomationObjectIds.BoundingRectangleProperty;
        public PropertyId ClassName => AutomationObjectIds.ClassNameProperty;
        public PropertyId ClickablePoint => AutomationObjectIds.ClickablePointProperty;
        public PropertyId ControllerFor => AutomationObjectIds.ControllerForProperty;
        public PropertyId ControlType => AutomationObjectIds.ControlTypeProperty;
        public PropertyId Culture => AutomationObjectIds.CultureProperty;
        public PropertyId DescribedBy => AutomationObjectIds.DescribedByProperty;
        public PropertyId FlowsFrom => AutomationObjectIds.FlowsFromProperty;
        public PropertyId FlowsTo => AutomationObjectIds.FlowsToProperty;
        public PropertyId FrameworkId => AutomationObjectIds.FrameworkIdProperty;
        public PropertyId HasKeyboardFocus => AutomationObjectIds.HasKeyboardFocusProperty;
        public PropertyId HelpText => AutomationObjectIds.HelpTextProperty;
        public PropertyId IsContentElement => AutomationObjectIds.IsContentElementProperty;
        public PropertyId IsControlElement => AutomationObjectIds.IsControlElementProperty;
        public PropertyId IsDataValidForForm => AutomationObjectIds.IsDataValidForFormProperty;
        public PropertyId IsEnabled => AutomationObjectIds.IsEnabledProperty;
        public PropertyId IsKeyboardFocusable => AutomationObjectIds.IsKeyboardFocusableProperty;
        public PropertyId IsOffscreen => AutomationObjectIds.IsOffscreenProperty;
        public PropertyId IsPassword => AutomationObjectIds.IsPasswordProperty;
        public PropertyId IsPeripheral => AutomationObjectIds.IsPeripheralProperty;
        public PropertyId IsRequiredForForm => AutomationObjectIds.IsRequiredForFormProperty;
        public PropertyId ItemStatus => AutomationObjectIds.ItemStatusProperty;
        public PropertyId ItemType => AutomationObjectIds.ItemTypeProperty;
        public PropertyId LabeledBy => AutomationObjectIds.AcceleratorKeyProperty;
        public PropertyId LiveSetting => AutomationObjectIds.LiveSettingProperty;
        public PropertyId LocalizedControlType => AutomationObjectIds.LocalizedControlTypeProperty;
        public PropertyId Name => AutomationObjectIds.NameProperty;
        public PropertyId NativeWindowHandle => AutomationObjectIds.NativeWindowHandleProperty;
        public PropertyId OptimizeForVisualContent => AutomationObjectIds.OptimizeForVisualContentProperty;
        public PropertyId Orientation => AutomationObjectIds.OrientationProperty;
        public PropertyId ProcessId => AutomationObjectIds.ProcessIdProperty;
        public PropertyId ProviderDescription => AutomationObjectIds.ProviderDescriptionProperty;
        public PropertyId RuntimeId => AutomationObjectIds.RuntimeIdProperty;
    }
}
