using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.EventHandlers;
using System;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.EventHandlers
{
    public class UIA2StructureChangedEventHandler : StructureChangedEventHandlerBase
    {
        public UIA.StructureChangedEventHandler EventHandler { get; private set; }

        public UIA2StructureChangedEventHandler(AutomationBase automation, Action<Element, StructureChangeType, int[]> callAction) : base(automation, callAction)
        {
            EventHandler = HandleStructureChangedEvent;
        }

        private void HandleStructureChangedEvent(object sender, UIA.StructureChangedEventArgs structureChangedEventArgs)
        {
            var automationObject = new UIA2AutomationObject((UIA2Automation)Automation, (UIA.AutomationElement)sender);
            var senderElement = new Element(automationObject);
            HandleStructureChangedEvent(senderElement, (StructureChangeType) structureChangedEventArgs.StructureChangeType, structureChangedEventArgs.GetRuntimeId());
        }
    }
}
