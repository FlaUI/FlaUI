using FlaUI.Core;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Patterns;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public partial class UIA2FrameworkAutomationElement
    {
        protected override IAutomationPattern<IAnnotationPattern> InitializeAnnotationPattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<IDockPattern> InitializeDockPattern()
        {
            return new AutomationPattern<IDockPattern, System.Windows.Automation.DockPattern>(
                DockPattern.Pattern, this, (b, p) => new DockPattern(b, p));
        }

        protected override IAutomationPattern<IDragPattern> InitializeDragPattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<IDropTargetPattern> InitializeDropTargetPattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<IExpandCollapsePattern> InitializeExpandCollapsePattern()
        {
            return new AutomationPattern<IExpandCollapsePattern, System.Windows.Automation.ExpandCollapsePattern>(
                ExpandCollapsePattern.Pattern, this, (b, p) => new ExpandCollapsePattern(b, p));
        }

        protected override IAutomationPattern<IGridItemPattern> InitializeGridItemPattern()
        {
            return new AutomationPattern<IGridItemPattern, System.Windows.Automation.GridItemPattern>(
                GridItemPattern.Pattern, this, (b, p) => new GridItemPattern(b, p));
        }

        protected override IAutomationPattern<IGridPattern> InitializeGridPattern()
        {
            return new AutomationPattern<IGridPattern, System.Windows.Automation.GridPattern>(
                 GridPattern.Pattern, this, (b, p) => new GridPattern(b, p));
        }

        protected override IAutomationPattern<IInvokePattern> InitializeInvokePattern()
        {
            return new AutomationPattern<IInvokePattern, System.Windows.Automation.InvokePattern>(
                InvokePattern.Pattern, this, (b, p) => new InvokePattern(b, p));
        }

        protected override IAutomationPattern<IItemContainerPattern> InitializeItemContainerPattern()
        {
#if NET35
            throw new NotSupportedByFrameworkException();
#else
            return new AutomationPattern<IItemContainerPattern, UIA.ItemContainerPattern>(
                ItemContainerPattern.Pattern, this, (b, p) => new ItemContainerPattern(b, p));
#endif
        }

        protected override IAutomationPattern<ILegacyIAccessiblePattern> InitializeLegacyIAccessiblePattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<IMultipleViewPattern> InitializeMultipleViewPattern()
        {
            return new AutomationPattern<IMultipleViewPattern, System.Windows.Automation.MultipleViewPattern>(
                MultipleViewPattern.Pattern, this, (b, p) => new MultipleViewPattern(b, p));
        }

        protected override IAutomationPattern<IObjectModelPattern> InitializeObjectModelPattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<IRangeValuePattern> InitializeRangeValuePattern()
        {
            return new AutomationPattern<IRangeValuePattern, System.Windows.Automation.RangeValuePattern>(
                RangeValuePattern.Pattern, this, (b, p) => new RangeValuePattern(b, p));
        }

        protected override IAutomationPattern<IScrollItemPattern> InitializeScrollItemPattern()
        {
            return new AutomationPattern<IScrollItemPattern, System.Windows.Automation.ScrollItemPattern>(
                ScrollItemPattern.Pattern, this, (b, p) => new ScrollItemPattern(b, p));
        }

        protected override IAutomationPattern<IScrollPattern> InitializeScrollPattern()
        {
            return new AutomationPattern<IScrollPattern, System.Windows.Automation.ScrollPattern>(
                ScrollPattern.Pattern, this, (b, p) => new ScrollPattern(b, p));
        }

        protected override IAutomationPattern<ISelectionItemPattern> InitializeSelectionItemPattern()
        {
            return new AutomationPattern<ISelectionItemPattern, System.Windows.Automation.SelectionItemPattern>(
                SelectionItemPattern.Pattern, this, (b, p) => new SelectionItemPattern(b, p));
        }

        protected override IAutomationPattern<ISelection2Pattern> InitializeSelection2Pattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<ISelectionPattern> InitializeSelectionPattern()
        {
            return new AutomationPattern<ISelectionPattern, System.Windows.Automation.SelectionPattern>(
                SelectionPattern.Pattern, this, (b, p) => new SelectionPattern(b, p));
        }

        protected override IAutomationPattern<ISpreadsheetItemPattern> InitializeSpreadsheetItemPattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<ISpreadsheetPattern> InitializeSpreadsheetPattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<IStylesPattern> InitializeStylesPattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<ISynchronizedInputPattern> InitializeSynchronizedInputPattern()
        {
#if NET35
            throw new NotSupportedByFrameworkException();
#else
            return new AutomationPattern<ISynchronizedInputPattern, UIA.SynchronizedInputPattern>(
                SynchronizedInputPattern.Pattern, this, (b, p) => new SynchronizedInputPattern(b, p));
#endif
        }

        protected override IAutomationPattern<ITableItemPattern> InitializeTableItemPattern()
        {
            return new AutomationPattern<ITableItemPattern, System.Windows.Automation.TableItemPattern>(
                TableItemPattern.Pattern, this, (b, p) => new TableItemPattern(b, p));
        }

        protected override IAutomationPattern<ITablePattern> InitializeTablePattern()
        {
            return new AutomationPattern<ITablePattern, System.Windows.Automation.TablePattern>(
                TablePattern.Pattern, this, (b, p) => new TablePattern(b, p));
        }

        protected override IAutomationPattern<ITextChildPattern> InitializeTextChildPattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<ITextEditPattern> InitializeTextEditPattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<IText2Pattern> InitializeText2Pattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<ITextPattern> InitializeTextPattern()
        {
            return new AutomationPattern<ITextPattern, System.Windows.Automation.TextPattern>(
                TextPattern.Pattern, this, (b, p) => new TextPattern(b, p));
        }

        protected override IAutomationPattern<ITogglePattern> InitializeTogglePattern()
        {
            return new AutomationPattern<ITogglePattern, System.Windows.Automation.TogglePattern>(
                TogglePattern.Pattern, this, (b, p) => new TogglePattern(b, p));
        }

        protected override IAutomationPattern<ITransform2Pattern> InitializeTransform2Pattern()
        {
            throw new NotSupportedByFrameworkException();
        }

        protected override IAutomationPattern<ITransformPattern> InitializeTransformPattern()
        {
            return new AutomationPattern<ITransformPattern, System.Windows.Automation.TransformPattern>(
                TransformPattern.Pattern, this, (b, p) => new TransformPattern(b, p));
        }

        protected override IAutomationPattern<IValuePattern> InitializeValuePattern()
        {
            return new AutomationPattern<IValuePattern, System.Windows.Automation.ValuePattern>(
                ValuePattern.Pattern, this, (b, p) => new ValuePattern(b, p));
        }

        protected override IAutomationPattern<IVirtualizedItemPattern> InitializeVirtualizedItemPattern()
        {
#if NET35
            throw new NotSupportedByFrameworkException();
#else
            return new AutomationPattern<IVirtualizedItemPattern, UIA.VirtualizedItemPattern>(
                 VirtualizedItemPattern.Pattern, this, (b, p) => new VirtualizedItemPattern(b, p));
#endif
        }

        protected override IAutomationPattern<IWindowPattern> InitializeWindowPattern()
        {
            return new AutomationPattern<IWindowPattern, System.Windows.Automation.WindowPattern>(
                WindowPattern.Pattern, this, (b, p) => new WindowPattern(b, p));
        }
    }
}
