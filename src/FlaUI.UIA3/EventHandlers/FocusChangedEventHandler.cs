using FlaUI.UIA3.Elements;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.EventHandlers
{
    internal class FocusChangedEventHandler :EventHandlerBase, UIA.IUIAutomationFocusChangedEventHandler
    {
        private readonly Action<Element> _callAction;

        public FocusChangedEventHandler(UIA3Automation automation, Action<Element> callAction)
            : base(automation)
        {
            _callAction = callAction;
        }

        public void HandleFocusChangedEvent(UIA.IUIAutomationElement sender)
        {
            var senderElement = new Element(Automation, sender);
            _callAction(senderElement);
        }
    }
}
