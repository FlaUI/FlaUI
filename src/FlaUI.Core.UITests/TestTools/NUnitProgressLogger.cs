using FlaUI.Core.Logging;
using NUnit.Framework;

namespace FlaUI.Core.UITests.TestTools
{
    public class NUnitProgressLogger : LoggerBase
    {
        protected override void GatedTrace(string message)
        {
            TestContext.Progress.WriteLine($"Trace: {message}");
        }

        protected override void GatedDebug(string message)
        {
            TestContext.Progress.WriteLine($"Debug: {message}");
        }

        protected override void GatedInfo(string message)
        {
            TestContext.Progress.WriteLine($"Info: {message}");
        }

        protected override void GatedWarn(string message)
        {
            TestContext.Progress.WriteLine($"Warn: {message}");
        }

        protected override void GatedError(string message)
        {
            TestContext.Progress.WriteLine($"Error: {message}");
        }

        protected override void GatedFatal(string message)
        {
            TestContext.Progress.WriteLine($"Fatal: {message}");
        }
    }
}
