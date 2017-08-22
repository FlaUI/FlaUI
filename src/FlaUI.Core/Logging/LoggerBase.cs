using System;

namespace FlaUI.Core.Logging
{
    public abstract class LoggerBase : ILogger
    {
        public bool IsTraceEnabled { get; set; }
        public bool IsDebugEnabled { get; set; }
        public bool IsInfoEnabled { get; set; }
        public bool IsWarnEnabled { get; set; }
        public bool IsErrorEnabled { get; set; }
        public bool IsFatalEnabled { get; set; }

        protected abstract void GatedTrace(string message);
        protected abstract void GatedDebug(string message);
        protected abstract void GatedInfo(string message);
        protected abstract void GatedWarn(string message);
        protected abstract void GatedError(string message);
        protected abstract void GatedFatal(string message);

        protected LoggerBase()
        {
            IsTraceEnabled = false;
            IsDebugEnabled = false;
            // Default log level is info and higher
            IsInfoEnabled = true;
            IsWarnEnabled = true;
            IsErrorEnabled = true;
            IsFatalEnabled = true;
        }

        public void Log(LogLevel logLevel, string message, params object[] args)
        {
            Log(logLevel, message, null, args);
        }

        public void Log(LogLevel logLevel, string message, Exception exception, params object[] args)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    if (IsTraceEnabled) { GatedTrace(GetFormattedMessage(message, exception, args)); }
                    break;
                case LogLevel.Debug:
                    if (IsDebugEnabled) { GatedDebug(GetFormattedMessage(message, exception, args)); }
                    break;
                case LogLevel.Info:
                    if (IsInfoEnabled) { GatedInfo(GetFormattedMessage(message, exception, args)); }
                    break;
                case LogLevel.Warn:
                    if (IsWarnEnabled) { GatedWarn(GetFormattedMessage(message, exception, args)); }
                    break;
                case LogLevel.Error:
                    if (IsErrorEnabled) { GatedError(GetFormattedMessage(message, exception, args)); }
                    break;
                case LogLevel.Fatal:
                    if (IsFatalEnabled) { GatedFatal(GetFormattedMessage(message, exception, args)); }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        public void Trace(string message, params object[] args)
        {
            Log(LogLevel.Trace, message, null, args);
        }

        public void Trace(string message, Exception exception, params object[] args)
        {
            Log(LogLevel.Trace, message, exception, args);
        }

        public void Debug(string message, params object[] args)
        {
            Log(LogLevel.Debug, message, null, args);
        }

        public void Debug(string message, Exception exception, params object[] args)
        {
            Log(LogLevel.Debug, message, exception, args);
        }

        public void Info(string message, params object[] args)
        {
            Log(LogLevel.Info, message, null, args);
        }

        public void Info(string message, Exception exception, params object[] args)
        {
            Log(LogLevel.Info, message, exception, args);
        }

        public void Warn(string message, params object[] args)
        {
            Log(LogLevel.Warn, message, null, args);
        }

        public void Warn(string message, Exception exception, params object[] args)
        {
            Log(LogLevel.Warn, message, exception, args);
        }

        public void Error(string message, params object[] args)
        {
            Log(LogLevel.Error, message, null, args);
        }

        public void Error(string message, Exception exception, params object[] args)
        {
            Log(LogLevel.Error, message, exception, args);
        }

        public void Fatal(string message, params object[] args)
        {
            Log(LogLevel.Fatal, message, null, args);
        }

        public void Fatal(string message, Exception exception, params object[] args)
        {
            Log(LogLevel.Fatal, message, exception, args);
        }

        private string GetFormattedMessage(string message, Exception exception, params object[] args)
        {
            var formattedMsg = args == null ? message : String.Format(message, args);
            return exception == null ? formattedMsg : String.Concat(formattedMsg, Environment.NewLine, exception);
        }
    }
}
