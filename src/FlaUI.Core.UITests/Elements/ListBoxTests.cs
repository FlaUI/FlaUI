using FlaUI.Core.AutomationElements;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class ListBoxTests : UITestBase
    {
        public ListBoxTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void Items()
        {
            var window = Application.GetMainWindow(Automation);
            var listBox = window.FindFirstDescendant(cf => cf.ByAutomationId("ListBox")).AsListBox();
            Assert.That(listBox, Is.Not.Null);
            Assert.That(listBox.Items, Has.Length.EqualTo(2));
        }

        [Test]
        public void SelectByIndex()
        {
            var window = Application.GetMainWindow(Automation);
            var listBox = window.FindFirstDescendant(cf => cf.ByAutomationId("ListBox")).AsListBox();
            Assert.That(listBox, Is.Not.Null);
            Assert.That(listBox.Items, Has.Length.EqualTo(2));
            Assert.That(listBox.Items[0], Is.InstanceOf<ListBoxItem>());
            Assert.That(listBox.Items[1], Is.InstanceOf<ListBoxItem>());
            Assert.IsNull(listBox.SelectedItem);
            var item = listBox.Select(0);
            Assert.That(item.Text, Is.EqualTo("ListBox Item #1"));
            Assert.That(listBox.SelectedItem.Text, Is.EqualTo("ListBox Item #1"));
            item = listBox.Select(1);
            Assert.That(item.Text, Is.EqualTo("ListBox Item #2"));
            Assert.That(listBox.SelectedItem.Text, Is.EqualTo("ListBox Item #2"));
        }

        [Test]
        public void SelectByText()
        {
            var window = Application.GetMainWindow(Automation);
            var listBox = window.FindFirstDescendant(cf => cf.ByAutomationId("ListBox")).AsListBox();
            var item = listBox.Select("ListBox Item #1");
            Assert.That(item.Text, Is.EqualTo("ListBox Item #1"));
            Assert.That(listBox.SelectedItem.Text, Is.EqualTo("ListBox Item #1"));

            item = listBox.Select("ListBox Item #2");
            Assert.That(item.Text, Is.EqualTo("ListBox Item #2"));
            Assert.That(listBox.SelectedItem.Text, Is.EqualTo("ListBox Item #2"));

            item = listBox.Select("ListBox Item #1");
            Assert.That(item.Text, Is.EqualTo("ListBox Item #1"));
            Assert.That(listBox.SelectedItem.Text, Is.EqualTo("ListBox Item #1"));
        }
    }
}
