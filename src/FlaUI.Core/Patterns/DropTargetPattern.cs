using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class DropTargetPattern : PatternBaseWithInformation<IUIAutomationDropTargetPattern, DropTargetPatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_DropTargetPatternId, "DropTarget");
        public static readonly AutomationProperty DropTargetEffectProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DropTargetDropTargetEffectPropertyId, "DropTargetEffect");
        public static readonly AutomationProperty DropTargetEffectsProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DropTargetDropTargetEffectsPropertyId, "DropTargetEffects");
        public static readonly AutomationEvent DragEnterEvent = AutomationEvent.Register(UIA_EventIds.UIA_DropTarget_DragEnterEventId, "DragEnter");
        public static readonly AutomationEvent DragLeaveEvent = AutomationEvent.Register(UIA_EventIds.UIA_DropTarget_DragLeaveEventId, "DragLeave");
        public static readonly AutomationEvent DragCompleteEvent = AutomationEvent.Register(UIA_EventIds.UIA_Drag_DragCompleteEventId, "DragComplete");

        internal DropTargetPattern(AutomationElement automationElement, IUIAutomationDropTargetPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new DropTargetPatternInformation(element, cached))
        {
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
