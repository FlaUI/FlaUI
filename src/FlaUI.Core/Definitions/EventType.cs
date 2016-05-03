using interop.UIAutomationCore;

namespace FlaUI.Core.Definitions
{
    public enum EventType
    {
        Text_TextChanged = UIA_EventIds.UIA_Text_TextChangedEventId,
        Text_TextSelectionChanged = UIA_EventIds.UIA_Text_TextSelectionChangedEventId,
        TextEdit_ConversionTargetChanged = UIA_EventIds.UIA_TextEdit_ConversionTargetChangedEventId,
        TextEdit_TextChanged = UIA_EventIds.UIA_TextEdit_TextChangedEventId,
        Window_WindowClosed = UIA_EventIds.UIA_Window_WindowClosedEventId,
        Window_WindowOpened = UIA_EventIds.UIA_Window_WindowOpenedEventId,
    }
}
