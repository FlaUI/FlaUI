using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Patterns
{
    public interface IItemContainerPattern
    {
        AutomationElement FindItemByProperty(AutomationElement startAfter, PropertyId property, object value);
    }
}
