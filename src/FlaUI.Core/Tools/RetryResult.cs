using System;

namespace FlaUI.Core.Tools
{
    /// <summary>
    /// Class which represents a result when a retry method was used.
    /// </summary>
    /// <typeparam name="T">The type of the returned value from the retry.</typeparam>
    public class RetryResult<T>
    {
        /// <summary>
        /// Constructor for a new <see cref="RetryResult{T}"/>.
        /// </summary>
        public RetryResult() : this(DateTime.UtcNow)
        {
        }

        /// <summary>
        /// Constructor for a new <see cref="RetryResult{T}"/> with a given start time.
        /// </summary>
        /// <param name="manualStartTime">The start time to set.</param>
        internal RetryResult(DateTime manualStartTime)
        {
            StartTime = manualStartTime;
        }

        /// <summary>
        /// Date and time when the retry was started.
        /// </summary>
        public DateTime StartTime { get; }

        /// <summary>
        /// Date and time when the retry finished or aborted.
        /// </summary>
        public DateTime EndTime { get; private set; }

        /// <summary>
        /// Flag which indicates if the retry finished because it reached the timeout.
        /// </summary>
        public bool TimedOut { get; private set; }

        /// <summary>
        /// Flag which indicates if the retry finished successfully.
        /// </summary>
        public bool Success => !TimedOut;

        /// <summary>
        /// Contains the last occured exception in the retry (if any). Only usefull if "ignoreException" is set to true on the retry.
        /// </summary>
        public Exception LastException { get; private set; }

        /// <summary>
        /// Flag which indicates if the retry had an exception or not.
        /// </summary>
        public bool HadException => LastException != null;

        /// <summary>
        /// Contains the final value returned by the retry.
        /// </summary>
        public T Result { get; internal set; }

        /// <summary>
        /// Time span how long the retry did run.
        /// </summary>
        public TimeSpan Duration => EndTime - StartTime;

        /// <summary>
        /// Contains the counter on how many iterations the retry did before returning.
        /// </summary>
        public long Iterations { get; internal set; }

        /// <summary>
        /// Finishes the retry and sets the according values.
        /// </summary>
        /// <param name="result">The value to set as result.</param>
        /// <param name="timedOut">The flag which indicates if the retry timed out or not.</param>
        /// <returns>The object itself for fluent usage.</returns>
        internal RetryResult<T> Finish(T result, bool timedOut = false)
        {
            EndTime = DateTime.UtcNow;
            Result = result;
            TimedOut = timedOut;
            return this;
        }

        /// <summary>
        /// Sets the last exception.
        /// </summary>
        /// <param name="ex">The exception to set.</param>
        /// <returns>The object itself for fluent usage.</returns>
        internal RetryResult<T> SetException(Exception ex)
        {
            LastException = ex;
            return this;
        }
    }
}
