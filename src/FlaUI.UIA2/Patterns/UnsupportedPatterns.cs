using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;

namespace FlaUI.UIA2.Patterns
{
    public class AnnotationPatternPropertyIds : IAnnotationPatternPropertyIds
    {
        public PropertyId AnnotationTypeId => PropertyId.NotSupportedByFramework;
        public PropertyId AnnotationTypeName => PropertyId.NotSupportedByFramework;
        public PropertyId Author => PropertyId.NotSupportedByFramework;
        public PropertyId DateTime => PropertyId.NotSupportedByFramework;
        public PropertyId Target => PropertyId.NotSupportedByFramework;
    }

    public class DragPatternPropertyIds : IDragPatternPropertyIds
    {
        public PropertyId DropEffect => PropertyId.NotSupportedByFramework;
        public PropertyId DropEffects => PropertyId.NotSupportedByFramework;
        public PropertyId IsGrabbed => PropertyId.NotSupportedByFramework;
        public PropertyId GrabbedItems => PropertyId.NotSupportedByFramework;
    }

    public class DragPatternEventIds : IDragPatternEventIds
    {
        public EventId DragCancelEvent => EventId.NotSupportedByFramework;
        public EventId DragCompleteEvent => EventId.NotSupportedByFramework;
        public EventId DragStartEvent => EventId.NotSupportedByFramework;
    }

    public class DropTargetPatternPropertyIds : IDropTargetPatternPropertyIds
    {
        public PropertyId DropTargetEffect => PropertyId.NotSupportedByFramework;
        public PropertyId DropTargetEffects => PropertyId.NotSupportedByFramework;
    }

    public class DropTargetPatternEventIds : IDropTargetPatternEventIds
    {
        public EventId DragEnterEvent => EventId.NotSupportedByFramework;
        public EventId DragLeaveEvent => EventId.NotSupportedByFramework;
        public EventId DragCompleteEvent => EventId.NotSupportedByFramework;
    }

    public class LegacyIAccessiblePatternPropertyIds : ILegacyIAccessiblePatternPropertyIds
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

    public class Selection2PatternPropertyIds : SelectionPatternPropertyIds, ISelection2PatternPropertyIds
    {
        public PropertyId CurrentSelectedItem => PropertyId.NotSupportedByFramework;
        public PropertyId FirstSelectedItem => PropertyId.NotSupportedByFramework;
        public PropertyId ItemCount => PropertyId.NotSupportedByFramework;
        public PropertyId LastSelectedItem => PropertyId.NotSupportedByFramework;
    }

    public class SpreadsheetItemPatternPropertyIds : ISpreadsheetItemPatternPropertyIds
    {
        public PropertyId Formula => PropertyId.NotSupportedByFramework;
        public PropertyId AnnotationObjects => PropertyId.NotSupportedByFramework;
        public PropertyId AnnotationTypes => PropertyId.NotSupportedByFramework;
    }

    public class StylesPatternPropertyIds : IStylesPatternPropertyIds
    {
        public PropertyId ExtendedProperties => PropertyId.NotSupportedByFramework;
        public PropertyId FillColor => PropertyId.NotSupportedByFramework;
        public PropertyId FillPatternColor => PropertyId.NotSupportedByFramework;
        public PropertyId FillPatternStyle => PropertyId.NotSupportedByFramework;
        public PropertyId Shape => PropertyId.NotSupportedByFramework;
        public PropertyId StyleId => PropertyId.NotSupportedByFramework;
        public PropertyId StyleName => PropertyId.NotSupportedByFramework;
    }

    public class TextEditPatternEventIdIds : TextPatternEventIds, ITextEditPatternEventIds
    {
        public EventId ConversionTargetChangedEvent => EventId.NotSupportedByFramework;
        public EventId TextChangedEvent2 => EventId.NotSupportedByFramework;
    }

    public class Transform2PatternPropertyIds : TransformPatternPropertyIds, ITransform2PatternPropertyIds
    {
        public PropertyId CanZoom => PropertyId.NotSupportedByFramework;
        public PropertyId ZoomLevel => PropertyId.NotSupportedByFramework;
        public PropertyId ZoomMaximum => PropertyId.NotSupportedByFramework;
        public PropertyId ZoomMinimum => PropertyId.NotSupportedByFramework;
    }
}
