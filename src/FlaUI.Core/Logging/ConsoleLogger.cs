using System;

namespace FlaUI.Core.Logging
{
    public class ConsoleLogger : AbstractBaseLogger
    {
        public override void GatedDebug(string message)
        {
            Console.WriteLine(message);
        }

        public override void GatedError(string message)
        {
            Console.Error.WriteLine(message);
        }

        public override void GatedFatal(string message)
        {
            Console.Error.WriteLine(message);
        }

        public override void GatedInfo(string message)
        {
            Console.WriteLine(message);
        }

        public override void GatedTrace(string message)
        {
            Console.WriteLine(message);
        }

        public override void GatedWarn(string message)
        {
            Console.WriteLine(message);
        }
    }
}
