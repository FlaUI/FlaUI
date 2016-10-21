using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Converters;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class SelectionItemPattern : PatternBaseWithInformation<UIA.SelectionItemPattern, SelectionItemPatternInformation>, ISelectionItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.Pattern.Id, "SelectionItem");
        public static readonly PropertyId IsSelectedProperty = PropertyId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.IsSelectedProperty.Id, "IsSelected");
        public static readonly PropertyId SelectionContainerProperty = PropertyId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.SelectionContainerProperty.Id, "SelectionContainer");
        public static readonly EventId ElementAddedToSelectionEvent = EventId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.ElementAddedToSelectionEvent.Id, "ElementAddedToSelection");
        public static readonly EventId ElementRemovedFromSelectionEvent = EventId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.ElementRemovedFromSelectionEvent.Id, "ElementRemovedFromSelection");
        public static readonly EventId ElementSelectedEvent = EventId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.ElementSelectedEvent.Id, "ElementSelected");

        public SelectionItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.SelectionItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        ISelectionItemPatternInformation IPatternWithInformation<ISelectionItemPatternInformation>.Cached => Cached;

        ISelectionItemPatternInformation IPatternWithInformation<ISelectionItemPatternInformation>.Current => Current;

        public ISelectionItemPatternProperties Properties => Automation.PropertyLibrary.SelectionItem;

        public ISelectionItemPatternEvents Events => Automation.EventLibrary.SelectionItem;

        protected override SelectionItemPatternInformation CreateInformation(bool cached)
        {
            return new SelectionItemPatternInformation(BasicAutomationElement, cached);
        }

        public void AddToSelection()
        {
            NativePattern.AddToSelection();
        }

        public void RemoveFromSelection()
        {
            NativePattern.RemoveFromSelection();
        }

        public void Select()
        {
            NativePattern.Select();
        }
    }

    public class SelectionItemPatternInformation : InformationBase, ISelectionItemPatternInformation
    {
        public SelectionItemPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public bool IsSelected => Get<bool>(SelectionItemPattern.IsSelectedProperty);

        public AutomationElement SelectionContainer
        {
            get
            {
                var nativeElement = Get<UIA.AutomationElement>(SelectionItemPattern.SelectionContainerProperty);
                return ValueConverter.NativeToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }
    }

    public class SelectionItemPatternProperties : ISelectionItemPatternProperties
    {
        public PropertyId IsSelectedProperty => SelectionItemPattern.IsSelectedProperty;

        public PropertyId SelectionContainerProperty => SelectionItemPattern.SelectionContainerProperty;
    }

    public class SelectionItemPatternEvents : ISelectionItemPatternEvents
    {
        public EventId ElementAddedToSelectionEvent => SelectionItemPattern.ElementAddedToSelectionEvent;

        public EventId ElementRemovedFromSelectionEvent => SelectionItemPattern.ElementRemovedFromSelectionEvent;

        public EventId ElementSelectedEvent => SelectionItemPattern.ElementSelectedEvent;
    }
}
