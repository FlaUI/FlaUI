using System;
using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Patterns;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3
{
    public class UIA3AutomationElementPatternValues : AutomationElementPatternValuesBase
    {
        public UIA3AutomationElementPatternValues(UIA3FrameworkAutomationElement frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        protected override IAutomationPattern<IAnnotationPattern> InitializeAnnotationPattern()
        {
            return new AutomationPattern<IAnnotationPattern, UIA.IUIAutomationAnnotationPattern>(
                AnnotationPattern.Pattern, FrameworkAutomationElement, (b, p) => new AnnotationPattern(b, p));
        }

        protected override IAutomationPattern<IDockPattern> InitializeDockPattern()
        {
            return new AutomationPattern<IDockPattern, UIA.IUIAutomationDockPattern>(
                DockPattern.Pattern, FrameworkAutomationElement, (b, p) => new DockPattern(b, p));
        }

        protected override IAutomationPattern<IDragPattern> InitializeDragPattern()
        {
            return new AutomationPattern<IDragPattern, UIA.IUIAutomationDragPattern>(
                DragPattern.Pattern, FrameworkAutomationElement, (b, p) => new DragPattern(b, p));
        }

        protected override IAutomationPattern<IDropTargetPattern> InitializeDropTargetPattern()
        {
            return new AutomationPattern<IDropTargetPattern, UIA.IUIAutomationDropTargetPattern>(
                DropTargetPattern.Pattern, FrameworkAutomationElement, (b, p) => new DropTargetPattern(b, p));
        }

        protected override IAutomationPattern<IExpandCollapsePattern> InitializeExpandCollapsePattern()
        {
            return new AutomationPattern<IExpandCollapsePattern, UIA.IUIAutomationExpandCollapsePattern>(
                ExpandCollapsePattern.Pattern, FrameworkAutomationElement, (b, p) => new ExpandCollapsePattern(b, p));
        }

        protected override IAutomationPattern<IGridItemPattern> InitializeGridItemPattern()
        {
            return new AutomationPattern<IGridItemPattern, UIA.IUIAutomationGridItemPattern>(
                GridItemPattern.Pattern, FrameworkAutomationElement, (b, p) => new GridItemPattern(b, p));
        }

        protected override IAutomationPattern<IGridPattern> InitializeGridPattern()
        {
            return new AutomationPattern<IGridPattern, UIA.IUIAutomationGridPattern>(
                 GridPattern.Pattern, FrameworkAutomationElement, (b, p) => new GridPattern(b, p));
        }

        protected override IAutomationPattern<IInvokePattern> InitializeInvokePattern()
        {
            return new AutomationPattern<IInvokePattern, UIA.IUIAutomationInvokePattern>(
                InvokePattern.Pattern, FrameworkAutomationElement, (b, p) => new InvokePattern(b, p));
        }

        protected override IAutomationPattern<IItemContainerPattern> InitializeItemContainerPattern()
        {
            return new AutomationPattern<IItemContainerPattern, UIA.IUIAutomationItemContainerPattern>(
                ItemContainerPattern.Pattern, FrameworkAutomationElement, (b, p) => new ItemContainerPattern(b, p));
        }

        protected override IAutomationPattern<ILegacyIAccessiblePattern> InitializeLegacyIAccessiblePattern()
        {
            return new AutomationPattern<ILegacyIAccessiblePattern, UIA.IUIAutomationLegacyIAccessiblePattern>(
                LegacyIAccessiblePattern.Pattern, FrameworkAutomationElement, (b, p) => new LegacyIAccessiblePattern(b, p));
        }

        protected override IAutomationPattern<IMultipleViewPattern> InitializeMultipleViewPattern()
        {
            return new AutomationPattern<IMultipleViewPattern, UIA.IUIAutomationMultipleViewPattern>(
                MultipleViewPattern.Pattern, FrameworkAutomationElement, (b, p) => new MultipleViewPattern(b, p));
        }

        protected override IAutomationPattern<IObjectModelPattern> InitializeObjectModelPattern()
        {
            return new AutomationPattern<IObjectModelPattern, UIA.IUIAutomationObjectModelPattern>(
                ObjectModelPattern.Pattern, FrameworkAutomationElement, (b, p) => new ObjectModelPattern(b, p));
        }

        protected override IAutomationPattern<IRangeValuePattern> InitializeRangeValuePattern()
        {
            return new AutomationPattern<IRangeValuePattern, UIA.IUIAutomationRangeValuePattern>(
                RangeValuePattern.Pattern, FrameworkAutomationElement, (b, p) => new RangeValuePattern(b, p));
        }

        protected override IAutomationPattern<IScrollItemPattern> InitializeScrollItemPattern()
        {
            return new AutomationPattern<IScrollItemPattern, UIA.IUIAutomationScrollItemPattern>(
                ScrollItemPattern.Pattern, FrameworkAutomationElement, (b, p) => new ScrollItemPattern(b, p));
        }

        protected override IAutomationPattern<IScrollPattern> InitializeScrollPattern()
        {
            return new AutomationPattern<IScrollPattern, UIA.IUIAutomationScrollPattern>(
                ScrollPattern.Pattern, FrameworkAutomationElement, (b, p) => new ScrollPattern(b, p));
        }

        protected override IAutomationPattern<ISelectionItemPattern> InitializeSelectionItemPattern()
        {
            return new AutomationPattern<ISelectionItemPattern, UIA.IUIAutomationSelectionItemPattern>(
                SelectionItemPattern.Pattern, FrameworkAutomationElement, (b, p) => new SelectionItemPattern(b, p));
        }

        protected override IAutomationPattern<ISelectionPattern> InitializeSelectionPattern()
        {
            return new AutomationPattern<ISelectionPattern, UIA.IUIAutomationSelectionPattern>(
                SelectionPattern.Pattern, FrameworkAutomationElement, (b, p) => new SelectionPattern(b, p));
        }

        protected override IAutomationPattern<ISpreadsheetItemPattern> InitializeSpreadsheetItemPattern()
        {
            return new AutomationPattern<ISpreadsheetItemPattern, UIA.IUIAutomationSpreadsheetItemPattern>(
                SpreadsheetItemPattern.Pattern, FrameworkAutomationElement, (b, p) => new SpreadsheetItemPattern(b, p));
        }

        protected override IAutomationPattern<ISpreadsheetPattern> InitializeSpreadsheetPattern()
        {
            return new AutomationPattern<ISpreadsheetPattern, UIA.IUIAutomationSpreadsheetPattern>(
                SpreadsheetPattern.Pattern, FrameworkAutomationElement, (b, p) => new SpreadsheetPattern(b, p));
        }

        protected override IAutomationPattern<IStylesPattern> InitializeStylesPattern()
        {
            return new AutomationPattern<IStylesPattern, UIA.IUIAutomationStylesPattern>(
                StylesPattern.Pattern, FrameworkAutomationElement, (b, p) => new StylesPattern(b, p));
        }

        protected override IAutomationPattern<ISynchronizedInputPattern> InitializeSynchronizedInputPattern()
        {
            return new AutomationPattern<ISynchronizedInputPattern, UIA.IUIAutomationSynchronizedInputPattern>(
                SynchronizedInputPattern.Pattern, FrameworkAutomationElement, (b, p) => new SynchronizedInputPattern(b, p));
        }

        protected override IAutomationPattern<ITableItemPattern> InitializeTableItemPattern()
        {
            return new AutomationPattern<ITableItemPattern, UIA.IUIAutomationTableItemPattern>(
                TableItemPattern.Pattern, FrameworkAutomationElement, (b, p) => new TableItemPattern(b, p));
        }

        protected override IAutomationPattern<ITablePattern> InitializeTablePattern()
        {
            return new AutomationPattern<ITablePattern, UIA.IUIAutomationTablePattern>(
                TablePattern.Pattern, FrameworkAutomationElement, (b, p) => new TablePattern(b, p));
        }

        protected override IAutomationPattern<ITextChildPattern> InitializeTextChildPattern()
        {
            return new AutomationPattern<ITextChildPattern, UIA.IUIAutomationTextChildPattern>(
                TextChildPattern.Pattern, FrameworkAutomationElement, (b, p) => new TextChildPattern(b, p));
        }

        protected override IAutomationPattern<ITextEditPattern> InitializeTextEditPattern()
        {
            return new AutomationPattern<ITextEditPattern, UIA.IUIAutomationTextEditPattern>(
                TextEditPattern.Pattern, FrameworkAutomationElement, (b, p) => new TextEditPattern(b, p));
        }

        protected override IAutomationPattern<IText2Pattern> InitializeText2Pattern()
        {
            return new AutomationPattern<IText2Pattern, UIA.IUIAutomationTextPattern2>(
                Text2Pattern.Pattern, FrameworkAutomationElement, (b, p) => new Text2Pattern(b, p));
        }

        protected override IAutomationPattern<ITextPattern> InitializeTextPattern()
        {
            return new AutomationPattern<ITextPattern, UIA.IUIAutomationTextPattern>(
                TextPattern.Pattern, FrameworkAutomationElement, (b, p) => new TextPattern(b, p));
        }

        protected override IAutomationPattern<ITogglePattern> InitializeTogglePattern()
        {
            return new AutomationPattern<ITogglePattern, UIA.IUIAutomationTogglePattern>(
                TogglePattern.Pattern, FrameworkAutomationElement, (b, p) => new TogglePattern(b, p));
        }

        protected override IAutomationPattern<ITransform2Pattern> InitializeTransform2Pattern()
        {
            return new AutomationPattern<ITransform2Pattern, UIA.IUIAutomationTransformPattern2>(
                Transform2Pattern.Pattern, FrameworkAutomationElement, (b, p) => new Transform2Pattern(b, p));
        }

        protected override IAutomationPattern<ITransformPattern> InitializeTransformPattern()
        {
            return new AutomationPattern<ITransformPattern, UIA.IUIAutomationTransformPattern>(
                TransformPattern.Pattern, FrameworkAutomationElement, (b, p) => new TransformPattern(b, p));
        }

        protected override IAutomationPattern<IValuePattern> InitializeValuePattern()
        {
            return new AutomationPattern<IValuePattern, UIA.IUIAutomationValuePattern>(
                ValuePattern.Pattern, FrameworkAutomationElement, (b, p) => new ValuePattern(b, p));
        }

        protected override IAutomationPattern<IVirtualizedItemPattern> InitializeVirtualizedItemPattern()
        {
            return new AutomationPattern<IVirtualizedItemPattern, UIA.IUIAutomationVirtualizedItemPattern>(
                 VirtualizedItemPattern.Pattern, FrameworkAutomationElement, (b, p) => new VirtualizedItemPattern(b, p));
        }

        protected override IAutomationPattern<IWindowPattern> InitializeWindowPattern()
        {
            return new AutomationPattern<IWindowPattern, UIA.IUIAutomationWindowPattern>(
                WindowPattern.Pattern, FrameworkAutomationElement, (b, p) => new WindowPattern(b, p));
        }

        public override IAutomationPattern<T> GetCustomPattern<T, TNative>(PatternId pattern, Func<FrameworkAutomationElementBase, TNative, T> patternCreateFunc)
        {
            return new AutomationPattern<T, TNative>(pattern, FrameworkAutomationElement, patternCreateFunc);
        }
    }
}
