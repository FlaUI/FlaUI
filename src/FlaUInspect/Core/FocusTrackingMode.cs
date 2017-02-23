using System;
using System.Diagnostics;
using System.Threading.Tasks;
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
            // Might give problems because inspect is registered as well.
            // MS recommends to call UIA commands on a thread outside of an UI thread.
            Task.Factory.StartNew(() => _eventHandler = _automation.RegisterFocusChangedEvent(OnFocusChanged));
        }

        public void Stop()
        {
            _automation.UnRegisterFocusChangedEvent(_eventHandler);
        }

        private void OnFocusChanged(AutomationElement automationElement)
        {
            // Skip items in the current process
            // Like Inspect itself or the overlay window
            if (automationElement.Info.ProcessId == Process.GetCurrentProcess().Id)
            {
                return;
            }
            if (!Equals(_currentFocusedElement, automationElement))
            {
                _currentFocusedElement = automationElement;
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    ElementFocused?.Invoke(automationElement);
                });
            }
        }
    }
}
