using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Patterns;

namespace FlaUI.UIA2
{
    public class UIA2PropertyLibrary : IPropertyLibray
    {
        public UIA2PropertyLibrary()
        {
            Element = new UIA2AutomationElementProperties();
            RangeValuePattern = new RangeValuePatternProperties();
            SelectionItemPattern = new SelectionItemPatternProperties();
            SelectionPattern = new SelectionPatternProperties();
            TableItemPattern = new TableItemPatternProperties();
            ValuePattern = new ValuePatternProperties();
            WindowPattern = new WindowPatternProperties();
        }

        public IAutomationElementProperties Element { get; }
        public IAnnotationPatternProperties AnnotationPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public IDragPatternProperties DragPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public ILegacyIAccessiblePatternProperties LegacyIAccessiblePattern { get { throw new NotSupportedByUIA2Exception(); } }
        public IRangeValuePatternProperties RangeValuePattern { get; }
        public ISelectionItemPatternProperties SelectionItemPattern { get; }
        public ISelectionPatternProperties SelectionPattern { get; }
        public IStylesPatternProperties StylesPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public ITableItemPatternProperties TableItemPattern { get; }
        public IValuePatternProperties ValuePattern { get; }
        public IWindowPatternProperties WindowPattern { get; }
    }
}
