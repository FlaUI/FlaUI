using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Identifiers;

namespace FlaUI.UIA2
{
    /// <summary>
    /// Implements a text attribute library for the UIA2 text attributes.
    /// </summary>
    public class UIA2TextAttributeLibrary : ITextAttributeLibrary
    {
#pragma warning disable 1591
        public TextAttributeId AfterParagraphSpacing => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId AnimationStyle => TextAttributes.AnimationStyle;
        public TextAttributeId AnnotationObjects => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId AnnotationTypes => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId BackgroundColor => TextAttributes.BackgroundColor;
        public TextAttributeId BeforeParagraphSpacing => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId BulletStyle => TextAttributes.BulletStyle;
        public TextAttributeId CapStyle => TextAttributes.CapStyle;
        public TextAttributeId CaretBidiMode => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId CaretPosition => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId Culture => TextAttributes.Culture;
        public TextAttributeId FontName => TextAttributes.FontName;
        public TextAttributeId FontSize => TextAttributes.FontSize;
        public TextAttributeId FontWeight => TextAttributes.FontWeight;
        public TextAttributeId ForegroundColor => TextAttributes.ForegroundColor;
        public TextAttributeId HorizontalTextAlignment => TextAttributes.HorizontalTextAlignment;
        public TextAttributeId IndentationFirstLine => TextAttributes.IndentationFirstLine;
        public TextAttributeId IndentationLeading => TextAttributes.IndentationLeading;
        public TextAttributeId IndentationTrailing => TextAttributes.IndentationTrailing;
        public TextAttributeId IsActive => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId IsHidden => TextAttributes.IsHidden;
        public TextAttributeId IsItalic => TextAttributes.IsItalic;
        public TextAttributeId IsReadOnly => TextAttributes.IsReadOnly;
        public TextAttributeId IsSubscript => TextAttributes.IsSubscript;
        public TextAttributeId IsSuperscript => TextAttributes.IsSuperscript;
        public TextAttributeId LineSpacing => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId Link => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId MarginBottom => TextAttributes.MarginBottom;
        public TextAttributeId MarginLeading => TextAttributes.MarginLeading;
        public TextAttributeId MarginTop => TextAttributes.MarginTop;
        public TextAttributeId MarginTrailing => TextAttributes.MarginTrailing;
        public TextAttributeId OutlineStyles => TextAttributes.OutlineStyles;
        public TextAttributeId OverlineColor => TextAttributes.OverlineColor;
        public TextAttributeId OverlineStyle => TextAttributes.OverlineStyle;
        public TextAttributeId SayAsInterpretAs => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId SelectionActiveEnd => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId StrikethroughColor => TextAttributes.StrikethroughColor;
        public TextAttributeId StrikethroughStyle => TextAttributes.StrikethroughStyle;
        public TextAttributeId StyleId => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId StyleName => TextAttributeId.NotSupportedByFramework;
        public TextAttributeId Tabs => TextAttributes.Tabs;
        public TextAttributeId TextFlowDirections => TextAttributes.TextFlowDirections;
        public TextAttributeId UnderlineColor => TextAttributes.UnderlineColor;
        public TextAttributeId UnderlineStyle => TextAttributes.UnderlineStyle;
#pragma warning restore 1591
    }
}
