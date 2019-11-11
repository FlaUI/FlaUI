using System;
using System.Drawing;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class TextBoxTests : UITestBase
    {
        private const string DefaultTextBoxText = "Test TextBox";

        public TextBoxTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType)
        {
        }

        [Test]
        public void DirectSetTest()
        {
            var window = App.GetMainWindow(Automation);
            var textBox = window.FindFirstDescendant(cf => cf.ByAutomationId("TextBox")).AsTextBox();
            var text = textBox.Text;
            Assert.That(text, Is.EqualTo(DefaultTextBoxText));
            var textToSet = "Hello World";
            textBox.Text = textToSet;
            text = textBox.Text;
            Assert.That(text, Is.EqualTo(textToSet));
            textBox.Text = DefaultTextBoxText;
        }

        [Test]
        public void EnterTest()
        {
            var window = App.GetMainWindow(Automation);
            var textBox = window.FindFirstDescendant(cf => cf.ByAutomationId("TextBox")).AsTextBox();
            var text = textBox.Text;
            Assert.That(text, Is.EqualTo(DefaultTextBoxText));
            var textToSet = "Hello World";
            textBox.Enter(textToSet);
            Wait.UntilInputIsProcessed(TimeSpan.FromMilliseconds(500));
            text = textBox.Text;
            Assert.That(text, Is.EqualTo(textToSet));
            textBox.Text = DefaultTextBoxText;
        }

        [Test]
        public void TextBoxColorTest()
        {
            if (ApplicationType == TestApplicationType.WinForms)
            {
                Assert.Ignore("WinForms currently does not report the color on text boxes.");
                return;
            }
            var window = App.GetMainWindow(Automation);
            var textBox = window.FindFirstDescendant(cf => cf.ByAutomationId("TextBox")).AsTextBox();
            var textRange = textBox.Patterns.Text.Pattern;
            var colorInt = (int)textRange.DocumentRange.GetAttributeValue(Automation.TextAttributeLibrary.ForegroundColor);
            Console.WriteLine(colorInt);
            var color = Color.FromArgb(colorInt);
            AssertColorEquality(color, Color.FromArgb(0, Color.Green));
        }

        private void AssertColorEquality(Color actual, Color expected)
        {
            if (actual.ToArgb() != expected.ToArgb())
            {
                var message =
                    $"Expected: Color[A = {expected.A}, R = {expected.R}, G = {expected.G}, B = {expected.B}]{Environment.NewLine}But was:  Color[A = {actual.A}, R = {actual.R}, G = {actual.G}, B = {actual.B}]";
                Assert.Fail(message);
            }
        }
    }
}
