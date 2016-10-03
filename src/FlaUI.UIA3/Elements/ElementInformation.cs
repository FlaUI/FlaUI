﻿using FlaUI.Core.Shapes;
using FlaUI.UIA3.Definitions;
using System;
using System.Globalization;

namespace FlaUI.UIA3.Elements
{
    public class ElementInformation : InformationBase
    {
        public ElementInformation(AutomationElement automationAutomationElement, bool cached)
            : base(automationAutomationElement, cached)
        {
        }

        public string AcceleratorKey
        {
            get { return Get<string>(Elements.AutomationElement.AcceleratorKeyProperty); }
        }

        public string AccessKey
        {
            get { return Get<string>(Elements.AutomationElement.AccessKeyProperty); }
        }

        public string AriaProperties
        {
            get { return Get<string>(Elements.AutomationElement.AriaPropertiesProperty); }
        }

        public string AriaRole
        {
            get { return Get<string>(Elements.AutomationElement.AriaRoleProperty); }
        }

        public string AutomationId
        {
            get { return Get<string>(Elements.AutomationElement.AutomationIdProperty); }
        }

        public Rectangle BoundingRectangle
        {
            get { return Get<Rectangle>(Elements.AutomationElement.BoundingRectangleProperty); }
        }

        public string ClassName
        {
            get { return Get<string>(Elements.AutomationElement.ClassNameProperty); }
        }

        public Point ClickablePoint
        {
            get
            {
                // First try getting it from the property
                var clickablePoint = Get<Point>(Elements.AutomationElement.ClickablePointProperty);
                // In some cases, the property is not supported but might be available
                // by the native method, so we will try this as fallback
                if (clickablePoint == null)
                {
                    // Try to get the value directly
                    clickablePoint = AutomationAutomationElement.GetClickablePoint();
                }
                return clickablePoint;
            }
        }

        public AutomationElement[] ControllerFor
        {
            get { return NativeElementArrayToElements(Elements.AutomationElement.ControllerForProperty); }
        }

        public ControlType ControlType
        {
            get { return Get<ControlType>(Elements.AutomationElement.ControlTypeProperty); }
        }

        public CultureInfo Culture
        {
            get { return Get<CultureInfo>(Elements.AutomationElement.CultureProperty); }
        }

        public AutomationElement[] DescribedBy
        {
            get { return NativeElementArrayToElements(Elements.AutomationElement.DescribedByProperty); }
        }

        public AutomationElement[] FlowsFrom
        {
            get { return NativeElementArrayToElements(Elements.AutomationElement.FlowsFromProperty); }
        }

        public AutomationElement[] FlowsTo
        {
            get { return NativeElementArrayToElements(Elements.AutomationElement.FlowsToProperty); }
        }

        public string FrameworkId
        {
            get { return Get<string>(Elements.AutomationElement.FrameworkIdProperty); }
        }

        public bool HasKeyboardFocus
        {
            get { return Get<bool>(Elements.AutomationElement.HasKeyboardFocusProperty); }
        }

        public string HelpText
        {
            get { return Get<string>(Elements.AutomationElement.HelpTextProperty); }
        }

        public bool IsContentElement
        {
            get { return Get<bool>(Elements.AutomationElement.IsContentElementProperty); }
        }

        public bool IsControlElement
        {
            get { return Get<bool>(Elements.AutomationElement.IsControlElementProperty); }
        }

        public bool IsDataValidForForm
        {
            get { return Get<bool>(Elements.AutomationElement.IsDataValidForFormProperty); }
        }

        public bool IsEnabled
        {
            get { return Get<bool>(Elements.AutomationElement.IsEnabledProperty); }
        }

        public bool IsKeyboardFocusable
        {
            get { return Get<bool>(AutomationElement.IsKeyboardFocusableProperty); }
        }

        public bool IsOffscreen
        {
            get { return Get<bool>(AutomationElement.IsOffscreenProperty); }
        }

        public bool IsPassword
        {
            get { return Get<bool>(AutomationElement.IsPasswordProperty); }
        }

        public bool IsPeripheral
        {
            get { return Get<bool>(AutomationElement.IsPeripheralProperty); }
        }

        public bool IsRequiredForForm
        {
            get { return Get<bool>(AutomationElement.IsRequiredForFormProperty); }
        }

        public string ItemStatus
        {
            get { return Get<string>(AutomationElement.ItemStatusProperty); }
        }

        public string ItemType
        {
            get { return Get<string>(AutomationElement.ItemTypeProperty); }
        }

        public AutomationElement LabeledBy
        {
            get { return NativeElementToElement(AutomationElement.LabeledByProperty); }
        }

        public LiveSetting LiveSetting
        {
            get { return Get<LiveSetting>(AutomationElement.LiveSettingProperty); }
        }

        public string LocalizedControlType
        {
            get { return Get<string>(AutomationElement.LocalizedControlTypeProperty); }
        }

        public string Name
        {
            get { return Get<string>(AutomationElement.NameProperty); }
        }

        public IntPtr NativeWindowHandle
        {
            get { return Get<IntPtr>(AutomationElement.NativeWindowHandleProperty); }
        }

        public bool OptimizeForVisualContent
        {
            get { return Get<bool>(AutomationElement.OptimizeForVisualContentProperty); }
        }

        public OrientationType Orientation
        {
            get { return Get<OrientationType>(AutomationElement.OrientationProperty); }
        }

        public int ProcessId
        {
            get { return Get<int>(AutomationElement.ProcessIdProperty); }
        }

        public string ProviderDescription
        {
            get { return Get<string>(AutomationElement.ProviderDescriptionProperty); }
        }

        public int[] RuntimeId
        {
            get { return Get<int[]>(AutomationElement.RuntimeIdProperty); }
        }
    }
}
