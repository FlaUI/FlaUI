using System;

namespace FlaUI.Core.Logging
{
    public class EventLogger : LoggerBase
    {
        public event Action<string> OnTrace;
        public event Action<string> OnDebug;
        public event Action<string> OnInfo;
        public event Action<string> OnWarn;
        public event Action<string> OnError;
        public event Action<string> OnFatal;
        public event Action<LogLevel, string> OnLog;

        protected override void GatedTrace(string message)
        {
            OnTrace?.Invoke(message);
            OnLog?.Invoke(LogLevel.Trace, message);
        }

        protected override void GatedDebug(string message)
        {
            OnDebug?.Invoke(message);
            OnLog?.Invoke(LogLevel.Debug, message);
        }

        protected override void GatedInfo(string message)
        {
            OnInfo?.Invoke(message);
            OnLog?.Invoke(LogLevel.Info, message);
        }

        protected override void GatedWarn(string message)
        {
            OnWarn?.Invoke(message);
            OnLog?.Invoke(LogLevel.Warn, message);
        }

        protected override void GatedError(string message)
        {
          OnError?.Invoke(message);
            OnLog?.Invoke(LogLevel.Error, message);
        }

        protected override void GatedFatal(string message)
        {
            OnFatal?.Invoke(message);
            OnLog?.Invoke(LogLevel.Fatal, message);
        }
    }
}
