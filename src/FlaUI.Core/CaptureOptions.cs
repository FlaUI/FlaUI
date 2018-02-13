namespace FlaUI.Core
{
    /// <summary>
    /// Options for capturing the screen.
    /// </summary>
    public class CaptureOptions
    {
        /// <summary>
        /// Flag to indicate if the mouse cursor should be painted.
        /// </summary>
        public bool AddCursor { get; set; } = true;

        /// <summary>
        /// Flag to indicate if the overlay string should be added
        /// </summary>
        public bool AddOverlayString { get; set; } = true;

        /// <summary>
        /// The string to use for the overlay. Has some variables which are automatically replaced.
        /// </summary>
        public string OverlayStringFormat { get; set; }

        /// <summary>
        /// The position of the overlay.
        /// </summary>
        public InfoOverlayPosition OverlayPosition { get; set; }

        public CaptureOptions()
        {
            // Set the default of the overlay string
            OverlayStringFormat = "{dt:yyyy-MM-dd HH:mm:ss.fff} / {name} / CPU: {cpu} / RAM: {mem.p.used}/{mem.p.tot} ({mem.p.used.perc})";
        }
    }

    public enum InfoOverlayPosition
    {
        Top,
        Bottom
    }
}
