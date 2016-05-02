using FlaUI.Core.Elements;
using interop.UIAutomationCore;
using System;

namespace FlaUI.Core.EventHandlers
{
    internal class StructureChangedEventHandler : EventHandlerBase, IUIAutomationStructureChangedEventHandler
    {
        private readonly Action<AutomationElement, Definitions.StructureChangeType, int[]> _callAction;

        public StructureChangedEventHandler(Automation automation, Action<AutomationElement, Definitions.StructureChangeType, int[]> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleStructureChangedEvent(IUIAutomationElement sender, StructureChangeType changeType, int[] runtimeId)
        {
            var senderElement = new AutomationElement(Automation, sender);
            var externChangeType = (Definitions.StructureChangeType) changeType;
            _callAction(senderElement, externChangeType, runtimeId);
        }
    }
}
