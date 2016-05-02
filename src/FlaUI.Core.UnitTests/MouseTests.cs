using FlaUI.Core.Input;
using NUnit.Framework;
using System.Threading;
using System.Windows;
using FlaUI.Core.Shapes;

namespace FlaUI.Core.UnitTests
{
    [TestFixture]
    public class MouseTests
    {
        [Test]
        public void MoveTest()
        {
            var mouse = new Mouse();
            mouse.Position = new Point(0, 0);
            mouse.MoveBy(800, 0);
            mouse.MoveBy(0, 400);
            mouse.MoveBy(-400, -200);
        }

        [Test]
        public void ClickTest()
        {
            var app = Application.Launch("mspaint");
            var window = app.GetMainWindow();
            var mouseX = window.Current.BoundingRectangle.Left + 50;
            var mouseY = window.Current.BoundingRectangle.Top + 200;
            app.Automation.Mouse.Position = new Point(mouseX, mouseY);
            app.Automation.Mouse.Down(MouseButton.Left);
            app.Automation.Mouse.MoveBy(100, 10);
            app.Automation.Mouse.MoveBy(10, 50);
            app.Automation.Mouse.Up(MouseButton.Left);
            Thread.Sleep(2000);
            app.Dispose();
        }
    }
}
