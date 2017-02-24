using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IDragPattern : IPattern
    {
        IDragPatternProperties Properties { get; }
        IDragPatternEvents Events { get; }
        string DropEffect { get; }
        string[] DropEffects { get; }
        bool IsGrabbed { get; }
        AutomationElement[] GrabbedItems { get; }
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
}
