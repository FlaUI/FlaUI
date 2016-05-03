using interop.UIAutomationCore;

namespace FlaUI.Core.Definitions
{
    public enum PropertyType
    {
        // Control Pattern Properties
        ToggleToggleState = UIA_PropertyIds.UIA_ToggleToggleStatePropertyId,
        TransformCanMove = UIA_PropertyIds.UIA_TransformCanMovePropertyId,
        TransformCanResize = UIA_PropertyIds.UIA_TransformCanResizePropertyId,
        TransformCanRotate = UIA_PropertyIds.UIA_TransformCanRotatePropertyId,
        Transform2CanZoom = UIA_PropertyIds.UIA_Transform2CanZoomPropertyId,
        Transform2ZoomLevel = UIA_PropertyIds.UIA_Transform2ZoomLevelPropertyId,
        Transform2ZoomMaximum = UIA_PropertyIds.UIA_Transform2ZoomMaximumPropertyId,
        Transform2ZoomMinimum = UIA_PropertyIds.UIA_Transform2ZoomMinimumPropertyId,
        ValueIsReadOnly = UIA_PropertyIds.UIA_ValueIsReadOnlyPropertyId,
        ValueValue = UIA_PropertyIds.UIA_ValueValuePropertyId,
        WindowCanMaximize = UIA_PropertyIds.UIA_WindowCanMaximizePropertyId,
        WindowCanMinimize = UIA_PropertyIds.UIA_WindowCanMinimizePropertyId,
        WindowIsModal = UIA_PropertyIds.UIA_WindowIsModalPropertyId,
        WindowIsTopmost = UIA_PropertyIds.UIA_WindowIsTopmostPropertyId,
        WindowWindowInteractionState = UIA_PropertyIds.UIA_WindowWindowInteractionStatePropertyId,
        WindowWindowVisualState = UIA_PropertyIds.UIA_WindowWindowVisualStatePropertyId,
    }
}
