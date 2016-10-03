using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Shapes;
using FlaUI.UIA2.EventHandlers;
using System;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    /// <summary>
    /// Automation implementation for UIA2
    /// </summary>
    public class UIA2Automation : AutomationBase
    {
        public UIA2Automation() : base(new UIA2PropertyLibrary())
        {
        }

        public override AutomationType AutomationType => AutomationType.UIA2;

        public override object NotSupportedValue => UIA.AutomationElement.NotSupported;

        public override Element GetDesktop()
        {
            var desktop = UIA.AutomationElement.RootElement;
            return new Element(WrapNativeElement(desktop));
        }

        public override Element FromPoint(Point point)
        {
            var nativeElement = UIA.AutomationElement.FromPoint(point);
            return nativeElement == null ? null : new Element(WrapNativeElement(nativeElement));
        }

        /// <summary>
        /// Creates an <see cref="UIA.AutomationElement"/> from a given windows handle (HWND)
        /// </summary>
        public override Element FromHandle(IntPtr hwnd)
        {
            var nativeElement = UIA.AutomationElement.FromHandle(hwnd);
            return nativeElement == null ? null : new Element(WrapNativeElement(nativeElement));
        }

        public override IAutomationFocusChangedEventHandler RegisterFocusChangedEvent(Action<Element> action)
        {
            var eventHandler = new UIA2FocusChangedEventHandler(this, action);
            UIA.Automation.AddAutomationFocusChangedEventHandler(eventHandler.EventHandler);
            return eventHandler;
        }

        public override void UnRegisterFocusChangedEvent(IAutomationFocusChangedEventHandler eventHandler)
        {
            UIA.Automation.RemoveAutomationFocusChangedEventHandler(((UIA2FocusChangedEventHandler)eventHandler).EventHandler);
        }

        public override void UnregisterAllEvents()
        {
            UIA.Automation.RemoveAllEventHandlers();
        }

        public UIA2AutomationObject WrapNativeElement(UIA.AutomationElement nativeElement)
        {
            return new UIA2AutomationObject(this, nativeElement);
        }
    }
}
