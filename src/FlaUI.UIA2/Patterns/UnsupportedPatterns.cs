using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;

namespace FlaUI.UIA2.Patterns
{
    public class AnnotationPatternProperties : IAnnotationPatternProperties
    {
        public PropertyId AnnotationTypeId => PropertyId.NotSupportedByFramework;
        public PropertyId AnnotationTypeName => PropertyId.NotSupportedByFramework;
        public PropertyId Author => PropertyId.NotSupportedByFramework;
        public PropertyId DateTime => PropertyId.NotSupportedByFramework;
        public PropertyId Target => PropertyId.NotSupportedByFramework;
    }

    public class DragPatternProperties : IDragPatternProperties
    {
        public PropertyId DropEffect => PropertyId.NotSupportedByFramework;
        public PropertyId DropEffects => PropertyId.NotSupportedByFramework;
        public PropertyId IsGrabbed => PropertyId.NotSupportedByFramework;
        public PropertyId GrabbedItems => PropertyId.NotSupportedByFramework;
    }

    public class DragPatternEvents : IDragPatternEvents
    {
        public EventId DragCancelEvent => EventId.NotSupportedByFramework;
        public EventId DragCompleteEvent => EventId.NotSupportedByFramework;
        public EventId DragStartEvent => EventId.NotSupportedByFramework;
    }

    public class DropTargetPatternProperties : IDropTargetPatternProperties
    {
        public PropertyId DropTargetEffect => PropertyId.NotSupportedByFramework;
        public PropertyId DropTargetEffects => PropertyId.NotSupportedByFramework;
    }

    public class DropTargetPatternEvents : IDropTargetPatternEvents
    {
        public EventId DragEnterEvent => EventId.NotSupportedByFramework;
        public EventId DragLeaveEvent => EventId.NotSupportedByFramework;
        public EventId DragCompleteEvent => EventId.NotSupportedByFramework;
    }

    public class LegacyIAccessiblePatternProperties : ILegacyIAccessiblePatternProperties
    {
        public PropertyId ChildId => PropertyId.NotSupportedByFramework;
        public PropertyId DefaultAction => PropertyId.NotSupportedByFramework;
        public PropertyId Description => PropertyId.NotSupportedByFramework;
        public PropertyId Help => PropertyId.NotSupportedByFramework;
        public PropertyId KeyboardShortcut => PropertyId.NotSupportedByFramework;
        public PropertyId Name => PropertyId.NotSupportedByFramework;
        public PropertyId Role => PropertyId.NotSupportedByFramework;
        public PropertyId Selection => PropertyId.NotSupportedByFramework;
        public PropertyId State => PropertyId.NotSupportedByFramework;
        public PropertyId Value => PropertyId.NotSupportedByFramework;
    }

    public class SpreadsheetItemPatternProperties : ISpreadsheetItemPatternProperties
    {
        public PropertyId Formula => PropertyId.NotSupportedByFramework;
        public PropertyId AnnotationObjects => PropertyId.NotSupportedByFramework;
        public PropertyId AnnotationTypes => PropertyId.NotSupportedByFramework;
    }

    public class StylesPatternProperties : IStylesPatternProperties
    {
        public PropertyId ExtendedProperties => PropertyId.NotSupportedByFramework;
        public PropertyId FillColor => PropertyId.NotSupportedByFramework;
        public PropertyId FillPatternColor => PropertyId.NotSupportedByFramework;
        public PropertyId FillPatternStyle => PropertyId.NotSupportedByFramework;
        public PropertyId Shape => PropertyId.NotSupportedByFramework;
        public PropertyId StyleId => PropertyId.NotSupportedByFramework;
        public PropertyId StyleName => PropertyId.NotSupportedByFramework;
    }

    public class TextEditPatternEvents : TextPatternEvents, ITextEditPatternEvents
    {
        public EventId ConversionTargetChangedEvent => EventId.NotSupportedByFramework;
        public EventId TextChangedEvent2 => EventId.NotSupportedByFramework;
    }

    public class Transform2PatternProperties : TransformPatternProperties, ITransform2PatternProperties
    {
        public PropertyId CanZoom => PropertyId.NotSupportedByFramework;
        public PropertyId ZoomLevel => PropertyId.NotSupportedByFramework;
        public PropertyId ZoomMaximum => PropertyId.NotSupportedByFramework;
        public PropertyId ZoomMinimum => PropertyId.NotSupportedByFramework;
    }
}
