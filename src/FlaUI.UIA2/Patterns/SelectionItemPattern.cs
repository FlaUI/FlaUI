using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Converters;
using FlaUI.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class SelectionItemPattern : SelectionItemPatternBase<UIA.SelectionItemPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.Pattern.Id, "SelectionItem", AutomationObjectIds.IsSelectionItemPatternAvailableProperty);
        public static readonly PropertyId IsSelectedProperty = PropertyId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.IsSelectedProperty.Id, "IsSelected");
        public static readonly PropertyId SelectionContainerProperty = PropertyId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.SelectionContainerProperty.Id, "SelectionContainer").SetConverter(AutomationElementConverter.NativeToManaged);
        public static readonly EventId ElementAddedToSelectionEvent = EventId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.ElementAddedToSelectionEvent.Id, "ElementAddedToSelection");
        public static readonly EventId ElementRemovedFromSelectionEvent = EventId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.ElementRemovedFromSelectionEvent.Id, "ElementRemovedFromSelection");
        public static readonly EventId ElementSelectedEvent = EventId.Register(AutomationType.UIA2, UIA.SelectionItemPattern.ElementSelectedEvent.Id, "ElementSelected");

        public SelectionItemPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.SelectionItemPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override void AddToSelection()
        {
            NativePattern.AddToSelection();
        }

        public override void RemoveFromSelection()
        {
            NativePattern.RemoveFromSelection();
        }

        public override void Select()
        {
            NativePattern.Select();
        }
    }

    public class SelectionItemPatternProperties : ISelectionItemPatternProperties
    {
        public PropertyId IsSelected => SelectionItemPattern.IsSelectedProperty;

        public PropertyId SelectionContainer => SelectionItemPattern.SelectionContainerProperty;
    }

    public class SelectionItemPatternEvents : ISelectionItemPatternEvents
    {
        public EventId ElementAddedToSelectionEvent => SelectionItemPattern.ElementAddedToSelectionEvent;

        public EventId ElementRemovedFromSelectionEvent => SelectionItemPattern.ElementRemovedFromSelectionEvent;

        public EventId ElementSelectedEvent => SelectionItemPattern.ElementSelectedEvent;
    }
}
