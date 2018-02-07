namespace FlaUI.Core.EventHandlers
{
    /// <summary>
    /// Base class for event handlers that are tied to elements.
    /// </summary>
    public abstract class ElementEventHandlerBase : EventHandlerBase
    {
        protected ElementEventHandlerBase(FrameworkAutomationElementBase frameworkElement) : base(frameworkElement.Automation)
        {
            FrameworkElement = frameworkElement;
        }

        /// <summary>
        /// The framework element element to which this event handler belongs to.
        /// </summary>
        protected FrameworkAutomationElementBase FrameworkElement { get; }
    }
}
