using System;

namespace FlaUI.Core.Logging
{
    public interface ILogger
    {
        bool IsTraceEnabled { get; }
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }

        void Trace(string message);
        void Trace(string message, Exception exception);
        void TraceFormat(string format, params object[] args);
        void TraceFormat(Exception exception, string format, params object[] args);
        void TraceFormat(IFormatProvider formatProvider, string format, params object[] args);
        void TraceFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args);

        void Debug(string message);
        void Debug(string message, Exception exception);
        void DebugFormat(string format, params object[] args);
        void DebugFormat(Exception exception, string format, params object[] args);
        void DebugFormat(IFormatProvider formatProvider, string format, params object[] args);
        void DebugFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args);

        void Info(string message);
        void Info(string message, Exception exception);
        void InfoFormat(string format, params object[] args);
        void InfoFormat(Exception exception, string format, params object[] args);
        void InfoFormat(IFormatProvider formatProvider, string format, params object[] args);
        void InfoFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args);

        void Warn(string message);
        void Warn(string message, Exception exception);
        void WarnFormat(string format, params object[] args);
        void WarnFormat(Exception exception, string format, params object[] args);
        void WarnFormat(IFormatProvider formatProvider, string format, params object[] args);
        void WarnFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args);

        void Error(string message);
        void Error(string message, Exception exception);
        void ErrorFormat(string format, params object[] args);
        void ErrorFormat(Exception exception, string format, params object[] args);
        void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args);
        void ErrorFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args);

        void Fatal(string message);
        void Fatal(string message, Exception exception);
        void FatalFormat(string format, params object[] args);
        void FatalFormat(Exception exception, string format, params object[] args);
        void FatalFormat(IFormatProvider formatProvider, string format, params object[] args);
        void FatalFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args);
    }
}
