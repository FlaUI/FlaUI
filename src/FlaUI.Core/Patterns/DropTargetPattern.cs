using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class DropTargetPattern : PatternBaseWithInformation<DropTargetPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_DropTargetPatternId, "DropTarget");
        public static readonly PropertyId DropTargetEffectProperty = PropertyId.Register(UIA_PropertyIds.UIA_DropTargetDropTargetEffectPropertyId, "DropTargetEffect");
        public static readonly PropertyId DropTargetEffectsProperty = PropertyId.Register(UIA_PropertyIds.UIA_DropTargetDropTargetEffectsPropertyId, "DropTargetEffects");
        public static readonly EventId DragEnterEvent = EventId.Register(UIA_EventIds.UIA_DropTarget_DragEnterEventId, "DragEnter");
        public static readonly EventId DragLeaveEvent = EventId.Register(UIA_EventIds.UIA_DropTarget_DragLeaveEventId, "DragLeave");
        public static readonly EventId DragCompleteEvent = EventId.Register(UIA_EventIds.UIA_Drag_DragCompleteEventId, "DragComplete");

        internal DropTargetPattern(AutomationElement automationElement, IUIAutomationDropTargetPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new DropTargetPatternInformation(element, cached))
        {
        }

        public IUIAutomationDropTargetPattern NativePattern
        {
            get { return (IUIAutomationDropTargetPattern)base.NativePattern; }
        }
    }

    public class DropTargetPatternInformation : InformationBase
    {
        public DropTargetPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public string DropTargetEffect
        {
            get { return Get<string>(DropTargetPattern.DropTargetEffectProperty); }
        }

        public string[] DropTargetEffects
        {
            get { return Get<string[]>(DropTargetPattern.DropTargetEffectsProperty); }
        }
    }
}
