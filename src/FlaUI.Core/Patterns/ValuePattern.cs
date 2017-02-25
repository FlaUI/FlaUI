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
    {
        protected ValuePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            IsReadOnly = new AutomationProperty<bool>(() => Properties.IsReadOnly, BasicAutomationElement);
            Value = new AutomationProperty<string>(() => Properties.Value, BasicAutomationElement);
        }

        public IValuePatternProperties Properties => Automation.PropertyLibrary.Value;

        public AutomationProperty<bool> IsReadOnly { get; }
        public AutomationProperty<string> Value { get; }

        public abstract void SetValue(string value);
    }
}
