using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class RadioButtonTests : UITestBase
    {
        public RadioButtonTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType) { }

        [Test]
        public void SelectSingleRadioButtonTest()
        {
            RestartApp();
            var radioButton = App.GetMainWindow(Automation).FindFirst(TreeScope.Descendants, Automation.ConditionFactory.ByAutomationId("RadioButton1")).AsRadioButton();
            Assert.That(radioButton.IsSelected, Is.False);
            radioButton.Select();
            Assert.That(radioButton.IsSelected, Is.True);
        }

        [Test]
        public void SelectRadioButtonGroupTest()
        {
            RestartApp();
            var radioButton1 = App.GetMainWindow(Automation).FindFirst(TreeScope.Descendants, Automation.ConditionFactory.ByAutomationId("RadioButton1")).AsRadioButton();
            var radioButton2 = App.GetMainWindow(Automation).FindFirst(TreeScope.Descendants, Automation.ConditionFactory.ByAutomationId("RadioButton2")).AsRadioButton();

            Assert.That(radioButton1.IsSelected && radioButton2.IsSelected, Is.False);

            radioButton1.Select();
            Assert.That(radioButton1.IsSelected, Is.True);
            Assert.That(radioButton2.IsSelected, Is.False);

            radioButton2.Select();
            Assert.That(radioButton1.IsSelected, Is.False);
            Assert.That(radioButton2.IsSelected, Is.True);
        }
    }
}
