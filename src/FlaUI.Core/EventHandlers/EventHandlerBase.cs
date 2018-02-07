using System;

namespace FlaUI.Core.EventHandlers
{
    /// <summary>
    /// Base class for all event handlers.
    /// </summary>
    public abstract class EventHandlerBase : IDisposable
    {
        /// <summary>
        /// Creates the event handler.
        /// </summary>
        protected EventHandlerBase(AutomationBase automation)
        {
            Automation = automation;
        }

        /// <summary>
        /// The <see cref="AutomationBase"/> object that belongs to the event handler.
        /// </summary>
        public AutomationBase Automation { get; }

        /// <summary>
        /// Cleans up the event handler by unregistering it.
        /// </summary>
        public void Dispose()
        {
            UnregisterEventHandler();
        }

        /// <summary>
        /// Unregisters the event handler from the automation.
        /// </summary>
        protected abstract void UnregisterEventHandler();
    }
}
