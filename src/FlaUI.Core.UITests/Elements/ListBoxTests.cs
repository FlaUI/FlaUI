using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
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
            listBox.Should().NotBeNull();
            listBox.Items.Should().HaveCount(2);
        }

        [Test]
        public void SelectByIndex()
        {
            var window = Application.GetMainWindow(Automation);
            var listBox = window.FindFirstDescendant(cf => cf.ByAutomationId("ListBox")).AsListBox();
            listBox.Should().NotBeNull();
            listBox.Items.Should().HaveCount(2);
            listBox.Items.Should().AllBeAssignableTo<ListBoxItem>();
            listBox.SelectedItem.Should().BeNull();
            var item = listBox.Select(0);
            item.Text.Should().Be("ListBox Item #1");
            listBox.SelectedItem.Text.Should().Be("ListBox Item #1");
            item = listBox.Select(1);
            item.Text.Should().Be("ListBox Item #2");
            listBox.SelectedItem.Text.Should().Be("ListBox Item #2");
        }

        [Test]
        public void SelectByText()
        {
            var window = Application.GetMainWindow(Automation);
            var listBox = window.FindFirstDescendant(cf => cf.ByAutomationId("ListBox")).AsListBox();
            var item = listBox.Select("ListBox Item #1");
            item.Text.Should().Be("ListBox Item #1");
            listBox.SelectedItem.Text.Should().Be("ListBox Item #1");

            item = listBox.Select("ListBox Item #2");
            item.Text.Should().Be("ListBox Item #2");
            listBox.SelectedItem.Text.Should().Be("ListBox Item #2");

            item = listBox.Select("ListBox Item #1");
            item.Text.Should().Be("ListBox Item #1");
            listBox.SelectedItem.Text.Should().Be("ListBox Item #1");
        }

        [Test]
        public void ItemsPropertyInLargeList()
        {
            if (ApplicationType != TestApplicationType.Wpf)
            {
                return; // test only for WPF, in Windows Forms all list items are loaded at startup
            }

            var window = Application.GetMainWindow(Automation);
            var tab = window.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(2); // Switch to "More Controls" tab

            var listBox = window.FindFirstDescendant(cf => cf.ByAutomationId("LargeListBox")).AsListBox();
            listBox.Items.Should().HaveCount(7);
            listBox.Items[6].Text.Should().Be("ListBox Item #7");

            tab.SelectTabItem(0); // Switch back to "Simple Controls"
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
            item.Text.Should().Be("ListBox Item #7");
            listBox.SelectedItems.Should().HaveCount(1);
            listBox.SelectedItem.Text.Should().Be("ListBox Item #7");

            item = listBox.AddToSelection("ListBox Item #6");
            item.Text.Should().Be("ListBox Item #6");
            listBox.SelectedItems.Should().HaveCount(2);
            listBox.SelectedItems[0].Text.Should().Be("ListBox Item #7");
            listBox.SelectedItems[1].Text.Should().Be("ListBox Item #6");

            tab.SelectTabItem(0); // Switch back to "Simple Controls"
        }

        [Test]
        public void SelectByIndexInLargeList()
        {
            if (ApplicationType != TestApplicationType.Wpf)
            {
                return; // test only for WPF, in Windows Forms all list items are loaded at startup
            }

            var window = Application.GetMainWindow(Automation);
            var tab = window.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(2); // Switch to "More Controls" tab

            var listBox = window.FindFirstDescendant(cf => cf.ByAutomationId("LargeListBox")).AsListBox();
            var item = listBox.Select(6);
            item.Text.Should().Be("ListBox Item #7");
            listBox.SelectedItems.Should().HaveCount(1);
            listBox.SelectedItem.Text.Should().Be("ListBox Item #7");

            item = listBox.AddToSelection(5);
            item.Text.Should().Be("ListBox Item #6");
            listBox.SelectedItems.Should().HaveCount(2);
            listBox.SelectedItems[0].Text.Should().Be("ListBox Item #7");
            listBox.SelectedItems[1].Text.Should().Be("ListBox Item #6");

            tab.SelectTabItem(0); // Switch back to "Simple Controls"
        }
    }
}
