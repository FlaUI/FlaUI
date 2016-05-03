using interop.UIAutomationCore;

namespace FlaUI.Core.Definitions
{
    public enum PatternType
    {
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
