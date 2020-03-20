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
        
        [Test]
        public void SelectByTextInLargeList()
        {
            if (ApplicationType != TestApplicationType.Wpf)
            {
                return; // test only for WPF, in Windows Forms all list items are loaded at startup
            }
        
            var window = Application.GetMainWindow(Automation);
            var tab = window.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(2); // Switch to "More Controls" tab
            
            var listBox = window.FindFirstDescendant(cf => cf.ByAutomationId("LargeListBox")).AsListBox();
            var item = listBox.Select("ListBox Item #7");
            Assert.That(item.Text, Is.EqualTo("ListBox Item #7"));
            Assert.That(listBox.SelectedItems, Has.Length.EqualTo(1));
            Assert.That(listBox.SelectedItem.Text, Is.EqualTo("ListBox Item #7"));
            
            item = listBox.AddToSelection("ListBox Item #6");
            Assert.That(item.Text, Is.EqualTo("ListBox Item #6"));
            Assert.That(listBox.SelectedItems, Has.Length.EqualTo(2));
            Assert.That(listBox.SelectedItems[0].Text, Is.EqualTo("ListBox Item #6"));
            Assert.That(listBox.SelectedItems[1].Text, Is.EqualTo("ListBox Item #7"));
            
            tab.SelectTabItem(0); // Switch back to "Simple Controls"
        }
    }
}
