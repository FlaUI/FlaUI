using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.Core
{
    public interface IPropertyLibrary
    {
        IAutomationElementPatternAvailabilityPropertyIds PatternAvailability { get; }
        IAutomationElementPropertyIds Element { get; }
        IAnnotationPatternProperties Annotation { get; }
        IDockPatternProperties Dock { get; }
        IDragPatternPropertyIds Drag { get; }
        IDropTargetPatternPropertyIds DropTarget { get; }
        IExpandCollapsePatternProperties ExpandCollapse { get; }
        IGridItemPatternProperties GridItem { get; }
        IGridPatternProperties Grid { get; }
        ILegacyIAccessiblePatternProperties LegacyIAccessible { get; }
        IMultipleViewPatternProperties MultipleView { get; }
        IRangeValuePatternProperties RangeValue { get; }
        IScrollPatternProperties Scroll { get; }
        ISelection2PatternPropertyIdIds Selection2 { get; }
        ISelectionItemPatternPropertyIds SelectionItem { get; }
        ISelectionPatternPropertyIds Selection { get; }
        ISpreadsheetItemPatternProperties SpreadsheetItem { get; }
        IStylesPatternProperties Styles { get; }
        ITableItemPatternProperties TableItem { get; }
        ITablePatternProperties Table { get; }
        ITogglePatternProperties Toggle { get; }
        ITransform2PatternProperties Transform2 { get; }
        ITransformPatternProperties Transform { get; }
        IValuePatternProperties Value { get; }
        IWindowPatternPropertyIds Window { get; }
    }
}
