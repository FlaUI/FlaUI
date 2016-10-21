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
            Dock = new DockPatternProperties();
            ExpandCollapse = new ExpandCollapsePatternProperties();
            GridItem = new GridItemPatternProperties();
            Grid = new GridPatternProperties();
            MultipleView = new MultipleViewPatternProperties();
            RangeValue = new RangeValuePatternProperties();
            Scroll = new ScrollPatternProperties();
            SelectionItem = new SelectionItemPatternProperties();
            Selection = new SelectionPatternProperties();
            TableItem = new TableItemPatternProperties();
            Table = new TablePatternProperties();
            Toggle = new TogglePatternProperties();
            Transform = new TransformPatternProperties();
            Value = new ValuePatternProperties();
            Window = new WindowPatternProperties();
        }

        public IAutomationElementProperties Element { get; }
        public IAnnotationPatternProperties Annotation { get { throw new NotSupportedByUIA2Exception(); } }
        public IDockPatternProperties Dock { get; }
        public IDragPatternProperties Drag { get { throw new NotSupportedByUIA2Exception(); } }
        public IDropTargetPatternProperties DropTarget { get { throw new NotSupportedByUIA2Exception(); } }
        public IExpandCollapsePatternProperties ExpandCollapse { get; }
        public IGridItemPatternProperties GridItem { get; }
        public IGridPatternProperties Grid { get; }
        public ILegacyIAccessiblePatternProperties LegacyIAccessible { get { throw new NotSupportedByUIA2Exception(); } }
        public IMultipleViewPatternProperties MultipleView { get; }
        public IRangeValuePatternProperties RangeValue { get; }
        public IScrollPatternProperties Scroll { get; }
        public ISelectionItemPatternProperties SelectionItem { get; }
        public ISelectionPatternProperties Selection { get; }
        public ISpreadsheetItemPatternProperties SpreadsheetItem { get { throw new NotSupportedByUIA2Exception(); } }
        public IStylesPatternProperties Styles { get { throw new NotSupportedByUIA2Exception(); } }
        public ITableItemPatternProperties TableItem { get; }
        public ITablePatternProperties Table { get; }
        public ITogglePatternProperties Toggle { get; }
        public ITransform2PatternProperties Transform2 { get { throw new NotSupportedByUIA2Exception(); } }
        public ITransformPatternProperties Transform { get; }
        public IValuePatternProperties Value { get; }
        public IWindowPatternProperties Window { get; }
    }
}
