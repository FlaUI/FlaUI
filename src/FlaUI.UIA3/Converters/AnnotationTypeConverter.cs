using System;
using System.Linq;
using FlaUI.Core.Definitions;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Converters
{
    /// <summary>
    /// Converter with converts between <see cref="UIA.UIA_AnnotationTypes"/> and FlaUIs <see cref="AnnotationType"/>.
    /// </summary>
    public static class AnnotationTypeConverter
    {
        /// <summary>
        /// Converts a <see cref="UIA.UIA_AnnotationTypes"/> to a FlaUI <see cref="AnnotationType"/>.
        /// </summary>
        public static object ToAnnotationType(object nativeAnnotationType)
        {
            switch ((int)nativeAnnotationType)
            {
                case UIA.UIA_AnnotationTypes.AnnotationType_AdvancedProofingIssue:
                    return AnnotationType.AdvancedProofingIssue;
                case UIA.UIA_AnnotationTypes.AnnotationType_Author:
                    return AnnotationType.Author;
                case UIA.UIA_AnnotationTypes.AnnotationType_CircularReferenceError:
                    return AnnotationType.CircularReferenceError;
                case UIA.UIA_AnnotationTypes.AnnotationType_Comment:
                    return AnnotationType.Comment;
                case UIA.UIA_AnnotationTypes.AnnotationType_ConflictingChange:
                    return AnnotationType.ConflictingChange;
                case UIA.UIA_AnnotationTypes.AnnotationType_DataValidationError:
                    return AnnotationType.DataValidationError;
                case UIA.UIA_AnnotationTypes.AnnotationType_DeletionChange:
                    return AnnotationType.DeletionChange;
                case UIA.UIA_AnnotationTypes.AnnotationType_EditingLockedChange:
                    return AnnotationType.EditingLockedChange;
                case UIA.UIA_AnnotationTypes.AnnotationType_Endnote:
                    return AnnotationType.Endnote;
                case UIA.UIA_AnnotationTypes.AnnotationType_ExternalChange:
                    return AnnotationType.ExternalChange;
                case UIA.UIA_AnnotationTypes.AnnotationType_Footer:
                    return AnnotationType.Footer;
                case UIA.UIA_AnnotationTypes.AnnotationType_Footnote:
                    return AnnotationType.Footnote;
                case UIA.UIA_AnnotationTypes.AnnotationType_FormatChange:
                    return AnnotationType.FormatChange;
                case UIA.UIA_AnnotationTypes.AnnotationType_FormulaError:
                    return AnnotationType.FormulaError;
                case UIA.UIA_AnnotationTypes.AnnotationType_GrammarError:
                    return AnnotationType.GrammarError;
                case UIA.UIA_AnnotationTypes.AnnotationType_Header:
                    return AnnotationType.Header;
                case UIA.UIA_AnnotationTypes.AnnotationType_Highlighted:
                    return AnnotationType.Highlighted;
                case UIA.UIA_AnnotationTypes.AnnotationType_InsertionChange:
                    return AnnotationType.InsertionChange;
                case UIA.UIA_AnnotationTypes.AnnotationType_Mathematics:
                    return AnnotationType.Mathematics;
                case UIA.UIA_AnnotationTypes.AnnotationType_MoveChange:
                    return AnnotationType.MoveChange;
                case UIA.UIA_AnnotationTypes.AnnotationType_SpellingError:
                    return AnnotationType.SpellingError;
                case UIA.UIA_AnnotationTypes.AnnotationType_TrackChanges:
                    return AnnotationType.TrackChanges;
                case UIA.UIA_AnnotationTypes.AnnotationType_Unknown:
                    return AnnotationType.Unknown;
                case UIA.UIA_AnnotationTypes.AnnotationType_UnsyncedChange:
                    return AnnotationType.UnsyncedChange;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Converts a FlaUI <see cref="AnnotationType"/> to a <see cref="UIA.UIA_AnnotationTypes"/>.
        /// </summary>
        public static object ToAnnotationTypeNative(AnnotationType annotationType)
        {
            switch (annotationType)
            {
                case AnnotationType.AdvancedProofingIssue:
                    return UIA.UIA_AnnotationTypes.AnnotationType_AdvancedProofingIssue;
                case AnnotationType.Author:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Author;
                case AnnotationType.CircularReferenceError:
                    return UIA.UIA_AnnotationTypes.AnnotationType_CircularReferenceError;
                case AnnotationType.Comment:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Comment;
                case AnnotationType.ConflictingChange:
                    return UIA.UIA_AnnotationTypes.AnnotationType_ConflictingChange;
                case AnnotationType.DataValidationError:
                    return UIA.UIA_AnnotationTypes.AnnotationType_DataValidationError;
                case AnnotationType.DeletionChange:
                    return UIA.UIA_AnnotationTypes.AnnotationType_DeletionChange;
                case AnnotationType.EditingLockedChange:
                    return UIA.UIA_AnnotationTypes.AnnotationType_EditingLockedChange;
                case AnnotationType.Endnote:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Endnote;
                case AnnotationType.ExternalChange:
                    return UIA.UIA_AnnotationTypes.AnnotationType_ExternalChange;
                case AnnotationType.Footer:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Footer;
                case AnnotationType.Footnote:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Footnote;
                case AnnotationType.FormatChange:
                    return UIA.UIA_AnnotationTypes.AnnotationType_FormatChange;
                case AnnotationType.FormulaError:
                    return UIA.UIA_AnnotationTypes.AnnotationType_FormulaError;
                case AnnotationType.GrammarError:
                    return UIA.UIA_AnnotationTypes.AnnotationType_GrammarError;
                case AnnotationType.Header:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Header;
                case AnnotationType.Highlighted:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Highlighted;
                case AnnotationType.InsertionChange:
                    return UIA.UIA_AnnotationTypes.AnnotationType_InsertionChange;
                case AnnotationType.Mathematics:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Mathematics;
                case AnnotationType.MoveChange:
                    return UIA.UIA_AnnotationTypes.AnnotationType_MoveChange;
                case AnnotationType.SpellingError:
                    return UIA.UIA_AnnotationTypes.AnnotationType_SpellingError;
                case AnnotationType.TrackChanges:
                    return UIA.UIA_AnnotationTypes.AnnotationType_TrackChanges;
                case AnnotationType.Unknown:
                    return UIA.UIA_AnnotationTypes.AnnotationType_Unknown;
                case AnnotationType.UnsyncedChange:
                    return UIA.UIA_AnnotationTypes.AnnotationType_UnsyncedChange;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Converts an array of <see cref="UIA.UIA_AnnotationTypes"/> to an array of FlaUI <see cref="AnnotationType"/>.
        /// </summary>
        public static object ToAnnotationTypeArray(object nativeAnnotationTypes)
        {
            var origValue = (int[])nativeAnnotationTypes;
            return origValue.Select(x => ToAnnotationType(x)).ToArray();
        }
    }
}
