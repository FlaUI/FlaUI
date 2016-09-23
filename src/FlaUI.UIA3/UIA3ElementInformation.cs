using FlaUI.Core;
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
        public string AutomationId { get { return Get<string>(AutomationObjectIds.AutomationIdProperty); } }
        public Rectangle BoundingRectangle { get { return Get<Rectangle>(AutomationObjectIds.BoundingRectangleProperty); } }
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
        public Element[] ControllerFor { get; }
        public ControlType ControlType { get { return Get<ControlType>(AutomationObjectIds.ControlTypeProperty); } }
        public CultureInfo Culture { get; }
        public Element[] DescribedBy { get; }
        public Element[] FlowsFrom { get; }
        public Element[] FlowsTo { get; }
        public string FrameworkId { get { return Get<string>(AutomationObjectIds.FrameworkIdProperty); } }
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
        public Element LabeledBy { get; }
        public string LocalizedControlType { get; }
        public string Name { get { return Get<string>(AutomationObjectIds.NameProperty); } }
        public IntPtr NativeWindowHandle { get; }
        public bool OptimizeForVisualContent { get; }
        public int ProcessId { get; }
        public string ProviderDescription { get; }
        public int[] RuntimeId { get; }
    }
}
