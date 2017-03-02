using System;
using System.Globalization;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    public class AutomationElementPropertyValues
    {
        private AutomationProperty<string> _acceleratorKey;
        private AutomationProperty<string> _accessKey;
        private AutomationProperty<string> _ariaProperties;
        private AutomationProperty<string> _ariaRole;
        private AutomationProperty<string> _automationId;
        private AutomationProperty<Rectangle> _boundingRectangle;
        private AutomationProperty<string> _className;
        private AutomationProperty<Point> _clickablePoint;
        private AutomationProperty<AutomationElement[]> _controllerFor;
        private AutomationProperty<ControlType> _controlType;
        private AutomationProperty<CultureInfo> _culture;
        private AutomationProperty<AutomationElement[]> _describedBy;
        private AutomationProperty<AutomationElement[]> _flowsFrom;
        private AutomationProperty<AutomationElement[]> _flowsTo;
        private AutomationProperty<string> _frameworkId;
        private AutomationProperty<bool> _hasKeyboardFocus;
        private AutomationProperty<string> _helpText;
        private AutomationProperty<bool> _isContentElement;
        private AutomationProperty<bool> _isControlElement;
        private AutomationProperty<bool> _isDataValidForForm;
        private AutomationProperty<bool> _isEnabled;
        private AutomationProperty<bool> _isKeyboardFocusable;
        private AutomationProperty<bool> _isOffscreen;
        private AutomationProperty<bool> _isPassword;
        private AutomationProperty<bool> _isPeripheral;
        private AutomationProperty<bool> _isRequiredForForm;
        private AutomationProperty<string> _itemStatus;
        private AutomationProperty<string> _itemType;
        private AutomationProperty<AutomationElement> _labeledBy;
        private AutomationProperty<LiveSetting> _liveSetting;
        private AutomationProperty<string> _localizedControlType;
        private AutomationProperty<string> _name;
        private AutomationProperty<IntPtr> _nativeWindowHandle;
        private AutomationProperty<bool> _optimizeForVisualContent;
        private AutomationProperty<OrientationType> _orientation;
        private AutomationProperty<int> _processId;
        private AutomationProperty<string> _providerDescription;
        private AutomationProperty<int[]> _runtimeId;

        public AutomationElementPropertyValues(BasicAutomationElementBase basicAutomationElement)
        {
            BasicAutomationElement = basicAutomationElement;
        }

        private BasicAutomationElementBase BasicAutomationElement { get; }
        private AutomationBase Automation => BasicAutomationElement.Automation;
        private IAutomationElementProperties Properties => Automation.PropertyLibrary.Element;

        public AutomationProperty<string> AcceleratorKey => GetOrCreate(ref _acceleratorKey, Properties.AcceleratorKey);
        public AutomationProperty<string> AccessKey => GetOrCreate(ref _accessKey, Properties.AccessKey);
        public AutomationProperty<string> AriaProperties => GetOrCreate(ref _ariaProperties, Properties.AriaProperties);
        public AutomationProperty<string> AriaRole => GetOrCreate(ref _ariaRole, Properties.AriaRole);
        public AutomationProperty<string> AutomationId => GetOrCreate(ref _automationId, Properties.AutomationId);
        public AutomationProperty<Rectangle> BoundingRectangle => GetOrCreate(ref _boundingRectangle, Properties.BoundingRectangle);
        public AutomationProperty<string> ClassName => GetOrCreate(ref _className, Properties.ClassName);
        public AutomationProperty<Point> ClickablePoint => GetOrCreate(ref _clickablePoint, Properties.ClickablePoint);
        public AutomationProperty<AutomationElement[]> ControllerFor => GetOrCreate(ref _controllerFor, Properties.ControllerFor);
        public AutomationProperty<ControlType> ControlType => GetOrCreate(ref _controlType, Properties.ControlType);
        public AutomationProperty<CultureInfo> Culture => GetOrCreate(ref _culture, Properties.Culture);
        public AutomationProperty<AutomationElement[]> DescribedBy => GetOrCreate(ref _describedBy, Properties.DescribedBy);
        public AutomationProperty<AutomationElement[]> FlowsFrom => GetOrCreate(ref _flowsFrom, Properties.FlowsFrom);
        public AutomationProperty<AutomationElement[]> FlowsTo => GetOrCreate(ref _flowsTo, Properties.FlowsTo);
        public AutomationProperty<string> FrameworkId => GetOrCreate(ref _frameworkId, Properties.FrameworkId);
        public AutomationProperty<bool> HasKeyboardFocus => GetOrCreate(ref _hasKeyboardFocus, Properties.HasKeyboardFocus);
        public AutomationProperty<string> HelpText => GetOrCreate(ref _helpText, Properties.HelpText);
        public AutomationProperty<bool> IsContentElement => GetOrCreate(ref _isContentElement, Properties.IsContentElement);
        public AutomationProperty<bool> IsControlElement => GetOrCreate(ref _isControlElement, Properties.IsControlElement);
        public AutomationProperty<bool> IsDataValidForForm => GetOrCreate(ref _isDataValidForForm, Properties.IsDataValidForForm);
        public AutomationProperty<bool> IsEnabled => GetOrCreate(ref _isEnabled, Properties.IsEnabled);
        public AutomationProperty<bool> IsKeyboardFocusable => GetOrCreate(ref _isKeyboardFocusable, Properties.IsKeyboardFocusable);
        public AutomationProperty<bool> IsOffscreen => GetOrCreate(ref _isOffscreen, Properties.IsOffscreen);
        public AutomationProperty<bool> IsPassword => GetOrCreate(ref _isPassword, Properties.IsPassword);
        public AutomationProperty<bool> IsPeripheral => GetOrCreate(ref _isPeripheral, Properties.IsPeripheral);
        public AutomationProperty<bool> IsRequiredForForm => GetOrCreate(ref _isRequiredForForm, Properties.IsRequiredForForm);
        public AutomationProperty<string> ItemStatus => GetOrCreate(ref _itemStatus, Properties.ItemStatus);
        public AutomationProperty<string> ItemType => GetOrCreate(ref _itemType, Properties.ItemType);
        public AutomationProperty<AutomationElement> LabeledBy => GetOrCreate(ref _labeledBy, Properties.LabeledBy);
        public AutomationProperty<LiveSetting> LiveSetting => GetOrCreate(ref _liveSetting, Properties.LiveSetting);
        public AutomationProperty<string> LocalizedControlType => GetOrCreate(ref _localizedControlType, Properties.LocalizedControlType);
        public AutomationProperty<string> Name => GetOrCreate(ref _name, Properties.Name);
        public AutomationProperty<IntPtr> NativeWindowHandle => GetOrCreate(ref _nativeWindowHandle, Properties.NativeWindowHandle);
        public AutomationProperty<bool> OptimizeForVisualContent => GetOrCreate(ref _optimizeForVisualContent, Properties.OptimizeForVisualContent);
        public AutomationProperty<OrientationType> Orientation => GetOrCreate(ref _orientation, Properties.Orientation);
        public AutomationProperty<int> ProcessId => GetOrCreate(ref _processId, Properties.ProcessId);
        public AutomationProperty<string> ProviderDescription => GetOrCreate(ref _providerDescription, Properties.ProviderDescription);
        public AutomationProperty<int[]> RuntimeId => GetOrCreate(ref _runtimeId, Properties.RuntimeId);

        private AutomationProperty<T> GetOrCreate<T>(ref AutomationProperty<T> val, PropertyId propertyId)
        {
            return val ?? (val = new AutomationProperty<T>(propertyId, BasicAutomationElement));
        }
    }
}
