using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITogglePattern : IPattern
    {
        ITogglePatternProperties Properties { get; }

        AutomationProperty<ToggleState> ToggleState { get; }

        void Toggle();
    }

    public interface ITogglePatternProperties
    {
        PropertyId ToggleState { get; }
    }

    public abstract class TogglePatternBase<TNativePattern> : PatternBase<TNativePattern>, ITogglePattern
        where TNativePattern : class
    {
        private AutomationProperty<ToggleState> _toggleState;

        protected TogglePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ITogglePatternProperties Properties => Automation.PropertyLibrary.Toggle;

        public AutomationProperty<ToggleState> ToggleState => GetOrCreate(ref _toggleState, Properties.ToggleState);

        public abstract void Toggle();
    }
}
