using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Tools;
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

        public SelectionItemPattern(AutomationObjectBase automationObject, UIA.IUIAutomationSelectionItemPattern nativePattern) : base(automationObject, nativePattern)
        {
            Properties = new SelectionItemPatternProperties();
            Events = new SelectionItemPatternEvents();
        }

        ISelectionItemPatternInformation IPatternWithInformation<ISelectionItemPatternInformation>.Cached
        {
            get { return Cached; }
        }

        ISelectionItemPatternInformation IPatternWithInformation<ISelectionItemPatternInformation>.Current
        {
            get { return Current; }
        }

        public ISelectionItemPatternProperties Properties { get; private set; }

        public ISelectionItemPatternEvents Events { get; private set; }

        protected override SelectionItemPatternInformation CreateInformation(bool cached)
        {
            return new SelectionItemPatternInformation(AutomationObject, cached);
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

    public class SelectionItemPatternInformation : ElementInformationBase, ISelectionItemPatternInformation
    {
        public SelectionItemPatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool IsSelected
        {
            get { return Get<bool>(SelectionItemPattern.IsSelectedProperty); }
        }

        public Element SelectionContainer
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElement>(SelectionItemPattern.SelectionContainerProperty);
                return NativeValueConverter.NativeToManaged((UIA3Automation)AutomationObject.Automation, nativeElement);
            }
        }
    }

    public class SelectionItemPatternProperties : ISelectionItemPatternProperties
    {
        public PropertyId IsSelectedProperty
        {
            get { return SelectionItemPattern.IsSelectedProperty; }
        }

        public PropertyId SelectionContainerProperty
        {
            get { return SelectionItemPattern.SelectionContainerProperty; }
        }
    }

    public class SelectionItemPatternEvents : ISelectionItemPatternEvents
    {
        public EventId ElementAddedToSelectionEvent
        {
            get { return SelectionItemPattern.ElementAddedToSelectionEvent; }
        }

        public EventId ElementRemovedFromSelectionEvent
        {
            get { return SelectionItemPattern.ElementRemovedFromSelectionEvent; }
        }

        public EventId ElementSelectedEvent
        {
            get { return SelectionItemPattern.ElementSelectedEvent; }
        }
    }
}
