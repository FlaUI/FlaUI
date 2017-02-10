using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class TreeTests : UITestBase
    {
        private Tree _tree;

        public TreeTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = App.GetMainWindow(Automation);
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
            Assert.That(tree.TreeItems, Has.Length.EqualTo(2));
            tree.TreeItems[0].Expand();
            tree.TreeItems[0].TreeItems[1].Expand();
            tree.TreeItems[0].TreeItems[1].TreeItems[0].Select();
            Assert.That(tree.SelectedTreeItem.Text, Is.EqualTo("Lvl3 a"));
        }
    }
}
