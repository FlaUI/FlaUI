namespace FlaUI.Core.Logging
{
    public class TraceLogger : LoggerBase
    {
        protected internal override void GatedDebug(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);
        }

        protected internal override void GatedError(string message)
        {
            System.Diagnostics.Trace.TraceError(message);
        }

        protected internal override void GatedFatal(string message)
        {
            System.Diagnostics.Trace.TraceError(message);
        }

        protected internal override void GatedInfo(string message)
        {
            System.Diagnostics.Trace.TraceError(message);
        }

        protected internal override void GatedTrace(string message)
        {
             System.Diagnostics.Trace.WriteLine(message);
        }

        protected internal override void GatedWarn(string message)
        {
            System.Diagnostics.Trace.TraceWarning(message);
        }
    }
}
