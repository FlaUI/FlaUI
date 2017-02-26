using FlaUI.Core;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Patterns;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3AutomationElementPatternValues : AutomationElementPatternValuesBase
    {
        public UIA3AutomationElementPatternValues(UIA3BasicAutomationElement basicAutomationElement)
        {
            Annotation = new AutomationPattern<IAnnotationPattern, UIA.IUIAutomationAnnotationPattern>(
                () => AnnotationPattern.Pattern, basicAutomationElement, (b, p) => new AnnotationPattern(b, p));
            Dock = new AutomationPattern<IDockPattern, UIA.IUIAutomationDockPattern>(
                () => DockPattern.Pattern, basicAutomationElement, (b, p) => new DockPattern(b, p));
            Drag = new AutomationPattern<IDragPattern, UIA.IUIAutomationDragPattern>(
                () => DragPattern.Pattern, basicAutomationElement, (b, p) => new DragPattern(b, p));
            DropTarget = new AutomationPattern<IDropTargetPattern, UIA.IUIAutomationDropTargetPattern>(
                () => DropTargetPattern.Pattern, basicAutomationElement, (b, p) => new DropTargetPattern(b, p));
            ExpandCollapse = new AutomationPattern<IExpandCollapsePattern, UIA.IUIAutomationExpandCollapsePattern>(
                () => ExpandCollapsePattern.Pattern, basicAutomationElement, (b, p) => new ExpandCollapsePattern(b, p));
            GridItem = new AutomationPattern<IGridItemPattern, UIA.IUIAutomationGridItemPattern>(
                () => GridItemPattern.Pattern, basicAutomationElement, (b, p) => new GridItemPattern(b, p));
            Grid = new AutomationPattern<IGridPattern, UIA.IUIAutomationGridPattern>(
                () => GridPattern.Pattern, basicAutomationElement, (b, p) => new GridPattern(b, p));
            Invoke = new AutomationPattern<IInvokePattern, UIA.IUIAutomationInvokePattern>(
                () => InvokePattern.Pattern, basicAutomationElement, (b, p) => new InvokePattern(b, p));
            ItemContainer = new AutomationPattern<IItemContainerPattern, UIA.IUIAutomationItemContainerPattern>(
                () => ItemContainerPattern.Pattern, basicAutomationElement, (b, p) => new ItemContainerPattern(b, p));
            LegacyIAccessible = new AutomationPattern<ILegacyIAccessiblePattern, UIA.IUIAutomationLegacyIAccessiblePattern>(
                () => LegacyIAccessiblePattern.Pattern, basicAutomationElement, (b, p) => new LegacyIAccessiblePattern(b, p));
            MultipleView = new AutomationPattern<IMultipleViewPattern, UIA.IUIAutomationMultipleViewPattern>(
                () => MultipleViewPattern.Pattern, basicAutomationElement, (b, p) => new MultipleViewPattern(b, p));
            ObjectModel = new AutomationPattern<IObjectModelPattern, UIA.IUIAutomationObjectModelPattern>(
                () => ObjectModelPattern.Pattern, basicAutomationElement, (b, p) => new ObjectModelPattern(b, p));
            RangeValue = new AutomationPattern<IRangeValuePattern, UIA.IUIAutomationRangeValuePattern>(
                () => RangeValuePattern.Pattern, basicAutomationElement, (b, p) => new RangeValuePattern(b, p));
            ScrollItem = new AutomationPattern<IScrollItemPattern, UIA.IUIAutomationScrollItemPattern>(
                () => ScrollItemPattern.Pattern, basicAutomationElement, (b, p) => new ScrollItemPattern(b, p));
            Scroll = new AutomationPattern<IScrollPattern, UIA.IUIAutomationScrollPattern>(
                () => ScrollPattern.Pattern, basicAutomationElement, (b, p) => new ScrollPattern(b, p));
            SelectionItem = new AutomationPattern<ISelectionItemPattern, UIA.IUIAutomationSelectionItemPattern>(
                () => SelectionItemPattern.Pattern, basicAutomationElement, (b, p) => new SelectionItemPattern(b, p));
            Selection = new AutomationPattern<ISelectionPattern, UIA.IUIAutomationSelectionPattern>(
                () => SelectionPattern.Pattern, basicAutomationElement, (b, p) => new SelectionPattern(b, p));
            SpreadsheetItem = new AutomationPattern<ISpreadsheetItemPattern, UIA.IUIAutomationSpreadsheetItemPattern>(
                () => SpreadsheetItemPattern.Pattern, basicAutomationElement, (b, p) => new SpreadsheetItemPattern(b, p));
            Spreadsheet = new AutomationPattern<ISpreadsheetPattern, UIA.IUIAutomationSpreadsheetPattern>(
                () => SpreadsheetPattern.Pattern, basicAutomationElement, (b, p) => new SpreadsheetPattern(b, p));
            Styles = new AutomationPattern<IStylesPattern, UIA.IUIAutomationStylesPattern>(
                () => StylesPattern.Pattern, basicAutomationElement, (b, p) => new StylesPattern(b, p));
            SynchronizedInput = new AutomationPattern<ISynchronizedInputPattern, UIA.IUIAutomationSynchronizedInputPattern>(
                () => SynchronizedInputPattern.Pattern, basicAutomationElement, (b, p) => new SynchronizedInputPattern(b, p));
            TableItem = new AutomationPattern<ITableItemPattern, UIA.IUIAutomationTableItemPattern>(
                () => TableItemPattern.Pattern, basicAutomationElement, (b, p) => new TableItemPattern(b, p));
            Table = new AutomationPattern<ITablePattern, UIA.IUIAutomationTablePattern>(
                () => TablePattern.Pattern, basicAutomationElement, (b, p) => new TablePattern(b, p));
            TextChild = new AutomationPattern<ITextChildPattern, UIA.IUIAutomationTextChildPattern>(
                () => TextChildPattern.Pattern, basicAutomationElement, (b, p) => new TextChildPattern(b, p));
            TextEdit = new AutomationPattern<ITextEditPattern, UIA.IUIAutomationTextEditPattern>(
                () => TextEditPattern.Pattern, basicAutomationElement, (b, p) => new TextEditPattern(b, p));
            Text2 = new AutomationPattern<IText2Pattern, UIA.IUIAutomationTextPattern2>(
                () => Text2Pattern.Pattern, basicAutomationElement, (b, p) => new Text2Pattern(b, p));
            Text = new AutomationPattern<ITextPattern, UIA.IUIAutomationTextPattern>(
                () => TextPattern.Pattern, basicAutomationElement, (b, p) => new TextPattern(b, p));
            Toggle = new AutomationPattern<ITogglePattern, UIA.IUIAutomationTogglePattern>(
                () => TogglePattern.Pattern, basicAutomationElement, (b, p) => new TogglePattern(b, p));
            Transform2 = new AutomationPattern<ITransform2Pattern, UIA.IUIAutomationTransformPattern2>(
                () => Transform2Pattern.Pattern, basicAutomationElement, (b, p) => new Transform2Pattern(b, p));
            Transform = new AutomationPattern<ITransformPattern, UIA.IUIAutomationTransformPattern>(
                () => TransformPattern.Pattern, basicAutomationElement, (b, p) => new TransformPattern(b, p));
            Value = new AutomationPattern<IValuePattern, UIA.IUIAutomationValuePattern>(
                () => ValuePattern.Pattern, basicAutomationElement, (b, p) => new ValuePattern(b, p));
            VirtualizedItem = new AutomationPattern<IVirtualizedItemPattern, UIA.IUIAutomationVirtualizedItemPattern>(
                () => VirtualizedItemPattern.Pattern, basicAutomationElement, (b, p) => new VirtualizedItemPattern(b, p));
            Window = new AutomationPattern<IWindowPattern, UIA.IUIAutomationWindowPattern>(
                () => WindowPattern.Pattern, basicAutomationElement, (b, p) => new WindowPattern(b, p));
        }

        public override IAutomationPattern<IAnnotationPattern> Annotation { get; }
        public override IAutomationPattern<IDockPattern> Dock { get; }
        public override IAutomationPattern<IDragPattern> Drag { get; }
        public override IAutomationPattern<IDropTargetPattern> DropTarget { get; }
        public override IAutomationPattern<IExpandCollapsePattern> ExpandCollapse { get; }
        public override IAutomationPattern<IGridItemPattern> GridItem { get; }
        public override IAutomationPattern<IGridPattern> Grid { get; }
        public override IAutomationPattern<IInvokePattern> Invoke { get; }
        public override IAutomationPattern<IItemContainerPattern> ItemContainer { get; }
        public override IAutomationPattern<ILegacyIAccessiblePattern> LegacyIAccessible { get; }
        public override IAutomationPattern<IMultipleViewPattern> MultipleView { get; }
        public override IAutomationPattern<IObjectModelPattern> ObjectModel { get; }
        public override IAutomationPattern<IRangeValuePattern> RangeValue { get; }
        public override IAutomationPattern<IScrollItemPattern> ScrollItem { get; }
        public override IAutomationPattern<IScrollPattern> Scroll { get; }
        public override IAutomationPattern<ISelectionItemPattern> SelectionItem { get; }
        public override IAutomationPattern<ISelectionPattern> Selection { get; }
        public override IAutomationPattern<ISpreadsheetItemPattern> SpreadsheetItem { get; }
        public override IAutomationPattern<ISpreadsheetPattern> Spreadsheet { get; }
        public override IAutomationPattern<IStylesPattern> Styles { get; }
        public override IAutomationPattern<ISynchronizedInputPattern> SynchronizedInput { get; }
        public override IAutomationPattern<ITableItemPattern> TableItem { get; }
        public override IAutomationPattern<ITablePattern> Table { get; }
        public override IAutomationPattern<ITextChildPattern> TextChild { get; }
        public override IAutomationPattern<ITextEditPattern> TextEdit { get; }
        public override IAutomationPattern<IText2Pattern> Text2 { get; }
        public override IAutomationPattern<ITextPattern> Text { get; }
        public override IAutomationPattern<ITogglePattern> Toggle { get; }
        public override IAutomationPattern<ITransform2Pattern> Transform2 { get; }
        public override IAutomationPattern<ITransformPattern> Transform { get; }
        public override IAutomationPattern<IValuePattern> Value { get; }
        public override IAutomationPattern<IVirtualizedItemPattern> VirtualizedItem { get; }
        public override IAutomationPattern<IWindowPattern> Window { get; }
    }
}
