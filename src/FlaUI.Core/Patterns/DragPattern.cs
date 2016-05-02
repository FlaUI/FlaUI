using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class DragPattern : PatternBase<IUIAutomationDragPattern>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_DragPatternId, "Drag");
        public static readonly AutomationProperty DropEffectProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DragDropEffectPropertyId, "DropEffect");
        public static readonly AutomationProperty DropEffectsProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DragDropEffectsPropertyId, "DropEffects");
        public static readonly AutomationProperty IsGrabbedProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DragIsGrabbedPropertyId, "IsGrabbed");
        public static readonly AutomationProperty GrabbedItemsProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_DragGrabbedItemsPropertyId, " GrabbedItems");
        public static readonly AutomationEvent DragCancelEvent = AutomationEvent.Register(UIA_EventIds.UIA_Drag_DragCancelEventId, "DragCancel");
        public static readonly AutomationEvent DragCompleteEvent = AutomationEvent.Register(UIA_EventIds.UIA_Drag_DragCompleteEventId, "DragComplete");
        public static readonly AutomationEvent DragStartEvent = AutomationEvent.Register(UIA_EventIds.UIA_Drag_DragStartEventId, "DragStart");

        public DragPatternInformation Cached { get; private set; }

        public DragPatternInformation Current { get; private set; }

        internal DragPattern(AutomationElement automationElement, IUIAutomationDragPattern nativePattern)
            : base(automationElement, nativePattern)
        {
            Cached = new DragPatternInformation(AutomationElement, true);
            Current = new DragPatternInformation(AutomationElement, false);
        }

        public class DragPatternInformation : InformationBase
        {
            public DragPatternInformation(AutomationElement automationElement, bool cached)
                : base(automationElement, cached)
            {
            }

            public string DropEffect
            {
                get { return AutomationElement.SafeGetPropertyValue<string>(DropEffectProperty, Cached); }
            }

            public string[] DropEffects
            {
                get { return AutomationElement.SafeGetPropertyValue<string[]>(DropEffectsProperty, Cached); }
            }

            public bool IsGrabbed
            {
                get { return AutomationElement.SafeGetPropertyValue<bool>(IsGrabbedProperty, Cached); }
            }

            public AutomationElement[] GrabbedItems
            {
                get { return NativeElementArrayToElements(GrabbedItemsProperty); }
            }
        }
    }
}
