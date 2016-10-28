using System.Windows;
using FlaUI.Core.Tools;

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

        public double X
        {
            get { return Left; }
            set { Left = value; }
        }

        public double Y
        {
            get { return Top; }
            set { Top = value; }
        }

        public double Width
        {
            get { return Right - Left; }
            set { Right = Left + value; }
        }

        public double Height
        {
            get { return Bottom - Top; }
            set { Bottom = Top + value; }
        }

        public bool IsEmpty => X.Equals(0) && Y.Equals(0) && Width.Equals(0) && Height.Equals(0);

        public bool IsValid => X.HasValue() && Y.HasValue() && Width.HasValue() && Height.HasValue();

        public Point Center => new Point(Width / 2 + Left, Height / 2 + Top);

        public Point North => GetNorth();

        public Point East => GetEast();

        public Point South => GetSouth();

        public Point West => GetWest();

        public Point ImmediateExteriorNorth => GetNorth(-1);

        public Point ImmediateInteriorNorth => GetNorth(1);

        public Point ImmediateExteriorEast => GetEast(1);

        public Point ImmediateInteriorEast => GetEast(-1);

        public Point ImmediateExteriorSouth => GetSouth(1);

        public Point ImmediateInteriorSouth => GetSouth(-1);

        public Point ImmediateExteriorWest => GetWest(-1);

        public Point ImmediateInteriorWest => GetWest(1);

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
            return new System.Drawing.Rectangle(r.X.ToInt(), r.Y.ToInt(), r.Width.ToInt(), r.Height.ToInt());
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

        public override string ToString()
        {
            return $"X={X},Y={Y},Width={Width},Height={Height}";
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

        public static Rectangle Empty => new Rectangle(0, 0, 0, 0);
    }
}
