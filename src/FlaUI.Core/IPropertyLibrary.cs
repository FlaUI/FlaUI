using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.Core
{
    public interface IPropertyLibrary
    {
        IAutomationElementPatternAvailabilityProperties PatternAvailability { get; }
        IAutomationElementProperties Element { get; }
        IAnnotationPatternProperties Annotation { get; }
        IDockPatternProperties Dock { get; }
        IDragPatternProperties Drag { get; }
        IDropTargetPatternProperties DropTarget { get; }
        IExpandCollapsePatternProperties ExpandCollapse { get; }
        IGridItemPatternProperties GridItem { get; }
        IGridPatternProperties Grid { get; }
        ILegacyIAccessiblePatternProperties LegacyIAccessible { get; }
        IMultipleViewPatternProperties MultipleView { get; }
        IRangeValuePatternProperties RangeValue { get; }
        IScrollPatternProperties Scroll { get; }
        ISelection2PatternProperties Selection2 { get; }
        ISelectionItemPatternProperties SelectionItem { get; }
        ISelectionPatternProperties Selection { get; }
        ISpreadsheetItemPatternProperties SpreadsheetItem { get; }
        IStylesPatternProperties Styles { get; }
        ITableItemPatternProperties TableItem { get; }
        ITablePatternProperties Table { get; }
        ITogglePatternProperties Toggle { get; }
        ITransform2PatternProperties Transform2 { get; }
        ITransformPatternProperties Transform { get; }
        IValuePatternProperties Value { get; }
        IWindowPatternProperties Window { get; }
    }
}
