using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(TestApplicationType.WinForms)]
    [TestFixture(TestApplicationType.Wpf)]
    public class CheckBoxTests : UITestBase
    {
        public CheckBoxTests(TestApplicationType appType)
            : base(appType)
        {
        }

        [Test]
        public void ToggleTest()
        {
            RestartApp();
            var window = App.GetMainWindow(Uia3Automation);
            var checkBox = window.FindFirst(TreeScope.Descendants, Uia3Automation.ConditionFactory.ByText("Test Checkbox")).AsCheckBox();
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.Off));
            checkBox.Toggle();
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.On));
        }

        [Test]
        public void SetStateTest()
        {
            var window = App.GetMainWindow(Uia3Automation);
            var checkBox = window.FindFirst(TreeScope.Descendants, Uia3Automation.ConditionFactory.ByText("Test Checkbox")).AsCheckBox();
            checkBox.State = ToggleState.On;
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.On));
            checkBox.State = ToggleState.Off;
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.Off));
            checkBox.State = ToggleState.On;
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.On));
        }

        [Test]
        public void ThreeWayToggleTest()
        {
            RestartApp();
            var window = App.GetMainWindow(Uia3Automation);
            var checkBox = window.FindFirst(TreeScope.Descendants, Uia3Automation.ConditionFactory.ByText("3-Way Test Checkbox")).AsCheckBox();
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.Off));
            checkBox.Toggle();
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.On));
            checkBox.Toggle();
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.Indeterminate));
        }

        [Test]
        public void ThreeWaySetStateTest()
        {
            var window = App.GetMainWindow(Uia3Automation);
            var checkBox = window.FindFirst(TreeScope.Descendants, Uia3Automation.ConditionFactory.ByText("3-Way Test Checkbox")).AsCheckBox();
            checkBox.State = ToggleState.On;
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.On));
            checkBox.State = ToggleState.Off;
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.Off));
            checkBox.State = ToggleState.Indeterminate;
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.Indeterminate));
            checkBox.State = ToggleState.On;
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.On));
        }
    }
}
