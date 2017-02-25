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
    {
        protected DragPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            DropEffect = new AutomationProperty<string>(() => Properties.DropEffect, BasicAutomationElement);
            DropEffects = new AutomationProperty<string[]>(() => Properties.DropEffects, BasicAutomationElement);
            IsGrabbed = new AutomationProperty<bool>(() => Properties.IsGrabbed, BasicAutomationElement);
            GrabbedItems = new AutomationProperty<AutomationElement[]>(() => Properties.GrabbedItems, BasicAutomationElement);
        }

        public IDragPatternProperties Properties => Automation.PropertyLibrary.Drag;
        public IDragPatternEvents Events => Automation.EventLibrary.Drag;

        public AutomationProperty<string> DropEffect { get; }
        public AutomationProperty<string[]> DropEffects { get; }
        public AutomationProperty<bool> IsGrabbed { get; }
        public AutomationProperty<AutomationElement[]> GrabbedItems { get; }
    }
}
