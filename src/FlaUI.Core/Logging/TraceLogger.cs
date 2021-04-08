namespace FlaUI.Core.Logging
{
    public class TraceLogger : LoggerBase
    {
        protected override void GatedDebug(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);
        }

        protected override void GatedError(string message)
        {
            System.Diagnostics.Trace.TraceError(message);
        }

        protected override void GatedFatal(string message)
        {
            System.Diagnostics.Trace.TraceError(message);
        }

        protected override void GatedInfo(string message)
        {
            System.Diagnostics.Trace.TraceError(message);
        }

        protected override void GatedTrace(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);
        }

        protected override void GatedWarn(string message)
        {
            System.Diagnostics.Trace.TraceWarning(message);
        }
    }
}
