// ReSharper disable InconsistentNaming
namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// Defines the video format that should be used for recording.
    /// </summary>
    public enum VideoFormat
    {
        /// <summary>
        /// Small file size, high cpu usage.
        /// </summary>
        x264,
        /// <summary>
        /// Medium file size, low cpu usage.
        /// </summary>
        xvid
    }
}
