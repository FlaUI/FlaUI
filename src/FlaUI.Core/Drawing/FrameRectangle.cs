using System;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace FlaUI.Core.Drawing
{
    public class FrameRectangle
    {
        private readonly ScreenRectangle[] _rectangles;
        const int Width = 3;

        internal FrameRectangle(Color color, Rectangle boundingRectangle)
        {
            // Using 4 rectangles to display each border
            var leftBorder = new ScreenRectangle(color, new Rectangle(boundingRectangle.X - Width, boundingRectangle.Y - Width, Width, boundingRectangle.Height + 2 * Width));
            var topBorder = new ScreenRectangle(color, new Rectangle(boundingRectangle.X, boundingRectangle.Y - Width, boundingRectangle.Width, Width));
            var rightBorder = new ScreenRectangle(color, new Rectangle(boundingRectangle.X + boundingRectangle.Width, boundingRectangle.Y - Width, Width, boundingRectangle.Height + 2 * Width));
            var bottomBorder = new ScreenRectangle(color, new Rectangle(boundingRectangle.X, boundingRectangle.Y + boundingRectangle.Height, boundingRectangle.Width, Width));
            _rectangles = new[] { leftBorder, topBorder, rightBorder, bottomBorder };
        }

        internal virtual void Highlight()
        {
            _rectangles.ToList().ForEach(x => x.Show());
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _rectangles.ToList().ForEach(x => x.Hide());
        }
    }
}
