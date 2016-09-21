using FlaUI.UIA3;
using FlaUI.UIA3.Tools;
using NUnit.Framework;
using System;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class NotepadTests
    {
        [Test]
        public void NotepadTest()
        {
            var app = Application.Launch("notepad.exe");
            var automation = new Automation();
            var window = app.GetMainWindow(automation);
            Console.WriteLine(window.Title);
            window.DrawHighlight();
            window.Move(100, 100);
            window.DrawHighlight();
            window.Move(200, 200);
            window.DrawHighlight();
            app.Close();
        }
    }
}
