using FlaUI.Core.AutomationElements;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class RadioButtonTests : UITestBase
    {
        public RadioButtonTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType)
        {
        }

        [Test]
        public void SelectSingleRadioButtonTest()
        {
            RestartApplication();
            var radioButton = Application.GetMainWindow(Automation).FindFirstDescendant(cf => cf.ByAutomationId("RadioButton1")).AsRadioButton();
            radioButton.IsChecked.Should().BeFalse();
            radioButton.IsChecked = true;
            radioButton.IsChecked.Should().BeTrue();
        }

        [Test]
        public void SelectRadioButtonGroupTest()
        {
            RestartApplication();
            var radioButton1 = Application.GetMainWindow(Automation).FindFirstDescendant(cf => cf.ByAutomationId("RadioButton1")).AsRadioButton();
            var radioButton2 = Application.GetMainWindow(Automation).FindFirstDescendant(cf => cf.ByAutomationId("RadioButton2")).AsRadioButton();

            (radioButton1.IsChecked && radioButton2.IsChecked).Should().BeFalse();

            radioButton1.IsChecked = true;
            radioButton1.IsChecked.Should().BeTrue();
            radioButton2.IsChecked.Should().BeFalse();

            radioButton2.IsChecked = true;
            radioButton1.IsChecked.Should().BeFalse();
            radioButton2.IsChecked.Should().BeTrue();
        }
    }
}
