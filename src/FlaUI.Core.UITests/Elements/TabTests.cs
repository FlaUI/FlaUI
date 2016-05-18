using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Input;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(TestApplicationType.WinForms)]
    [TestFixture(TestApplicationType.Wpf)]
    public class TabTests : UITestBase
    {
        public TabTests(TestApplicationType appType)
            : base(appType)
        {
        }

        [Test]
        public void TabSelectTest()
        {
            RestartApp();
            var mainWindow = App.GetMainWindow();
            var tab = mainWindow.FindFirst(TreeScope.Descendants, ConditionFactory.ByControlType(ControlType.Tab)).AsTab();
            Assert.That(tab.TabItems, Has.Length.EqualTo(2));
            Assert.That(tab.SelectedTabItemIndex, Is.EqualTo(0));
            tab.SelectTabItem(1);
            Helpers.WaitUntilInputIsProcessed();
            Assert.That(tab.SelectedTabItemIndex, Is.EqualTo(1));
            tab.SelectTabItem(0);
            Helpers.WaitUntilInputIsProcessed();
            Assert.That(tab.SelectedTabItemIndex, Is.EqualTo(0));
        }
    }
}
