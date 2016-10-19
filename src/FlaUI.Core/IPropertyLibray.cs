using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.Core
{
    public interface IPropertyLibray
    {
        IAutomationElementProperties Element { get; }
        IAnnotationPatternProperties AnnotationPattern { get; }
        IDragPatternProperties DragPattern { get; }
        ILegacyIAccessiblePatternProperties LegacyIAccessiblePattern { get; }
        IRangeValuePatternProperties RangeValuePattern { get; }
        ISelectionItemPatternProperties SelectionItemPattern { get; }
        ISelectionPatternProperties SelectionPattern { get; }
        IStylesPatternProperties StylesPattern { get; }
        ITableItemPatternProperties TableItemPattern { get; }
        IValuePatternProperties ValuePattern { get; }
        IWindowPatternProperties WindowPattern { get; }
    }
}
