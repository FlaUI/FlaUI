using System;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class ComboBoxTests : UITestBase
    {
        private Window _mainWindow;

        public ComboBoxTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void TestOneTimeSetup()
        {
            _mainWindow = Retry.WhileNull(() => Application.GetMainWindow(Automation), TimeSpan.FromSeconds(1)).Result;
            _mainWindow.Should().NotBeNull();
        }

        [Test]
        [TestCase("EditableCombo")]
        [TestCase("NonEditableCombo")]
        public void SelectedItemTest(string comboBoxId)
        {
            var combo = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(comboBoxId)).AsComboBox();
            combo.Items[1].Select();
            var selectedItem = combo.SelectedItem;
            selectedItem.Should().NotBeNull();
            selectedItem.Text.Should().Be("Item 2");
        }

        [Test]
        [TestCase("EditableCombo")]
        [TestCase("NonEditableCombo")]
        public void SelectByIndexTest(string comboBoxId)
        {
            var combo = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(comboBoxId)).AsComboBox();
            combo.Select(1);
            var selectedItem = combo.SelectedItem;
            selectedItem.Should().NotBeNull();
            selectedItem.Text.Should().Be("Item 2");
        }

        [Test]
        [TestCase("EditableCombo")]
        [TestCase("NonEditableCombo")]
        public void SelectByTextTest(string comboBoxId)
        {
            var combo = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(comboBoxId)).AsComboBox();
            combo.Select("Item 2");
            var selectedItem = combo.SelectedItem;
            selectedItem.Should().NotBeNull();
            selectedItem.Text.Should().Be("Item 2");
        }

        [Test]
        [TestCase("EditableCombo")]
        [TestCase("NonEditableCombo")]
        public void ExpandCollapseTest(string comboBoxId)
        {
            var combo = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(comboBoxId)).AsComboBox();
            combo.Expand();
            combo.ExpandCollapseState.Should().Be(ExpandCollapseState.Expanded);
            combo.Collapse();
            combo.ExpandCollapseState.Should().Be(ExpandCollapseState.Collapsed);
        }

        [Test]
        public void EditableTextTest()
        {
            var combo = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("EditableCombo")).AsComboBox();
            combo.Should().NotBeNull();
            combo.EditableText = "Item 3";
            combo.SelectedItem.Should().NotBeNull();
            combo.SelectedItem.Text.Should().Be("Item 3");
        }

        [Test]
        public void AssertMessageBoxCanBeRetrievedInSelection()
        {
            var combo = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("NonEditableCombo")).AsComboBox();
            combo.Expand();
            combo.Items[3].Click();
            var retryResult = Retry.While(() => _mainWindow.FindFirstDescendant(cf => cf.ByClassName("#32770"))?.AsWindow(), w => w == null, TimeSpan.FromMilliseconds(1000));
            var window = retryResult.Result;
            window.Should().NotBeNull("Expected a window that was shown when combobox item was selected");
            window.FindFirstDescendant(cf => cf.ByAutomationId("Close")).AsButton().Invoke();
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ComboBoxItemIsNotOffscreen(int comboBoxItem)
        {
            var combo = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("NonEditableCombo")).AsComboBox();
            var isOffscreen = combo.Items[comboBoxItem].IsOffscreen;
            isOffscreen.Should().BeFalse();
            combo.Collapse();
        }
    }
}
