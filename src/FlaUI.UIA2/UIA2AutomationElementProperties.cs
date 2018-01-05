using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Identifiers;

namespace FlaUI.UIA2
{
    public partial class UIA2AutomationElementProperties : IAutomationElementProperties
    {
        public PropertyId AcceleratorKey => AutomationObjectIds.AcceleratorKeyProperty;
        public PropertyId AccessKey => AutomationObjectIds.AccessKeyProperty;
        public PropertyId AriaProperties => PropertyId.NotSupportedByFramework;
        public PropertyId AriaRole => PropertyId.NotSupportedByFramework;
        public PropertyId AutomationId => AutomationObjectIds.AutomationIdProperty;
        public PropertyId BoundingRectangle => AutomationObjectIds.BoundingRectangleProperty;
        public PropertyId ClassName => AutomationObjectIds.ClassNameProperty;
        public PropertyId ClickablePoint => AutomationObjectIds.ClickablePointProperty;
        public PropertyId ControllerFor => PropertyId.NotSupportedByFramework;
        public PropertyId ControlType => AutomationObjectIds.ControlTypeProperty;
        public PropertyId Culture => AutomationObjectIds.CultureProperty;
        public PropertyId DescribedBy => PropertyId.NotSupportedByFramework;
        public PropertyId FlowsFrom => PropertyId.NotSupportedByFramework;
        public PropertyId FlowsTo => PropertyId.NotSupportedByFramework;
        public PropertyId FrameworkId => AutomationObjectIds.FrameworkIdProperty;
        public PropertyId HasKeyboardFocus => AutomationObjectIds.HasKeyboardFocusProperty;
        public PropertyId HelpText => AutomationObjectIds.HelpTextProperty;
        public PropertyId IsContentElement => AutomationObjectIds.IsContentElementProperty;
        public PropertyId IsControlElement => AutomationObjectIds.IsControlElementProperty;
        public PropertyId IsDataValidForForm => PropertyId.NotSupportedByFramework;
        public PropertyId IsEnabled => AutomationObjectIds.IsEnabledProperty;
        public PropertyId IsKeyboardFocusable => AutomationObjectIds.IsKeyboardFocusableProperty;
        public PropertyId IsOffscreen => AutomationObjectIds.IsOffscreenProperty;
        public PropertyId IsPassword => AutomationObjectIds.IsPasswordProperty;
        public PropertyId IsPeripheral => PropertyId.NotSupportedByFramework;
        public PropertyId IsRequiredForForm => AutomationObjectIds.IsRequiredForFormProperty;
        public PropertyId ItemStatus => AutomationObjectIds.ItemStatusProperty;
        public PropertyId ItemType => AutomationObjectIds.ItemTypeProperty;
        public PropertyId LabeledBy => AutomationObjectIds.AcceleratorKeyProperty;
        public PropertyId LocalizedControlType => AutomationObjectIds.LocalizedControlTypeProperty;
        public PropertyId Name => AutomationObjectIds.NameProperty;
        public PropertyId NativeWindowHandle => AutomationObjectIds.NativeWindowHandleProperty;
        public PropertyId OptimizeForVisualContent => PropertyId.NotSupportedByFramework;
        public PropertyId Orientation => AutomationObjectIds.OrientationProperty;
        public PropertyId ProcessId => AutomationObjectIds.ProcessIdProperty;
        public PropertyId ProviderDescription => PropertyId.NotSupportedByFramework;
        public PropertyId RuntimeId => AutomationObjectIds.RuntimeIdProperty;
    }

    /// <summary>
    /// Partial class with additions from .NET 4.7.1
    /// </summary>
    public partial class UIA2AutomationElementProperties
    {
#if NET471
        public PropertyId LiveSetting => AutomationObjectIds.LiveSettingProperty;
#else
        public PropertyId LiveSetting => PropertyId.NotSupportedByFramework;
#endif
    }
}
