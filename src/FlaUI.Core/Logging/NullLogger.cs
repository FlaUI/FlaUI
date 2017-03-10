namespace FlaUI.Core.Logging
{
    public class NullLogger : LoggerBase
    {
        protected internal override void GatedTrace(string message)
        {
        }

        protected internal override void GatedDebug(string message)
        {
        }

        protected internal override void GatedInfo(string message)
        {
        }

        protected internal override void GatedWarn(string message)
        {
        }

        protected internal override void GatedError(string message)
        {
        }

        protected internal override void GatedFatal(string message)
        {
        }
    }
}
