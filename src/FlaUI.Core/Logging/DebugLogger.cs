namespace FlaUI.Core.Logging
{
    public class DebugLogger : LoggerBase
    {
        protected override void GatedDebug(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        protected override void GatedError(string message)
        {
            System.Diagnostics.Debug.Fail(message);
        }

        protected override void GatedFatal(string message)
        {
            System.Diagnostics.Debug.Fail(message);
        }

        protected override void GatedInfo(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        protected override void GatedTrace(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        protected override void GatedWarn(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
