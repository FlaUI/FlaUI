using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;

namespace FlaUI.UIA2
{
    public class UIA2AutomationElementProperties : IAutomationElementProperties
    {
        public PropertyId AcceleratorKeyProperty => AutomationObjectIds.AcceleratorKeyProperty;
        public PropertyId AccessKeyProperty => AutomationObjectIds.AccessKeyProperty;

        public PropertyId AriaPropertiesProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId AriaRoleProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId AutomationIdProperty => AutomationObjectIds.AutomationIdProperty;
        public PropertyId BoundingRectangleProperty => AutomationObjectIds.BoundingRectangleProperty;
        public PropertyId ClassNameProperty => AutomationObjectIds.ClassNameProperty;
        public PropertyId ClickablePointProperty => AutomationObjectIds.ClickablePointProperty;

        public PropertyId ControllerForProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId ControlTypeProperty => AutomationObjectIds.ControlTypeProperty;
        public PropertyId CultureProperty => AutomationObjectIds.CultureProperty;

        public PropertyId DescribedByProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId FlowsFromProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId FlowsToProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId FrameworkIdProperty => AutomationObjectIds.FrameworkIdProperty;
        public PropertyId HasKeyboardFocusProperty => AutomationObjectIds.HasKeyboardFocusProperty;
        public PropertyId HelpTextProperty => AutomationObjectIds.HelpTextProperty;
        public PropertyId IsContentElementProperty => AutomationObjectIds.IsContentElementProperty;
        public PropertyId IsControlElementProperty => AutomationObjectIds.IsControlElementProperty;

        public PropertyId IsDataValidForFormProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId IsEnabledProperty => AutomationObjectIds.IsEnabledProperty;
        public PropertyId IsKeyboardFocusableProperty => AutomationObjectIds.IsKeyboardFocusableProperty;
        public PropertyId IsOffscreenProperty => AutomationObjectIds.IsOffscreenProperty;
        public PropertyId IsPasswordProperty => AutomationObjectIds.IsPasswordProperty;

        public PropertyId IsPeripheralProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId IsRequiredForFormProperty => AutomationObjectIds.IsRequiredForFormProperty;
        public PropertyId ItemStatusProperty => AutomationObjectIds.ItemStatusProperty;
        public PropertyId ItemTypeProperty => AutomationObjectIds.ItemTypeProperty;
        public PropertyId LabeledByProperty => AutomationObjectIds.AcceleratorKeyProperty;

        public PropertyId LiveSettingProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId LocalizedControlTypeProperty => AutomationObjectIds.LocalizedControlTypeProperty;
        public PropertyId NameProperty => AutomationObjectIds.NameProperty;
        public PropertyId NativeWindowHandleProperty => AutomationObjectIds.NativeWindowHandleProperty;

        public PropertyId OptimizeForVisualContentProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId OrientationProperty => AutomationObjectIds.OrientationProperty;
        public PropertyId ProcessIdProperty => AutomationObjectIds.ProcessIdProperty;

        public PropertyId ProviderDescriptionProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId RuntimeIdProperty => AutomationObjectIds.RuntimeIdProperty;
    }
}
