using FlaUI.Core.Shapes;
using FlaUI.UIA3.Definitions;
using System;
using System.Globalization;

namespace FlaUI.UIA3.Elements
{
    public class ElementInformation : InformationBase
    {
        public ElementInformation(Element automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public string AcceleratorKey
        {
            get { return Get<string>(Element.AcceleratorKeyProperty); }
        }

        public string AccessKey
        {
            get { return Get<string>(Element.AccessKeyProperty); }
        }

        public string AriaProperties
        {
            get { return Get<string>(Element.AriaPropertiesProperty); }
        }

        public string AriaRole
        {
            get { return Get<string>(Element.AriaRoleProperty); }
        }

        public string AutomationId
        {
            get { return Get<string>(Element.AutomationIdProperty); }
        }

        public Rectangle BoundingRectangle
        {
            get { return Get<Rectangle>(Element.BoundingRectangleProperty); }
        }

        public string ClassName
        {
            get { return Get<string>(Element.ClassNameProperty); }
        }

        public Point ClickablePoint
        {
            get
            {
                // First try getting it from the property
                var clickablePoint = Get<Point>(Element.ClickablePointProperty);
                // In some cases, the property is not supported but might be available
                // by the native method, so we will try this as fallback
                if (clickablePoint == null)
                {
                    // Try to get the value directly
                    clickablePoint = AutomationElement.GetClickablePoint();
                }
                return clickablePoint;
            }
        }

        public Element[] ControllerFor
        {
            get { return NativeElementArrayToElements(Element.ControllerForProperty); }
        }

        public ControlType ControlType
        {
            get { return Get<ControlType>(Element.ControlTypeProperty); }
        }

        public CultureInfo Culture
        {
            get { return Get<CultureInfo>(Element.CultureProperty); }
        }

        public Element[] DescribedBy
        {
            get { return NativeElementArrayToElements(Element.DescribedByProperty); }
        }

        public Element[] FlowsFrom
        {
            get { return NativeElementArrayToElements(Element.FlowsFromProperty); }
        }

        public Element[] FlowsTo
        {
            get { return NativeElementArrayToElements(Element.FlowsToProperty); }
        }

        public string FrameworkId
        {
            get { return Get<string>(Element.FrameworkIdProperty); }
        }

        public bool HasKeyboardFocus
        {
            get { return Get<bool>(Element.HasKeyboardFocusProperty); }
        }

        public string HelpText
        {
            get { return Get<string>(Element.HelpTextProperty); }
        }

        public bool IsContentElement
        {
            get { return Get<bool>(Element.IsContentElementProperty); }
        }

        public bool IsControlElement
        {
            get { return Get<bool>(Element.IsControlElementProperty); }
        }

        public bool IsDataValidForForm
        {
            get { return Get<bool>(Element.IsDataValidForFormProperty); }
        }

        public bool IsEnabled
        {
            get { return Get<bool>(Element.IsEnabledProperty); }
        }

        public bool IsKeyboardFocusable
        {
            get { return Get<bool>(Element.IsKeyboardFocusableProperty); }
        }

        public bool IsOffscreen
        {
            get { return Get<bool>(Element.IsOffscreenProperty); }
        }

        public bool IsPassword
        {
            get { return Get<bool>(Element.IsPasswordProperty); }
        }

        public bool IsPeripheral
        {
            get { return Get<bool>(Element.IsPeripheralProperty); }
        }

        public bool IsRequiredForForm
        {
            get { return Get<bool>(Element.IsRequiredForFormProperty); }
        }

        public string ItemStatus
        {
            get { return Get<string>(Element.ItemStatusProperty); }
        }

        public string ItemType
        {
            get { return Get<string>(Element.ItemTypeProperty); }
        }

        public Element LabeledBy
        {
            get { return NativeElementToElement(Element.LabeledByProperty); }
        }

        public LiveSetting LiveSetting
        {
            get { return Get<LiveSetting>(Element.LiveSettingProperty); }
        }

        public string LocalizedControlType
        {
            get { return Get<string>(Element.LocalizedControlTypeProperty); }
        }

        public string Name
        {
            get { return Get<string>(Element.NameProperty); }
        }

        public IntPtr NativeWindowHandle
        {
            get { return Get<IntPtr>(Element.NativeWindowHandleProperty); }
        }

        public bool OptimizeForVisualContent
        {
            get { return Get<bool>(Element.OptimizeForVisualContentProperty); }
        }

        public OrientationType Orientation
        {
            get { return Get<OrientationType>(Element.OrientationProperty); }
        }

        public int ProcessId
        {
            get { return Get<int>(Element.ProcessIdProperty); }
        }

        public string ProviderDescription
        {
            get { return Get<string>(Element.ProviderDescriptionProperty); }
        }

        public int[] RuntimeId
        {
            get { return Get<int[]>(Element.RuntimeIdProperty); }
        }
    }
}
