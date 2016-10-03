using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(TestApplicationType.WinForms)]
    [TestFixture(TestApplicationType.Wpf)]
    public class ProgressBarTests : UITestBase
    {
        public ProgressBarTests(TestApplicationType appType) : base(appType) { }

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
            var mainWindow = App.GetMainWindow(Uia3Automation);
            var element = mainWindow.FindFirst(TreeScope.Descendants, mainWindow.ConditionFactory.ByAutomationId("ProgressBar")).AsProgressBar();
            return element;
        }
    }
}
