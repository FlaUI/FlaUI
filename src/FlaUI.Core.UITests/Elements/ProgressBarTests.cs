using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class ProgressBarTests : UITestBase
    {
        public ProgressBarTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType)
        {
        }

        [Test]
        public void MinimumValueTest()
        {
            var bar = GetProgressBar();
            Assert.That(bar.Minimum, Is.EqualTo(0));
        }

        [Test]
        public void MaximumValueTest()
        {
            var bar = GetProgressBar();
            Assert.That(bar.Maximum, Is.EqualTo(100));
        }

        [Test]
        public void ValueTest()
        {
            var bar = GetProgressBar();
            Assert.That(bar.Value, Is.EqualTo(50));
        }

        private ProgressBar GetProgressBar()
        {
            var mainWindow = App.GetMainWindow(Automation);
            var element = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("ProgressBar")).AsProgressBar();
            return element;
        }
    }
}
