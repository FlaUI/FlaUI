using FlaUI.Core.AutomationElements;

namespace FlaUI.Core.UITests.WordPad.Screens
{
    public class InfoScreen : Window
    {
        public InfoScreen(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        public Button OkButton => FindFirstChild(cf => cf.ByText("OK")).AsButton();
    }
}
