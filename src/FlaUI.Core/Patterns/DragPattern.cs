using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class DragPattern : PatternBaseWithInformation<IUIAutomationDragPattern, DragPatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_DragPatternId, "Drag");
        public static readonly AutomationProperty DropEffectProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DragDropEffectPropertyId, "DropEffect");
        public static readonly AutomationProperty DropEffectsProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DragDropEffectsPropertyId, "DropEffects");
        public static readonly AutomationProperty IsGrabbedProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DragIsGrabbedPropertyId, "IsGrabbed");
        public static readonly AutomationProperty GrabbedItemsProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DragGrabbedItemsPropertyId, " GrabbedItems");
        public static readonly AutomationEvent DragCancelEvent = AutomationEvent.Register(UIA_EventIds.UIA_Drag_DragCancelEventId, "DragCancel");
        public static readonly AutomationEvent DragCompleteEvent = AutomationEvent.Register(UIA_EventIds.UIA_Drag_DragCompleteEventId, "DragComplete");
        public static readonly AutomationEvent DragStartEvent = AutomationEvent.Register(UIA_EventIds.UIA_Drag_DragStartEventId, "DragStart");

        internal DragPattern(AutomationElement automationElement, IUIAutomationDragPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new DragPatternInformation(element, cached))
        {
        }
    }

    public class DragPatternInformation : InformationBase
    {
        public DragPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public string DropEffect
        {
            get { return Get<string>(DragPattern.DropEffectProperty); }
        }

        public string[] DropEffects
        {
            get { return Get<string[]>(DragPattern.DropEffectsProperty); }
        }

        public bool IsGrabbed
        {
            get { return Get<bool>(DragPattern.IsGrabbedProperty); }
        }

        public AutomationElement[] GrabbedItems
        {
            get { return NativeElementArrayToElements(DragPattern.GrabbedItemsProperty); }
        }
    }
}
