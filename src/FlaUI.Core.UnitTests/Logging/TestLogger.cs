using FlaUI.Core.Logging;

namespace FlaUI.Core.UnitTests.Logging
{
    public class TestLogger : LoggerBase
    {
        protected override void GatedTrace(string message)
        {
            PublicTrace(message);
        }

        protected override void GatedDebug(string message)
        {
            PublicDebug(message);
        }

        protected override void GatedInfo(string message)
        {
            PublicInfo(message);
        }

        protected override void GatedWarn(string message)
        {
            PublicWarn(message);
        }

        protected override void GatedError(string message)
        {
            PublicError(message);
        }

        protected override void GatedFatal(string message)
        {
            PublicFatal(message);
        }

        public virtual void PublicTrace(string message)
        {
        }

        public virtual void PublicDebug(string message)
        {
        }

        public virtual void PublicInfo(string message)
        {
        }

        public virtual void PublicWarn(string message)
        {
        }

        public virtual void PublicError(string message)
        {
        }

        public virtual void PublicFatal(string message)
        {
        }
    }
}
