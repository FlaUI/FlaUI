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
        protected PatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern)
        {
            FrameworkAutomationElement = frameworkAutomationElement ?? throw new ArgumentNullException(nameof(frameworkAutomationElement));
            NativePattern = nativePattern ?? throw new ArgumentNullException(nameof(nativePattern));
        }

        public FrameworkAutomationElementBase FrameworkAutomationElement { get; }

        public TNativePattern NativePattern { get; }

        public AutomationBase Automation => FrameworkAutomationElement.Automation;

        protected AutomationProperty<T> GetOrCreate<T>(ref AutomationProperty<T>? val, PropertyId propertyId)
        {
            return val ?? (val = new AutomationProperty<T>(propertyId, FrameworkAutomationElement));
        }
    }
}
