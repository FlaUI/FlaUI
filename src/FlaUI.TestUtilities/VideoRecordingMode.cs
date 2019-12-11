namespace FlaUI.TestUtilities
{
    /// <summary>
    /// Defines how videos should be recorded for the tests.
    /// </summary>
    public enum VideoRecordingMode
    {
        /// <summary>
        /// Do not record any video.
        /// </summary>
        NoVideo,

        /// <summary>
        /// Record one separate video per test.
        /// </summary>
        OnePerTest,

        /// <summary>
        /// Report one video for the whole test fixture.
        /// </summary>
        OnePerFixture,
    }
}
