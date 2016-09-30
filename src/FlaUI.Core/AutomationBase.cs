using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Overlay;
using FlaUI.Core.Shapes;
using System;

namespace FlaUI.Core
{
    /// <summary>
    /// Base class for the native automation object
    /// </summary>
    public abstract class AutomationBase : IDisposable
    {
        /// <summary>
        /// Manager object for overlays
        /// </summary>
        public OverlayManager OverlayManager { get; private set; }

        /// <summary>
        /// The automation type of the automation implementation
        /// </summary>
        public abstract AutomationType AutomationType { get; }

        /// <summary>
        /// Object which represents the "Not Supported" value
        /// </summary>
        public abstract object NotSupportedValue { get; }

        /// <summary>
        /// Creates an automation object
        /// </summary>
        protected AutomationBase()
        {
            OverlayManager = new OverlayManager();
        }

        public abstract Element GetDesktop();

        /// <summary>
        /// Creates an <see cref="Element"/> from a given point
        /// </summary>
        public abstract Element FromPoint(Point point);

        /// <summary>
        /// Creates an <see cref="Element"/> from a given windows handle (HWND)
        /// </summary>
        public abstract Element FromHandle(IntPtr hwnd);
        
        public abstract IAutomationFocusChangedEventHandler RegisterFocusChangedEvent(Action<Element> action);

        public abstract void UnRegisterFocusChangedEvent(IAutomationFocusChangedEventHandler eventHandler);

        /// <summary>
        /// Removes all registered event handlers
        /// </summary>
        public abstract void UnregisterAllEvents();

        /// <summary>
        /// Cleans up the resources
        /// </summary>
        public void Dispose()
        {
            UnregisterAllEvents();
            OverlayManager.Dispose();
        }
    }
}
