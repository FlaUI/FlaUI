using System;

namespace FlaUI.Core.Logging
{
    public static class Logger
    {
        private static ILogger _default = new ConsoleLogger();

        public static ILogger Default
        {
            get => _default;
            set => _default = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
