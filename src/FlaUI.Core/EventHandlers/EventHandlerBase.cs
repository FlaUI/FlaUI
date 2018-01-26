namespace FlaUI.Core.EventHandlers
{
    /// <summary>
    /// Base class for all event handlers.
    /// </summary>
    public abstract class EventHandlerBase
    {
        /// <summary>
        /// The <see cref="AutomationBase"/> object that belongs to the event handler.
        /// </summary>
        public AutomationBase Automation { get; }

        /// <summary>
        /// Creates the event handler.
        /// </summary>
        protected EventHandlerBase(AutomationBase automation)
        {
            Automation = automation;
        }
    }
}
