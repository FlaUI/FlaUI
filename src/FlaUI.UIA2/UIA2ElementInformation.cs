using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Shapes;
using System;
using System.Globalization;

namespace FlaUI.UIA2
{
    public class UIA2ElementInformation : ElementInformationBase, IElementInformation
    {
        public UIA2ElementInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public string AcceleratorKey { get; }
        public string AccessKey { get; }
        public string AriaProperties { get; }
        public string AriaRole { get; }
        public string AutomationId { get { return Get<string>(AutomationObjectIds.AutomationIdProperty); } }
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
        public Rectangle BoundingRectangle { get { return Get<Rectangle>(AutomationObjectIds.BoundingRectangleProperty); } }
        public string ClassName { get; }
        public Point ClickablePoint { get { return Get<Point>(AutomationObjectIds.ClickablePointProperty); } }
        public Element[] ControllerFor { get; }
        public ControlType ControlType { get; }
        public CultureInfo Culture { get; }
        public Element[] DescribedBy { get; }
        public Element[] FlowsFrom { get; }
        public string Name { get { return Get<string>(AutomationObjectIds.NameProperty); } }
        public IntPtr NativeWindowHandle { get; }
        public bool OptimizeForVisualContent { get; }
        public int ProcessId { get; }
        public string ProviderDescription { get; }
        public int[] RuntimeId { get; }
    }
}
