using System;
using System.Collections;
using System.Threading;

namespace FlaUI.Core.Tools
{
    public class RetryResult<T>
    {
        public RetryResult()
        {
            StartTime = DateTime.UtcNow;
        }

        public DateTime StartTime { get; }
        public DateTime EndTime { get; private set; }
        public bool TimedOut { get; private set; }
        public Exception LastException { get; private set; }
        public bool HadException => LastException != null;
        public T Result { get; private set; }
        public TimeSpan Duration => EndTime - StartTime;
        public long Iterations { get; internal set; }

        internal RetryResult<T> Finish(T result, bool timedOut = false)
        {
            EndTime = DateTime.UtcNow;
            Result = result;
            TimedOut = timedOut;
            return this;
        }

        internal void SetException(Exception ex)
        {
            LastException = ex;
        }
    }

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
        /// Retries while the given method evaluates to true and returns the value from the method.
        /// If it fails, it returns the default of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="retryMethod">The method which is retried.</param>
        /// <param name="checkMethod">The method which is used to decide if a retry is needed or if the value is correct.</param>
        /// <param name="timeout">The timeout when the retry aborts.</param>
        /// <param name="interval">The interval of retries.</param>
        /// <param name="throwOnTimeout">A flag indicating if it should throw on timeout.</param>
        /// <param name="ignoreException">A flag indicating if it should retry on an exception.</param>
        /// <param name="lastValueOnTimeout">A flag indicating if the last value should be returned on timeout. Returns the default if the value could never be fetched.</param>
        /// <param name="defaultOnTimeout">Allows to define a default value in case of a timeout.</param>
        /// <returns>The value from <paramref name="checkMethod"/> or the default of <typeparamref name="T"/>.</returns>
        public static RetryResult<T> While<T>(Func<T> retryMethod, Func<T, bool> checkMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false, bool ignoreException = false, bool lastValueOnTimeout = false, T defaultOnTimeout = default(T))
        {
            var retryResult = new RetryResult<T>();
            timeout = timeout ?? Timeout;
            interval = interval ?? Interval;
            var startTime = DateTime.UtcNow;
            Exception lastException = null;
            T lastValue = defaultOnTimeout;
            do
            {
                retryResult.Iterations++;
                try
                {
                    lastValue = retryMethod();
                    if (!checkMethod(lastValue))
                    {
                        return retryResult.Finish(lastValue);
                    }
                }
                catch (Exception ex)
                {
                    if (!ignoreException)
                    {
                        throw;
                    }
                    lastException = ex;
                    retryResult.SetException(ex);
                }
                Thread.Sleep(interval.Value);
            } while (!IsTimeoutReached(startTime, timeout.Value));
            if (throwOnTimeout)
            {
                throw new TimeoutException("Timeout occurred in retry", lastException);
            }
            return retryResult.Finish(lastValueOnTimeout ? lastValue : defaultOnTimeout, true);
        }

        /// <summary>
        /// Retries while the given method evaluates to true.
        /// </summary>
        /// <returns>True if the retry completed successfully within the time and false otherwise.</returns>
        public static RetryResult<bool> WhileTrue(Func<bool> checkMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false, bool ignoreException = false)
        {
            // Use the generic retry. To have the correct return value on success, we need to inverse the result of the check method.
            return While(() => !checkMethod(), r => !r, timeout: timeout, interval: interval, throwOnTimeout: throwOnTimeout, ignoreException: ignoreException);
        }

        /// <summary>
        /// Retries while the given method evaluates to false.
        /// </summary>
        /// <returns>True if the retry completed successfully within the time and false otherwise.</returns>
        public static RetryResult<bool> WhileFalse(Func<bool> checkMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false, bool ignoreException = false)
        {
            // Use the generic retry. To have the correct return value on success, we need to inverse the result of the check method.
            return While(() => checkMethod(), r => !r, timeout: timeout, interval: interval, throwOnTimeout: throwOnTimeout, ignoreException: ignoreException);
        }

        /// <summary>
        /// Retries while the given method evaluates to null.
        /// </summary>
        /// <returns>The value from <paramref name="checkMethod"/> or the default of <typeparamref name="T"/> in case of a timeout.</returns>
        public static RetryResult<T> WhileNull<T>(Func<T> checkMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false, bool ignoreException = false)
        {
            return While(checkMethod, r => r == null, timeout: timeout, interval: interval, throwOnTimeout: throwOnTimeout, ignoreException: ignoreException);
        }

        /// <summary>
        /// Retries while the given method evaluates to not null.
        /// </summary>
        /// <returns>True if it evaluated to null within the time or false in case of a timeout.</returns>
        public static RetryResult<bool> WhileNotNull<T>(Func<T> checkMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false, bool ignoreException = false)
        {
            return WhileTrue(() => checkMethod() != null, timeout: timeout, interval: interval, throwOnTimeout: throwOnTimeout, ignoreException: ignoreException);
        }

        /// <summary>
        /// Retries while return value from the given method evaluates to null or has no elements.
        /// </summary>
        public static RetryResult<T> WhileEmpty<T>(Func<T> checkMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false, bool ignoreException = false) where T : IEnumerable
        {
            return While(checkMethod, r => r == null || !r.GetEnumerator().MoveNext(), timeout: timeout, interval: interval, throwOnTimeout: throwOnTimeout, ignoreException: ignoreException);
        }

        /// <summary>
        /// Retries while return value from the given method is null or an empty string.
        /// </summary>
        public static RetryResult<string> WhileEmpty(Func<string> checkMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false, bool ignoreException = false)
        {
            return While(checkMethod, r => String.IsNullOrEmpty(r), timeout: timeout, interval: interval, throwOnTimeout: throwOnTimeout, ignoreException: ignoreException);
        }

        /// <summary>
        /// Retries while the given method has an exception.
        /// </summary>
        /// <returns>True if the method completed without exception, false otherwise.</returns>
        public static RetryResult<bool> WhileException(Action retryMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false)
        {
            var success = false;
            WhileTrue(() => { retryMethod(); success = true; return false; }, timeout: timeout, interval: interval, ignoreException: true, throwOnTimeout: throwOnTimeout);
            return success;
        }

        /// <summary>
        /// Retries while the given method has an exception and returns the value from the method.
        /// </summary>
        public static RetryResult<T> WhileException<T>(Func<T> retryMethod, TimeSpan? timeout = null, TimeSpan? interval = null, bool throwOnTimeout = false)
        {
            T returnValue = default(T);
            WhileTrue(() => { returnValue = retryMethod(); return false; }, timeout: timeout, interval: interval, ignoreException: true, throwOnTimeout: throwOnTimeout);
            return returnValue;
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
