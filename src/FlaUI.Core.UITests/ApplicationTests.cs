using FlaUI.UIA3;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class ApplicationTests
    {
        [Test]
        public void DisposeWhenClosed()
        {
            using (new UIA3Automation())
            {
                using (var app = Application.Launch("notepad.exe"))
                {
                    app.WaitWhileMainHandleIsMissing();
                    app.Close();
                }
            }
        }
    }
}
