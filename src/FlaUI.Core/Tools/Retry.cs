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
                    if (DateTime.Now.Subtract(startTime) < timeout)
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
                    if (DateTime.Now.Subtract(startTime) < timeout)
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
                if (DateTime.Now.Subtract(startTime) < timeout)
                {
                    throw new Exception("Timeout occurred in retry");
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
                if (DateTime.Now.Subtract(startTime) < timeout)
                {
                    throw new Exception("Timeout occurred in retry");
                }
                Thread.Sleep(retryInterval ?? DefaultRetryInterval);
            }
        }
    }
}
