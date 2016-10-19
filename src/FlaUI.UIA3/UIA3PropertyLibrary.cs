using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Patterns;

namespace FlaUI.UIA3
{
    public class UIA3PropertyLibrary : IPropertyLibray
    {
        public UIA3PropertyLibrary()
        {
            Element = new UIA3AutomationElementProperties();
            AnnotationPattern = new AnnotationPatternProperties();
            DragPattern = new DragPatternProperties();
            LegacyIAccessiblePattern = new LegacyIAccessiblePatternProperties();
            RangeValuePattern = new RangeValuePatternProperties();
            SelectionItemPattern = new SelectionItemPatternProperties();
            SelectionPattern = new SelectionPatternProperties();
            StylesPattern = new StylesPatternProperties();
            TableItemPattern = new TableItemPatternProperties();
            ValuePattern = new ValuePatternProperties();
            WindowPattern = new WindowPatternProperties();
        }

        public IAutomationElementProperties Element { get; }
        public IAnnotationPatternProperties AnnotationPattern { get; }
        public IDragPatternProperties DragPattern { get; }
        public ILegacyIAccessiblePatternProperties LegacyIAccessiblePattern { get; }
        public IRangeValuePatternProperties RangeValuePattern { get; }
        public ISelectionItemPatternProperties SelectionItemPattern { get; }
        public ISelectionPatternProperties SelectionPattern { get; }
        public IStylesPatternProperties StylesPattern { get; }
        public ITableItemPatternProperties TableItemPattern { get; }
        public IValuePatternProperties ValuePattern { get; }
        public IWindowPatternProperties WindowPattern { get; }
    }
}
