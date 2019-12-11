using FlaUI.Core.AutomationElements;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class RadioButtonTests : FlaUITestBase
    {
        public RadioButtonTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType)
        {
        }

        [Test]
        public void SelectSingleRadioButtonTest()
        {
            RestartApplication();
            var radioButton = Application.GetMainWindow(Automation).FindFirstDescendant(cf => cf.ByAutomationId("RadioButton1")).AsRadioButton();
            Assert.That(radioButton.IsChecked, Is.False);
            radioButton.IsChecked = true;
            Assert.That(radioButton.IsChecked, Is.True);
        }

        [Test]
        public void SelectRadioButtonGroupTest()
        {
            RestartApplication();
            var radioButton1 = Application.GetMainWindow(Automation).FindFirstDescendant(cf => cf.ByAutomationId("RadioButton1")).AsRadioButton();
            var radioButton2 = Application.GetMainWindow(Automation).FindFirstDescendant(cf => cf.ByAutomationId("RadioButton2")).AsRadioButton();

            Assert.That(radioButton1.IsChecked && radioButton2.IsChecked, Is.False);

            radioButton1.IsChecked = true;
            Assert.That(radioButton1.IsChecked, Is.True);
            Assert.That(radioButton2.IsChecked, Is.False);

            radioButton2.IsChecked = true;
            Assert.That(radioButton1.IsChecked, Is.False);
            Assert.That(radioButton2.IsChecked, Is.True);
        }
    }
}
