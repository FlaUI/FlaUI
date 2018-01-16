using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.EventHandlers
{
    public class UIA3StructureChangedEventHandler : StructureChangedEventHandlerBase, UIA.IUIAutomationStructureChangedEventHandler
    {
        public UIA3StructureChangedEventHandler(AutomationBase automation, Action<AutomationElement, StructureChangeType, int[]> callAction) : base(automation, callAction)
        {
        }

        public void HandleStructureChangedEvent(UIA.IUIAutomationElement sender, UIA.StructureChangeType changeType, int[] runtimeId)
        {
            var basicAutomationElement = new UIA3BasicAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(basicAutomationElement);
            HandleStructureChangedEvent(senderElement, (StructureChangeType)changeType, runtimeId);
        }
    }
}
