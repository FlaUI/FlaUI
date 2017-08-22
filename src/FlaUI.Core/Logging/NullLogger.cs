namespace FlaUI.Core.Logging
{
    public class NullLogger : LoggerBase
    {
        protected override void GatedTrace(string message)
        {
        }

        protected override void GatedDebug(string message)
        {
        }

        protected override void GatedInfo(string message)
        {
        }

        protected override void GatedWarn(string message)
        {
        }

        protected override void GatedError(string message)
        {
        }

        protected override void GatedFatal(string message)
        {
        }
    }
}
