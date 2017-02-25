using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IExpandCollapsePattern : IPattern
    {
        IExpandCollapsePatternProperties Properties { get; }

        AutomationProperty<ExpandCollapseState> ExpandCollapseState { get; }

        void Collapse();
        void Expand();
    }

    public interface IExpandCollapsePatternProperties
    {
        PropertyId ExpandCollapseState { get; }
    }

    public abstract class ExpandCollapsePatternBase<TNativePattern> : PatternBase<TNativePattern>, IExpandCollapsePattern
    {
        protected ExpandCollapsePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ExpandCollapseState = new AutomationProperty<ExpandCollapseState>(() => Properties.ExpandCollapseState, BasicAutomationElement);
        }

        public IExpandCollapsePatternProperties Properties => Automation.PropertyLibrary.ExpandCollapse;

        public AutomationProperty<ExpandCollapseState> ExpandCollapseState { get; }

        public abstract void Collapse();
        public abstract void Expand();
    }
}
