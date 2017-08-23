using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IValuePattern : IPattern
    {
        IValuePatternProperties Properties { get; }

        AutomationProperty<bool> IsReadOnly { get; }
        AutomationProperty<string> Value { get; }

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

        protected ValuePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IValuePatternProperties Properties => Automation.PropertyLibrary.Value;

        public AutomationProperty<bool> IsReadOnly => GetOrCreate(ref _isReadOnly, Properties.IsReadOnly);
        public AutomationProperty<string> Value => GetOrCreate(ref _value, Properties.Value);

        public abstract void SetValue(string value);
    }
}
