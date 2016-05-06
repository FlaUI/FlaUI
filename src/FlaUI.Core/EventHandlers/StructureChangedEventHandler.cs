using System;
using FlaUI.Core.Elements;
using interop.UIAutomationCore;
using StructureChangeType = FlaUI.Core.Definitions.StructureChangeType;

namespace FlaUI.Core.EventHandlers
{
    internal class StructureChangedEventHandler : EventHandlerBase, IUIAutomationStructureChangedEventHandler
    {
        private readonly Action<AutomationElement, StructureChangeType, int[]> _callAction;

        public StructureChangedEventHandler(Automation automation, Action<AutomationElement, StructureChangeType, int[]> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleStructureChangedEvent(IUIAutomationElement sender, interop.UIAutomationCore.StructureChangeType changeType, int[] runtimeId)
        {
            var senderElement = new AutomationElement(Automation, sender);
            var externChangeType = (StructureChangeType) changeType;
            _callAction(senderElement, externChangeType, runtimeId);
        }
    }
}
