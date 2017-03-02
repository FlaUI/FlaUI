using FlaUI.Core;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Patterns;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3AutomationElementPatternValues : AutomationElementPatternValuesBase
    {
        public UIA3AutomationElementPatternValues(UIA3BasicAutomationElement basicAutomationElement) : base(basicAutomationElement)
        {
        }

        protected override IAutomationPattern<IAnnotationPattern> InitializeAnnotationPattern()
        {
            return new AutomationPattern<IAnnotationPattern, UIA.IUIAutomationAnnotationPattern>(
                AnnotationPattern.Pattern, BasicAutomationElement, (b, p) => new AnnotationPattern(b, p));
        }

        protected override IAutomationPattern<IDockPattern> InitializeDockPattern()
        {
            return new AutomationPattern<IDockPattern, UIA.IUIAutomationDockPattern>(
                DockPattern.Pattern, BasicAutomationElement, (b, p) => new DockPattern(b, p));
        }

        protected override IAutomationPattern<IDragPattern> InitializeDragPattern()
        {
            return new AutomationPattern<IDragPattern, UIA.IUIAutomationDragPattern>(
                DragPattern.Pattern, BasicAutomationElement, (b, p) => new DragPattern(b, p));
        }

        protected override IAutomationPattern<IDropTargetPattern> InitializeDropTargetPattern()
        {
            return new AutomationPattern<IDropTargetPattern, UIA.IUIAutomationDropTargetPattern>(
                DropTargetPattern.Pattern, BasicAutomationElement, (b, p) => new DropTargetPattern(b, p));
        }

        protected override IAutomationPattern<IExpandCollapsePattern> InitializeExpandCollapsePattern()
        {
            return new AutomationPattern<IExpandCollapsePattern, UIA.IUIAutomationExpandCollapsePattern>(
                ExpandCollapsePattern.Pattern, BasicAutomationElement, (b, p) => new ExpandCollapsePattern(b, p));
        }

        protected override IAutomationPattern<IGridItemPattern> InitializeGridItemPattern()
        {
            return new AutomationPattern<IGridItemPattern, UIA.IUIAutomationGridItemPattern>(
                GridItemPattern.Pattern, BasicAutomationElement, (b, p) => new GridItemPattern(b, p));
        }

        protected override IAutomationPattern<IGridPattern> InitializeGridPattern()
        {
            return new AutomationPattern<IGridPattern, UIA.IUIAutomationGridPattern>(
                 GridPattern.Pattern, BasicAutomationElement, (b, p) => new GridPattern(b, p));
        }

        protected override IAutomationPattern<IInvokePattern> InitializeInvokePattern()
        {
            return new AutomationPattern<IInvokePattern, UIA.IUIAutomationInvokePattern>(
                InvokePattern.Pattern, BasicAutomationElement, (b, p) => new InvokePattern(b, p));
        }

        protected override IAutomationPattern<IItemContainerPattern> InitializeItemContainerPattern()
        {
            return new AutomationPattern<IItemContainerPattern, UIA.IUIAutomationItemContainerPattern>(
                ItemContainerPattern.Pattern, BasicAutomationElement, (b, p) => new ItemContainerPattern(b, p));
        }

        protected override IAutomationPattern<ILegacyIAccessiblePattern> InitializeLegacyIAccessiblePattern()
        {
            return new AutomationPattern<ILegacyIAccessiblePattern, UIA.IUIAutomationLegacyIAccessiblePattern>(
                LegacyIAccessiblePattern.Pattern, BasicAutomationElement, (b, p) => new LegacyIAccessiblePattern(b, p));
        }

        protected override IAutomationPattern<IMultipleViewPattern> InitializeMultipleViewPattern()
        {
            return new AutomationPattern<IMultipleViewPattern, UIA.IUIAutomationMultipleViewPattern>(
                MultipleViewPattern.Pattern, BasicAutomationElement, (b, p) => new MultipleViewPattern(b, p));
        }

        protected override IAutomationPattern<IObjectModelPattern> InitializeObjectModelPattern()
        {
            return new AutomationPattern<IObjectModelPattern, UIA.IUIAutomationObjectModelPattern>(
                ObjectModelPattern.Pattern, BasicAutomationElement, (b, p) => new ObjectModelPattern(b, p));
        }

        protected override IAutomationPattern<IRangeValuePattern> InitializeRangeValuePattern()
        {
            return new AutomationPattern<IRangeValuePattern, UIA.IUIAutomationRangeValuePattern>(
                RangeValuePattern.Pattern, BasicAutomationElement, (b, p) => new RangeValuePattern(b, p));
        }

        protected override IAutomationPattern<IScrollItemPattern> InitializeScrollItemPattern()
        {
            return new AutomationPattern<IScrollItemPattern, UIA.IUIAutomationScrollItemPattern>(
                ScrollItemPattern.Pattern, BasicAutomationElement, (b, p) => new ScrollItemPattern(b, p));
        }

        protected override IAutomationPattern<IScrollPattern> InitializeScrollPattern()
        {
            return new AutomationPattern<IScrollPattern, UIA.IUIAutomationScrollPattern>(
                ScrollPattern.Pattern, BasicAutomationElement, (b, p) => new ScrollPattern(b, p));
        }

        protected override IAutomationPattern<ISelectionItemPattern> InitializeSelectionItemPattern()
        {
            return new AutomationPattern<ISelectionItemPattern, UIA.IUIAutomationSelectionItemPattern>(
                SelectionItemPattern.Pattern, BasicAutomationElement, (b, p) => new SelectionItemPattern(b, p));
        }

        protected override IAutomationPattern<ISelectionPattern> InitializeSelectionPattern()
        {
            return new AutomationPattern<ISelectionPattern, UIA.IUIAutomationSelectionPattern>(
                SelectionPattern.Pattern, BasicAutomationElement, (b, p) => new SelectionPattern(b, p));
        }

        protected override IAutomationPattern<ISpreadsheetItemPattern> InitializeSpreadsheetItemPattern()
        {
            return new AutomationPattern<ISpreadsheetItemPattern, UIA.IUIAutomationSpreadsheetItemPattern>(
                SpreadsheetItemPattern.Pattern, BasicAutomationElement, (b, p) => new SpreadsheetItemPattern(b, p));
        }

        protected override IAutomationPattern<ISpreadsheetPattern> InitializeSpreadsheetPattern()
        {
            return new AutomationPattern<ISpreadsheetPattern, UIA.IUIAutomationSpreadsheetPattern>(
                SpreadsheetPattern.Pattern, BasicAutomationElement, (b, p) => new SpreadsheetPattern(b, p));
        }

        protected override IAutomationPattern<IStylesPattern> InitializeStylesPattern()
        {
            return new AutomationPattern<IStylesPattern, UIA.IUIAutomationStylesPattern>(
                StylesPattern.Pattern, BasicAutomationElement, (b, p) => new StylesPattern(b, p));
        }

        protected override IAutomationPattern<ISynchronizedInputPattern> InitializeSynchronizedInputPattern()
        {
            return new AutomationPattern<ISynchronizedInputPattern, UIA.IUIAutomationSynchronizedInputPattern>(
                SynchronizedInputPattern.Pattern, BasicAutomationElement, (b, p) => new SynchronizedInputPattern(b, p));
        }

        protected override IAutomationPattern<ITableItemPattern> InitializeTableItemPattern()
        {
            return new AutomationPattern<ITableItemPattern, UIA.IUIAutomationTableItemPattern>(
                TableItemPattern.Pattern, BasicAutomationElement, (b, p) => new TableItemPattern(b, p));
        }

        protected override IAutomationPattern<ITablePattern> InitializeTablePattern()
        {
            return new AutomationPattern<ITablePattern, UIA.IUIAutomationTablePattern>(
                TablePattern.Pattern, BasicAutomationElement, (b, p) => new TablePattern(b, p));
        }

        protected override IAutomationPattern<ITextChildPattern> InitializeTextChildPattern()
        {
            return new AutomationPattern<ITextChildPattern, UIA.IUIAutomationTextChildPattern>(
                TextChildPattern.Pattern, BasicAutomationElement, (b, p) => new TextChildPattern(b, p));
        }

        protected override IAutomationPattern<ITextEditPattern> InitializeTextEditPattern()
        {
            return new AutomationPattern<ITextEditPattern, UIA.IUIAutomationTextEditPattern>(
                TextEditPattern.Pattern, BasicAutomationElement, (b, p) => new TextEditPattern(b, p));
        }

        protected override IAutomationPattern<IText2Pattern> InitializeText2Pattern()
        {
            return new AutomationPattern<IText2Pattern, UIA.IUIAutomationTextPattern2>(
                Text2Pattern.Pattern, BasicAutomationElement, (b, p) => new Text2Pattern(b, p));
        }

        protected override IAutomationPattern<ITextPattern> InitializeTextPattern()
        {
            return new AutomationPattern<ITextPattern, UIA.IUIAutomationTextPattern>(
                TextPattern.Pattern, BasicAutomationElement, (b, p) => new TextPattern(b, p));
        }

        protected override IAutomationPattern<ITogglePattern> InitializeTogglePattern()
        {
            return new AutomationPattern<ITogglePattern, UIA.IUIAutomationTogglePattern>(
                TogglePattern.Pattern, BasicAutomationElement, (b, p) => new TogglePattern(b, p));
        }

        protected override IAutomationPattern<ITransform2Pattern> InitializeTransform2Pattern()
        {
            return new AutomationPattern<ITransform2Pattern, UIA.IUIAutomationTransformPattern2>(
                Transform2Pattern.Pattern, BasicAutomationElement, (b, p) => new Transform2Pattern(b, p));
        }

        protected override IAutomationPattern<ITransformPattern> InitializeTransformPattern()
        {
            return new AutomationPattern<ITransformPattern, UIA.IUIAutomationTransformPattern>(
                TransformPattern.Pattern, BasicAutomationElement, (b, p) => new TransformPattern(b, p));
        }

        protected override IAutomationPattern<IValuePattern> InitializeValuePattern()
        {
            return new AutomationPattern<IValuePattern, UIA.IUIAutomationValuePattern>(
                ValuePattern.Pattern, BasicAutomationElement, (b, p) => new ValuePattern(b, p));
        }

        protected override IAutomationPattern<IVirtualizedItemPattern> InitializeVirtualizedItemPattern()
        {
            return new AutomationPattern<IVirtualizedItemPattern, UIA.IUIAutomationVirtualizedItemPattern>(
                 VirtualizedItemPattern.Pattern, BasicAutomationElement, (b, p) => new VirtualizedItemPattern(b, p));
        }

        protected override IAutomationPattern<IWindowPattern> InitializeWindowPattern()
        {
            return new AutomationPattern<IWindowPattern, UIA.IUIAutomationWindowPattern>(
                WindowPattern.Pattern, BasicAutomationElement, (b, p) => new WindowPattern(b, p));
        }
    }
}
