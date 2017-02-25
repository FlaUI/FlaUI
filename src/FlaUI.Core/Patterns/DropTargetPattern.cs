using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IDropTargetPattern : IPattern
    {
        IDropTargetPatternProperties Properties { get; }
        IDropTargetPatternEvents Events { get; }

        AutomationProperty<string> DropTargetEffect { get; }
        AutomationProperty<string[]> DropTargetEffects { get; }
    }

    public interface IDropTargetPatternProperties
    {
        PropertyId DropTargetEffectProperty { get; }
        PropertyId DropTargetEffectsProperty { get; }
    }

    public interface IDropTargetPatternEvents
    {
        EventId DragEnterEvent { get; }
        EventId DragLeaveEvent { get; }
        EventId DragCompleteEvent { get; }
    }

    public abstract class DropTargetPatternBase<TNativePattern> : PatternBase<TNativePattern>, IDropTargetPattern
    {
        protected DropTargetPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            DropTargetEffect = new AutomationProperty<string>(() => Properties.DropTargetEffectProperty, BasicAutomationElement);
            DropTargetEffects = new AutomationProperty<string[]>(() => Properties.DropTargetEffectsProperty, BasicAutomationElement);
        }

        public IDropTargetPatternProperties Properties => Automation.PropertyLibrary.DropTarget;
        public IDropTargetPatternEvents Events => Automation.EventLibrary.DropTarget;

        public AutomationProperty<string> DropTargetEffect { get; }
        public AutomationProperty<string[]> DropTargetEffects { get; }
    }
}
