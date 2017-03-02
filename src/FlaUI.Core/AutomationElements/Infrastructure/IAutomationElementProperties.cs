using FlaUI.Core.Identifiers;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    public interface IAutomationElementProperties
    {
        PropertyId AcceleratorKey { get; }
        PropertyId AccessKey { get; }
        PropertyId AriaProperties { get; }
        PropertyId AriaRole { get; }
        PropertyId AutomationId { get; }
        PropertyId BoundingRectangle { get; }
        PropertyId ClassName { get; }
        PropertyId ClickablePoint { get; }
        PropertyId ControllerFor { get; }
        PropertyId ControlType { get; }
        PropertyId Culture { get; }
        PropertyId DescribedBy { get; }
        PropertyId FlowsFrom { get; }
        PropertyId FlowsTo { get; }
        PropertyId FrameworkId { get; }
        PropertyId HasKeyboardFocus { get; }
        PropertyId HelpText { get; }
        PropertyId IsContentElement { get; }
        PropertyId IsControlElement { get; }
        PropertyId IsDataValidForForm { get; }
        PropertyId IsEnabled { get; }
        PropertyId IsKeyboardFocusable { get; }
        PropertyId IsOffscreen { get; }
        PropertyId IsPassword { get; }
        PropertyId IsPeripheral { get; }
        PropertyId IsRequiredForForm { get; }
        PropertyId ItemStatus { get; }
        PropertyId ItemType { get; }
        PropertyId LabeledBy { get; }
        PropertyId LiveSetting { get; }
        PropertyId LocalizedControlType { get; }
        PropertyId Name { get; }
        PropertyId NativeWindowHandle { get; }
        PropertyId OptimizeForVisualContent { get; }
        PropertyId Orientation { get; }
        PropertyId ProcessId { get; }
        PropertyId ProviderDescription { get; }
        PropertyId RuntimeId { get; }
    }
}
