using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IDockPattern : IPattern
    {
        IDockPatternProperties Properties { get; }

        AutomationProperty<DockPosition> DockPosition { get; }

        void SetDockPosition(DockPosition dockPos);
    }

    public interface IDockPatternProperties
    {
        PropertyId DockPosition { get; }
    }

    public abstract class DockPatternBase<TNativePattern> : PatternBase<TNativePattern>, IDockPattern
    {
        protected DockPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            DockPosition = new AutomationProperty<DockPosition>(() => Properties.DockPosition, BasicAutomationElement);
        }

        public IDockPatternProperties Properties => Automation.PropertyLibrary.Dock;

        public AutomationProperty<DockPosition> DockPosition { get; }

        public abstract void SetDockPosition(DockPosition dockPos);
    }
}
