using interop.UIAutomationCore;

namespace FlaUI.Core.Definitions
{
    public enum AnnotationType
    {
        Comment = UIA_AnnotationTypes.AnnotationType_Comment,
        Footer = UIA_AnnotationTypes.AnnotationType_Footer,
        FormulaError = UIA_AnnotationTypes.AnnotationType_FormulaError,
        GrammarError = UIA_AnnotationTypes.AnnotationType_GrammarError,
        Header = UIA_AnnotationTypes.AnnotationType_Header,
        Highlighted = UIA_AnnotationTypes.AnnotationType_Highlighted,
        SpellingError = UIA_AnnotationTypes.AnnotationType_SpellingError,
        TrackChanges = UIA_AnnotationTypes.AnnotationType_TrackChanges,
        Unknown = UIA_AnnotationTypes.AnnotationType_Unknown,
    }
}
