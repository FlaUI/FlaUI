using interop.UIAutomationCore;
using System;
using System.Windows;

namespace FlaUI.Core.Shapes
{
    /// <summary>
    /// UI-independent implementation of a rectangle
    /// </summary>
    public class Rectangle : ShapeBase
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Right { get; set; }
        public double Bottom { get; set; }

        public double X { get { return Left; } set { Left = value; } }
        public double Y { get { return Top; } set { Top = value; } }
        public double Width { get { return Right - Left; } set { Right = Left + value; } }
        public double Height { get { return Bottom - Top; } set { Bottom = Top + value; } }

        public bool IsEmpty
        {
            get { return X.Equals(0) && Y.Equals(0) && Width.Equals(0) && Height.Equals(0); }
        }

        public Point Center
        {
            get { return new Point(Width / 2 + Left, Height / 2 + Top); }
        }

        public Point North { get { return GetNorth(); } }

        public Point East { get { return GetEast(); } }

        public Point South { get { return GetSouth(); } }

        public Point West { get { return GetWest(); } }

        public Point ImmediateExteriorNorth { get { return GetNorth(-1); } }

        public Point ImmediateInteriorNorth { get { return GetNorth(1); } }

        public Point ImmediateExteriorEast { get { return GetEast(1); } }

        public Point ImmediateInteriorEast { get { return GetEast(-1); } }

        public Point ImmediateExteriorSouth { get { return GetSouth(1); } }

        public Point ImmediateInteriorSouth { get { return GetSouth(-1); } }

        public Point ImmediateExteriorWest { get { return GetWest(-1); } }

        public Point ImmediateInteriorWest { get { return GetWest(1); } }

        public Rectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Implicit conversion to GDI rectangle
        /// </summary>
        public static implicit operator System.Drawing.Rectangle(Rectangle r)
        {
            return new System.Drawing.Rectangle(r.ToInt32(r.X), r.ToInt32(r.Y), r.ToInt32(r.Width), r.ToInt32(r.Height));
        }

        /// <summary>
        /// Implicit conversion from GDI rectangle
        /// </summary>
        public static implicit operator Rectangle(System.Drawing.Rectangle r)
        {
            return new Rectangle(r.X, r.Y, r.Width, r.Height);
        }

        /// <summary>
        /// Implicit conversion to WPF rectangle
        /// </summary>
        public static implicit operator Rect(Rectangle r)
        {
            return new Rect(r.X, r.Y, r.Width, r.Height);
        }

        /// <summary>
        /// Implicit conversion from WPF rectangle
        /// </summary>
        public static implicit operator Rectangle(Rect r)
        {
            return new Rectangle(r.X, r.Y, r.Width, r.Height);
        }

        /// <summary>
        /// Implicit conversion to native rectangle
        /// </summary>
        public static implicit operator tagRECT(Rectangle r)
        {
            return new tagRECT
            {
                left = r.ToInt32(r.Left),
                top = r.ToInt32(r.Top),
                right = r.ToInt32(r.Right),
                bottom = r.ToInt32(r.Bottom)
            };
        }

        /// <summary>
        /// Implicit conversion from native rectangle
        /// </summary>
        public static implicit operator Rectangle(tagRECT r)
        {
            return new Rectangle(r.left, r.top, r.right - r.left, r.bottom - r.top);
        }

        public override string ToString()
        {
            return String.Format("X={0},Y={1},Width={2},Height={3}", X, Y, Width, Height);
        }

        private Point GetNorth(int by = 0)
        {
            return new Point(Center.X, Top + by);
        }

        private Point GetEast(int by = 0)
        {
            return new Point(Right + by, Center.Y);
        }

        private Point GetSouth(int by = 0)
        {
            return new Point(Center.X, Bottom + by);
        }

        private Point GetWest(int by = 0)
        {
            return new Point(Left + by, Center.Y);
        }
    }
}
