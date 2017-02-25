using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Identifiers;

namespace FlaUI.UIA2
{
    public class UIA2AutomationElementProperties : IAutomationElementProperties
    {
        public PropertyId AcceleratorKey => AutomationObjectIds.AcceleratorKeyProperty;
        public PropertyId AccessKey => AutomationObjectIds.AccessKeyProperty;

        public PropertyId AriaProperties
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId AriaRole
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId AutomationId => AutomationObjectIds.AutomationIdProperty;
        public PropertyId BoundingRectangle => AutomationObjectIds.BoundingRectangleProperty;
        public PropertyId ClassName => AutomationObjectIds.ClassNameProperty;
        public PropertyId ClickablePoint => AutomationObjectIds.ClickablePointProperty;

        public PropertyId ControllerFor
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId ControlType => AutomationObjectIds.ControlTypeProperty;
        public PropertyId Culture => AutomationObjectIds.CultureProperty;

        public PropertyId DescribedBy
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId FlowsFrom
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId FlowsTo
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId FrameworkId => AutomationObjectIds.FrameworkIdProperty;
        public PropertyId HasKeyboardFocus => AutomationObjectIds.HasKeyboardFocusProperty;
        public PropertyId HelpText => AutomationObjectIds.HelpTextProperty;
        public PropertyId IsContentElement => AutomationObjectIds.IsContentElementProperty;
        public PropertyId IsControlElement => AutomationObjectIds.IsControlElementProperty;

        public PropertyId IsDataValidForForm
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId IsEnabled => AutomationObjectIds.IsEnabledProperty;
        public PropertyId IsKeyboardFocusable => AutomationObjectIds.IsKeyboardFocusableProperty;
        public PropertyId IsOffscreen => AutomationObjectIds.IsOffscreenProperty;
        public PropertyId IsPassword => AutomationObjectIds.IsPasswordProperty;

        public PropertyId IsPeripheral
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId IsRequiredForForm => AutomationObjectIds.IsRequiredForFormProperty;
        public PropertyId ItemStatus => AutomationObjectIds.ItemStatusProperty;
        public PropertyId ItemType => AutomationObjectIds.ItemTypeProperty;
        public PropertyId LabeledBy => AutomationObjectIds.AcceleratorKeyProperty;

        public PropertyId LiveSetting
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId LocalizedControlType => AutomationObjectIds.LocalizedControlTypeProperty;
        public PropertyId Name => AutomationObjectIds.NameProperty;
        public PropertyId NativeWindowHandle => AutomationObjectIds.NativeWindowHandleProperty;

        public PropertyId OptimizeForVisualContent
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId Orientation => AutomationObjectIds.OrientationProperty;
        public PropertyId ProcessId => AutomationObjectIds.ProcessIdProperty;

        public PropertyId ProviderDescription
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId RuntimeId => AutomationObjectIds.RuntimeIdProperty;
    }
}
