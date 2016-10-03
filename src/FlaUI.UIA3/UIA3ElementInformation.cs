﻿using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Shapes;
using System;
using System.Globalization;
using FlaUI.Core.Definitions;

namespace FlaUI.UIA3
{
    public class UIA3ElementInformation : ElementInformationBase, IElementInformation
    {
        public UIA3ElementInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public string AcceleratorKey { get; }
        public string AccessKey { get; }
        public string AriaProperties { get; }
        public string AriaRole { get; }
        public string AutomationId => Get<string>(AutomationObjectIds.AutomationIdProperty);
        public Rectangle BoundingRectangle => Get<Rectangle>(AutomationObjectIds.BoundingRectangleProperty);
        public string ClassName { get; }
        public Point ClickablePoint
        {
            get
            {
                // First try getting it from the property
                var clickablePoint = Get<Point>(AutomationObjectIds.ClickablePointProperty);
                // In some cases, the property is not supported but might be available
                // by the native method, so we will try this as fallback
                if (clickablePoint == null)
                {
                    // Try to get the value directly
                    clickablePoint = AutomationObject.GetClickablePoint();
                }
                return clickablePoint;
            }
        }
        public AutomationElement[] ControllerFor { get; }
        public ControlType ControlType => Get<ControlType>(AutomationObjectIds.ControlTypeProperty);
        public CultureInfo Culture { get; }
        public AutomationElement[] DescribedBy { get; }
        public AutomationElement[] FlowsFrom { get; }
        public AutomationElement[] FlowsTo { get; }
        public string FrameworkId => Get<string>(AutomationObjectIds.FrameworkIdProperty);
        public bool HasKeyboardFocus { get; }
        public string HelpText { get; }
        public bool IsContentElement { get; }
        public bool IsControlElement { get; }
        public bool IsDataValidForForm { get; }
        public bool IsEnabled { get; }
        public bool IsKeyboardFocusable { get; }
        public bool IsOffscreen { get; }
        public bool IsPassword { get; }
        public bool IsPeripheral { get; }
        public bool IsRequiredForForm { get; }
        public string ItemStatus { get; }
        public string ItemType { get; }
        public AutomationElement LabeledBy { get; }
        public string LocalizedControlType { get; }
        public string Name => Get<string>(AutomationObjectIds.NameProperty);
        public IntPtr NativeWindowHandle { get; }
        public bool OptimizeForVisualContent { get; }
        public int ProcessId { get; }
        public string ProviderDescription { get; }
        public int[] RuntimeId { get; }
    }
}
