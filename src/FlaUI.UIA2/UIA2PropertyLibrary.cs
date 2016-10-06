using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.UIA2
{
    public class UIA2PropertyLibrary : IPropertyLibray
    {
        public UIA2PropertyLibrary()
        {
            Generic = new UIA2AutomationElementProperties();
        }

        public IAutomationElementProperties Generic { get; }
    }
}
