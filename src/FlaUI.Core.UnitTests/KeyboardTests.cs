using NUnit.Framework;

namespace FlaUI.Core.UnitTests
{
    [TestFixture]
    public class KeyboardTests
    {
        [Test]
        public void KeyboardTest()
        {
            var app = Application.Launch("notepad.exe");
            app.Automation.Keyboard.Write("ééé aaa");
            System.Threading.Thread.Sleep(5000);
            app.Dispose();
        }
    }
}
