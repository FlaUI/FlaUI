namespace FlaUI.Core.Logging
{
    public class TraceLogger : AbstractBaseLogger
    {
        public override void GatedDebug(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);
        }

        public override void GatedError(string message)
        {
            System.Diagnostics.Trace.TraceError(message);
        }

        public override void GatedFatal(string message)
        {
            System.Diagnostics.Trace.TraceError(message);
        }

        public override void GatedInfo(string message)
        {
            System.Diagnostics.Trace.TraceError(message);
        }

        public override void GatedTrace(string message)
        {
             System.Diagnostics.Trace.WriteLine(message);
        }

        public override void GatedWarn(string message)
        {
            System.Diagnostics.Trace.TraceWarning(message);
        }
    }
}
