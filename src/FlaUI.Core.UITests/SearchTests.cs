using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class SearchTests
    {
        [Test]
        public void SearchWithRetryTest()
        {
            using (var app = Application.Launch("notepad.exe"))
            {
                using (var automation = new UIA3Automation())
                {
                    var window = app.GetMainWindow(automation);
                    Assert.That(window, Is.Not.Null);
                    Assert.That(window.Title, Is.Not.Null);

                    Task.Factory.StartNew(async () =>
                    {
                        await Task.Delay(5000);
                        ShowHelpScreen();
                    });


                    var dialogWindow = Retry.Find(() => window.FindFirstChild(cf => cf.ByControlType(ControlType.Window)),
                        new RetrySettings
                        {
                            Timeout = TimeSpan.FromSeconds(6),
                            Interval = TimeSpan.FromMilliseconds(500)
                        }
                    );
                }
            }
        }

        private void ShowHelpScreen()
        {
            using (Keyboard.Pressing(VirtualKeyShort.ALT))
            {
                Keyboard.Type(VirtualKeyShort.KEY_H);
                Keyboard.Type(VirtualKeyShort.KEY_A);
            }
        }
    }
}
