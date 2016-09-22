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
    public class TextBoxTests : UITestBase
    {
        public TextBoxTests(TestApplicationType appType) : base(appType)
        {
        }

        [Test]
        public void DirectSetTest()
        {
            var window = App.GetMainWindow(Uia3Automation);
            var textBox = window.FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId("TextBox")).AsTextBox();
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
            var textBox = window.FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId("TextBox")).AsTextBox();
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
