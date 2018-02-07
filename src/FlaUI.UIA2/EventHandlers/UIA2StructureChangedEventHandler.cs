using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.EventHandlers
{
    /// <summary>
    /// UIA2 implementation of a structure changed event handler.
    /// </summary>
    public class UIA2StructureChangedEventHandler : StructureChangedEventHandlerBase
    {
        public UIA.StructureChangedEventHandler EventHandler { get; }

        public UIA2StructureChangedEventHandler(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, StructureChangeType, int[]> callAction) : base(frameworkElement, callAction)
        {
            EventHandler = HandleStructureChangedEvent;
        }

        private void HandleStructureChangedEvent(object sender, UIA.StructureChangedEventArgs structureChangedEventArgs)
        {
            var frameworkElement = new UIA2FrameworkAutomationElement((UIA2Automation)Automation, (UIA.AutomationElement)sender);
            var senderElement = new AutomationElement(frameworkElement);
            HandleStructureChangedEvent(senderElement, (StructureChangeType)structureChangedEventArgs.StructureChangeType, structureChangedEventArgs.GetRuntimeId());
        }
    }
}
