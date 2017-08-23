using System;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Patterns.Infrastructure
{
    /// <summary>
    /// Base class for a pattern implementation.
    /// </summary>
    /// <typeparam name="TNativePattern">The type of the native pattern.</typeparam>
    public abstract class PatternBase<TNativePattern> : IPattern
        where TNativePattern : class
    {
        protected PatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern)
        {
            BasicAutomationElement = basicAutomationElement ?? throw new ArgumentNullException(nameof(basicAutomationElement));
            NativePattern = nativePattern ?? throw new ArgumentNullException(nameof(nativePattern));
        }

        public BasicAutomationElementBase BasicAutomationElement { get; }

        public TNativePattern NativePattern { get; }

        public AutomationBase Automation => BasicAutomationElement.Automation;

        protected AutomationProperty<T> GetOrCreate<T>(ref AutomationProperty<T> val, PropertyId propertyId)
        {
            return val ?? (val = new AutomationProperty<T>(propertyId, BasicAutomationElement));
        }
    }
}
