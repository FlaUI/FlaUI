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
            AcceleratorKey = new AutomationProperty<string>(() => Properties.AcceleratorKey, BasicAutomationElement);
            AccessKey = new AutomationProperty<string>(() => Properties.AccessKey, BasicAutomationElement);
            AriaProperties = new AutomationProperty<string>(() => Properties.AriaProperties, BasicAutomationElement);
            AriaRole = new AutomationProperty<string>(() => Properties.AriaRole, BasicAutomationElement);
            AutomationId = new AutomationProperty<string>(() => Properties.AutomationId, BasicAutomationElement);
            BoundingRectangle = new AutomationProperty<Rectangle>(() => Properties.BoundingRectangle, BasicAutomationElement);
            ClassName = new AutomationProperty<string>(() => Properties.ClassName, BasicAutomationElement);
            ClickablePoint = new AutomationProperty<Point>(() => Properties.ClickablePoint, BasicAutomationElement);
            ControllerFor = new AutomationProperty<AutomationElement[]>(() => Properties.ControllerFor, BasicAutomationElement);
            ControlType = new AutomationProperty<ControlType>(() => Properties.ControlType, BasicAutomationElement);
            Culture = new AutomationProperty<CultureInfo>(() => Properties.Culture, BasicAutomationElement);
            DescribedBy = new AutomationProperty<AutomationElement[]>(() => Properties.DescribedBy, BasicAutomationElement);
            FlowsFrom = new AutomationProperty<AutomationElement[]>(() => Properties.FlowsFrom, BasicAutomationElement);
            FlowsTo = new AutomationProperty<AutomationElement[]>(() => Properties.FlowsTo, BasicAutomationElement);
            FrameworkId = new AutomationProperty<string>(() => Properties.FrameworkId, BasicAutomationElement);
            HasKeyboardFocus = new AutomationProperty<bool>(() => Properties.HasKeyboardFocus, BasicAutomationElement);
            HelpText = new AutomationProperty<string>(() => Properties.HelpText, BasicAutomationElement);
            IsContentElement = new AutomationProperty<bool>(() => Properties.IsContentElement, BasicAutomationElement);
            IsControlElement = new AutomationProperty<bool>(() => Properties.IsControlElement, BasicAutomationElement);
            IsDataValidForForm = new AutomationProperty<bool>(() => Properties.IsDataValidForForm, BasicAutomationElement);
            IsEnabled = new AutomationProperty<bool>(() => Properties.IsEnabled, BasicAutomationElement);
            IsKeyboardFocusable = new AutomationProperty<bool>(() => Properties.IsKeyboardFocusable, BasicAutomationElement);
            IsOffscreen = new AutomationProperty<bool>(() => Properties.IsOffscreen, BasicAutomationElement);
            IsPassword = new AutomationProperty<bool>(() => Properties.IsPassword, BasicAutomationElement);
            IsPeripheral = new AutomationProperty<bool>(() => Properties.IsPeripheral, BasicAutomationElement);
            IsRequiredForForm = new AutomationProperty<bool>(() => Properties.IsRequiredForForm, BasicAutomationElement);
            ItemStatus = new AutomationProperty<string>(() => Properties.ItemStatus, BasicAutomationElement);
            ItemType = new AutomationProperty<string>(() => Properties.ItemType, BasicAutomationElement);
            LabeledBy = new AutomationProperty<AutomationElement>(() => Properties.LabeledBy, BasicAutomationElement);
            LiveSetting = new AutomationProperty<LiveSetting>(() => Properties.LiveSetting, BasicAutomationElement);
            LocalizedControlType = new AutomationProperty<string>(() => Properties.LocalizedControlType, BasicAutomationElement);
            Name = new AutomationProperty<string>(() => Properties.Name, BasicAutomationElement);
            NativeWindowHandle = new AutomationProperty<IntPtr>(() => Properties.NativeWindowHandle, BasicAutomationElement);
            OptimizeForVisualContent = new AutomationProperty<bool>(() => Properties.OptimizeForVisualContent, BasicAutomationElement);
            Orientation = new AutomationProperty<OrientationType>(() => Properties.Orientation, BasicAutomationElement);
            ProcessId = new AutomationProperty<int>(() => Properties.ProcessId, BasicAutomationElement);
            ProviderDescription = new AutomationProperty<string>(() => Properties.ProviderDescription, BasicAutomationElement);
            RuntimeId = new AutomationProperty<int[]>(() => Properties.RuntimeId, BasicAutomationElement);
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
