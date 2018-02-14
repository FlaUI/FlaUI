using System;
using System.Drawing;

namespace FlaUI.Core.Overlay
{
    public interface IOverlayManager : IDisposable
    {
        /// <summary>
        /// Border size of the overlay
        /// </summary>
        int Size { get; set; }

        /// <summary>
        /// Margin of the overlay (use negative to move it inside)
        /// </summary>
        int Margin { get; set; }

        /// <summary>
        /// Shows the overlay for a small duration asynchronously.
        /// </summary>
        void Show(Rectangle rectangle, Color color, int durationInMs);

        /// <summary>
        /// Shows the overlay for a small duration and blocks the execution until it is hidden again.
        /// </summary>
        void ShowBlocking(Rectangle rectangle, Color color, int durationInMs);
    }
}
