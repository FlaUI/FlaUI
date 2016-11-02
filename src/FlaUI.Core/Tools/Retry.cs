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
            while (DateTime.Now.Subtract(startTime) < timeout)
            {
                try
                {
                    retryAction();
                    return;
                }
                catch (Exception)
                {
                    Thread.Sleep(retryInterval ?? DefaultRetryInterval);
                }
            }
            retryAction();
        }

        public static T WhileException<T>(Func<T> retryMethod, TimeSpan timeout, TimeSpan? retryInterval = null)
        {
            var startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime) < timeout)
            {
                try
                {
                    return retryMethod();
                }
                catch (Exception)
                {
                    Thread.Sleep(retryInterval ?? DefaultRetryInterval);
                }
            }
            return retryMethod();
        }

        public static T While<T>(Func<T> retryMethod, Predicate<T> whilePredicate, TimeSpan timeout, TimeSpan? retryInterval = null)
        {
            var startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime) < timeout)
            {
                T element;
                try
                {
                    element = retryMethod();
                }
                catch (Exception)
                {
                    Thread.Sleep(retryInterval ?? DefaultRetryInterval);
                    continue;
                }

                if (whilePredicate(element))
                {
                    Thread.Sleep(retryInterval ?? DefaultRetryInterval);
                    continue;
                }

                return element;
            }
            return retryMethod();
        }
    }
}
