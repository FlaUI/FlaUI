using System;
using System.Drawing;
using System.Linq;
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
            var window = Application.GetMainWindow(Automation);
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
            var window = Application.GetMainWindow(Automation);
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
            var window = Application.GetMainWindow(Automation);
            var textBox = window.FindFirstDescendant(cf => cf.ByAutomationId("TextBox")).AsTextBox();
            var textRange = textBox.Patterns.Text.Pattern;
            var colorInt = (int)textRange.DocumentRange.GetAttributeValue(Automation.TextAttributeLibrary.ForegroundColor);
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

    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    public class Win32FallbackTextBoxTests : UITestBase
    {
        public Win32FallbackTextBoxTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType)
        {
        }

        [Test]
        public void DirectSetDoesNotEnterTextThroughKeyboardAfterSuccessfulWin32Fallback()
        {
            var window = Application.GetMainWindow(Automation);
            var fallbackElement = window.FindAllDescendants()
                .FirstOrDefault(element => element.Properties.ClassName.ValueOrDefault?.StartsWith("WindowsForms10.RichEdit", StringComparison.Ordinal) == true);
            Assert.That(fallbackElement, Is.Not.Null);
            Assert.That(fallbackElement.Patterns.Value.IsSupported, Is.False);
            Assert.That(fallbackElement.Properties.NativeWindowHandle.ValueOrDefault, Is.Not.EqualTo(IntPtr.Zero));

            var focusedTextBox = window.FindFirstDescendant(cf => cf.ByAutomationId("TextBox")).AsTextBox();
            const string focusedTextBoxValue = "Focused textbox sentinel";
            focusedTextBox.Text = focusedTextBoxValue;
            focusedTextBox.Focus();
            Assert.That(Automation.Compare(Automation.FocusedElement(), focusedTextBox), Is.True);

            var fallbackTextBox = fallbackElement.AsTextBox();
            const string fallbackTextBoxValue = "Win32 fallback text";
            fallbackTextBox.Text = fallbackTextBoxValue;

            Assert.That(fallbackTextBox.Text, Is.EqualTo(fallbackTextBoxValue));
            Assert.That(focusedTextBox.Text, Is.EqualTo(focusedTextBoxValue));
            Assert.That(Automation.Compare(Automation.FocusedElement(), focusedTextBox), Is.True);
        }
    }
}
