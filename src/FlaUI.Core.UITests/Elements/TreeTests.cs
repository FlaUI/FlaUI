﻿using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class TreeTests : FlaUITestBase
    {
        private Tree _tree;

        public TreeTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = Application.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(1);
            var tree = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("treeView1")).AsTree();
            _tree = tree;
        }

        [Test]
        public void SelectionTest()
        {
            var tree = _tree;
            Assert.That(tree.SelectedTreeItem, Is.Null);
            Assert.That(tree.Items, Has.Length.EqualTo(2));
            tree.Items[0].Expand();
            tree.Items[0].Items[1].Expand();
            tree.Items[0].Items[1].Items[0].Select();
            Assert.That(tree.SelectedTreeItem, Is.Not.Null);
            Assert.That(tree.SelectedTreeItem.Text, Is.EqualTo("Lvl3 a"));
        }
    }
}
