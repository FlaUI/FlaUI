using FlaUI.Core;
using FlaUI.Core.Identifiers;

namespace FlaUI.UIA3.Patterns
{
    public static class Transform2PatternIds
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PatternIds.UIA_TransformPattern2Id, "Transform2");
        public static readonly PropertyId CanZoomProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_Transform2CanZoomPropertyId, "CanZoom");
        public static readonly PropertyId ZoomLevelProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_Transform2ZoomLevelPropertyId, "ZoomLevel");
        public static readonly PropertyId ZoomMaximumProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_Transform2ZoomMaximumPropertyId, "ZoomMaximum");
        public static readonly PropertyId ZoomMinimumProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_Transform2ZoomMinimumPropertyId, "ZoomMinimum");
    }
}
