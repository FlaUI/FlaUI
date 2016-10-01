using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(TestApplicationType.WinForms)]
    [TestFixture(TestApplicationType.Wpf)]
    public class TextBoxTests : UITestBase
    {
        public TextBoxTests(TestApplicationType appType) : base(appType)
        {
        }

        [Test]
        public void DirectSetTest()
        {
            var window = App.GetMainWindow(Uia3Automation);
            var textBox = window.FindFirst(TreeScope.Descendants, Uia3Automation.ConditionFactory.ByAutomationId("TextBox")).AsTextBox();
            var text = textBox.Text;
            Assert.That(text, Is.Empty);
            var textToSet = "Hello World";
            textBox.Text = textToSet;
            text = textBox.Text;
            Assert.That(text, Is.EqualTo(textToSet));
            textBox.Text = "";
        }

        [Test]
        public void EnterTest()
        {
            var window = App.GetMainWindow(Uia3Automation);
            var textBox = window.FindFirst(TreeScope.Descendants, Uia3Automation.ConditionFactory.ByAutomationId("TextBox")).AsTextBox();
            var text = textBox.Text;
            Assert.That(text, Is.Empty);
            var textToSet = "Hello World";
            textBox.Enter(textToSet);
            text = textBox.Text;
            Assert.That(text, Is.EqualTo(textToSet));
            textBox.Text = "";
        }
    }
}
