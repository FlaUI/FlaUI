using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Elements.Infrastructure
{
    public interface IElementProperties
    {
        PropertyId AcceleratorKeyProperty { get; }
        PropertyId AccessKeyProperty { get; }
        PropertyId AriaPropertiesProperty { get; }
        PropertyId AriaRoleProperty { get; }
        PropertyId AutomationIdProperty { get; }
        PropertyId BoundingRectangleProperty { get; }
        PropertyId ClassNameProperty { get; }
        PropertyId ClickablePointProperty { get; }
        PropertyId ControllerForProperty { get; }
        PropertyId ControlTypeProperty { get; }
        PropertyId CultureProperty { get; }
        PropertyId DescribedByProperty { get; }
        PropertyId FlowsFromProperty { get; }
        PropertyId FlowsToProperty { get; }
        PropertyId FrameworkIdProperty { get; }
        PropertyId HasKeyboardFocusProperty { get; }
        PropertyId HelpTextProperty { get; }
        PropertyId IsContentElementProperty { get; }
        PropertyId IsControlElementProperty { get; }
        PropertyId IsDataValidForFormProperty { get; }
        PropertyId IsEnabledProperty { get; }
        PropertyId IsKeyboardFocusableProperty { get; }
        PropertyId IsOffscreenProperty { get; }
        PropertyId IsPasswordProperty { get; }
        PropertyId IsPeripheralProperty { get; }
        PropertyId IsRequiredForFormProperty { get; }
        PropertyId ItemStatusProperty { get; }
        PropertyId ItemTypeProperty { get; }
        PropertyId LabeledByProperty { get; }
        PropertyId LiveSettingProperty { get; }
        PropertyId LocalizedControlTypeProperty { get; }
        PropertyId NameProperty { get; }
        PropertyId NativeWindowHandleProperty { get; }
        PropertyId OptimizeForVisualContentProperty { get; }
        PropertyId OrientationProperty { get; }
        PropertyId ProcessIdProperty { get; }
        PropertyId ProviderDescriptionProperty { get; }
        PropertyId RuntimeIdProperty { get; }
    }
}
