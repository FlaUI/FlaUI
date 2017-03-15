using FlaUI.Core.Identifiers;

namespace FlaUI.Core
{
    /// <summary>
    /// Base class for information objects
    /// </summary>
    public abstract class InformationBase2
    {
        /// <summary>
        /// The element this information belongs to
        /// </summary>
        protected AutomationElementBase AutomationElement { get; private set; }

        /// <summary>
        /// Flag to indicate if the information is cached or not
        /// </summary>
        protected bool Cached { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        protected InformationBase2(AutomationElementBase automationElement, bool cached)
        {
            AutomationElement = automationElement;
            Cached = cached;
        }

        /// <summary>
        /// Shortcut to get the property 
        /// </summary>
        protected T Get<T>(PropertyId property)
        {
            return AutomationElement.SafeGetPropertyValue<T>(property, Cached);
        }
    }
}
