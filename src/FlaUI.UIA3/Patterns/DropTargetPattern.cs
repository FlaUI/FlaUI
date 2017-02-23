using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class DropTargetPattern : PatternBase<UIA.IUIAutomationDropTargetPattern>, IDropTargetPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_DropTargetPatternId, "DropTarget", AutomationObjectIds.IsDropTargetPatternAvailableProperty);
        public static readonly PropertyId DropTargetEffectProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DropTargetDropTargetEffectPropertyId, "DropTargetEffect");
        public static readonly PropertyId DropTargetEffectsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DropTargetDropTargetEffectsPropertyId, "DropTargetEffects");
        public static readonly EventId DragEnterEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_DropTarget_DragEnterEventId, "DragEnter");
        public static readonly EventId DragLeaveEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_DropTarget_DragLeaveEventId, "DragLeave");
        public static readonly EventId DragCompleteEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Drag_DragCompleteEventId, "DragComplete");

        public DropTargetPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationDropTargetPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IDropTargetPatternProperties Properties => Automation.PropertyLibrary.DropTarget;

        public IDropTargetPatternEvents Events => Automation.EventLibrary.DropTarget;

        public string DropTargetEffect => Get<string>(DropTargetEffectProperty);

        public string[] DropTargetEffects => Get<string[]>(DropTargetEffectsProperty);
    }

    public class DropTargetPatternProperties : IDropTargetPatternProperties
    {
        public PropertyId DropTargetEffectProperty => DropTargetPattern.DropTargetEffectProperty;
        public PropertyId DropTargetEffectsProperty => DropTargetPattern.DropTargetEffectsProperty;
    }

    public class DropTargetPatternEvents : IDropTargetPatternEvents
    {
        public EventId DragEnterEvent => DropTargetPattern.DragEnterEvent;
        public EventId DragLeaveEvent => DropTargetPattern.DragLeaveEvent;
        public EventId DragCompleteEvent => DropTargetPattern.DragCompleteEvent;
    }
}
