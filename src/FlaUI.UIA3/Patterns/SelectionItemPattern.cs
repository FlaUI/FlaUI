using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SelectionItemPattern : PatternBaseWithInformation<UIA.IUIAutomationSelectionItemPattern, SelectionItemPatternInformation>, ISelectionItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SelectionItemPatternId, "SelectionItem");
        public static readonly PropertyId IsSelectedProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SelectionItemIsSelectedPropertyId, "IsSelected");
        public static readonly PropertyId SelectionContainerProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SelectionItemSelectionContainerPropertyId, "SelectionContainer");
        public static readonly EventId ElementAddedToSelectionEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_SelectionItem_ElementAddedToSelectionEventId, "ElementAddedToSelection");
        public static readonly EventId ElementRemovedFromSelectionEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_SelectionItem_ElementRemovedFromSelectionEventId, "ElementRemovedFromSelection");
        public static readonly EventId ElementSelectedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_SelectionItem_ElementSelectedEventId, "ElementSelected");

        public SelectionItemPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationSelectionItemPattern nativePattern) : base(basicAutomationElement, nativePattern)
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
            return new SelectionItemPatternInformation(BasicAutomationElement, cached);
        }

        public void AddToSelection()
        {
            ComCallWrapper.Call(() => NativePattern.AddToSelection());
        }

        public void RemoveFromSelection()
        {
            ComCallWrapper.Call(() => NativePattern.RemoveFromSelection());
        }

        public void Select()
        {
            ComCallWrapper.Call(() => NativePattern.Select());
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
                var nativeElement = Get<UIA.IUIAutomationElement>(SelectionItemPattern.SelectionContainerProperty);
                return ValueConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
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
