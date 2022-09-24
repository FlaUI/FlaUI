using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Identifiers;

namespace FlaUI.UIA2
{
    public partial class UIA2AutomationElementPropertyIds : IAutomationElementPropertyIds
    {
#pragma warning disable 1591
        public PropertyId AcceleratorKey => AutomationObjectIds.AcceleratorKeyProperty;
        public PropertyId AccessKey => AutomationObjectIds.AccessKeyProperty;
        public PropertyId AnnotationObjects => PropertyId.NotSupportedByFramework;
        public PropertyId AnnotationTypes => PropertyId.NotSupportedByFramework;
        public PropertyId AriaProperties => PropertyId.NotSupportedByFramework;
        public PropertyId AriaRole => PropertyId.NotSupportedByFramework;
        public PropertyId AutomationId => AutomationObjectIds.AutomationIdProperty;
        public PropertyId BoundingRectangle => AutomationObjectIds.BoundingRectangleProperty;
        public PropertyId CenterPoint => PropertyId.NotSupportedByFramework;
        public PropertyId ClassName => AutomationObjectIds.ClassNameProperty;
        public PropertyId ClickablePoint => AutomationObjectIds.ClickablePointProperty;
        public PropertyId ControllerFor => PropertyId.NotSupportedByFramework;
        public PropertyId ControlType => AutomationObjectIds.ControlTypeProperty;
        public PropertyId Culture => AutomationObjectIds.CultureProperty;
        public PropertyId DescribedBy => PropertyId.NotSupportedByFramework;
        public PropertyId FillColor => PropertyId.NotSupportedByFramework;
        public PropertyId FillType => PropertyId.NotSupportedByFramework;
        public PropertyId FlowsFrom => PropertyId.NotSupportedByFramework;
        public PropertyId FlowsTo => PropertyId.NotSupportedByFramework;
        public PropertyId FrameworkId => AutomationObjectIds.FrameworkIdProperty;
        public PropertyId FullDescription => PropertyId.NotSupportedByFramework;
        public PropertyId HasKeyboardFocus => AutomationObjectIds.HasKeyboardFocusProperty;
        public PropertyId HeadingLevel => PropertyId.NotSupportedByFramework;
        public PropertyId HelpText => AutomationObjectIds.HelpTextProperty;
        public PropertyId IsContentElement => AutomationObjectIds.IsContentElementProperty;
        public PropertyId IsControlElement => AutomationObjectIds.IsControlElementProperty;
        public PropertyId IsDataValidForForm => PropertyId.NotSupportedByFramework;
        public PropertyId IsDialog => PropertyId.NotSupportedByFramework;
        public PropertyId IsEnabled => AutomationObjectIds.IsEnabledProperty;
        public PropertyId IsKeyboardFocusable => AutomationObjectIds.IsKeyboardFocusableProperty;
        public PropertyId IsOffscreen => AutomationObjectIds.IsOffscreenProperty;
        public PropertyId IsPassword => AutomationObjectIds.IsPasswordProperty;
        public PropertyId IsPeripheral => PropertyId.NotSupportedByFramework;
        public PropertyId IsRequiredForForm => AutomationObjectIds.IsRequiredForFormProperty;
        public PropertyId ItemStatus => AutomationObjectIds.ItemStatusProperty;
        public PropertyId ItemType => AutomationObjectIds.ItemTypeProperty;
        public PropertyId LabeledBy => AutomationObjectIds.LabeledByProperty;
        public PropertyId LandmarkType => PropertyId.NotSupportedByFramework;
        public PropertyId Level => PropertyId.NotSupportedByFramework;
        public PropertyId LocalizedControlType => AutomationObjectIds.LocalizedControlTypeProperty;
        public PropertyId LocalizedLandmarkType => PropertyId.NotSupportedByFramework;
        public PropertyId Name => AutomationObjectIds.NameProperty;
        public PropertyId NativeWindowHandle => AutomationObjectIds.NativeWindowHandleProperty;
        public PropertyId OptimizeForVisualContent => PropertyId.NotSupportedByFramework;
        public PropertyId Orientation => AutomationObjectIds.OrientationProperty;
        public PropertyId OutlineColor => PropertyId.NotSupportedByFramework;
        public PropertyId OutlineThickness => PropertyId.NotSupportedByFramework;
        public PropertyId PositionInSet => PropertyId.NotSupportedByFramework;
        public PropertyId ProcessId => AutomationObjectIds.ProcessIdProperty;
        public PropertyId ProviderDescription => PropertyId.NotSupportedByFramework;
        public PropertyId Rotation => PropertyId.NotSupportedByFramework;
        public PropertyId RuntimeId => AutomationObjectIds.RuntimeIdProperty;
        public PropertyId Size => PropertyId.NotSupportedByFramework;
        public PropertyId SizeOfSet => PropertyId.NotSupportedByFramework;
        public PropertyId VisualEffects => PropertyId.NotSupportedByFramework;
#pragma warning restore 1591
    }

    /// <summary>
    /// Partial class with additions from .NET 4.7.1 or higher
    /// </summary>
    public partial class UIA2AutomationElementPropertyIds
    {
#pragma warning disable 1591
#if NET48
        public PropertyId LiveSetting => AutomationObjectIds.LiveSettingProperty;
#else
        public PropertyId LiveSetting => PropertyId.NotSupportedByFramework;
#endif
#pragma warning restore 1591
    }
}
