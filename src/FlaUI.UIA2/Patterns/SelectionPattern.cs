using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Tools;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class SelectionPattern : PatternBaseWithInformation<UIA.SelectionPattern, SelectionPatternInformation>, ISelectionPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.SelectionPattern.Pattern.Id, "Selection");
        public static readonly PropertyId CanSelectMultipleProperty = PropertyId.Register(AutomationType.UIA2, UIA.SelectionPattern.CanSelectMultipleProperty.Id, "CanSelectMultiple");
        public static readonly PropertyId IsSelectionRequiredProperty = PropertyId.Register(AutomationType.UIA2, UIA.SelectionPattern.IsSelectionRequiredProperty.Id, "IsSelectionRequired");
        public static readonly PropertyId SelectionProperty = PropertyId.Register(AutomationType.UIA2, UIA.SelectionPattern.SelectionProperty.Id, "Selection");
        public static readonly EventId InvalidatedEvent = EventId.Register(AutomationType.UIA2, UIA.SelectionPattern.InvalidatedEvent.Id, "Invalidated");

        public SelectionPattern(BasicAutomationElementBase basicAutomationElement, UIA.SelectionPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Properties = new SelectionPatternProperties();
            Events = new SelectionPatternEvents();
        }

        ISelectionPatternInformation IPatternWithInformation<ISelectionPatternInformation>.Cached => Cached;

        ISelectionPatternInformation IPatternWithInformation<ISelectionPatternInformation>.Current => Current;

        public ISelectionPatternProperties Properties { get; }
        public ISelectionPatternEvents Events { get; }

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
                var nativeElement = Get<UIA.AutomationElementCollection>(SelectionPattern.SelectionProperty);
                return NativeValueConverter.NativeArrayToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeElement);
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
