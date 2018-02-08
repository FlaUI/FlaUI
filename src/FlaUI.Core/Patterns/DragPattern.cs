using FlaUI.Core.AutomationElements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IDragPattern : IPattern
    {
        IDragPatternPropertyIds PropertyIds { get; }
        IDragPatternEventIds EventIds { get; }

        AutomationProperty<string> DropEffect { get; }
        AutomationProperty<string[]> DropEffects { get; }
        AutomationProperty<bool> IsGrabbed { get; }
        AutomationProperty<AutomationElement[]> GrabbedItems { get; }
    }

    public interface IDragPatternPropertyIds
    {
        PropertyId DropEffect { get; }
        PropertyId DropEffects { get; }
        PropertyId IsGrabbed { get; }
        PropertyId GrabbedItems { get; }
    }

    public interface IDragPatternEventIds
    {
        EventId DragCancelEvent { get; }
        EventId DragCompleteEvent { get; }
        EventId DragStartEvent { get; }
    }

    public abstract class DragPatternBase<TNativePattern> : PatternBase<TNativePattern>, IDragPattern
        where TNativePattern : class
    {
        private AutomationProperty<string> _dropEffect;
        private AutomationProperty<string[]> _dropEffects;
        private AutomationProperty<bool> _isGrabbed;
        private AutomationProperty<AutomationElement[]> _grabbedItems;

        protected DragPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public IDragPatternPropertyIds PropertyIds => Automation.PropertyLibrary.Drag;
        public IDragPatternEventIds EventIds => Automation.EventLibrary.Drag;

        public AutomationProperty<string> DropEffect => GetOrCreate(ref _dropEffect, PropertyIds.DropEffect);
        public AutomationProperty<string[]> DropEffects => GetOrCreate(ref _dropEffects, PropertyIds.DropEffects);
        public AutomationProperty<bool> IsGrabbed => GetOrCreate(ref _isGrabbed, PropertyIds.IsGrabbed);
        public AutomationProperty<AutomationElement[]> GrabbedItems => GetOrCreate(ref _grabbedItems, PropertyIds.GrabbedItems);
    }
}
