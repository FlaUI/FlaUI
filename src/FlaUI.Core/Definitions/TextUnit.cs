namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify units of text for the purposes of navigation.
    /// </summary>
    public enum TextUnit
    {
        /// <summary>
        /// Specifies that the text unit is one character in length.
        /// </summary>
        Character = 0,

        /// <summary>
        /// Specifies that the text unit is the length of a single, common format specification, such as bold, italic, or similar.
        /// </summary>
        Format = 1,

        /// <summary>
        /// Specifies that the text unit is one word in length.
        /// </summary>
        Word = 2,

        /// <summary>
        /// Specifies that the text unit is one line in length.
        /// </summary>
        Line = 3,

        /// <summary>
        /// Specifies that the text unit is one paragraph in length.
        /// </summary>
        Paragraph = 4,

        /// <summary>
        /// Specifies that the text unit is one document-specific page in length.
        /// </summary>
        Page = 5,

        /// <summary>
        /// Specifies that the text unit is an entire document in length.
        /// </summary>
        Document = 6
    }
}
