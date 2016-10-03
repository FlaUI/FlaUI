using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using System;

namespace FlaUI.Core.EventHandlers
{
    public abstract class StructureChangedEventHandlerBase : EventHandlerBase, IAutomationStructureChangedEventHandler
    {
        private readonly Action<Element, StructureChangeType, int[]> _callAction;

        protected StructureChangedEventHandlerBase(AutomationBase automation, Action<Element, StructureChangeType, int[]> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleStructureChangedEvent(Element sender, StructureChangeType changeType, int[] runtimeId)
        {
            _callAction(sender, changeType, runtimeId);
        }
    }
}
