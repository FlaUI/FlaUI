using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;

namespace FlaUI.UIA2
{
    public class UIA2ElementProperties :  IElementProperties
    {
        public PropertyId AcceleratorKeyProperty
        {
            get { return AutomationObjectIds.AcceleratorKeyProperty; }
        }

        public PropertyId AccessKeyProperty
        {
            get { return AutomationObjectIds.AccessKeyProperty; }
        }

        public PropertyId AriaPropertiesProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId AriaRoleProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId AutomationIdProperty
        {
            get { return AutomationObjectIds.AutomationIdProperty; }
        }

        public PropertyId BoundingRectangleProperty
        {
            get { return AutomationObjectIds.BoundingRectangleProperty; }
        }

        public PropertyId ClassNameProperty
        {
            get { return AutomationObjectIds.ClassNameProperty; }
        }

        public PropertyId ClickablePointProperty
        {
            get { return AutomationObjectIds.ClickablePointProperty; }
        }

        public PropertyId ControllerForProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId ControlTypeProperty
        {
            get { return AutomationObjectIds.ControlTypeProperty; }
        }

        public PropertyId CultureProperty
        {
            get { return AutomationObjectIds.CultureProperty; }
        }

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

        public PropertyId FrameworkIdProperty
        {
            get { return AutomationObjectIds.FrameworkIdProperty; }
        }

        public PropertyId HasKeyboardFocusProperty
        {
            get { return AutomationObjectIds.HasKeyboardFocusProperty; }
        }

        public PropertyId HelpTextProperty
        {
            get { return AutomationObjectIds.HelpTextProperty; }
        }

        public PropertyId IsContentElementProperty
        {
            get { return AutomationObjectIds.IsContentElementProperty; }
        }

        public PropertyId IsControlElementProperty
        {
            get { return AutomationObjectIds.IsControlElementProperty; }
        }

        public PropertyId IsDataValidForFormProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId IsEnabledProperty
        {
            get { return AutomationObjectIds.IsEnabledProperty; }
        }

        public PropertyId IsKeyboardFocusableProperty
        {
            get { return AutomationObjectIds.IsKeyboardFocusableProperty; }
        }

        public PropertyId IsOffscreenProperty
        {
            get { return AutomationObjectIds.IsOffscreenProperty; }
        }

        public PropertyId IsPasswordProperty
        {
            get { return AutomationObjectIds.IsPasswordProperty; }
        }

        public PropertyId IsPeripheralProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId IsRequiredForFormProperty
        {
            get { return AutomationObjectIds.IsRequiredForFormProperty; }
        }

        public PropertyId ItemStatusProperty
        {
            get { return AutomationObjectIds.ItemStatusProperty; }
        }

        public PropertyId ItemTypeProperty
        {
            get { return AutomationObjectIds.ItemTypeProperty; }
        }

        public PropertyId LabeledByProperty
        {
            get { return AutomationObjectIds.AcceleratorKeyProperty; }
        }

        public PropertyId LiveSettingProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId LocalizedControlTypeProperty
        {
            get { return AutomationObjectIds.LocalizedControlTypeProperty; }
        }

        public PropertyId NameProperty
        {
            get { return AutomationObjectIds.NameProperty; }
        }

        public PropertyId NativeWindowHandleProperty
        {
            get { return AutomationObjectIds.NativeWindowHandleProperty; }
        }

        public PropertyId OptimizeForVisualContentProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId OrientationProperty
        {
            get { return AutomationObjectIds.OrientationProperty; }
        }

        public PropertyId ProcessIdProperty
        {
            get { return AutomationObjectIds.ProcessIdProperty; }
        }

        public PropertyId ProviderDescriptionProperty
        {
            get { throw new NotSupportedByUIA2Exception(); }
        }

        public PropertyId RuntimeIdProperty
        {
            get { return AutomationObjectIds.RuntimeIdProperty; }
        }
    }
}
