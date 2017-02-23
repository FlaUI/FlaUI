using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IDropTargetPattern : IPattern
    {
        IDropTargetPatternProperties Properties { get; }
        IDropTargetPatternEvents Events { get; }
        string DropTargetEffect { get; }
        string[] DropTargetEffects { get; }
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
}
