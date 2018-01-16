using System;

namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values for the VisualEffects attribute.
    /// </summary>
    [Flags]
    public enum VisualEffects
    {
        /// <summary>
        /// No visual effects.
        /// </summary>
        None = 0,

        /// <summary>
        /// Shadow effect.
        /// </summary>
        Shadow = 1 << 0,

        /// <summary>
        /// Reflection effect.
        /// </summary>
        Reflection = 1 << 1,

        /// <summary>
        /// Glow effect.
        /// </summary>
        Glow = 1 << 2,

        /// <summary>
        /// Soft edges effect.
        /// </summary>
        SoftEdges = 1 << 3,

        /// <summary>
        /// Bevel effect.
        /// </summary>
        Bevel = 1 << 4
    }
}
