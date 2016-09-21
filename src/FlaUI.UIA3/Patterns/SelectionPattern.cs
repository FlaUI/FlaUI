using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SelectionPattern : PatternBaseWithInformation<SelectionPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_SelectionPatternId, "Selection");
        public static readonly PropertyId CanSelectMultipleProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_SelectionCanSelectMultiplePropertyId, "CanSelectMultiple");
        public static readonly PropertyId IsSelectionRequiredProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_SelectionIsSelectionRequiredPropertyId, "IsSelectionRequired");
        public static readonly PropertyId SelectionProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_SelectionSelectionPropertyId, "Selection");
        public static readonly EventId InvalidatedEvent = EventId.Register(UIA.UIA_EventIds.UIA_Selection_InvalidatedEventId, "Invalidated");

        internal SelectionPattern(Element automationElement, UIA.IUIAutomationSelectionPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new SelectionPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationSelectionPattern NativePattern
        {
            get { return (UIA.IUIAutomationSelectionPattern)base.NativePattern; }
        }
    }

    public class SelectionPatternInformation : InformationBase
    {
        public SelectionPatternInformation(Element automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public bool CanSelectMultiple
        {
            get { return Get<bool>(SelectionPattern.CanSelectMultipleProperty); }
        }

        public bool IsSelectionRequired
        {
            get { return Get<bool>(SelectionPattern.IsSelectionRequiredProperty); }
        }

        public Element[] Selection
        {
            get { return NativeElementArrayToElements(SelectionPattern.SelectionProperty); }
        }
    }
}
