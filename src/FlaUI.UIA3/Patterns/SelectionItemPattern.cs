using FlaUI.Core;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class SelectionItemPattern : PatternBaseWithInformation<SelectionItemPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SelectionItemPatternId, "SelectionItem");
        public static readonly PropertyId IsSelectedProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SelectionItemIsSelectedPropertyId, "IsSelected");
        public static readonly PropertyId SelectionContainerProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SelectionItemSelectionContainerPropertyId, "SelectionContainer");
        public static readonly EventId ElementAddedToSelectionEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_SelectionItem_ElementAddedToSelectionEventId, "ElementAddedToSelection");
        public static readonly EventId ElementRemovedFromSelectionEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_SelectionItem_ElementRemovedFromSelectionEventId, "ElementRemovedFromSelection");
        public static readonly EventId ElementSelectedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_SelectionItem_ElementSelectedEventId, "ElementSelected");

        internal SelectionItemPattern(Element automationElement, UIA.IUIAutomationSelectionItemPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new SelectionItemPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationSelectionItemPattern NativePattern
        {
            get { return (UIA.IUIAutomationSelectionItemPattern)base.NativePattern; }
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

    public class SelectionItemPatternInformation : InformationBase
    {
        public SelectionItemPatternInformation(Element automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public bool IsSelected
        {
            get { return Get<bool>(SelectionItemPattern.IsSelectedProperty); }
        }

        public Element SelectionContainer
        {
            get { return NativeElementToElement(SelectionItemPattern.SelectionContainerProperty); }
        }
    }
}
