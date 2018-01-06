namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Types of annotations in a document.
    /// </summary>
    public enum AnnotationType
    {
        /// <summary>
        /// An advanced proofing issue.
        /// </summary>
        AdvancedProofingIssue,

        /// <summary>
        /// The author of the document.
        /// </summary>
        Author,

        /// <summary>
        /// A circular reference error that occurred.
        /// </summary>
        CircularReferenceError,

        /// <summary>
        /// A comment. Comments can take different forms depending on the application.
        /// </summary>
        Comment,

        /// <summary>
        /// A conflicting change that was made to the document.
        /// </summary>
        ConflictingChange,

        /// <summary>
        /// A data validation error that occurred.
        /// </summary>
        DataValidationError,

        /// <summary>
        /// A deletion change that was made to the document.
        /// </summary>
        DeletionChange,

        /// <summary>
        /// An editing locked change that was made to the document.
        /// </summary>
        EditingLockedChange,

        /// <summary>
        /// The endnote for a document.
        /// </summary>
        Endnote,

        /// <summary>
        /// An external change that was made to the document.
        /// </summary>
        ExternalChange,

        /// <summary>
        /// The footer for a page in a document.
        /// </summary>
        Footer,

        /// <summary>
        /// The footnote for a page in a document.
        /// </summary>
        Footnote,

        /// <summary>
        /// A format change that was made.
        /// </summary>
        FormatChange,

        /// <summary>
        /// An error in a formula. Formula errors typically include red text and exclamation marks.
        /// </summary>
        FormulaError,

        /// <summary>
        /// A grammatical error, often denoted by a green squiggly line.
        /// </summary>
        GrammarError,

        /// <summary>
        /// The header for a page in a document.
        /// </summary>
        Header,

        /// <summary>
        /// Highlighted content, typically denoted by a contrasting background color.
        /// </summary>
        Highlighted,

        /// <summary>
        /// An insertion change that was made to the document.
        /// </summary>
        InsertionChange,

        /// <summary>
        /// A text range containing mathematics.
        /// </summary>
        Mathematics,

        /// <summary>
        /// A move change that was made to the document.
        /// </summary>
        MoveChange,

        /// <summary>
        /// A spelling error, often denoted by a red squiggly line.
        /// </summary>
        SpellingError,

        /// <summary>
        /// A change that was made to the document.
        /// </summary>
        TrackChanges,

        /// <summary>
        /// The annotation type is unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// An unsynced change that was made to the document.
        /// </summary>
        UnsyncedChange
    }
}
