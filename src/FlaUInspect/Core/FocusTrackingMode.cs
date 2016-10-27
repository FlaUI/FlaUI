using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.EventHandlers;

namespace FlaUInspect.Core
{
    public class FocusTrackingMode
    {
        private readonly AutomationBase _automation;
        private IAutomationFocusChangedEventHandler _eventHandler;
        private AutomationElement _currentFocusedElement;

        public event Action<AutomationElement> ElementFocused;

        public FocusTrackingMode(AutomationBase automation)
        {
            _automation = automation;
        }

        public void Start()
        {
            _eventHandler = _automation.RegisterFocusChangedEvent(OnFocusChanged);
        }

        public void Stop()
        {
            _automation.UnRegisterFocusChangedEvent(_eventHandler);
        }

        private void OnFocusChanged(AutomationElement automationElement)
        {
            if (!Equals(_currentFocusedElement, automationElement))
            {
                _currentFocusedElement = automationElement;
                ElementFocused?.Invoke(automationElement);
            }
        }
    }
}
