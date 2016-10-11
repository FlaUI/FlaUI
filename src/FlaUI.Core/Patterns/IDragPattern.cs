using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IDragPattern : IPatternWithInformation<IDragPatternInformation>
    {
        IDragPatternProperties Properties { get; }
        IDragPatternEvents Events { get; }
    }

    public interface IDragPatternInformation : IPatternInformation
    {
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
