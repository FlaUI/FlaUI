using FlaUI.Core.Logging;
using NUnit.Framework;

namespace FlaUI.TestUtilities
{
    /// <summary>
    /// Implementation of a FlaUI logger which logs to the NUnit progress stream.
    /// </summary>
    public class NUnitProgressLogger : LoggerBase
    {
        /// <inheritdoc />
        protected override void GatedTrace(string message)
        {
            TestContext.Progress.WriteLine($"Trace: {message}");
        }

        /// <inheritdoc />
        protected override void GatedDebug(string message)
        {
            TestContext.Progress.WriteLine($"Debug: {message}");
        }

        /// <inheritdoc />
        protected override void GatedInfo(string message)
        {
            TestContext.Progress.WriteLine($"Info: {message}");
        }

        /// <inheritdoc />
        protected override void GatedWarn(string message)
        {
            TestContext.Progress.WriteLine($"Warn: {message}");
        }

        /// <inheritdoc />
        protected override void GatedError(string message)
        {
            TestContext.Progress.WriteLine($"Error: {message}");
        }

        /// <inheritdoc />
        protected override void GatedFatal(string message)
        {
            TestContext.Progress.WriteLine($"Fatal: {message}");
        }
    }
}
