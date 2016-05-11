using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.UITests.TestFramework;
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
            var window = App.GetMainWindow();
            var label = window.FindFirst(TreeScope.Descendants, ConditionFactory.ByText("Test Label")).AsLabel();
            Assert.That(label, Is.Not.Null);
            Assert.That(label.Text, Is.EqualTo("Test Label"));
        }
    }
}
