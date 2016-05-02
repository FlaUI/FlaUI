using interop.UIAutomationCore;

namespace FlaUI.Core.Definitions
{
    public enum EventType
    {
        InputDiscarded = UIA_EventIds.UIA_InputDiscardedEventId,
        InputReachedOtherElement = UIA_EventIds.UIA_InputReachedOtherElementEventId,
        InputReachedTarget = UIA_EventIds.UIA_InputReachedTargetEventId,
        Invoke_Invoked = UIA_EventIds.UIA_Invoke_InvokedEventId,
        Selection_Invalidated = UIA_EventIds.UIA_Selection_InvalidatedEventId,
        SelectionItem_ElementAddedToSelection = UIA_EventIds.UIA_SelectionItem_ElementAddedToSelectionEventId,
        SelectionItem_ElementRemovedFromSelection = UIA_EventIds.UIA_SelectionItem_ElementRemovedFromSelectionEventId,
        SelectionItem_ElementSelected = UIA_EventIds.UIA_SelectionItem_ElementSelectedEventId,
        Text_TextChanged = UIA_EventIds.UIA_Text_TextChangedEventId,
        Text_TextSelectionChanged = UIA_EventIds.UIA_Text_TextSelectionChangedEventId,
        TextEdit_ConversionTargetChanged = UIA_EventIds.UIA_TextEdit_ConversionTargetChangedEventId,
        TextEdit_TextChanged = UIA_EventIds.UIA_TextEdit_TextChangedEventId,
        Window_WindowClosed = UIA_EventIds.UIA_Window_WindowClosedEventId,
        Window_WindowOpened = UIA_EventIds.UIA_Window_WindowOpenedEventId,
    }
}
