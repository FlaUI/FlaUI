using System;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class NotepadTests
    {
        [Test]
        public void NotepadTest()
        {
            var app =  Application.Launch("notepad.exe");
            var window = app.GetMainWindow();
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
