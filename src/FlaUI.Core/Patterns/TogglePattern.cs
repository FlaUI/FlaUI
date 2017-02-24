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
        PropertyId ToggleStateProperty { get; }
    }

    public abstract class TogglePatternBase<TNativePattern> : PatternBase<TNativePattern>, ITogglePattern
    {
        protected TogglePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ToggleState = new AutomationProperty<ToggleState>(() => Properties.ToggleStateProperty, BasicAutomationElement);
        }

        public ITogglePatternProperties Properties => Automation.PropertyLibrary.Toggle;

        public AutomationProperty<ToggleState> ToggleState { get; }

        public abstract void Toggle();
    }
}
