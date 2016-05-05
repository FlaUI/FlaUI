using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class DragPattern : PatternBaseWithInformation<IUIAutomationDragPattern, DragPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_DragPatternId, "Drag");
        public static readonly PropertyId DropEffectProperty = PropertyId.Register(UIA_PropertyIds.UIA_DragDropEffectPropertyId, "DropEffect");
        public static readonly PropertyId DropEffectsProperty = PropertyId.Register(UIA_PropertyIds.UIA_DragDropEffectsPropertyId, "DropEffects");
        public static readonly PropertyId IsGrabbedProperty = PropertyId.Register(UIA_PropertyIds.UIA_DragIsGrabbedPropertyId, "IsGrabbed");
        public static readonly PropertyId GrabbedItemsProperty = PropertyId.Register(UIA_PropertyIds.UIA_DragGrabbedItemsPropertyId, " GrabbedItems");
        public static readonly EventId DragCancelEvent = EventId.Register(UIA_EventIds.UIA_Drag_DragCancelEventId, "DragCancel");
        public static readonly EventId DragCompleteEvent = EventId.Register(UIA_EventIds.UIA_Drag_DragCompleteEventId, "DragComplete");
        public static readonly EventId DragStartEvent = EventId.Register(UIA_EventIds.UIA_Drag_DragStartEventId, "DragStart");

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
