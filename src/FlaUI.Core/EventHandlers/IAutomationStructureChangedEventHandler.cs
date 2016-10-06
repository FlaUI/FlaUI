using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.EventHandlers
{
    public interface IAutomationStructureChangedEventHandler
    {
        void HandleStructureChangedEvent(AutomationElement sender, StructureChangeType changeType, int[] runtimeId);
    }
}
