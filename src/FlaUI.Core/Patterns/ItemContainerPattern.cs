using FlaUI.Core.AutomationElements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IItemContainerPattern : IPattern
    {
        AutomationElement? FindItemByProperty(AutomationElement? startAfter, PropertyId? property, object? value);
    }
}
