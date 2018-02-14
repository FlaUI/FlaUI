using System;
using System.Drawing;

namespace FlaUI.Core.Tools
{
    /// <summary>
    /// Extension methods for the <see cref="Point"/> class.
    /// </summary>
    public static class PointExtensions
    {
        public static double Distance(this Point self, Point other) => self.Distance(other.X, other.Y);
        public static double Distance(this Point self, double otherX, double otherY) => Math.Sqrt(Math.Pow(self.X - otherX, 2) + Math.Pow(self.Y - otherY, 2));
    }
}
