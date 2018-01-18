using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Patterns;

namespace FlaUI.UIA3
{
    public class UIA3PropertyLibrary : IPropertyLibrary
    {
        public UIA3PropertyLibrary()
        {
            PatternAvailability = new UIA3AutomationElementPatternAvailabilityPropertyIds();
            Element = new UIA3AutomationElementPropertyIds();
            Annotation = new AnnotationPatternProperties();
            Dock = new DockPatternProperties();
            Drag = new DragPatternPropertyIds();
            DropTarget = new DropTargetPatternPropertyIds();
            ExpandCollapse = new ExpandCollapsePatternProperties();
            GridItem = new GridItemPatternProperties();
            Grid = new GridPatternProperties();
            LegacyIAccessible = new LegacyIAccessiblePatternProperties();
            MultipleView = new MultipleViewPatternProperties();
            RangeValue = new RangeValuePatternProperties();
            Scroll = new ScrollPatternProperties();
            SelectionItem = new SelectionItemPatternPropertyIds();
            Selection = new SelectionPatternPropertyIds();
            Selection2 = new Selection2PatternPropertyIdIds();
            SpreadsheetItem = new SpreadsheetItemPatternProperties();
            Styles = new StylesPatternProperties();
            TableItem = new TableItemPatternProperties();
            Table = new TablePatternProperties();
            Toggle = new TogglePatternProperties();
            Transform2 = new Transform2PatternProperties();
            Transform = new TransformPatternProperties();
            Value = new ValuePatternProperties();
            Window = new WindowPatternPropertyIds();
        }

        public IAutomationElementPatternAvailabilityPropertyIds PatternAvailability { get; }
        public IAutomationElementPropertyIds Element { get; }
        public IAnnotationPatternProperties Annotation { get; }
        public IDockPatternProperties Dock { get; }
        public IDragPatternPropertyIds Drag { get; }
        public IDropTargetPatternPropertyIds DropTarget { get; }
        public IExpandCollapsePatternProperties ExpandCollapse { get; }
        public IGridItemPatternProperties GridItem { get; }
        public IGridPatternProperties Grid { get; }
        public ILegacyIAccessiblePatternProperties LegacyIAccessible { get; }
        public IMultipleViewPatternProperties MultipleView { get; }
        public IRangeValuePatternProperties RangeValue { get; }
        public IScrollPatternProperties Scroll { get; }
        public ISelectionItemPatternPropertyIds SelectionItem { get; }
        public ISelectionPatternPropertyIds Selection { get; }
        public ISelection2PatternPropertyIdIds Selection2 { get; }
        public ISpreadsheetItemPatternProperties SpreadsheetItem { get; }
        public IStylesPatternProperties Styles { get; }
        public ITableItemPatternProperties TableItem { get; }
        public ITablePatternProperties Table { get; }
        public ITogglePatternProperties Toggle { get; }
        public ITransform2PatternProperties Transform2 { get; }
        public ITransformPatternProperties Transform { get; }
        public IValuePatternProperties Value { get; }
        public IWindowPatternPropertyIds Window { get; }
    }
}
