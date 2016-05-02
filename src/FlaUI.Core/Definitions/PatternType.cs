using interop.UIAutomationCore;

namespace FlaUI.Core.Definitions
{
    public enum PatternType
    {
        GridItem = UIA_PatternIds.UIA_GridItemPatternId,
        Grid = UIA_PatternIds.UIA_GridPatternId,
        ItemContainer = UIA_PatternIds.UIA_ItemContainerPatternId,
        LegacyIAccessible = UIA_PatternIds.UIA_LegacyIAccessiblePatternId,
        MultipleView = UIA_PatternIds.UIA_MultipleViewPatternId,
        ObjectModel = UIA_PatternIds.UIA_ObjectModelPatternId,
        RangeValue = UIA_PatternIds.UIA_RangeValuePatternId,
        ScrollItem = UIA_PatternIds.UIA_ScrollItemPatternId,
        Scroll = UIA_PatternIds.UIA_ScrollPatternId,
        SelectionItem = UIA_PatternIds.UIA_SelectionItemPatternId,
        Selection = UIA_PatternIds.UIA_SelectionPatternId,
        SpreadsheetItem = UIA_PatternIds.UIA_SpreadsheetItemPatternId,
        Spreadsheet = UIA_PatternIds.UIA_SpreadsheetPatternId,
        Styles = UIA_PatternIds.UIA_StylesPatternId,
        SynchronizedInput = UIA_PatternIds.UIA_SynchronizedInputPatternId,
        TableItem = UIA_PatternIds.UIA_TableItemPatternId,
        Table = UIA_PatternIds.UIA_TablePatternId,
        TextChild = UIA_PatternIds.UIA_TextChildPatternId,
        TextEdit = UIA_PatternIds.UIA_TextEditPatternId,
        Text2 = UIA_PatternIds.UIA_TextPattern2Id,
        Text = UIA_PatternIds.UIA_TextPatternId,
        Toggle = UIA_PatternIds.UIA_TogglePatternId,
        Transform2 = UIA_PatternIds.UIA_TransformPattern2Id,
        Transform = UIA_PatternIds.UIA_TransformPatternId,
        Value = UIA_PatternIds.UIA_ValuePatternId,
        VirtualizedItem = UIA_PatternIds.UIA_VirtualizedItemPatternId,
        Window = UIA_PatternIds.UIA_WindowPatternId,
    }
}
