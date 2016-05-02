using FlaUI.Core.Definitions;
using FlaUI.Core.Shapes;
using System;
using System.Globalization;

namespace FlaUI.Core.Elements
{
    public class AutomationElementInformation : InformationBase
    {
        public AutomationElementInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public string AcceleratorKey
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.AcceleratorKeyProperty, Cached); }
        }

        public string AccessKey
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.AccessKeyProperty, Cached); }
        }

        public string AriaProperties
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.AriaPropertiesProperty, Cached); }
        }

        public string AriaRole
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.AriaRoleProperty, Cached); }
        }

        public string AutomationId
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.AutomationIdProperty, Cached); }
        }

        public Rectangle BoundingRectangle
        {
            get
            {
                var values = AutomationElement.SafeGetPropertyValue<double[]>(AutomationElement.BoundingRectangleProperty, Cached);
                return new Rectangle(values[0], values[1], values[2], values[3]);
            }
        }

        public string ClassName
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.ClassNameProperty, Cached); }
        }

        public Point ClickablePoint
        {
            get
            {
                var values = AutomationElement.SafeGetPropertyValue<double[]>(AutomationElement.ClickablePointProperty, Cached);
                return new Point(values[0], values[1]);
            }
        }

        public AutomationElement[] ControllerFor
        {
            get { return NativeElementArrayToElements(AutomationElement.ControllerForProperty); }
        }

        public ControlType ControlType
        {
            get { return (ControlType)AutomationElement.SafeGetPropertyValue<int>(AutomationElement.ControlTypeProperty, Cached); }
        }

        public CultureInfo Culture
        {
            get
            {
                var cultureId = AutomationElement.SafeGetPropertyValue<int>(AutomationElement.CultureProperty, Cached);
                return cultureId == 0 ? CultureInfo.InvariantCulture : new CultureInfo(cultureId);
            }
        }

        public AutomationElement[] DescribedBy
        {
            get { return NativeElementArrayToElements(AutomationElement.DescribedByProperty); }
        }

        public AutomationElement[] FlowsFrom
        {
            get { return NativeElementArrayToElements(AutomationElement.FlowsFromProperty); }
        }

        public AutomationElement[] FlowsTo
        {
            get { return NativeElementArrayToElements(AutomationElement.FlowsToProperty); }
        }

        public string FrameworkId
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.FrameworkIdProperty, Cached); }
        }

        public bool HasKeyboardFocus
        {
            get { return AutomationElement.SafeGetPropertyValue<bool>(AutomationElement.HasKeyboardFocusProperty, Cached); }
        }

        public string HelpText
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.HelpTextProperty, Cached); }
        }

        public bool IsContentElement
        {
            get { return AutomationElement.SafeGetPropertyValue<bool>(AutomationElement.IsContentElementProperty, Cached); }
        }

        public bool IsControlElement
        {
            get { return AutomationElement.SafeGetPropertyValue<bool>(AutomationElement.IsControlElementProperty, Cached); }
        }

        public bool IsDataValidForForm
        {
            get { return AutomationElement.SafeGetPropertyValue<bool>(AutomationElement.IsDataValidForFormProperty, Cached); }
        }

        public bool IsEnabled
        {
            get { return AutomationElement.SafeGetPropertyValue<bool>(AutomationElement.IsEnabledProperty, Cached); }
        }

        public bool IsKeyboardFocusable
        {
            get { return AutomationElement.SafeGetPropertyValue<bool>(AutomationElement.IsKeyboardFocusableProperty, Cached); }
        }

        public bool IsOffscreen
        {
            get { return AutomationElement.SafeGetPropertyValue<bool>(AutomationElement.IsOffscreenProperty, Cached); }
        }

        public bool IsPassword
        {
            get { return AutomationElement.SafeGetPropertyValue<bool>(AutomationElement.IsPasswordProperty, Cached); }
        }

        public bool IsPeripheral
        {
            get { return AutomationElement.SafeGetPropertyValue<bool>(AutomationElement.IsPeripheralProperty, Cached); }
        }

        public bool IsRequiredForForm
        {
            get { return AutomationElement.SafeGetPropertyValue<bool>(AutomationElement.IsRequiredForFormProperty, Cached); }
        }

        public string ItemStatus
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.ItemStatusProperty, Cached); }
        }

        public string ItemType
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.ItemTypeProperty, Cached); }
        }

        public AutomationElement LabeledBy
        {
            get { return NativeElementToElement(AutomationElement.LabeledByProperty); }
        }

        public LiveSetting LiveSetting
        {
            get { return AutomationElement.SafeGetPropertyValue<LiveSetting>(AutomationElement.LiveSettingProperty, Cached); }
        }

        public string LocalizedControlType
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.LocalizedControlTypeProperty, Cached); }
        }

        public string Name
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.NameProperty, Cached); }
        }

        public IntPtr NativeWindowHandle
        {
            get { return AutomationElement.SafeGetPropertyValue<IntPtr>(AutomationElement.NativeWindowHandleProperty, Cached); }
        }

        public bool OptimizeForVisualContent
        {
            get { return AutomationElement.SafeGetPropertyValue<bool>(AutomationElement.OptimizeForVisualContentProperty, Cached); }
        }

        public OrientationType Orientation
        {
            get { return AutomationElement.SafeGetPropertyValue<OrientationType>(AutomationElement.OrientationProperty, Cached); }
        }

        public int ProcessId
        {
            get { return AutomationElement.SafeGetPropertyValue<int>(AutomationElement.ProcessIdProperty, Cached); }
        }

        public string ProviderDescription
        {
            get { return AutomationElement.SafeGetPropertyValue<string>(AutomationElement.ProviderDescriptionProperty, Cached); }
        }

        public int[] RuntimeId
        {
            get { return AutomationElement.SafeGetPropertyValue<int[]>(AutomationElement.RuntimeIdProperty, Cached); }
        }
    }
}
