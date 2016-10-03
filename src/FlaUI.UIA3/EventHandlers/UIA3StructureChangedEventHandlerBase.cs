using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.EventHandlers;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    public class UIA3StructureChangedEventHandler : StructureChangedEventHandlerBase, UIA.IUIAutomationStructureChangedEventHandler
    {
        public UIA3StructureChangedEventHandler(AutomationBase automation, Action<Element, StructureChangeType, int[]> callAction) : base(automation, callAction)
        {
        }

        public void HandleStructureChangedEvent(UIA.IUIAutomationElement sender, UIA.StructureChangeType changeType, int[] runtimeId)
        {
            var automationObject = new UIA3AutomationObject((UIA3Automation)Automation, sender);
            var senderElement = new Element(automationObject);
            HandleStructureChangedEvent(senderElement, (StructureChangeType) changeType, runtimeId);
        }
    }
}
