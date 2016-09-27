using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    internal class StructureChangedEventHandler : EventHandlerBase, UIA.IUIAutomationStructureChangedEventHandler
    {
        private readonly Action<Element, StructureChangeType, int[]> _callAction;

        public StructureChangedEventHandler(UIA3Automation automation, Action<Element, StructureChangeType, int[]> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleStructureChangedEvent(UIA.IUIAutomationElement sender, interop.UIAutomationCore.StructureChangeType changeType, int[] runtimeId)
        {
            var senderElement = new Element(Automation, sender);
            var externChangeType = (StructureChangeType) changeType;
            _callAction(senderElement, externChangeType, runtimeId);
        }
    }
}
