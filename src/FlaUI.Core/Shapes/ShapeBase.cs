using System;

namespace FlaUI.Core.Shapes
{
    /// <summary>
    /// Base class for coordinate based shapes
    /// </summary>
    public abstract class ShapeBase
    {
        /// <summary>
        /// Converts the value to the nearest int32
        /// </summary>
        public int ToInt32(double value)
        {
            return Convert.ToInt32(value);
        }
    }
}
