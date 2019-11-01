namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values used in creating property conditions.
    /// </summary>
    public enum PropertyConditionFlags
    {
        /// <summary>
        /// No flags.
        /// </summary>
        None = 0,

        /// <summary>
        /// Comparison of string properties is not case-sensitive.
        /// </summary>
        IgnoreCase = 1,

        /// <summary>
        /// Comparison of substring properties is enabled.
        /// Only available on Windows version 1809 and newer.
        /// </summary>
        MatchSubstring = 2
    }
}
