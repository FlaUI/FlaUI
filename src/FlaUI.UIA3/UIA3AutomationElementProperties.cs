using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Identifiers;

namespace FlaUI.UIA3
{
    public class UIA3AutomationElementProperties : IAutomationElementProperties
    {
        public PropertyId AcceleratorKey => AutomationObjectIds.AcceleratorKeyProperty;
        public PropertyId AccessKey => AutomationObjectIds.AccessKeyProperty;
        public PropertyId AnnotationObjects => AutomationObjectIds.AnnotationObjectsProperty;
        public PropertyId AnnotationTypes => AutomationObjectIds.AnnotationTypesProperty;
        public PropertyId AriaProperties => AutomationObjectIds.AriaPropertiesProperty;
        public PropertyId AriaRole => AutomationObjectIds.AriaRoleProperty;
        public PropertyId AutomationId => AutomationObjectIds.AutomationIdProperty;
        public PropertyId BoundingRectangle => AutomationObjectIds.BoundingRectangleProperty;
        public PropertyId CenterPoint => AutomationObjectIds.CenterPointProperty;
        public PropertyId ClassName => AutomationObjectIds.ClassNameProperty;
        public PropertyId ClickablePoint => AutomationObjectIds.ClickablePointProperty;
        public PropertyId ControllerFor => AutomationObjectIds.ControllerForProperty;
        public PropertyId ControlType => AutomationObjectIds.ControlTypeProperty;
        public PropertyId Culture => AutomationObjectIds.CultureProperty;
        public PropertyId DescribedBy => AutomationObjectIds.DescribedByProperty;
        public PropertyId FillColor => AutomationObjectIds.FillColorProperty;
        public PropertyId FillType => AutomationObjectIds.FillTypeProperty;
        public PropertyId FlowsFrom => AutomationObjectIds.FlowsFromProperty;
        public PropertyId FlowsTo => AutomationObjectIds.FlowsToProperty;
        public PropertyId FrameworkId => AutomationObjectIds.FrameworkIdProperty;
        public PropertyId FullDescription => AutomationObjectIds.FullDescriptionProperty;
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
        public PropertyId LandmarkType => AutomationObjectIds.LandmarkTypeProperty;
        public PropertyId Level => AutomationObjectIds.LevelProperty;
        public PropertyId LiveSetting => AutomationObjectIds.LiveSettingProperty;
        public PropertyId LocalizedControlType => AutomationObjectIds.LocalizedControlTypeProperty;
        public PropertyId LocalizedLandmarkType => AutomationObjectIds.LocalizedLandmarkTypeProperty;
        public PropertyId Name => AutomationObjectIds.NameProperty;
        public PropertyId NativeWindowHandle => AutomationObjectIds.NativeWindowHandleProperty;
        public PropertyId OptimizeForVisualContent => AutomationObjectIds.OptimizeForVisualContentProperty;
        public PropertyId Orientation => AutomationObjectIds.OrientationProperty;
        public PropertyId OutlineColor => AutomationObjectIds.OutlineColorProperty;
        public PropertyId OutlineThickness => AutomationObjectIds.OutlineThicknessProperty;
        public PropertyId PositionInSet => AutomationObjectIds.PositionInSetProperty;
        public PropertyId ProcessId => AutomationObjectIds.ProcessIdProperty;
        public PropertyId ProviderDescription => AutomationObjectIds.ProviderDescriptionProperty;
        public PropertyId Rotation => AutomationObjectIds.RotationProperty;
        public PropertyId RuntimeId => AutomationObjectIds.RuntimeIdProperty;
        public PropertyId Size => AutomationObjectIds.SizeProperty;
        public PropertyId SizeOfSet => AutomationObjectIds.SizeOfSetProperty;
        public PropertyId VisualEffects => AutomationObjectIds.VisualEffectsProperty;
    }
}
