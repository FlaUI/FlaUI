using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SelectionPattern : PatternBaseWithInformation<UIA.IUIAutomationSelectionPattern, SelectionPatternInformation>, ISelectionPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SelectionPatternId, "Selection");
        public static readonly PropertyId CanSelectMultipleProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SelectionCanSelectMultiplePropertyId, "CanSelectMultiple");
        public static readonly PropertyId IsSelectionRequiredProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SelectionIsSelectionRequiredPropertyId, "IsSelectionRequired");
        public static readonly PropertyId SelectionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SelectionSelectionPropertyId, "Selection");
        public static readonly EventId InvalidatedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Selection_InvalidatedEventId, "Invalidated");

        public SelectionPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationSelectionPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        ISelectionPatternInformation IPatternWithInformation<ISelectionPatternInformation>.Cached => Cached;

        ISelectionPatternInformation IPatternWithInformation<ISelectionPatternInformation>.Current => Current;

        public ISelectionPatternProperties Properties => Automation.PropertyLibrary.Selection;

        public ISelectionPatternEvents Events => Automation.EventLibrary.Selection;

        protected override SelectionPatternInformation CreateInformation(bool cached)
        {
            return new SelectionPatternInformation(BasicAutomationElement, cached);
        }
    }

    public class SelectionPatternInformation : InformationBase, ISelectionPatternInformation
    {
        public SelectionPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public bool CanSelectMultiple => Get<bool>(SelectionPattern.CanSelectMultipleProperty);

        public bool IsSelectionRequired => Get<bool>(SelectionPattern.IsSelectionRequiredProperty);

        public AutomationElement[] Selection
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(SelectionPattern.SelectionProperty);
                return ValueConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }
    }

    public class SelectionPatternProperties : ISelectionPatternProperties
    {
        public PropertyId CanSelectMultipleProperty => SelectionPattern.CanSelectMultipleProperty;
        public PropertyId IsSelectionRequiredProperty => SelectionPattern.IsSelectionRequiredProperty;
        public PropertyId SelectionProperty => SelectionPattern.SelectionProperty;
    }

    public class SelectionPatternEvents : ISelectionPatternEvents
    {
        public EventId InvalidatedEvent => SelectionPattern.InvalidatedEvent;
    }
}
