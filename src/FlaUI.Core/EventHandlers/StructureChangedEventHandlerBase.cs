using System;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.EventHandlers
{
    public abstract class StructureChangedEventHandlerBase : EventHandlerBase, IAutomationStructureChangedEventHandler
    {
        private readonly Action<AutomationElement, StructureChangeType, int[]> _callAction;

        protected StructureChangedEventHandlerBase(AutomationBase automation, Action<AutomationElement, StructureChangeType, int[]> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleStructureChangedEvent(AutomationElement sender, StructureChangeType changeType, int[] runtimeId)
        {
            _callAction(sender, changeType, runtimeId);
        }
    }
}
