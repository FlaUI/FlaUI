using System.Windows.Automation;

namespace ManagedUiaCustomizationCore
{
    public interface IStandalonePropertyProvider
    {
        object GetPropertyValue(AutomationProperty property);
    }
}