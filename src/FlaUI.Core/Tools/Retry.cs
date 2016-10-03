using System;
using System.Threading;

namespace FlaUI.Core.Tools
{
    public static class Retry
    {
        private static readonly TimeSpan DefaultRetryInterval = TimeSpan.FromMilliseconds(200);

        public static void For(Action action, TimeSpan retryFor, TimeSpan? retryInterval = null)
        {
            var startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < retryFor.TotalMilliseconds)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception)
                {
                    Thread.Sleep(retryInterval ?? DefaultRetryInterval);
                }
            }

            action();
        }

        public static T For<T>(Func<T> func, Predicate<T> shouldRetry, TimeSpan retryFor,
            TimeSpan? retryInterval = null)
        {
            var startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < retryFor.TotalMilliseconds)
            {
                T element;
                try
                {
                    element = func();
                }
                catch (Exception)
                {
                    Thread.Sleep(retryInterval ?? DefaultRetryInterval);
                    continue;
                }

                if (!shouldRetry(element))
                    return element;
            }

            return func();
        }
    }
}
