using FlaUI.Core;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class DragPattern : PatternBaseWithInformation<DragPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_DragPatternId, "Drag");
        public static readonly PropertyId DropEffectProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_DragDropEffectPropertyId, "DropEffect");
        public static readonly PropertyId DropEffectsProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_DragDropEffectsPropertyId, "DropEffects");
        public static readonly PropertyId IsGrabbedProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_DragIsGrabbedPropertyId, "IsGrabbed");
        public static readonly PropertyId GrabbedItemsProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_DragGrabbedItemsPropertyId, " GrabbedItems");
        public static readonly EventId DragCancelEvent = EventId.Register(UIA.UIA_EventIds.UIA_Drag_DragCancelEventId, "DragCancel");
        public static readonly EventId DragCompleteEvent = EventId.Register(UIA.UIA_EventIds.UIA_Drag_DragCompleteEventId, "DragComplete");
        public static readonly EventId DragStartEvent = EventId.Register(UIA.UIA_EventIds.UIA_Drag_DragStartEventId, "DragStart");

        internal DragPattern(Element automationElement, UIA.IUIAutomationDragPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new DragPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationDragPattern NativePattern
        {
            get { return (UIA.IUIAutomationDragPattern)base.NativePattern; }
        }
    }

    public class DragPatternInformation : InformationBase
    {
        public DragPatternInformation(Element automationElement, bool cached)
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

        public Element[] GrabbedItems
        {
            get { return NativeElementArrayToElements(DragPattern.GrabbedItemsProperty); }
        }
    }
}
