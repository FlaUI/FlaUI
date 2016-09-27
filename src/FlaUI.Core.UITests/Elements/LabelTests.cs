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
    public class LabelTests : UITestBase
    {
        public LabelTests(TestApplicationType appType)
            : base(appType)
        {
        }

        [Test]
        public void GetText()
        {
            var window = App.GetMainWindow(Uia3Automation);
            var label = window.FindFirst(TreeScope.Descendants, ConditionFactory.ByText("Test Label")).AsLabel();
            Assert.That(label, Is.Not.Null);
            Assert.That(label.Text, Is.EqualTo("Test Label"));
        }
    }
}
