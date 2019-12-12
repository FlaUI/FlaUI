using System.Drawing;
using System.Threading;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using FlaUI.UIA3;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class MouseTests
    {
        [Test]
        public void MoveTest()
        {
            Mouse.Position = new Point(0, 0);
            Mouse.MoveBy(800, 0);
            Mouse.MoveBy(0, 400);
            Mouse.MoveBy(-400, -200);
        }

        [Test]
        public void ClickTest()
        {
            var app = Application.Launch("mspaint");
            using (var automation = new UIA3Automation())
            {
                var mainWindow = app.GetMainWindow(automation);
                var mouseX = mainWindow.Properties.BoundingRectangle.Value.Left + 50;
                var mouseY = mainWindow.Properties.BoundingRectangle.Value.Top + 200;
                Mouse.Position = new Point(mouseX, mouseY);
                Mouse.Down(MouseButton.Left);
                Mouse.MoveBy(100, 10);
                Mouse.MoveBy(10, 50);
                Mouse.Up(MouseButton.Left);
                Thread.Sleep(500);
                UtilityMethods.CloseWindowWithDontSave(mainWindow);
            }
            app.Dispose();
        }

        [Test]
        public void MoveOnePixelTest()
        {
            var startPositon = Mouse.Position;

            Assert.DoesNotThrow(() =>
            {
                Mouse.MoveBy(1, 0);
            }, "Failed to move mouse by 1-x");
            Assert.That(Mouse.Position.X, Is.EqualTo(startPositon.X + 1));
            Assert.That(Mouse.Position.Y, Is.EqualTo(startPositon.Y));
        }

        [Test]
        public void MoveZeroTest()
        {
            var startPositon = Mouse.Position;
            Assert.DoesNotThrow(() =>
            {
                Mouse.MoveBy(0, 10);
            }, "Failed to move mouse by 0-x");
            Assert.That(Mouse.Position.X, Is.EqualTo(startPositon.X));
            Assert.That(Mouse.Position.Y, Is.EqualTo(startPositon.Y + 10));

            startPositon = Mouse.Position;
            Assert.DoesNotThrow(() =>
            {
                Mouse.MoveBy(10, 0);
            }, "Failed to move mouse by 0-y");
            Assert.That(Mouse.Position.X, Is.EqualTo(startPositon.X + 10));
            Assert.That(Mouse.Position.Y, Is.EqualTo(startPositon.Y));

            startPositon = Mouse.Position;
            Assert.DoesNotThrow(() =>
            {
                Mouse.MoveBy(0, 0);
            }, "Failed to move mouse by 0-x and 0-y");
            Assert.That(Mouse.Position.X, Is.EqualTo(startPositon.X));
            Assert.That(Mouse.Position.Y, Is.EqualTo(startPositon.Y));
        }
    }
}
