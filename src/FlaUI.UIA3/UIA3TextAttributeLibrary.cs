using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Identifiers;

namespace FlaUI.UIA3
{
    /// <summary>
    /// Implements a text attribute library for the UIA3 text attributes.
    /// </summary>
    public class UIA3TextAttributeLibrary : ITextAttributeLibrary
    {
#pragma warning disable 1591
        public TextAttributeId AfterParagraphSpacing => TextAttributes.AfterParagraphSpacing;
        public TextAttributeId AnimationStyle => TextAttributes.AnimationStyle;
        public TextAttributeId AnnotationObjects => TextAttributes.AnnotationObjects;
        public TextAttributeId AnnotationTypes => TextAttributes.AnnotationTypes;
        public TextAttributeId BackgroundColor => TextAttributes.BackgroundColor;
        public TextAttributeId BeforeParagraphSpacing => TextAttributes.BeforeParagraphSpacing;
        public TextAttributeId BulletStyle => TextAttributes.BulletStyle;
        public TextAttributeId CapStyle => TextAttributes.CapStyle;
        public TextAttributeId CaretBidiMode => TextAttributes.CaretBidiMode;
        public TextAttributeId CaretPosition => TextAttributes.CaretPosition;
        public TextAttributeId Culture => TextAttributes.Culture;
        public TextAttributeId FontName => TextAttributes.FontName;
        public TextAttributeId FontSize => TextAttributes.FontSize;
        public TextAttributeId FontWeight => TextAttributes.FontWeight;
        public TextAttributeId ForegroundColor => TextAttributes.ForegroundColor;
        public TextAttributeId HorizontalTextAlignment => TextAttributes.HorizontalTextAlignment;
        public TextAttributeId IndentationFirstLine => TextAttributes.IndentationFirstLine;
        public TextAttributeId IndentationLeading => TextAttributes.IndentationLeading;
        public TextAttributeId IndentationTrailing => TextAttributes.IndentationTrailing;
        public TextAttributeId IsActive => TextAttributes.IsActive;
        public TextAttributeId IsHidden => TextAttributes.IsHidden;
        public TextAttributeId IsItalic => TextAttributes.IsItalic;
        public TextAttributeId IsReadOnly => TextAttributes.IsReadOnly;
        public TextAttributeId IsSubscript => TextAttributes.IsSubscript;
        public TextAttributeId IsSuperscript => TextAttributes.IsSuperscript;
        public TextAttributeId LineSpacing => TextAttributes.LineSpacing;
        public TextAttributeId Link => TextAttributes.Link;
        public TextAttributeId MarginBottom => TextAttributes.MarginBottom;
        public TextAttributeId MarginLeading => TextAttributes.MarginLeading;
        public TextAttributeId MarginTop => TextAttributes.MarginTop;
        public TextAttributeId MarginTrailing => TextAttributes.MarginTrailing;
        public TextAttributeId OutlineStyles => TextAttributes.OutlineStyles;
        public TextAttributeId OverlineColor => TextAttributes.OverlineColor;
        public TextAttributeId OverlineStyle => TextAttributes.OverlineStyle;
        public TextAttributeId SayAsInterpretAs => TextAttributes.SayAsInterpretAs;
        public TextAttributeId SelectionActiveEnd => TextAttributes.SelectionActiveEnd;
        public TextAttributeId StrikethroughColor => TextAttributes.StrikethroughColor;
        public TextAttributeId StrikethroughStyle => TextAttributes.StrikethroughStyle;
        public TextAttributeId StyleId => TextAttributes.StyleId;
        public TextAttributeId StyleName => TextAttributes.StyleName;
        public TextAttributeId Tabs => TextAttributes.Tabs;
        public TextAttributeId TextFlowDirections => TextAttributes.TextFlowDirections;
        public TextAttributeId UnderlineColor => TextAttributes.UnderlineColor;
        public TextAttributeId UnderlineStyle => TextAttributes.UnderlineStyle;
#pragma warning restore 1591
    }
}
