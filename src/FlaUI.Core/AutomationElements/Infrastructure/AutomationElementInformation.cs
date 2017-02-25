using System;
using System.Globalization;
using FlaUI.Core.Definitions;
using FlaUI.Core.Shapes;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    public class AutomationElementInformation
    {
        public AutomationElementInformation(BasicAutomationElementBase basicAutomationElement)
        {
            BasicAutomationElement = basicAutomationElement;
            AcceleratorKey = new AutomationProperty<string>(() => Properties.AcceleratorKeyProperty, BasicAutomationElement);
            AccessKey = new AutomationProperty<string>(() => Properties.AccessKeyProperty, BasicAutomationElement);
            AriaProperties = new AutomationProperty<string>(() => Properties.AriaPropertiesProperty, BasicAutomationElement);
            AriaRole = new AutomationProperty<string>(() => Properties.AriaRoleProperty, BasicAutomationElement);
            AutomationId = new AutomationProperty<string>(() => Properties.AutomationIdProperty, BasicAutomationElement);
            BoundingRectangle = new AutomationProperty<Rectangle>(() => Properties.BoundingRectangleProperty, BasicAutomationElement);
            ClassName = new AutomationProperty<string>(() => Properties.ClassNameProperty, BasicAutomationElement);
            ClickablePoint = new AutomationProperty<Point>(() => Properties.ClickablePointProperty, BasicAutomationElement);
            ControllerFor = new AutomationProperty<AutomationElement[]>(() => Properties.ControllerForProperty, BasicAutomationElement);
            ControlType = new AutomationProperty<ControlType>(() => Properties.ControlTypeProperty, BasicAutomationElement);
            Culture = new AutomationProperty<CultureInfo>(() => Properties.CultureProperty, BasicAutomationElement);
            DescribedBy = new AutomationProperty<AutomationElement[]>(() => Properties.DescribedByProperty, BasicAutomationElement);
            FlowsFrom = new AutomationProperty<AutomationElement[]>(() => Properties.FlowsFromProperty, BasicAutomationElement);
            FlowsTo = new AutomationProperty<AutomationElement[]>(() => Properties.FlowsToProperty, BasicAutomationElement);
            FrameworkId = new AutomationProperty<string>(() => Properties.FrameworkIdProperty, BasicAutomationElement);
            HasKeyboardFocus = new AutomationProperty<bool>(() => Properties.HasKeyboardFocusProperty, BasicAutomationElement);
            HelpText = new AutomationProperty<string>(() => Properties.HelpTextProperty, BasicAutomationElement);
            IsContentElement = new AutomationProperty<bool>(() => Properties.IsContentElementProperty, BasicAutomationElement);
            IsControlElement = new AutomationProperty<bool>(() => Properties.IsControlElementProperty, BasicAutomationElement);
            IsDataValidForForm = new AutomationProperty<bool>(() => Properties.IsDataValidForFormProperty, BasicAutomationElement);
            IsEnabled = new AutomationProperty<bool>(() => Properties.IsEnabledProperty, BasicAutomationElement);
            IsKeyboardFocusable = new AutomationProperty<bool>(() => Properties.IsKeyboardFocusableProperty, BasicAutomationElement);
            IsOffscreen = new AutomationProperty<bool>(() => Properties.IsOffscreenProperty, BasicAutomationElement);
            IsPassword = new AutomationProperty<bool>(() => Properties.IsPasswordProperty, BasicAutomationElement);
            IsPeripheral = new AutomationProperty<bool>(() => Properties.IsPeripheralProperty, BasicAutomationElement);
            IsRequiredForForm = new AutomationProperty<bool>(() => Properties.IsRequiredForFormProperty, BasicAutomationElement);
            ItemStatus = new AutomationProperty<string>(() => Properties.ItemStatusProperty, BasicAutomationElement);
            ItemType = new AutomationProperty<string>(() => Properties.ItemTypeProperty, BasicAutomationElement);
            LabeledBy = new AutomationProperty<AutomationElement>(() => Properties.LabeledByProperty, BasicAutomationElement);
            LiveSetting = new AutomationProperty<LiveSetting>(() => Properties.LiveSettingProperty, BasicAutomationElement);
            LocalizedControlType = new AutomationProperty<string>(() => Properties.LocalizedControlTypeProperty, BasicAutomationElement);
            Name = new AutomationProperty<string>(() => Properties.NameProperty, BasicAutomationElement);
            NativeWindowHandle = new AutomationProperty<IntPtr>(() => Properties.NativeWindowHandleProperty, BasicAutomationElement);
            OptimizeForVisualContent = new AutomationProperty<bool>(() => Properties.OptimizeForVisualContentProperty, BasicAutomationElement);
            Orientation = new AutomationProperty<OrientationType>(() => Properties.OrientationProperty, BasicAutomationElement);
            ProcessId = new AutomationProperty<int>(() => Properties.ProcessIdProperty, BasicAutomationElement);
            ProviderDescription = new AutomationProperty<string>(() => Properties.ProviderDescriptionProperty, BasicAutomationElement);
            RuntimeId = new AutomationProperty<int[]>(() => Properties.RuntimeIdProperty, BasicAutomationElement);
        }

        private BasicAutomationElementBase BasicAutomationElement { get; }
        private AutomationBase Automation => BasicAutomationElement.Automation;
        private IAutomationElementProperties Properties => Automation.PropertyLibrary.Element;

        public AutomationProperty<string> AcceleratorKey { get; }
        public AutomationProperty<string> AccessKey { get; }
        public AutomationProperty<string> AriaProperties { get; }
        public AutomationProperty<string> AriaRole { get; }
        public AutomationProperty<string> AutomationId { get; }
        public AutomationProperty<Rectangle> BoundingRectangle { get; }
        public AutomationProperty<string> ClassName { get; }
        public AutomationProperty<Point> ClickablePoint { get; }
        public AutomationProperty<AutomationElement[]> ControllerFor { get; }
        public AutomationProperty<ControlType> ControlType { get; }
        public AutomationProperty<CultureInfo> Culture { get; }
        public AutomationProperty<AutomationElement[]> DescribedBy { get; }
        public AutomationProperty<AutomationElement[]> FlowsFrom { get; }
        public AutomationProperty<AutomationElement[]> FlowsTo { get; }
        public AutomationProperty<string> FrameworkId { get; }
        public AutomationProperty<bool> HasKeyboardFocus { get; }
        public AutomationProperty<string> HelpText { get; }
        public AutomationProperty<bool> IsContentElement { get; }
        public AutomationProperty<bool> IsControlElement { get; }
        public AutomationProperty<bool> IsDataValidForForm { get; }
        public AutomationProperty<bool> IsEnabled { get; }
        public AutomationProperty<bool> IsKeyboardFocusable { get; }
        public AutomationProperty<bool> IsOffscreen { get; }
        public AutomationProperty<bool> IsPassword { get; }
        public AutomationProperty<bool> IsPeripheral { get; }
        public AutomationProperty<bool> IsRequiredForForm { get; }
        public AutomationProperty<string> ItemStatus { get; }
        public AutomationProperty<string> ItemType { get; }
        public AutomationProperty<AutomationElement> LabeledBy { get; }
        public AutomationProperty<LiveSetting> LiveSetting { get; }
        public AutomationProperty<string> LocalizedControlType { get; }
        public AutomationProperty<string> Name { get; }
        public AutomationProperty<IntPtr> NativeWindowHandle { get; }
        public AutomationProperty<bool> OptimizeForVisualContent { get; }
        public AutomationProperty<OrientationType> Orientation { get; }
        public AutomationProperty<int> ProcessId { get; }
        public AutomationProperty<string> ProviderDescription { get; }
        public AutomationProperty<int[]> RuntimeId { get; }
    }
}
