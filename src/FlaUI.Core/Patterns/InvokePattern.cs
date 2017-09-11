using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    /// <summary>
    /// Interface for an invoke pattern.
    /// </summary>
    public interface IInvokePattern : IPattern
    {
        /// <summary>
        /// Gets the supported events by this pattern.
        /// </summary>
        IInvokePatternEvents Events { get; }

        /// <summary>
        /// Invokes the element.
        /// </summary>
        void Invoke();
    }

    /// <summary>
    /// Interface for invoke pattern events.
    /// </summary>
    public interface IInvokePatternEvents
    {
        /// <summary>
        /// Gets the invoked event.
        /// </summary>
        EventId InvokedEvent { get; }
    }

    /// <summary>
    /// Base cass for an <see cref="IInvokePattern"/>.
    /// </summary>
    /// <typeparam name="TNativePattern">The type of the native invoke pattern.</typeparam>
    public abstract class InvokePatternBase<TNativePattern> : PatternBase<TNativePattern>, IInvokePattern
        where TNativePattern : class
    {
        /// <summary>
        /// Creates the <see cref="IInvokePattern"/>.
        /// </summary>
        protected InvokePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        /// <inheritdoc />
        public IInvokePatternEvents Events => Automation.EventLibrary.Invoke;

        /// <inheritdoc />
        public abstract void Invoke();
    }
}
