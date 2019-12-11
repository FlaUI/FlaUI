using System.Threading;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    public class SpinnerTests : FlaUITestBase
    {
        public SpinnerTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void SetValueTest()
        {
            var spinner = GetSpinner();
            spinner.Value = 6;
            Assert.That(spinner.Value, Is.EqualTo(6));
            spinner.Value = 4;
            Assert.That(spinner.Value, Is.EqualTo(4));
        }

        /*[Test]
        public void IncrementTest()
        {
            var spinner = GetSpinner();
            spinner.Value = 5;
            spinner.Increment();
            Assert.That(spinner.Value, Is.EqualTo(6));
        }*/

        /*[Test]
        public void DecrementTest()
        {
            var spinner = GetSpinner();
            spinner.Value = 5;
            spinner.Decrement();
            Assert.That(spinner.Value, Is.EqualTo(4));
        }*/

        private Spinner GetSpinner()
        {
            var element = Application.GetMainWindow(Automation).FindFirstDescendant(cf => cf.ByAutomationId("numericUpDown1")).AsSpinner();
            return element;
        }
    }
}
