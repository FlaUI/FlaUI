using System;
using System.Drawing;
using FlaUI.Core.Input;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    [Ignore("Only for local testing for now as a demo app is missing.")]
    public class TouchTests
    {
        [Test]
        public void Test()
        {
            var currPos = Mouse.Position;

            Touch.Tap(currPos);

            Touch.Hold(TimeSpan.FromSeconds(2), currPos);

            Touch.Pinch(currPos, 0, 100, TimeSpan.FromSeconds(2));

            Touch.Drag(TimeSpan.FromSeconds(2), currPos, Point.Add(currPos, new Size(100, 0)));

            Touch.Rotate(currPos, 200, 0, 2 * Math.PI, TimeSpan.FromSeconds(3));
        }
    }
}
