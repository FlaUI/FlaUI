using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Definitions
{
    public static class TextAttributes
    {
        public static readonly TextAttributeId AnimationStyle = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_AnimationStyleAttributeId, "AnimationStyle");
        public static readonly TextAttributeId AnnotationObjects = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_AnnotationObjectsAttributeId, "AnnotationObjects");
        public static readonly TextAttributeId AnnotationTypes = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_AnnotationTypesAttributeId, "AnnotationTypes");
        public static readonly TextAttributeId BackgroundColor = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_BackgroundColorAttributeId, "BackgroundColor");
        public static readonly TextAttributeId BulletStyle = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_BulletStyleAttributeId, "BulletStyle");
        public static readonly TextAttributeId CapStyle = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_CapStyleAttributeId, "CapStyle");
        public static readonly TextAttributeId CaretBidiMode = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_CaretBidiModeAttributeId, "CaretBidiMode");
        public static readonly TextAttributeId CaretPosition = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_CaretPositionAttributeId, "CaretPosition");
        public static readonly TextAttributeId Culture = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_CultureAttributeId, "Culture").SetConverter(NativeValueConverter.ToCulture);
        public static readonly TextAttributeId FontName = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_FontNameAttributeId, "FontName");
        public static readonly TextAttributeId FontSize = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_FontSizeAttributeId, "FontSize");
        public static readonly TextAttributeId FontWeight = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_FontWeightAttributeId, "FontWeight");
        public static readonly TextAttributeId ForegroundColor = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_ForegroundColorAttributeId, "ForegroundColor");
        public static readonly TextAttributeId HorizontalTextAlignment = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_HorizontalTextAlignmentAttributeId, "HorizontalTextAlignment");
        public static readonly TextAttributeId IndentationFirstLine = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_IndentationFirstLineAttributeId, "IndentationFirstLine");
        public static readonly TextAttributeId IndentationLeading = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_IndentationLeadingAttributeId, "IndentationLeading");
        public static readonly TextAttributeId IndentationTrailing = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_IndentationTrailingAttributeId, "IndentationTrailing");
        public static readonly TextAttributeId IsActive = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_IsActiveAttributeId, "IsActive");
        public static readonly TextAttributeId IsHidden = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_IsHiddenAttributeId, "IsHidden");
        public static readonly TextAttributeId IsItalic = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_IsItalicAttributeId, "IsItalic");
        public static readonly TextAttributeId IsReadOnly = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_IsReadOnlyAttributeId, "IsReadOnly");
        public static readonly TextAttributeId IsSubscript = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_IsSubscriptAttributeId, "IsSubscript");
        public static readonly TextAttributeId IsSuperscript = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_IsSuperscriptAttributeId, "IsSuperscript");
        public static readonly TextAttributeId Link = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_LinkAttributeId, "Link");
        public static readonly TextAttributeId MarginBottom = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_MarginBottomAttributeId, "MarginBottom");
        public static readonly TextAttributeId MarginLeading = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_MarginLeadingAttributeId, "MarginLeading");
        public static readonly TextAttributeId MarginTop = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_MarginTopAttributeId, "MarginTop");
        public static readonly TextAttributeId MarginTrailing = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_MarginTrailingAttributeId, "MarginTrailing");
        public static readonly TextAttributeId OutlineStyles = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_OutlineStylesAttributeId, "OutlineStyles");
        public static readonly TextAttributeId OverlineColor = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_OverlineColorAttributeId, "OverlineColor");
        public static readonly TextAttributeId OverlineStyle = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_OverlineStyleAttributeId, "OverlineStyle");
        public static readonly TextAttributeId SelectionActiveEnd = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_SelectionActiveEndAttributeId, "SelectionActiveEnd");
        public static readonly TextAttributeId StrikethroughColor = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_StrikethroughColorAttributeId, "StrikethroughColor");
        public static readonly TextAttributeId StrikethroughStyle = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_StrikethroughStyleAttributeId, "StrikethroughStyle");
        public static readonly TextAttributeId StyleId = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_StyleIdAttributeId, "StyleId");
        public static readonly TextAttributeId StyleName = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_StyleNameAttributeId, "StyleName");
        public static readonly TextAttributeId Tabs = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_TabsAttributeId, "Tabs");
        public static readonly TextAttributeId TextFlowDirections = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_TextFlowDirectionsAttributeId, "TextFlowDirections");
        public static readonly TextAttributeId UnderlineColor = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_UnderlineColorAttributeId, "UnderlineColor");
        public static readonly TextAttributeId UnderlineStyle = TextAttributeId.Register(AutomationType.UIA3, UIA.UIA_TextAttributeIds.UIA_UnderlineStyleAttributeId, "UnderlineStyle");
    }
}
