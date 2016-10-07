using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Definitions
{
    public enum AnnotationType
    {
        Comment = UIA.UIA_AnnotationTypes.AnnotationType_Comment,
        Footer = UIA.UIA_AnnotationTypes.AnnotationType_Footer,
        FormulaError = UIA.UIA_AnnotationTypes.AnnotationType_FormulaError,
        GrammarError = UIA.UIA_AnnotationTypes.AnnotationType_GrammarError,
        Header = UIA.UIA_AnnotationTypes.AnnotationType_Header,
        Highlighted = UIA.UIA_AnnotationTypes.AnnotationType_Highlighted,
        SpellingError = UIA.UIA_AnnotationTypes.AnnotationType_SpellingError,
        TrackChanges = UIA.UIA_AnnotationTypes.AnnotationType_TrackChanges,
        Unknown = UIA.UIA_AnnotationTypes.AnnotationType_Unknown
    }
}
