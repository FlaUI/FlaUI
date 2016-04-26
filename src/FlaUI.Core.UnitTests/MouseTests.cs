using System;
using System.Security.Permissions;
using System.Threading;
using FlaUI.Core.Input;
using NUnit.Framework;
using System.Windows;
using FlaUI.Core.WindowsAPI;

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
            var mouseX = window.BoundingRectangle.Top + 200;
            var mouseY = window.BoundingRectangle.Left + 50;
            app.Automation.Mouse.Position = new Point(mouseX, mouseY);
            app.Automation.Mouse.MouseDown(MouseButton.Left);
            app.Automation.Mouse.MoveBy(100, 10);
            app.Automation.Mouse.MouseUp(MouseButton.Left);
            Thread.Sleep(2000);
            app.Dispose();
        }

        [Test]
        public void CursorTest()
        {
            var img = User32.LoadImage(IntPtr.Zero, "#32514", ImageType.IMAGE_CURSOR, 0, 0, ImageLoadOptions.LR_SHARED);
            User32.SetCursor(img);
          //  Thread.Sleep(5000);
            User32.SetCursor(img);
          //  Thread.Sleep(2000);
            var cr = User32.LoadCursor(IntPtr.Zero, StandardCursors.IDC_CROSS);
          //  User32.SetCursor(cr);
            Thread.Sleep(2000);
        }
    }
}
