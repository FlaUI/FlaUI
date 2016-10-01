using System;
using System.Threading;

namespace FlaUI.UIA3.Tools
{
    public static class Retry
    {
        private static readonly TimeSpan DefaultRetryInterval = TimeSpan.FromMilliseconds(200);
        private static readonly TimeSpan DefaultRetryFor = TimeSpan.Zero;

        public static T ForDefault<T>(Func<T> func, Predicate<T> shouldRetry)
        {
            return For(func, shouldRetry, DefaultRetryFor);
        }

        public static void ForDefault(Action action)
        {
            For(action, DefaultRetryFor);
        }

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
