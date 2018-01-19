using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IDropTargetPattern : IPattern
    {
        IDropTargetPatternPropertyIds PropertyIds { get; }
        IDropTargetPatternEventIds EventIds { get; }

        AutomationProperty<string> DropTargetEffect { get; }
        AutomationProperty<string[]> DropTargetEffects { get; }
    }

    public interface IDropTargetPatternPropertyIds
    {
        PropertyId DropTargetEffect { get; }
        PropertyId DropTargetEffects { get; }
    }

    public interface IDropTargetPatternEventIds
    {
        EventId DragEnterEvent { get; }
        EventId DragLeaveEvent { get; }
        EventId DragCompleteEvent { get; }
    }

    public abstract class DropTargetPatternBase<TNativePattern> : PatternBase<TNativePattern>, IDropTargetPattern
        where TNativePattern : class
    {
        private AutomationProperty<string> _dropTargetEffect;
        private AutomationProperty<string[]> _dropTargetEffects;

        protected DropTargetPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public IDropTargetPatternPropertyIds PropertyIds => Automation.PropertyLibrary.DropTarget;
        public IDropTargetPatternEventIds EventIds => Automation.EventLibrary.DropTarget;

        public AutomationProperty<string> DropTargetEffect => GetOrCreate(ref _dropTargetEffect, PropertyIds.DropTargetEffect);
        public AutomationProperty<string[]> DropTargetEffects => GetOrCreate(ref _dropTargetEffects, PropertyIds.DropTargetEffects);
    }
}
