using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Shapes;
using System;
using System.Globalization;

namespace FlaUI.UIA3
{
    public class UIA3ElementInformation : ElementInformationBase, IElementInformation
    {
        public UIA3ElementInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public string AcceleratorKey => Get<string>(AutomationObjectIds.AcceleratorKeyProperty);
        public string AccessKey => Get<string>(AutomationObjectIds.AccessKeyProperty);
        public string AriaProperties => Get<string>(AutomationObjectIds.AriaPropertiesProperty);
        public string AriaRole => Get<string>(AutomationObjectIds.AriaRoleProperty);
        public string AutomationId => Get<string>(AutomationObjectIds.AutomationIdProperty);
        public Rectangle BoundingRectangle => Get<Rectangle>(AutomationObjectIds.BoundingRectangleProperty);
        public string ClassName => Get<string>(AutomationObjectIds.ClassNameProperty);
        public Point ClickablePoint => Get<Point>(AutomationObjectIds.ClickablePointProperty);
        public AutomationElement[] ControllerFor => Get<AutomationElement[]>(AutomationObjectIds.ControllerForProperty);
        public ControlType ControlType => Get<ControlType>(AutomationObjectIds.ControlTypeProperty);
        public CultureInfo Culture => Get<CultureInfo>(AutomationObjectIds.CultureProperty);
        public AutomationElement[] DescribedBy => Get<AutomationElement[]>(AutomationObjectIds.DescribedByProperty);
        public AutomationElement[] FlowsFrom => Get<AutomationElement[]>(AutomationObjectIds.FlowsFromProperty);
        public AutomationElement[] FlowsTo => Get<AutomationElement[]>(AutomationObjectIds.FlowsToProperty);
        public string FrameworkId => Get<string>(AutomationObjectIds.FrameworkIdProperty);
        public bool HasKeyboardFocus => Get<bool>(AutomationObjectIds.HasKeyboardFocusProperty);
        public string HelpText => Get<string>(AutomationObjectIds.HelpTextProperty);
        public bool IsContentElement => Get<bool>(AutomationObjectIds.IsContentElementProperty);
        public bool IsControlElement => Get<bool>(AutomationObjectIds.IsControlElementProperty);
        public bool IsDataValidForForm => Get<bool>(AutomationObjectIds.IsDataValidForFormProperty);
        public bool IsEnabled => Get<bool>(AutomationObjectIds.IsEnabledProperty);
        public bool IsKeyboardFocusable => Get<bool>(AutomationObjectIds.IsKeyboardFocusableProperty);
        public bool IsOffscreen => Get<bool>(AutomationObjectIds.IsOffscreenProperty);
        public bool IsPassword => Get<bool>(AutomationObjectIds.IsPasswordProperty);
        public bool IsPeripheral => Get<bool>(AutomationObjectIds.IsPeripheralProperty);
        public bool IsRequiredForForm => Get<bool>(AutomationObjectIds.IsRequiredForFormProperty);
        public string ItemStatus => Get<string>(AutomationObjectIds.ItemStatusProperty);
        public string ItemType => Get<string>(AutomationObjectIds.ItemTypeProperty);
        public AutomationElement LabeledBy => Get<AutomationElement>(AutomationObjectIds.LabeledByProperty);
        public LiveSetting LiveSetting => Get<LiveSetting>(AutomationObjectIds.LiveSettingProperty);
        public string LocalizedControlType => Get<string>(AutomationObjectIds.LocalizedControlTypeProperty);
        public string Name => Get<string>(AutomationObjectIds.NameProperty);
        public IntPtr NativeWindowHandle => Get<IntPtr>(AutomationObjectIds.NativeWindowHandleProperty);
        public bool OptimizeForVisualContent => Get<bool>(AutomationObjectIds.OptimizeForVisualContentProperty);
        public OrientationType Orientation => Get<OrientationType>(AutomationObjectIds.OrientationProperty);
        public int ProcessId => Get<int>(AutomationObjectIds.ProcessIdProperty);
        public string ProviderDescription => Get<string>(AutomationObjectIds.ProviderDescriptionProperty);
        public int[] RuntimeId => Get<int[]>(AutomationObjectIds.RuntimeIdProperty);
    }
}
