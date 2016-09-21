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
    public class TreeTests : UITestBase
    {
        private Tree _tree;

        public TreeTests(TestApplicationType appType)
            : base(appType)
        {
        }

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = App.GetMainWindow(Uia3Automation);
            var tab = mainWindow.FindFirst(TreeScope.Descendants, ConditionFactory.ByControlType(ControlType.Tab)).AsTab();
            tab.SelectTabItem(1);
            var tree = mainWindow.FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId("treeView1")).AsTree();
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
