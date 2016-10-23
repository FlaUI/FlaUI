using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Patterns
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class ExpandCollapsePatternTests : UITestBase
    {
        private AutomationElement _expander;

        public ExpandCollapsePatternTests(AutomationType automationType, TestApplicationType appType) : base(automationType, appType)
        {
        }

        [OneTimeSetUp]
        public void SelectTab()
        {
            var mainWindow = App.GetMainWindow(Automation);
            var tab = mainWindow.FindFirstDescendant(mainWindow.ConditionFactory.ByControlType(ControlType.Tab)).AsTab();
            var tabItem = tab.SelectTabItem(1);
            _expander = tabItem.FindFirstChild(mainWindow.ConditionFactory.ByAutomationId("Expander"));
        }

        [Test]
        public void ExpanderTest()
        {
            var expander = _expander;
            Assert.That(expander, Is.Not.Null);
            var ecp = expander.PatternFactory.GetExpandCollapsePattern();
            Assert.That(ecp, Is.Not.Null);
            Assert.That(ecp.Current.ExpandCollapseState, Is.EqualTo(ExpandCollapseState.Collapsed));
            ecp.Expand();
            Assert.That(ecp.Current.ExpandCollapseState, Is.EqualTo(ExpandCollapseState.Expanded));
            ecp.Collapse();
            Assert.That(ecp.Current.ExpandCollapseState, Is.EqualTo(ExpandCollapseState.Collapsed));
        }
    }
}
