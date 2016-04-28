using FlaUI.Core.WindowsAPI;
using System;

namespace FlaUI.Core.Shapes
{
    /// <summary>
    /// UI-independent implementation of a point
    /// </summary>
    public class Point : ShapeBase
    {
        /// <summary>
        /// Exact x-coordinate
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Exact y-coordinate
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        ///  Gets a value indicating whether this point is empty (all coordinates are 0)
        /// </summary>
        public bool IsEmpty
        {
            get { return X.Equals(0) && Y.Equals(0); }
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Calculates the distance to the other given point
        /// </summary>
        public double Distance(Point otherPoint)
        {
            return Distance(otherPoint.X, otherPoint.Y);
        }

        public double Distance(double otherX, double otherY)
        {
            return Math.Sqrt(Math.Pow(X - otherX, 2) + Math.Pow(Y - otherY, 2));
        }

        /// <summary>
        /// Implicit conversion to GDI point
        /// </summary>
        public static implicit operator System.Drawing.Point(Point p)
        {
            return new System.Drawing.Point(p.ToInt32(p.X), p.ToInt32(p.Y));
        }

        /// <summary>
        /// Implicit conversion from GDI point
        /// </summary>
        public static implicit operator Point(System.Drawing.Point p)
        {
            return new Point(p.X, p.Y);
        }

        /// <summary>
        /// Implicit conversion to WPF point
        /// </summary>
        public static implicit operator System.Windows.Point(Point p)
        {
            return new System.Windows.Point(p.X, p.Y);
        }

        /// <summary>
        /// Implicit conversion from WPF point
        /// </summary>
        public static implicit operator Point(System.Windows.Point p)
        {
            return new Point(p.X, p.Y);
        }

        /// <summary>
        /// Implicit conversion to native point
        /// </summary>
        public static implicit operator POINT(Point p)
        {
            return new POINT { X = p.ToInt32(p.X), Y = p.ToInt32(p.Y) };
        }

        /// <summary>
        /// Implicit conversion from native point
        /// </summary>
        public static implicit operator Point(POINT p)
        {
            return new Point(p.X, p.Y);
        }

        public override string ToString()
        {
            return String.Format("X={0},Y={1}", X, Y);
        }
    }
}
