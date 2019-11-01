using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.EventHandlers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.EventHandlers
{
    public class UIA3ActiveTextPositionChangedEventHandler: ActiveTextPositionChangedEventHandlerBase, UIA.IUIAutomationActiveTextPositionChangedEventHandler
    {
        public UIA3ActiveTextPositionChangedEventHandler(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, ITextRange> callAction) : base(frameworkElement, callAction)
        {
        }

        public void HandleActiveTextPositionChangedEvent(UIA.IUIAutomationElement sender, UIA.IUIAutomationTextRange range)
        {
            var frameworkElement = new UIA3FrameworkAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(frameworkElement);
            var rangeElement = new UIA3TextRange((UIA3Automation)Automation, range);
            HandleActiveTextPositionChangedEvent(senderElement, rangeElement);
        }
    }
}
