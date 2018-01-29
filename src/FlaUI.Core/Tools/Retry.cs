using System;
using System.Threading;

namespace FlaUI.Core.Tools
{
    /// <summary>
    /// Static class with methods for retrying actions.
    /// </summary>
    public static class Retry
    {
        /// <summary>
        /// The default timeout to use for retries without a given timeout. The default is 1000ms.
        /// </summary>
        public static TimeSpan Timeout { get; set; } = TimeSpan.FromMilliseconds(1000);

        /// <summary>
        /// The default interval to use for retries without a given interval. The default is 100ms.
        /// </summary>
        public static TimeSpan Interval { get; set; } = TimeSpan.FromMilliseconds(100);

        /// <summary>
        /// Retries while the given method evaluates to true.
        /// </summary>
        /// <returns>True if the condition met, false otherwise.</returns>
        public static bool While(Func<bool> checkMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false, bool ignoreException = false)
        {
            timeout = timeout ?? Timeout;
            interval = interval ?? Interval;
            var startTime = DateTime.UtcNow;
            Exception lastException = null;
            do
            {
                try
                {
                    if (!checkMethod())
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    if (!ignoreException)
                    {
                        throw;
                    }
                    lastException = ex;
                }
                Thread.Sleep(interval.Value);
            } while (!IsTimeoutReached(startTime, timeout.Value));
            if (throwOnTimeout)
            {
                throw new TimeoutException("Timeout occurred in retry", lastException);
            }
            return false;
        }

        /// <summary>
        /// Retries while the given method evaluates to true and returns the value from the method.
        /// </summary>
        public static T While<T>(Func<T> retryMethod, Func<T, bool> checkMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false, bool ignoreException = false)
        {
            timeout = timeout ?? Timeout;
            interval = interval ?? Interval;
            var startTime = DateTime.UtcNow;
            Exception lastException = null;
            do
            {
                try
                {
                    var obj = retryMethod();
                    if (!checkMethod(obj))
                    {
                        return obj;
                    }
                }
                catch (Exception ex)
                {
                    if (!ignoreException)
                    {
                        throw;
                    }
                    lastException = ex;
                }
                Thread.Sleep(interval.Value);
            } while (!IsTimeoutReached(startTime, timeout.Value));
            if (throwOnTimeout)
            {
                throw new TimeoutException("Timeout occurred in retry", lastException);
            }
            return default(T);
        }

        /// <summary>
        /// Retries while the given method has an exception.
        /// </summary>
        /// <returns>True if the method completed successfully, false otherwise.</returns>
        public static bool WhileException(Action retryMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false)
        {
            timeout = timeout ?? Timeout;
            interval = interval ?? Interval;
            var startTime = DateTime.UtcNow;
            Exception lastException;
            do
            {
                try
                {
                    retryMethod();
                    return true;
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }
                Thread.Sleep(interval.Value);
            } while (!IsTimeoutReached(startTime, timeout.Value));
            if (throwOnTimeout)
            {
                throw new TimeoutException("Timeout occurred in retry", lastException);
            }
            return false;
        }

        /// <summary>
        /// Retries while the given method has an exception and returns the value from the method.
        /// </summary>
        public static T WhileException<T>(Func<T> retryMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false)
        {
            timeout = timeout ?? Timeout;
            interval = interval ?? Interval;
            var startTime = DateTime.UtcNow;
            Exception lastException;
            do
            {
                try
                {
                    return retryMethod();
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }
                Thread.Sleep(interval.Value);
            } while (!IsTimeoutReached(startTime, timeout.Value));
            if (throwOnTimeout)
            {
                throw new TimeoutException("Timeout occurred in retry", lastException);
            }
            return default(T);
        }

        /// <summary>
        /// Method which checks if the timeout is reached.
        /// </summary>
        private static bool IsTimeoutReached(DateTime startTime, TimeSpan timeout)
        {
            // Check for infinite timeout
            if (timeout.TotalMilliseconds < 0)
            {
                return false;
            }
            return DateTime.UtcNow.Subtract(startTime) > timeout;
        }
    }
}
