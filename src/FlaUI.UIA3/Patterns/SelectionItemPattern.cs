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

        public bool IsSelected => Get<bool>(SelectionItemPattern.IsSelectedProperty);

        public AutomationElement SelectionContainer
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
