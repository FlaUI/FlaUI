namespace FlaUI.TestUtilities
{
    /// <summary>
    /// Defines how the application under test should be started by the test fixture.
    /// </summary>
    public enum ApplicationStartMode
    {
        /// <summary>
        /// Do not start or stop the application as this is done outside.
        /// </summary>
        None,

        /// <summary>
        /// Start the application before each test and close it after each test.
        /// </summary>
        OncePerTest,

        /// <summary>
        /// Start the application once for the whole test fixture and close it when all tests are finished.
        /// </summary>
        OncePerFixture
    }
}
