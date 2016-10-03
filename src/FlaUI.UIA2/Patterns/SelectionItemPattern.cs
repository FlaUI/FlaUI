using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Tools;
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

        public SelectionItemPattern(AutomationObjectBase automationObject, UIA.SelectionItemPattern nativePattern) : base(automationObject, nativePattern)
        {
            Properties = new SelectionItemPatternProperties();
            Events = new SelectionItemPatternEvents();
        }

        ISelectionItemPatternInformation IPatternWithInformation<ISelectionItemPatternInformation>.Cached => Cached;

        ISelectionItemPatternInformation IPatternWithInformation<ISelectionItemPatternInformation>.Current => Current;

        public ISelectionItemPatternProperties Properties { get; }

        public ISelectionItemPatternEvents Events { get; }

        protected override SelectionItemPatternInformation CreateInformation(bool cached)
        {
            return new SelectionItemPatternInformation(AutomationObject, cached);
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

    public class SelectionItemPatternInformation : ElementInformationBase, ISelectionItemPatternInformation
    {
        public SelectionItemPatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool IsSelected => Get<bool>(SelectionItemPattern.IsSelectedProperty);

        public AutomationElement SelectionContainer
        {
            get
            {
                var nativeElement = Get<UIA.AutomationElement>(SelectionItemPattern.SelectionContainerProperty);
                return NativeValueConverter.NativeToManaged((UIA2Automation)AutomationObject.Automation, nativeElement);
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
