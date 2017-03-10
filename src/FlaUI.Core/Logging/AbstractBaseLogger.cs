using System;

namespace FlaUI.Core.Logging
{
    public abstract class AbstractBaseLogger : ILogger
    {
        public bool IsTraceEnabled { get; set; }
        public bool IsDebugEnabled { get; set; }
        public bool IsInfoEnabled { get; set; }
        public bool IsWarnEnabled { get; set; }
        public bool IsErrorEnabled { get; set; }
        public bool IsFatalEnabled { get; set; }

        public abstract void GatedTrace(string message);
        public abstract void GatedDebug(string message);
        public abstract void GatedInfo(string message);
        public abstract void GatedWarn(string message);
        public abstract void GatedError(string message);
        public abstract void GatedFatal(string message);

        public AbstractBaseLogger()
        {
            IsTraceEnabled = false;
            IsDebugEnabled = false;

            // Default log level to info as info is the lowest
            // log level which should not be considered 'FlaUI developer'
            // focused.
            IsInfoEnabled = true;
            IsWarnEnabled = true;
            IsErrorEnabled = true;
            IsFatalEnabled = true;
        }

        public void Trace(string message)
        {
            if (IsTraceEnabled)
            {
                GatedTrace(message);
            }
        }

        public void Debug(string message)
        {
            if (IsDebugEnabled)
            {
                GatedDebug(message);
            }
        }

        public void Info(string message)
        {
            if (IsInfoEnabled)
            {
                GatedInfo(message);
            }
        }

        public void Warn(string message)
        {
            if (IsWarnEnabled)
            {
                GatedWarn(message);
            }
        }

        public void Error(string message)
        {
            if (IsErrorEnabled)
            {
                GatedError(message);
            }
        }

        public void Fatal(string message)
        {
            if (IsFatalEnabled)
            {
                GatedFatal(message);
            }
        }

        public void Trace(string message, Exception exception)
        {
            Trace(String.Concat(message, Environment.NewLine, exception));
        }

        public void TraceFormat(string format, params object[] args)
        {
            Trace(String.Format(format, args));
        }

        public void TraceFormat(Exception exception, string format, params object[] args)
        {
            Trace(String.Format(format, args), exception);
        }

        public void TraceFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            Trace(String.Format(formatProvider, format, args));
        }

        public void TraceFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            Trace(String.Format(formatProvider, format, args), exception);
        }

        public void Debug(string message, Exception exception)
        {
            Debug(String.Concat(message, Environment.NewLine, exception));
        }

        public void DebugFormat(string format, params object[] args)
        {
            Debug(String.Format(format, args));
        }

        public void DebugFormat(Exception exception, string format, params object[] args)
        {
            Debug(String.Format(format, args), exception);
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            Debug(String.Format(formatProvider, format, args));
        }

        public void DebugFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            Debug(String.Format(formatProvider, format, args), exception);
        }

        public void Info(string message, Exception exception)
        {
            Info(String.Concat(message, Environment.NewLine, exception));
        }

        public void InfoFormat(string format, params object[] args)
        {
            Info(String.Format(format, args));
        }

        public void InfoFormat(Exception exception, string format, params object[] args)
        {
            Info(String.Format(format, args), exception);
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            Info(String.Format(formatProvider, format, args));
        }

        public void InfoFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            Info(String.Format(formatProvider, format, args), exception);
        }

        public void Warn(string message, Exception exception)
        {
            Warn(String.Concat(message, Environment.NewLine, exception));
        }

        public void WarnFormat(string format, params object[] args)
        {
            Warn(String.Format(format, args));
        }

        public void WarnFormat(Exception exception, string format, params object[] args)
        {
            Warn(String.Format(format, args), exception);
        }

        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            Warn(String.Format(formatProvider, format, args));
        }

        public void WarnFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            Warn(String.Format(formatProvider, format, args), exception);
        }

        public void Error(string message, Exception exception)
        {
            Error(String.Concat(message, Environment.NewLine, exception));
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Error(String.Format(format, args));
        }

        public void ErrorFormat(Exception exception, string format, params object[] args)
        {
            Error(String.Format(format, args), exception);
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            Error(String.Format(formatProvider, format, args));
        }

        public void ErrorFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            Error(String.Format(formatProvider, format, args), exception);
        }

        public void Fatal(string message, Exception exception)
        {
            Fatal(String.Concat(message, Environment.NewLine, exception));
        }

        public void FatalFormat(string format, params object[] args)
        {
            Fatal(String.Format(format, args));
        }

        public void FatalFormat(Exception exception, string format, params object[] args)
        {
            Fatal(String.Format(format, args), exception);
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            Fatal(String.Format(formatProvider, format, args));
        }

        public void FatalFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            Fatal(String.Format(formatProvider, format, args), exception);
        }
    }
}
