using System;

/// <summary>
/// This object contains various settings that influence the behavior of retries.
/// </summary>
public class RetrySettings
{
    /// <summary>
    /// The timeout when the retry will abort if it did not succeed.
    /// </summary>
    public TimeSpan? Timeout { get; set; }

    /// <summary>
    /// The interval of the retries.
    /// </summary>
    public TimeSpan? Interval { get; set; }

    /// <summary>
    /// A flag indicating if it should throw an <see cref="TimeoutException"/> if the timeout is reached.
    /// </summary>
    public bool ThrowOnTimeout { get; set; }

    /// <summary>
    /// A flag indicating if it should continue retrying when an exception occurs.
    /// </summary>
    public bool IgnoreException { get; set; }

    /// <summary>
    /// The message that should be added to the timeout exception in case a timeout occurs.
    /// </summary>
    public string TimeoutMessage { get; set; }
}
