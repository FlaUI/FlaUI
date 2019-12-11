using FlaUI.Core.AutomationElements;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class LabelTests : FlaUITestBase
    {
        public LabelTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void GetText()
        {
            var window = Application.GetMainWindow(Automation);
            var label = window.FindFirstDescendant(cf => cf.ByText("Test Label")).AsLabel();
            Assert.That(label, Is.Not.Null);
            Assert.That(label.Text, Is.EqualTo("Test Label"));
        }
    }
}
