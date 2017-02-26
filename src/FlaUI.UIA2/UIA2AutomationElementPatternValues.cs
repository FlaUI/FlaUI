using FlaUI.Core;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Patterns;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public class UIA2AutomationElementPatternValues : AutomationElementPatternValuesBase
    {
        public UIA2AutomationElementPatternValues(UIA2BasicAutomationElement basicAutomationElement)
        {
            Dock = new AutomationPattern<IDockPattern, UIA.DockPattern>(
                () => DockPattern.Pattern, basicAutomationElement, (b, p) => new DockPattern(b, p));
            ExpandCollapse = new AutomationPattern<IExpandCollapsePattern, UIA.ExpandCollapsePattern>(
                () => ExpandCollapsePattern.Pattern, basicAutomationElement, (b, p) => new ExpandCollapsePattern(b, p));
            GridItem = new AutomationPattern<IGridItemPattern, UIA.GridItemPattern>(
                () => GridItemPattern.Pattern, basicAutomationElement, (b, p) => new GridItemPattern(b, p));
            Grid = new AutomationPattern<IGridPattern, UIA.GridPattern>(
                () => GridPattern.Pattern, basicAutomationElement, (b, p) => new GridPattern(b, p));
            Invoke = new AutomationPattern<IInvokePattern, UIA.InvokePattern>(
                () => InvokePattern.Pattern, basicAutomationElement, (b, p) => new InvokePattern(b, p));
#if !NET35
            ItemContainer = new AutomationPattern<IItemContainerPattern, UIA.ItemContainerPattern>(
                () => ItemContainerPattern.Pattern, basicAutomationElement, (b, p) => new ItemContainerPattern(b, p));
#endif
            MultipleView = new AutomationPattern<IMultipleViewPattern, UIA.MultipleViewPattern>(
                () => MultipleViewPattern.Pattern, basicAutomationElement, (b, p) => new MultipleViewPattern(b, p));
            RangeValue = new AutomationPattern<IRangeValuePattern, UIA.RangeValuePattern>(
                () => RangeValuePattern.Pattern, basicAutomationElement, (b, p) => new RangeValuePattern(b, p));
            ScrollItem = new AutomationPattern<IScrollItemPattern, UIA.ScrollItemPattern>(
                () => ScrollItemPattern.Pattern, basicAutomationElement, (b, p) => new ScrollItemPattern(b, p));
            Scroll = new AutomationPattern<IScrollPattern, UIA.ScrollPattern>(
                () => ScrollPattern.Pattern, basicAutomationElement, (b, p) => new ScrollPattern(b, p));
            SelectionItem = new AutomationPattern<ISelectionItemPattern, UIA.SelectionItemPattern>(
                () => SelectionItemPattern.Pattern, basicAutomationElement, (b, p) => new SelectionItemPattern(b, p));
            Selection = new AutomationPattern<ISelectionPattern, UIA.SelectionPattern>(
                () => SelectionPattern.Pattern, basicAutomationElement, (b, p) => new SelectionPattern(b, p));
#if !NET35
            SynchronizedInput = new AutomationPattern<ISynchronizedInputPattern, UIA.SynchronizedInputPattern>(
                () => SynchronizedInputPattern.Pattern, basicAutomationElement, (b, p) => new SynchronizedInputPattern(b, p));
#endif
            TableItem = new AutomationPattern<ITableItemPattern, UIA.TableItemPattern>(
                () => TableItemPattern.Pattern, basicAutomationElement, (b, p) => new TableItemPattern(b, p));
            Table = new AutomationPattern<ITablePattern, UIA.TablePattern>(
                () => TablePattern.Pattern, basicAutomationElement, (b, p) => new TablePattern(b, p));
            Text = new AutomationPattern<ITextPattern, UIA.TextPattern>(
                () => TextPattern.Pattern, basicAutomationElement, (b, p) => new TextPattern(b, p));
            Toggle = new AutomationPattern<ITogglePattern, UIA.TogglePattern>(
                () => TogglePattern.Pattern, basicAutomationElement, (b, p) => new TogglePattern(b, p));
            Transform = new AutomationPattern<ITransformPattern, UIA.TransformPattern>(
                () => TransformPattern.Pattern, basicAutomationElement, (b, p) => new TransformPattern(b, p));
            Value = new AutomationPattern<IValuePattern, UIA.ValuePattern>(
                () => ValuePattern.Pattern, basicAutomationElement, (b, p) => new ValuePattern(b, p));
#if !NET35
            VirtualizedItem = new AutomationPattern<IVirtualizedItemPattern, UIA.VirtualizedItemPattern>(
                () => VirtualizedItemPattern.Pattern, basicAutomationElement, (b, p) => new VirtualizedItemPattern(b, p));
#endif
            Window = new AutomationPattern<IWindowPattern, UIA.WindowPattern>(
                () => WindowPattern.Pattern, basicAutomationElement, (b, p) => new WindowPattern(b, p));
        }

        public override IAutomationPattern<IAnnotationPattern> Annotation { get { throw new NotSupportedByUIA2Exception(); } }
        public override IAutomationPattern<IDockPattern> Dock { get; }
        public override IAutomationPattern<IDragPattern> Drag { get { throw new NotSupportedByUIA2Exception(); } }
        public override IAutomationPattern<IDropTargetPattern> DropTarget { get { throw new NotSupportedByUIA2Exception(); } }
        public override IAutomationPattern<IExpandCollapsePattern> ExpandCollapse { get; }
        public override IAutomationPattern<IGridItemPattern> GridItem { get; }
        public override IAutomationPattern<IGridPattern> Grid { get; }
        public override IAutomationPattern<IInvokePattern> Invoke { get; }
#if !NET35
        public override IAutomationPattern<IItemContainerPattern> ItemContainer { get; }
#else
        public override IAutomationPattern<IItemContainerPattern> ItemContainer { get { throw new NotSupportedByUIA2Exception(); } }
#endif
        public override IAutomationPattern<ILegacyIAccessiblePattern> LegacyIAccessible { get { throw new NotSupportedByUIA2Exception(); } }
        public override IAutomationPattern<IMultipleViewPattern> MultipleView { get; }
        public override IAutomationPattern<IObjectModelPattern> ObjectModel { get { throw new NotSupportedByUIA2Exception(); } }
        public override IAutomationPattern<IRangeValuePattern> RangeValue { get; }
        public override IAutomationPattern<IScrollItemPattern> ScrollItem { get; }
        public override IAutomationPattern<IScrollPattern> Scroll { get; }
        public override IAutomationPattern<ISelectionItemPattern> SelectionItem { get; }
        public override IAutomationPattern<ISelectionPattern> Selection { get; }
        public override IAutomationPattern<ISpreadsheetItemPattern> SpreadsheetItem { get { throw new NotSupportedByUIA2Exception(); } }
        public override IAutomationPattern<ISpreadsheetPattern> Spreadsheet { get { throw new NotSupportedByUIA2Exception(); } }
        public override IAutomationPattern<IStylesPattern> Styles { get { throw new NotSupportedByUIA2Exception(); } }
#if !NET35
        public override IAutomationPattern<ISynchronizedInputPattern> SynchronizedInput { get; }
#else
        public override IAutomationPattern<ISynchronizedInputPattern> SynchronizedInput { get { throw new NotSupportedByUIA2Exception(); } }
#endif
        public override IAutomationPattern<ITableItemPattern> TableItem { get; }
        public override IAutomationPattern<ITablePattern> Table { get; }
        public override IAutomationPattern<ITextChildPattern> TextChild { get { throw new NotSupportedByUIA2Exception(); } }
        public override IAutomationPattern<ITextEditPattern> TextEdit { get { throw new NotSupportedByUIA2Exception(); } }
        public override IAutomationPattern<IText2Pattern> Text2 { get { throw new NotSupportedByUIA2Exception(); } }
        public override IAutomationPattern<ITextPattern> Text { get; }
        public override IAutomationPattern<ITogglePattern> Toggle { get; }
        public override IAutomationPattern<ITransform2Pattern> Transform2 { get { throw new NotSupportedByUIA2Exception(); } }
        public override IAutomationPattern<ITransformPattern> Transform { get; }
        public override IAutomationPattern<IValuePattern> Value { get; }
#if !NET35
        public override IAutomationPattern<IVirtualizedItemPattern> VirtualizedItem { get; }
#else
        public override IAutomationPattern<IVirtualizedItemPattern> VirtualizedItem { get { throw new NotSupportedByUIA2Exception(); } }
#endif
        public override IAutomationPattern<IWindowPattern> Window { get; }
    }
}
