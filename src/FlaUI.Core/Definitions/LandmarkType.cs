namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// This topic describes the named constants used to identify Microsoft UI Automation landmark types.
    /// </summary>
    public enum LandmarkType
    {
        /// <summary>
        /// Indicates a custom string should be used to describe the landmark using the value from UIA_LocalizedLandmarkTypePropertyId.
        /// </summary>
        CustomLandmark = 80000,

        /// <summary>
        /// Indicates that the landmark is related to form type elements typically used for data entry.
        /// </summary>
        FormLandmark = 80001,

        /// <summary>
        /// Indicates that the landmark is for the primary content and not secondary or a lesser priority.
        /// </summary>
        MainLandmark = 80002,

        /// <summary>
        /// Indicates that the landmark is related to navigation type elements.
        /// </summary>
        NavigationLandmark = 80003,

        /// <summary>
        /// Indicates that the landmark is related to search type elements.
        /// </summary>
        SearchLandmark = 80004
    }
}
