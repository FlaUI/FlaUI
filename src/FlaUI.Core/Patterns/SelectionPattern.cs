using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class SelectionPattern : PatternBaseWithInformation<IUIAutomationSelectionPattern, SelectionPatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_SelectionPatternId, "Selection");
        public static readonly AutomationProperty CanSelectMultipleProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_SelectionCanSelectMultiplePropertyId, "CanSelectMultiple");
        public static readonly AutomationProperty IsSelectionRequiredProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_SelectionIsSelectionRequiredPropertyId, "IsSelectionRequired");
        public static readonly AutomationProperty SelectionProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_SelectionSelectionPropertyId, "Selection");
        public static readonly AutomationEvent InvalidatedEvent = AutomationEvent.Register(UIA_EventIds.UIA_Selection_InvalidatedEventId, "Invalidated");

        internal SelectionPattern(AutomationElement automationElement, IUIAutomationSelectionPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new SelectionPatternInformation(element, cached))
        {
        }
    }

    public class SelectionPatternInformation : InformationBase
    {
        public SelectionPatternInformation(AutomationElement automationElement, bool cached)
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

        public AutomationElement[] Selection
        {
            get { return NativeElementArrayToElements(SelectionPattern.SelectionProperty); }
        }
    }
}
