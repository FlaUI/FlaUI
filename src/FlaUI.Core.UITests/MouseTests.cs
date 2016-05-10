using FlaUI.Core.Input;
using FlaUI.Core.Shapes;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;
using System.Threading;

namespace FlaUI.Core.UITests
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
            var mainWindow = app.GetMainWindow();
            var mouseX = mainWindow.Current.BoundingRectangle.Left + 50;
            var mouseY = mainWindow.Current.BoundingRectangle.Top + 200;
            app.Automation.Mouse.Position = new Point(mouseX, mouseY);
            app.Automation.Mouse.Down(MouseButton.Left);
            app.Automation.Mouse.MoveBy(100, 10);
            app.Automation.Mouse.MoveBy(10, 50);
            app.Automation.Mouse.Up(MouseButton.Left);
            Thread.Sleep(500);
            TestUtilities.CloseWindowWithDontSave(mainWindow);
            app.Dispose();
        }
    }
}
