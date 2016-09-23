using FlaUI.Core.Shapes;
using System;
using System.Globalization;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.Elements.Infrastructure
{
    public interface IElementInformation
    {
        string AcceleratorKey { get; }

        string AccessKey { get; }

        string AriaProperties { get; }

        string AriaRole { get; }

        string AutomationId { get; }

        Rectangle BoundingRectangle { get; }

        string ClassName { get; }

        Point ClickablePoint { get; }

        Element[] ControllerFor { get; }

        ControlType ControlType { get; }

        CultureInfo Culture { get; }

        Element[] DescribedBy { get; }

        Element[] FlowsFrom { get; }

        Element[] FlowsTo { get; }

        string FrameworkId { get; }

        bool HasKeyboardFocus { get; }

        string HelpText { get; }

        bool IsContentElement { get; }

        bool IsControlElement { get; }

        bool IsDataValidForForm { get; }

        bool IsEnabled { get; }

        bool IsKeyboardFocusable { get; }

        bool IsOffscreen { get; }

        bool IsPassword { get; }

        bool IsPeripheral { get; }

        bool IsRequiredForForm { get; }

        string ItemStatus { get; }

        string ItemType { get; }

        Element LabeledBy { get; }

        //LiveSetting LiveSetting { get; }

        string LocalizedControlType { get; }

        string Name { get; }

        IntPtr NativeWindowHandle { get; }

        bool OptimizeForVisualContent { get; }

        //OrientationType Orientation { get; }

        int ProcessId { get; }

        string ProviderDescription { get; }

        int[] RuntimeId { get; }
    }
}
