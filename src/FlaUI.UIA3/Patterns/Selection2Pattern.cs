using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Patterns
{
    public class Selection2Pattern : Selection2PatternBase<UIA.IUIAutomationSelectionPattern2>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SelectionPattern2Id, "Selection2", AutomationObjectIds.IsSelectionPattern2AvailableProperty);
        public static readonly PropertyId CurrentSelectedItemProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Selection2CurrentSelectedItemPropertyId, "CurrentSelectedItem");
        public static readonly PropertyId FirstSelectedItemProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Selection2FirstSelectedItemPropertyId, "FirstSelectedItem");
        public static readonly PropertyId ItemCountProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Selection2ItemCountPropertyId, "ItemCount");
        public static readonly PropertyId LastSelectedItemProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Selection2LastSelectedItemPropertyId, "LastSelectedItem");

        private readonly SelectionPattern _selectionPattern;

        public Selection2Pattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationSelectionPattern2 nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
            _selectionPattern = new SelectionPattern(frameworkAutomationElement, nativePattern);
        }
    }

    public class Selection2PatternProperties : SelectionPatternProperties, ISelection2PatternProperties
    {
        public PropertyId CurrentSelectedItem => Selection2Pattern.CurrentSelectedItemProperty;
        public PropertyId FirstSelectedItem => Selection2Pattern.FirstSelectedItemProperty;
        public PropertyId ItemCount => Selection2Pattern.ItemCountProperty;
        public PropertyId LastSelectedItem => Selection2Pattern.LastSelectedItemProperty;
    }
}
