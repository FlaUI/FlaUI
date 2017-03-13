using System;
using System.Threading;

namespace FlaUI.Core.Tools
{
    public static class Retry
    {
        public static readonly TimeSpan DefaultRetryFor = TimeSpan.FromMilliseconds(1000);
        private static readonly TimeSpan DefaultRetryInterval = TimeSpan.FromMilliseconds(200);

        public static void WhileException(Action retryAction, TimeSpan timeout, TimeSpan? retryInterval = null)
        {
            var startTime = DateTime.Now;
            while (true)
            {
                try
                {
                    retryAction();
                    return;
                }
                catch (Exception ex)
                {
                    if (IsTimeouted(startTime, timeout))
                    {
                        throw new Exception("Timeout occurred in retry", ex);
                    }
                    Thread.Sleep(retryInterval ?? DefaultRetryInterval);
                }
            }
        }

        public static T WhileException<T>(Func<T> retryMethod, TimeSpan timeout, TimeSpan? retryInterval = null)
        {
            var startTime = DateTime.Now;
            while (true)
            {
                try
                {
                    return retryMethod();
                }
                catch (Exception ex)
                {
                    if (IsTimeouted(startTime, timeout))
                    {
                        throw new Exception("Timeout occurred in retry", ex);
                    }
                    Thread.Sleep(retryInterval ?? DefaultRetryInterval);
                }
            }
        }

        public static T While<T>(Func<T> retryMethod, Predicate<T> whilePredicate, TimeSpan timeout, TimeSpan? retryInterval = null)
        {
            var startTime = DateTime.Now;
            while (true)
            {
                var obj = retryMethod();
                if (!whilePredicate(obj))
                {
                    return obj;
                }
                if (IsTimeouted(startTime, timeout))
                {
                    return obj;
                }
                Thread.Sleep(retryInterval ?? DefaultRetryInterval);
            }
        }

        public static void While(Func<bool> whilePredicate, TimeSpan timeout, TimeSpan? retryInterval = null)
        {
            var startTime = DateTime.Now;
            while (true)
            {
                if (!whilePredicate())
                {
                    return;
                }
                if (IsTimeouted(startTime, timeout))
                {
                    return;
                }
                Thread.Sleep(retryInterval ?? DefaultRetryInterval);
            }
        }

        private static bool IsTimeouted(DateTime startTime, TimeSpan timeout)
        {
            // Check for infinite timeout
            if (timeout.TotalMilliseconds < 0)
            {
                return false;
            }
            return DateTime.Now.Subtract(startTime) >= timeout;
        }
    }
}
