using FlaUI.Core.UITests.TestFramework;
using FlaUI.UIA3.Conditions;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Tools;
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
            var element = App.GetMainWindow(Uia3Automation).FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId("ProgressBar")).AsProgressBar();
            return element;
        }
    }
}
