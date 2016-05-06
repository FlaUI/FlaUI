using System;

namespace FlaUI.Core.Logging
{
    public class ConsoleLogger : ILogger
    {
        public bool IsTraceEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsDebugEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsInfoEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsWarnEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsErrorEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsFatalEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public void Trace(string message)
        {
            Console.WriteLine(message);
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

        public void Debug(string message)
        {
            Console.WriteLine(message);
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

        public void Info(string message)
        {
            Console.WriteLine(message);
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

        public void Warn(string message)
        {
            Console.WriteLine(message);
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

        public void Error(string message)
        {
            Console.WriteLine(message);
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

        public void Fatal(string message)
        {
            Console.WriteLine(message);
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
