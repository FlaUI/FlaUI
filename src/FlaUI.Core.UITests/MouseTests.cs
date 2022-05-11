using System;
using System.Drawing;
using System.Text;
using System.Threading;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestFramework;
using FlaUI.UIA3;
using FluentAssertions;
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
            var startPosition = Mouse.Position;

            Action act = () => Mouse.MoveBy(1, 0);
            act.Should().NotThrow("Failed to move mouse by 1-x");
            Mouse.Position.X.Should().Be(startPosition.X + 1);
            Mouse.Position.Y.Should().Be(startPosition.Y);
        }

        [Test]
        public void MoveZeroTest()
        {
            var startPosition = Mouse.Position;
            Action act = () => Mouse.MoveBy(0, 10);
            act.Should().NotThrow("Failed to move mouse by 0-x");
            Mouse.Position.X.Should().Be(startPosition.X);
            Mouse.Position.Y.Should().Be(startPosition.Y + 10);

            startPosition = Mouse.Position;
            act = () => Mouse.MoveBy(10, 0);
            act.Should().NotThrow("Failed to move mouse by 0-x");
            Mouse.Position.X.Should().Be(startPosition.X + 10);
            Mouse.Position.Y.Should().Be(startPosition.Y);

            startPosition = Mouse.Position;
            act = () => Mouse.MoveBy(0, 0);
            act.Should().NotThrow("Failed to move mouse by 0-x and 0-y");
            Mouse.Position.X.Should().Be(startPosition.X);
            Mouse.Position.Y.Should().Be(startPosition.Y);
        }

        [Test]
        public void ScrollTest()
        {
            UtilityMethods.IgnoreOnUIA2();
            using (var app = Application.Launch("notepad.exe"))
            {
                using (var automation = new UIA3Automation())
                {
                    var mainWindow = app.GetMainWindow(automation);
                    var documentElement = mainWindow.FindFirstChild("15");
                    var sb = new StringBuilder();
                    for (var i = 0; i < 1000; i++)
                    {
                        sb.Append("aaa" + Environment.NewLine);
                    }
                    documentElement.Patterns.Value.Pattern.SetValue(sb.ToString());
                    Mouse.Position = documentElement.BoundingRectangle.Center();
                    Wait.UntilInputIsProcessed();

                    var initScroll = documentElement.Patterns.Scroll.Pattern.VerticalScrollPercent.Value;
                    initScroll.Should().Be(0);
                    Mouse.Scroll(-100);
                    Wait.UntilInputIsProcessed();
                    var downScroll = documentElement.Patterns.Scroll.Pattern.VerticalScrollPercent.Value;
                    downScroll.Should().BeGreaterThan(initScroll);

                    Mouse.Scroll(100);
                    Wait.UntilInputIsProcessed();
                    var upScroll = documentElement.Patterns.Scroll.Pattern.VerticalScrollPercent.Value;
                    upScroll.Should().BeLessThan(downScroll);

                    UtilityMethods.CloseWindowWithDontSave(mainWindow);
                }
            }
        }
    }
}
