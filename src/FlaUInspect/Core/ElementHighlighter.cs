using System.Threading.Tasks;
using System.Windows.Media;
using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUInspect.Core
{
    public static class ElementHighlighter
    {
        public static void HighlightElement(AutomationElement automationElement)
        {
            Task.Run(() => automationElement.DrawHighlight(false, Colors.Red, 1000));
        }
    }
}
