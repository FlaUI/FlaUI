using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.EventHandlers
{
    public class UIA2StructureChangedEventHandler : StructureChangedEventHandlerBase
    {
        public UIA.StructureChangedEventHandler EventHandler { get; private set; }

        public UIA2StructureChangedEventHandler(AutomationBase automation, Action<AutomationElement, StructureChangeType, int[]> callAction) : base(automation, callAction)
        {
            EventHandler = HandleStructureChangedEvent;
        }

        private void HandleStructureChangedEvent(object sender, UIA.StructureChangedEventArgs structureChangedEventArgs)
        {
            var basicAutomationElement = new UIA2BasicAutomationElement((UIA2Automation)Automation, (UIA.AutomationElement)sender);
            var senderElement = new AutomationElement(basicAutomationElement);
            HandleStructureChangedEvent(senderElement, (StructureChangeType)structureChangedEventArgs.StructureChangeType, structureChangedEventArgs.GetRuntimeId());
        }
    }
}
