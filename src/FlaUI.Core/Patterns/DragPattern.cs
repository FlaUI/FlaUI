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
        PropertyId DropEffectProperty { get; }
        PropertyId DropEffectsProperty { get; }
        PropertyId IsGrabbedProperty { get; }
        PropertyId GrabbedItemsProperty { get; }
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
            DropEffect = new AutomationProperty<string>(() => Properties.DropEffectProperty, BasicAutomationElement);
            DropEffects = new AutomationProperty<string[]>(() => Properties.DropEffectsProperty, BasicAutomationElement);
            IsGrabbed = new AutomationProperty<bool>(() => Properties.IsGrabbedProperty, BasicAutomationElement);
            GrabbedItems = new AutomationProperty<AutomationElement[]>(() => Properties.GrabbedItemsProperty, BasicAutomationElement);
        }

        public IDragPatternProperties Properties => Automation.PropertyLibrary.Drag;
        public IDragPatternEvents Events => Automation.EventLibrary.Drag;

        public AutomationProperty<string> DropEffect { get; }
        public AutomationProperty<string[]> DropEffects { get; }
        public AutomationProperty<bool> IsGrabbed { get; }
        public AutomationProperty<AutomationElement[]> GrabbedItems { get; }
    }
}
