using System;

namespace FlaUI.Core.Logging
{
    public static class Logger
    {
        private static ILogger _default = new ConsoleLogger();

        public static ILogger Default
        {
            get
            {
                return _default;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Default logger can not be null");
                }
                _default = value;
            }
        }
    }
}
