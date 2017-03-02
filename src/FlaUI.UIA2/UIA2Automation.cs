using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Shapes;
using FlaUI.UIA2.Converters;
using FlaUI.UIA2.EventHandlers;
using FlaUI.UIA2.Extensions;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    /// <summary>
    /// Automation implementation for UIA2
    /// </summary>
    public class UIA2Automation : AutomationBase
    {
        public UIA2Automation() : base(new UIA2PropertyLibrary(), new UIA2EventLibrary(), new UIA2PatternLibrary())
        {
            TreeWalkerFactory = new UIA2TreeWalkerFactory(this);
        }

        public override ITreeWalkerFactory TreeWalkerFactory { get; }

        public override AutomationType AutomationType => AutomationType.UIA2;

        public override object NotSupportedValue => UIA.AutomationElement.NotSupported;

        public override AutomationElement GetDesktop()
        {
            var nativeElement = InternalGetNativeElement(() => UIA.AutomationElement.RootElement);
            return AutomationElementConverter.NativeToManaged(this, nativeElement);
        }

        public override AutomationElement FromPoint(Point point)
        {
            var nativeElement = InternalGetNativeElement(() => UIA.AutomationElement.FromPoint(point));
            return AutomationElementConverter.NativeToManaged(this, nativeElement);
        }

        /// <summary>
        /// Creates an <see cref="UIA.AutomationElement" /> from a given windows handle (HWND)
        /// </summary>
        public override AutomationElement FromHandle(IntPtr hwnd)
        {
            var nativeElement = InternalGetNativeElement(() => UIA.AutomationElement.FromHandle(hwnd));
            return AutomationElementConverter.NativeToManaged(this, nativeElement);
        }

        public override AutomationElement FocusedElement()
        {
            var nativeElement = InternalGetNativeElement(() => UIA.AutomationElement.FocusedElement);
            return AutomationElementConverter.NativeToManaged(this, nativeElement);
        }

        public override IAutomationFocusChangedEventHandler RegisterFocusChangedEvent(Action<AutomationElement> action)
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

        public override bool Compare(AutomationElement element1, AutomationElement element2)
        {
            return UIA.Automation.Compare(element1.ToNative(), element2.ToNative());
        }

        public AutomationElement WrapNativeElement(UIA.AutomationElement nativeElement)
        {
            return nativeElement == null ? null : new AutomationElement(new UIA2BasicAutomationElement(this, nativeElement));
        }

        /// <summary>
        /// Gets the native element according to the passed action. Uses caching if it is active.
        /// </summary>
        private UIA.AutomationElement InternalGetNativeElement(Func<UIA.AutomationElement> getAction)
        {
            if (!CacheRequest.IsCachingActive)
            {
                return getAction();
            }
            var cacheRequest = CacheRequest.Current.ToNative();
            using (cacheRequest.Activate())
            {
                return getAction();
            }
        }
    }
}
