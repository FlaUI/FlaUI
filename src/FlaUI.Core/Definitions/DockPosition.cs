using FlaUI.Core.Patterns;

namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify the dock position of an object, represented by a <see cref="IDockPattern"/>, within a docking container.
    /// </summary>
    public enum DockPosition
    {
        /// <summary>
        /// The window is docked at the top.
        /// </summary>
        Top = 0,

        /// <summary>
        /// The window is docked at the left.
        /// </summary>
        Left = 1,

        /// <summary>
        /// The window is docked at the bottom.
        /// </summary>
        Bottom = 2,

        /// <summary>
        /// The window is docked at the right.
        /// </summary>
        Right = 3,

        /// <summary>
        /// The window is docked on all four sides.
        /// </summary>
        Fill = 4,

        /// <summary>
        /// The window is not docked.
        /// </summary>
        None = 5
    }
}
