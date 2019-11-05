using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.Core
{
    /// <summary>
    /// Interface for a property library.
    /// </summary>
    public interface IPropertyLibrary
    {
#pragma warning disable 1591
        IAutomationElementPatternAvailabilityPropertyIds PatternAvailability { get; }
        IAutomationElementPropertyIds Element { get; }
        IAnnotationPatternPropertyIds Annotation { get; }
        IDockPatternPropertyIds Dock { get; }
        IDragPatternPropertyIds Drag { get; }
        IDropTargetPatternPropertyIds DropTarget { get; }
        IExpandCollapsePatternPropertyIds ExpandCollapse { get; }
        IGridItemPatternPropertyIds GridItem { get; }
        IGridPatternPropertyIds Grid { get; }
        ILegacyIAccessiblePatternPropertyIds LegacyIAccessible { get; }
        IMultipleViewPatternPropertyIds MultipleView { get; }
        IRangeValuePatternPropertyIds RangeValue { get; }
        IScrollPatternPropertyIds Scroll { get; }
        ISelection2PatternPropertyIds Selection2 { get; }
        ISelectionItemPatternPropertyIds SelectionItem { get; }
        ISelectionPatternPropertyIds Selection { get; }
        ISpreadsheetItemPatternPropertyIds SpreadsheetItem { get; }
        IStylesPatternPropertyIds Styles { get; }
        ITableItemPatternPropertyIds TableItem { get; }
        ITablePatternPropertyIds Table { get; }
        ITogglePatternPropertyIds Toggle { get; }
        ITransform2PatternPropertyIds Transform2 { get; }
        ITransformPatternPropertyIds Transform { get; }
        IValuePatternPropertyIds Value { get; }
        IWindowPatternPropertyIds Window { get; }
#pragma warning restore 1591
    }
}
