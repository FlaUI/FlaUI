using FlaUI.Core.Identifiers;

namespace FlaUI.Core
{
    /// <summary>
    /// Interface for a text attribute library.
    /// </summary>
    public interface ITextAttributeLibrary
    {
#pragma warning disable 1591
        TextAttributeId AfterParagraphSpacing { get; }
        TextAttributeId AnimationStyle { get; }
        TextAttributeId AnnotationObjects { get; }
        TextAttributeId AnnotationTypes { get; }
        TextAttributeId BackgroundColor { get; }
        TextAttributeId BeforeParagraphSpacing { get; }
        TextAttributeId BulletStyle { get; }
        TextAttributeId CapStyle { get; }
        TextAttributeId CaretBidiMode { get; }
        TextAttributeId CaretPosition { get; }
        TextAttributeId Culture { get; }
        TextAttributeId FontName { get; }
        TextAttributeId FontSize { get; }
        TextAttributeId FontWeight { get; }
        TextAttributeId ForegroundColor { get; }
        TextAttributeId HorizontalTextAlignment { get; }
        TextAttributeId IndentationFirstLine { get; }
        TextAttributeId IndentationLeading { get; }
        TextAttributeId IndentationTrailing { get; }
        TextAttributeId IsActive { get; }
        TextAttributeId IsHidden { get; }
        TextAttributeId IsItalic { get; }
        TextAttributeId IsReadOnly { get; }
        TextAttributeId IsSubscript { get; }
        TextAttributeId IsSuperscript { get; }
        TextAttributeId LineSpacing { get; }
        TextAttributeId Link { get; }
        TextAttributeId MarginBottom { get; }
        TextAttributeId MarginLeading { get; }
        TextAttributeId MarginTop { get; }
        TextAttributeId MarginTrailing { get; }
        TextAttributeId OutlineStyles { get; }
        TextAttributeId OverlineColor { get; }
        TextAttributeId OverlineStyle { get; }
        TextAttributeId SayAsInterpretAs { get; }
        TextAttributeId SelectionActiveEnd { get; }
        TextAttributeId StrikethroughColor { get; }
        TextAttributeId StrikethroughStyle { get; }
        TextAttributeId StyleId { get; }
        TextAttributeId StyleName { get; }
        TextAttributeId Tabs { get; }
        TextAttributeId TextFlowDirections { get; }
        TextAttributeId UnderlineColor { get; }
        TextAttributeId UnderlineStyle { get; }
#pragma warning restore 1591
    }
}
