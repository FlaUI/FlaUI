using System;

namespace FlaUI.Core.Logging
{
    public class ConsoleLogger : LoggerBase
    {
        protected internal override void GatedDebug(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        protected internal override void GatedError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine(message);
            Console.ResetColor();
        }

        protected internal override void GatedFatal(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Error.WriteLine(message);
            Console.ResetColor();
        }

        protected internal override void GatedInfo(string message)
        {
            Console.WriteLine(message);
        }

        protected internal override void GatedTrace(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        protected internal override void GatedWarn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
