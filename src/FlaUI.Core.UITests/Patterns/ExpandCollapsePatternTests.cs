using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
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
            var tab = mainWindow.FindFirstDescendant(cf => cf.ByControlType(ControlType.Tab)).AsTab();
            var tabItem = tab.SelectTabItem(1);
            _expander = tabItem.FindFirstNested(cf => new ConditionBase[] { cf.ByControlType(ControlType.Pane), cf.ByAutomationId("Expander") });
        }

        [Test]
        public void ExpanderTest()
        {
            var expander = _expander;
            Assert.That(expander, Is.Not.Null);
            var ecp = expander.Patterns.ExpandCollapse.Pattern;
            Assert.That(ecp, Is.Not.Null);
            Assert.That(ecp.ExpandCollapseState.Value, Is.EqualTo(ExpandCollapseState.Collapsed));
            ecp.Expand();
            Assert.That(ecp.ExpandCollapseState.Value, Is.EqualTo(ExpandCollapseState.Expanded));
            ecp.Collapse();
            Assert.That(ecp.ExpandCollapseState.Value, Is.EqualTo(ExpandCollapseState.Collapsed));
        }
    }
}
