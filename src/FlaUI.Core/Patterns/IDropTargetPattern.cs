using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IDropTargetPattern : IPatternWithInformation<IDropTargetPatternInformation>
    {
        IDropTargetPatternProperties Properties { get; }
        IDropTargetPatternEvents Events { get; }
    }

    public interface IDropTargetPatternInformation : IPatternInformation
    {
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
