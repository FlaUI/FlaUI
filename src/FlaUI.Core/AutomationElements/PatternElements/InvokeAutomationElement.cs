using FlaUI.Core.Patterns;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    /// <summary>
    /// An element that supports the <see cref="IInvokePattern"/>.
    /// </summary>
    public class InvokeAutomationElement : AutomationElement
    {
        /// <summary>
        /// Creates an element with a <see cref="IInvokePattern"/>.
        /// </summary>
        public InvokeAutomationElement(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        ///  Provides direct access to the invoke pattern.
        /// </summary>
        public IInvokePattern InvokePattern => Patterns.Invoke.Pattern;

        /// <summary>
        /// Invokes the element.
        /// </summary>
        public void Invoke()
        {
            InvokePattern.Invoke();
        }
    }
}
