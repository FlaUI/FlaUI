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
    public class RadioButtonTests : UITestBase
    {
        public RadioButtonTests(TestApplicationType appType) : base(appType) { }

        [Test]
        public void SelectSingleRadioButtonTest()
        {
            RestartApp();
            var radioButton = App.GetMainWindow(Uia3Automation).FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId("RadioButton1")).AsRadioButton();
            Assert.That(radioButton.IsSelected, Is.False);
            radioButton.Select();
            Assert.That(radioButton.IsSelected, Is.True);
        }

        [Test]
        public void SelectRadioButtonGroupTest()
        {
            RestartApp();
            var radioButton1 = App.GetMainWindow(Uia3Automation).FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId("RadioButton1")).AsRadioButton();
            var radioButton2 = App.GetMainWindow(Uia3Automation).FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId("RadioButton2")).AsRadioButton();

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
