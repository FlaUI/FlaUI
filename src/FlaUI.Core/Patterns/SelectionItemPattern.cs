using FlaUI.Core.Elements;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class SelectionItemPattern : PatternBaseWithInformation<IUIAutomationSelectionItemPattern, SelectionItemPatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_SelectionItemPatternId, "SelectionItem");
        public static readonly AutomationProperty IsSelectedProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_SelectionItemIsSelectedPropertyId, "IsSelected");
        public static readonly AutomationProperty SelectionContainerProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_SelectionItemSelectionContainerPropertyId, "SelectionContainer");
        public static readonly AutomationEvent ElementAddedToSelectionEvent = AutomationEvent.Register(UIA_EventIds.UIA_SelectionItem_ElementAddedToSelectionEventId, "ElementAddedToSelection");
        public static readonly AutomationEvent ElementRemovedFromSelectionEvent = AutomationEvent.Register(UIA_EventIds.UIA_SelectionItem_ElementRemovedFromSelectionEventId, "ElementRemovedFromSelection");
        public static readonly AutomationEvent ElementSelectedEvent = AutomationEvent.Register(UIA_EventIds.UIA_SelectionItem_ElementSelectedEventId, "ElementSelected");

        internal SelectionItemPattern(AutomationElement automationElement, IUIAutomationSelectionItemPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new SelectionItemPatternInformation(element, cached))
        {
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
        public SelectionItemPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public bool IsSelected
        {
            get { return Get<bool>(SelectionItemPattern.IsSelectedProperty); }
        }

        public AutomationElement SelectionContainer
        {
            get { return NativeElementToElement(SelectionItemPattern.SelectionContainerProperty); }
        }
    }
}
