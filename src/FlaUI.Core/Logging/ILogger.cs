using System;

namespace FlaUI.Core.Logging
{
    public interface ILogger
    {
        bool IsTraceEnabled { get; set; }
        bool IsDebugEnabled { get; set; }
        bool IsInfoEnabled { get; set; }
        bool IsWarnEnabled { get; set; }
        bool IsErrorEnabled { get; set; }
        bool IsFatalEnabled { get; set; }

        void SetMinLevel(LogLevel minLevel);

        void Log(LogLevel logLevel, string message, params object[] args);
        void Log(LogLevel logLevel, string message, Exception exception, params object[] args);

        void Trace(string message, params object[] args);
        void Trace(string message, Exception exception, params object[] args);

        void Debug(string message, params object[] args);
        void Debug(string message, Exception exception, params object[] args);

        void Info(string message, params object[] args);
        void Info(string message, Exception exception, params object[] args);

        void Warn(string message, params object[] args);
        void Warn(string message, Exception exception, params object[] args);

        void Error(string message, params object[] args);
        void Error(string message, Exception exception, params object[] args);

        void Fatal(string message, params object[] args);
        void Fatal(string message, Exception exception, params object[] args);
    }
}
