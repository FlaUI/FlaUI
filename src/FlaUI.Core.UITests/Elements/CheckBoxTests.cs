using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class CheckBoxTests : UITestBase
    {
        public CheckBoxTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void ToggleTest()
        {
            RestartApp();
            var window = App.GetMainWindow(Automation);
            var checkBox = window.FindFirstDescendant(cf => cf.ByName("Test Checkbox")).AsCheckBox();
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.Off));
            checkBox.Toggle();
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.On));
        }

        [Test]
        public void SetStateTest()
        {
            var window = App.GetMainWindow(Automation);
            var checkBox = window.FindFirstDescendant(cf => cf.ByText("Test Checkbox")).AsCheckBox();
            checkBox.ToggleState = ToggleState.On;
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.On));
            checkBox.ToggleState = ToggleState.Off;
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.Off));
            checkBox.ToggleState = ToggleState.On;
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.On));
        }

        [Test]
        public void ThreeWayToggleTest()
        {
            RestartApp();
            var window = App.GetMainWindow(Automation);
            var checkBox = window.FindFirstDescendant(cf => cf.ByText("3-Way Test Checkbox")).AsCheckBox();
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.Off));
            checkBox.Toggle();
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.On));
            checkBox.Toggle();
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.Indeterminate));
        }

        [Test]
        public void ThreeWaySetStateTest()
        {
            var window = App.GetMainWindow(Automation);
            var checkBox = window.FindFirstDescendant(cf => cf.ByText("3-Way Test Checkbox")).AsCheckBox();
            checkBox.ToggleState = ToggleState.On;
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.On));
            checkBox.ToggleState = ToggleState.Off;
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.Off));
            checkBox.ToggleState = ToggleState.Indeterminate;
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.Indeterminate));
            checkBox.ToggleState = ToggleState.On;
            Assert.That(checkBox.ToggleState, Is.EqualTo(ToggleState.On));
        }
    }
}
