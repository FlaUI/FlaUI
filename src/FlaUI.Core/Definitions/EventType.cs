using interop.UIAutomationCore;

namespace FlaUI.Core.Definitions
{
    public enum EventType
    {
        AsyncContentLoaded = UIA_EventIds.UIA_AsyncContentLoadedEventId,
        AutomationFocusChanged = UIA_EventIds.UIA_AutomationFocusChangedEventId,
        AutomationPropertyChanged = UIA_EventIds.UIA_AutomationPropertyChangedEventId,
        Drag_DragCancel = UIA_EventIds.UIA_Drag_DragCancelEventId,
        Drag_DragComplete = UIA_EventIds.UIA_Drag_DragCompleteEventId,
        Drag_DragStart = UIA_EventIds.UIA_Drag_DragStartEventId,
        DropTarget_DragEnter = UIA_EventIds.UIA_DropTarget_DragEnterEventId,
        DropTarget_DragLeave = UIA_EventIds.UIA_DropTarget_DragLeaveEventId,
        DropTarget_Dropped = UIA_EventIds.UIA_DropTarget_DroppedEventId,
        HostedFragmentRootsInvalidated = UIA_EventIds.UIA_HostedFragmentRootsInvalidatedEventId,
        InputDiscarded = UIA_EventIds.UIA_InputDiscardedEventId,
        InputReachedOtherElement = UIA_EventIds.UIA_InputReachedOtherElementEventId,
        InputReachedTarget = UIA_EventIds.UIA_InputReachedTargetEventId,
        Invoke_Invoked = UIA_EventIds.UIA_Invoke_InvokedEventId,
        LayoutInvalidated = UIA_EventIds.UIA_LayoutInvalidatedEventId,
        LiveRegionChanged = UIA_EventIds.UIA_LiveRegionChangedEventId,
        MenuClosed = UIA_EventIds.UIA_MenuClosedEventId,
        MenuModeEnd = UIA_EventIds.UIA_MenuModeEndEventId,
        MenuModeStart = UIA_EventIds.UIA_MenuModeStartEventId,
        MenuOpened = UIA_EventIds.UIA_MenuOpenedEventId,
        Selection_Invalidated = UIA_EventIds.UIA_Selection_InvalidatedEventId,
        SelectionItem_ElementAddedToSelection = UIA_EventIds.UIA_SelectionItem_ElementAddedToSelectionEventId,
        SelectionItem_ElementRemovedFromSelection = UIA_EventIds.UIA_SelectionItem_ElementRemovedFromSelectionEventId,
        SelectionItem_ElementSelected = UIA_EventIds.UIA_SelectionItem_ElementSelectedEventId,
        StructureChanged = UIA_EventIds.UIA_StructureChangedEventId,
        SystemAlert = UIA_EventIds.UIA_SystemAlertEventId,
        Text_TextChanged = UIA_EventIds.UIA_Text_TextChangedEventId,
        Text_TextSelectionChanged = UIA_EventIds.UIA_Text_TextSelectionChangedEventId,
        TextEdit_ConversionTargetChanged = UIA_EventIds.UIA_TextEdit_ConversionTargetChangedEventId,
        TextEdit_TextChanged = UIA_EventIds.UIA_TextEdit_TextChangedEventId,
        ToolTipClosed = UIA_EventIds.UIA_ToolTipClosedEventId,
        ToolTipOpened = UIA_EventIds.UIA_ToolTipOpenedEventId,
        Window_WindowClosed = UIA_EventIds.UIA_Window_WindowClosedEventId,
        Window_WindowOpened = UIA_EventIds.UIA_Window_WindowOpenedEventId,
    }
}
