using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.UIA3
{
    public class UIA3PropertyLibrary : IPropertyLibray
    {
        public UIA3PropertyLibrary()
        {
            Generic = new UIA3AutomationElementProperties();
        }

        public IAutomationElementProperties Generic { get; }
    }
}
