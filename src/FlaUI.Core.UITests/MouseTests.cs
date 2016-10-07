using System.Threading;
using FlaUI.Core.Input;
using FlaUI.Core.Shapes;
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
            using (var automation = new UIA3Automation())
            {
                var mainWindow = app.GetMainWindow(automation);
                var mouseX = mainWindow.Current.BoundingRectangle.Left + 50;
                var mouseY = mainWindow.Current.BoundingRectangle.Top + 200;
                Mouse.Instance.Position = new Point(mouseX, mouseY);
                Mouse.Instance.Down(MouseButton.Left);
                Mouse.Instance.MoveBy(100, 10);
                Mouse.Instance.MoveBy(10, 50);
                Mouse.Instance.Up(MouseButton.Left);
                Thread.Sleep(500);
                TestUtilities.CloseWindowWithDontSave(mainWindow);
            }
            app.Dispose();
        }
    }
}
