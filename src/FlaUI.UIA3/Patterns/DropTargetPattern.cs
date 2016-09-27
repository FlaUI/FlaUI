﻿using FlaUI.Core;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class DropTargetPattern : PatternBaseWithInformation<DropTargetPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_DropTargetPatternId, "DropTarget");
        public static readonly PropertyId DropTargetEffectProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DropTargetDropTargetEffectPropertyId, "DropTargetEffect");
        public static readonly PropertyId DropTargetEffectsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DropTargetDropTargetEffectsPropertyId, "DropTargetEffects");
        public static readonly EventId DragEnterEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_DropTarget_DragEnterEventId, "DragEnter");
        public static readonly EventId DragLeaveEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_DropTarget_DragLeaveEventId, "DragLeave");
        public static readonly EventId DragCompleteEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Drag_DragCompleteEventId, "DragComplete");

        internal DropTargetPattern(Element automationElement, UIA.IUIAutomationDropTargetPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new DropTargetPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationDropTargetPattern NativePattern
        {
            get { return (UIA.IUIAutomationDropTargetPattern)base.NativePattern; }
        }
    }

    public class DropTargetPatternInformation : InformationBase
    {
        public DropTargetPatternInformation(Element automationElement, bool cached)
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
