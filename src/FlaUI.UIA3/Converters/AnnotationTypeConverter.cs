using System;
using System.Linq;
using FlaUI.Core.Definitions;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Converters
{
    public static class AnnotationTypeConverter
    {
        public static object ToAnnotationType(object nativeAnnotationType)
        {
            switch ((int)nativeAnnotationType)
            {
                case UIA.UIA_AnnotationTypes.AnnotationType_Comment:
                    return AnnotationType.Comment;
                case UIA.UIA_AnnotationTypes.AnnotationType_Footer:
                    return AnnotationType.Footer;
                case UIA.UIA_AnnotationTypes.AnnotationType_FormulaError:
                    return AnnotationType.FormulaError;
                case UIA.UIA_AnnotationTypes.AnnotationType_GrammarError:
                    return AnnotationType.GrammarError;
                case UIA.UIA_AnnotationTypes.AnnotationType_Header:
                    return AnnotationType.Header;
                case UIA.UIA_AnnotationTypes.AnnotationType_Highlighted:
                    return AnnotationType.Highlighted;
                case UIA.UIA_AnnotationTypes.AnnotationType_SpellingError:
                    return AnnotationType.SpellingError;
                case UIA.UIA_AnnotationTypes.AnnotationType_TrackChanges:
                    return AnnotationType.TrackChanges;
                case UIA.UIA_AnnotationTypes.AnnotationType_Unknown:
                    return AnnotationType.Unknown;
                default:
                    throw new NotSupportedException();
            }
        }

        public static object ToAnnotationTypeNative(AnnotationType annotationType)
        {
            switch (annotationType)
            {
                case AnnotationType.Comment:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Comment;
                case AnnotationType.Footer:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Footer;
                case AnnotationType.FormulaError:
                    return UIA.UIA_AnnotationTypes.AnnotationType_FormulaError;
                case AnnotationType.GrammarError:
                    return UIA.UIA_AnnotationTypes.AnnotationType_GrammarError;
                case AnnotationType.Header:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Header;
                case AnnotationType.Highlighted:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Highlighted;
                case AnnotationType.SpellingError:
                    return UIA.UIA_AnnotationTypes.AnnotationType_SpellingError;
                case AnnotationType.TrackChanges:
                    return UIA.UIA_AnnotationTypes.AnnotationType_TrackChanges;
                case AnnotationType.Unknown:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Unknown;
                default:
                    throw new NotSupportedException();
            }
        }

        public static object ToAnnotationTypeArray(object nativeAnnotationTypes)
        {
            var origValue = (int[])nativeAnnotationTypes;
            return origValue.Select(x => ToAnnotationType(x)).ToArray();
        }
    }
}
