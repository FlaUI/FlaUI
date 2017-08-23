using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IDragPattern : IPattern
    {
        IDragPatternProperties Properties { get; }
        IDragPatternEvents Events { get; }

        AutomationProperty<string> DropEffect { get; }
        AutomationProperty<string[]> DropEffects { get; }
        AutomationProperty<bool> IsGrabbed { get; }
        AutomationProperty<AutomationElement[]> GrabbedItems { get; }
    }

    public interface IDragPatternProperties
    {
        PropertyId DropEffect { get; }
        PropertyId DropEffects { get; }
        PropertyId IsGrabbed { get; }
        PropertyId GrabbedItems { get; }
    }

    public interface IDragPatternEvents
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

        protected DragPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IDragPatternProperties Properties => Automation.PropertyLibrary.Drag;
        public IDragPatternEvents Events => Automation.EventLibrary.Drag;

        public AutomationProperty<string> DropEffect => GetOrCreate(ref _dropEffect, Properties.DropEffect);
        public AutomationProperty<string[]> DropEffects => GetOrCreate(ref _dropEffects, Properties.DropEffects);
        public AutomationProperty<bool> IsGrabbed => GetOrCreate(ref _isGrabbed, Properties.IsGrabbed);
        public AutomationProperty<AutomationElement[]> GrabbedItems => GetOrCreate(ref _grabbedItems, Properties.GrabbedItems);
    }
}
