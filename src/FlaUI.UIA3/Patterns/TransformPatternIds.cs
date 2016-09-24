using FlaUI.Core;
using FlaUI.Core.Identifiers;

namespace FlaUI.UIA3.Patterns
{
    public static class TransformPatternIds
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PatternIds.UIA_TransformPatternId, "Transform");
        public static readonly PropertyId CanMoveProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_TransformCanMovePropertyId, "CanMove");
        public static readonly PropertyId CanResizeProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_TransformCanResizePropertyId, "CanResize");
        public static readonly PropertyId CanRotateProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_TransformCanRotatePropertyId, "CanRotate");
    }
}
