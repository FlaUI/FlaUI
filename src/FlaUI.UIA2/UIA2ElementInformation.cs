using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Exceptions;
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

        public string AcceleratorKey => Get<string>(AutomationObjectIds.AcceleratorKeyProperty);
        public string AccessKey => Get<string>(AutomationObjectIds.AccessKeyProperty);
        public string AriaProperties { get { throw new NotSupportedByUIA2Exception(); } }
        public string AriaRole { get { throw new NotSupportedByUIA2Exception(); } }
        public string AutomationId => Get<string>(AutomationObjectIds.AutomationIdProperty);
        public Rectangle BoundingRectangle => Get<Rectangle>(AutomationObjectIds.BoundingRectangleProperty);
        public string ClassName => Get<string>(AutomationObjectIds.ClassNameProperty);
        public Point ClickablePoint => Get<Point>(AutomationObjectIds.ClickablePointProperty);
        public Element[] ControllerFor { get { throw new NotSupportedByUIA2Exception(); } }
        public ControlType ControlType => Get<ControlType>(AutomationObjectIds.ControlTypeProperty);
        public CultureInfo Culture => Get<CultureInfo>(AutomationObjectIds.CultureProperty);
        public Element[] DescribedBy { get { throw new NotSupportedByUIA2Exception(); } }
        public Element[] FlowsFrom { get { throw new NotSupportedByUIA2Exception(); } }
        public Element[] FlowsTo { get { throw new NotSupportedByUIA2Exception(); } }
        public string FrameworkId => Get<string>(AutomationObjectIds.FrameworkIdProperty);
        public bool HasKeyboardFocus => Get<bool>(AutomationObjectIds.HasKeyboardFocusProperty);
        public string HelpText => Get<string>(AutomationObjectIds.HelpTextProperty);
        public bool IsContentElement => Get<bool>(AutomationObjectIds.IsContentElementProperty);
        public bool IsControlElement => Get<bool>(AutomationObjectIds.IsControlElementProperty);
        public bool IsDataValidForForm { get { throw new NotSupportedByUIA2Exception(); } }
        public bool IsEnabled => Get<bool>(AutomationObjectIds.IsEnabledProperty);
        public bool IsKeyboardFocusable => Get<bool>(AutomationObjectIds.IsKeyboardFocusableProperty);
        public bool IsOffscreen => Get<bool>(AutomationObjectIds.IsOffscreenProperty);
        public bool IsPassword => Get<bool>(AutomationObjectIds.IsPasswordProperty);
        public bool IsPeripheral { get { throw new NotSupportedByUIA2Exception(); } }
        public bool IsRequiredForForm => Get<bool>(AutomationObjectIds.IsRequiredForFormProperty);
        public string ItemStatus => Get<string>(AutomationObjectIds.ItemStatusProperty);
        public string ItemType => Get<string>(AutomationObjectIds.ItemTypeProperty);
        public Element LabeledBy => Get<Element>(AutomationObjectIds.LabeledByProperty);
        public LiveSetting LiveSetting { get { throw new NotSupportedByUIA2Exception(); } }
        public string LocalizedControlType => Get<string>(AutomationObjectIds.LocalizedControlTypeProperty);
        public string Name => Get<string>(AutomationObjectIds.NameProperty);
        public IntPtr NativeWindowHandle => Get<IntPtr>(AutomationObjectIds.NativeWindowHandleProperty);
        public bool OptimizeForVisualContent { get { throw new NotSupportedByUIA2Exception(); } }
        public OrientationType Orientation => Get<OrientationType>(AutomationObjectIds.OrientationProperty);
        public int ProcessId => Get<int>(AutomationObjectIds.ProcessIdProperty);
        public string ProviderDescription { get { throw new NotSupportedByUIA2Exception(); } }
        public int[] RuntimeId => Get<int[]>(AutomationObjectIds.RuntimeIdProperty);
    }
}
