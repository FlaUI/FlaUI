using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IValuePattern : IPattern
    {
        /// <summary>
        /// Gets the object which provides access to all properties of this pattern.
        /// </summary>
        IValuePatternProperties Properties { get; }

        /// <summary>
        /// Gets a value that specifies whether the value of the element is read-only.
        /// </summary>
        AutomationProperty<bool> IsReadOnly { get; }

        /// <summary>
        /// Gets the value of the element.
        /// </summary>
        AutomationProperty<string> Value { get; }

        /// <summary>
        /// Sets the value of the control.
        /// </summary>
        /// <param name="value">The value to set.</param>
        void SetValue(string value);
    }

    public interface IValuePatternProperties
    {
        PropertyId IsReadOnly { get; }
        PropertyId Value { get; }
    }

    public abstract class ValuePatternBase<TNativePattern> : PatternBase<TNativePattern>, IValuePattern
        where TNativePattern : class
    {
        private AutomationProperty<bool> _isReadOnly;
        private AutomationProperty<string> _value;

        protected ValuePatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        /// <inheritdoc />
        public IValuePatternProperties Properties => Automation.PropertyLibrary.Value;

        /// <inheritdoc />
        public AutomationProperty<bool> IsReadOnly => GetOrCreate(ref _isReadOnly, Properties.IsReadOnly);

        /// <inheritdoc />
        public AutomationProperty<string> Value => GetOrCreate(ref _value, Properties.Value);

        /// <inheritdoc />
        public abstract void SetValue(string value);
    }
}
