using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class DragPattern : DragPatternBase<UIA.IUIAutomationDragPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_DragPatternId, "Drag", AutomationObjectIds.IsDragPatternAvailableProperty);
        public static readonly PropertyId DropEffectProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DragDropEffectPropertyId, "DropEffect");
        public static readonly PropertyId DropEffectsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DragDropEffectsPropertyId, "DropEffects");
        public static readonly PropertyId IsGrabbedProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DragIsGrabbedPropertyId, "IsGrabbed");
        public static readonly PropertyId GrabbedItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DragGrabbedItemsPropertyId, " GrabbedItems").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly EventId DragCancelEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Drag_DragCancelEventId, "DragCancel");
        public static readonly EventId DragCompleteEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Drag_DragCompleteEventId, "DragComplete");
        public static readonly EventId DragStartEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Drag_DragStartEventId, "DragStart");

        public DragPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationDragPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }
    }

    public class DragPatternProperties : IDragPatternProperties
    {
        public PropertyId DropEffectProperty => DragPattern.DropEffectProperty;
        public PropertyId DropEffectsProperty => DragPattern.DropEffectsProperty;
        public PropertyId IsGrabbedProperty => DragPattern.IsGrabbedProperty;
        public PropertyId GrabbedItemsProperty => DragPattern.GrabbedItemsProperty;
    }

    public class DragPatternEvents : IDragPatternEvents
    {
        public EventId DragCancelEvent => DragPattern.DragCancelEvent;
        public EventId DragCompleteEvent => DragPattern.DragCompleteEvent;
        public EventId DragStartEvent => DragPattern.DragStartEvent;
    }
}
