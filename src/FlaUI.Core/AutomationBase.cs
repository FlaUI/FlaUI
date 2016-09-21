using FlaUI.Core.Overlay;
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
        public OverlayManager OverlayManager
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates an automation object
        /// </summary>
        protected AutomationBase()
        {
            OverlayManager = new OverlayManager();
        }

        /// <summary>
        /// Object which represents the "Not Supported" value
        /// </summary>
        public abstract object NotSupportedValue { get; }

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
