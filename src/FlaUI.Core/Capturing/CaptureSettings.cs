namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// Class with various settings for capturing images.
    /// </summary>
    public class CaptureSettings
    {
        /// <summary>
        /// The width of the output. Set to -1 to scale it in aspect ratio to the <see cref="OutputHeight"/>.
        /// </summary>
        public int OutputWidth { get; set; } = -1;

        /// <summary>
        /// The height of the output. Set to -1 to scale it in aspect ratio to the <see cref="OutputWidth"/>.
        /// </summary>
        public int OutputHeight { get; set; } = -1;

        /// <summary>
        /// The scale of the output (1 == 100%).
        /// </summary>
        public double OutputScale { get; set; } = 1;
    }
}
