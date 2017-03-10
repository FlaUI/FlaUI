namespace FlaUI.Core.Logging
{
    public class DebugLogger : AbstractBaseLogger
    {
        public override void GatedDebug(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public override void GatedError(string message)
        {
            System.Diagnostics.Debug.Fail(message);
        }

        public override void GatedFatal(string message)
        {
            System.Diagnostics.Debug.Fail(message);
        }

        public override void GatedInfo(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public override void GatedTrace(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public override void GatedWarn(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
