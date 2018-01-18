using FlaUI.Core.Patterns;

namespace FlaUI.Core
{
    public abstract partial class FrameworkAutomationElementBase : FrameworkAutomationElementBase.IFrameworkPatterns
    {
        private IAutomationPattern<IAnnotationPattern> _annotationPattern;
        private IAutomationPattern<IDockPattern> _dockPattern;
        private IAutomationPattern<IDragPattern> _dragPattern;
        private IAutomationPattern<IDropTargetPattern> _dropTargetPattern;
        private IAutomationPattern<IExpandCollapsePattern> _expandCollapsePattern;
        private IAutomationPattern<IGridItemPattern> _gridItemPattern;
        private IAutomationPattern<IGridPattern> _gridPattern;
        private IAutomationPattern<IInvokePattern> _invokePattern;
        private IAutomationPattern<IItemContainerPattern> _itemContainerPattern;
        private IAutomationPattern<ILegacyIAccessiblePattern> _legacyIAccessiblePattern;
        private IAutomationPattern<IMultipleViewPattern> _multipleViewPattern;
        private IAutomationPattern<IObjectModelPattern> _objectModelPattern;
        private IAutomationPattern<IRangeValuePattern> _rangeValuePattern;
        private IAutomationPattern<IScrollItemPattern> _scrollItemPattern;
        private IAutomationPattern<IScrollPattern> _scrollPattern;
        private IAutomationPattern<ISelectionItemPattern> _selectionItemPattern;
        private IAutomationPattern<ISelection2Pattern> _selection2Pattern;
        private IAutomationPattern<ISelectionPattern> _selectionPattern;
        private IAutomationPattern<ISpreadsheetItemPattern> _spreadsheetItemPattern;
        private IAutomationPattern<ISpreadsheetPattern> _spreadsheetPattern;
        private IAutomationPattern<IStylesPattern> _stylesPattern;
        private IAutomationPattern<ISynchronizedInputPattern> _synchronizedInputPattern;
        private IAutomationPattern<ITableItemPattern> _tableItemPattern;
        private IAutomationPattern<ITablePattern> _tablePattern;
        private IAutomationPattern<ITextChildPattern> _textChildPattern;
        private IAutomationPattern<ITextEditPattern> _textEditPattern;
        private IAutomationPattern<IText2Pattern> _text2Pattern;
        private IAutomationPattern<ITextPattern> _textPattern;
        private IAutomationPattern<ITogglePattern> _togglePattern;
        private IAutomationPattern<ITransform2Pattern> _transform2Pattern;
        private IAutomationPattern<ITransformPattern> _transformPattern;
        private IAutomationPattern<IValuePattern> _valuePattern;
        private IAutomationPattern<IVirtualizedItemPattern> _virtualizedItemPattern;
        private IAutomationPattern<IWindowPattern> _windowPattern;

        /// <summary>
        /// Provides access to all patterns.
        /// </summary>
        public IFrameworkPatterns Patterns => this;

        IAutomationPattern<IAnnotationPattern> IFrameworkPatterns.Annotation => _annotationPattern ?? (_annotationPattern = InitializeAnnotationPattern());
        IAutomationPattern<IDockPattern> IFrameworkPatterns.Dock => _dockPattern ?? (_dockPattern = InitializeDockPattern());
        IAutomationPattern<IDragPattern> IFrameworkPatterns.Drag => _dragPattern ?? (_dragPattern = InitializeDragPattern());
        IAutomationPattern<IDropTargetPattern> IFrameworkPatterns.DropTarget => _dropTargetPattern ?? (_dropTargetPattern = InitializeDropTargetPattern());
        IAutomationPattern<IExpandCollapsePattern> IFrameworkPatterns.ExpandCollapse => _expandCollapsePattern ?? (_expandCollapsePattern = InitializeExpandCollapsePattern());
        IAutomationPattern<IGridItemPattern> IFrameworkPatterns.GridItem => _gridItemPattern ?? (_gridItemPattern = InitializeGridItemPattern());
        IAutomationPattern<IGridPattern> IFrameworkPatterns.Grid => _gridPattern ?? (_gridPattern = InitializeGridPattern());
        IAutomationPattern<IInvokePattern> IFrameworkPatterns.Invoke => _invokePattern ?? (_invokePattern = InitializeInvokePattern());
        IAutomationPattern<IItemContainerPattern> IFrameworkPatterns.ItemContainer => _itemContainerPattern ?? (_itemContainerPattern = InitializeItemContainerPattern());
        IAutomationPattern<ILegacyIAccessiblePattern> IFrameworkPatterns.LegacyIAccessible => _legacyIAccessiblePattern ?? (_legacyIAccessiblePattern = InitializeLegacyIAccessiblePattern());
        IAutomationPattern<IMultipleViewPattern> IFrameworkPatterns.MultipleView => _multipleViewPattern ?? (_multipleViewPattern = InitializeMultipleViewPattern());
        IAutomationPattern<IObjectModelPattern> IFrameworkPatterns.ObjectModel => _objectModelPattern ?? (_objectModelPattern = InitializeObjectModelPattern());
        IAutomationPattern<IRangeValuePattern> IFrameworkPatterns.RangeValue => _rangeValuePattern ?? (_rangeValuePattern = InitializeRangeValuePattern());
        IAutomationPattern<IScrollItemPattern> IFrameworkPatterns.ScrollItem => _scrollItemPattern ?? (_scrollItemPattern = InitializeScrollItemPattern());
        IAutomationPattern<IScrollPattern> IFrameworkPatterns.Scroll => _scrollPattern ?? (_scrollPattern = InitializeScrollPattern());
        IAutomationPattern<ISelectionItemPattern> IFrameworkPatterns.SelectionItem => _selectionItemPattern ?? (_selectionItemPattern = InitializeSelectionItemPattern());
        IAutomationPattern<ISelection2Pattern> IFrameworkPatterns.Selection2 => _selection2Pattern ?? (_selection2Pattern = InitializeSelection2Pattern());
        IAutomationPattern<ISelectionPattern> IFrameworkPatterns.Selection => _selectionPattern ?? (_selectionPattern = InitializeSelectionPattern());
        IAutomationPattern<ISpreadsheetItemPattern> IFrameworkPatterns.SpreadsheetItem => _spreadsheetItemPattern ?? (_spreadsheetItemPattern = InitializeSpreadsheetItemPattern());
        IAutomationPattern<ISpreadsheetPattern> IFrameworkPatterns.Spreadsheet => _spreadsheetPattern ?? (_spreadsheetPattern = InitializeSpreadsheetPattern());
        IAutomationPattern<IStylesPattern> IFrameworkPatterns.Styles => _stylesPattern ?? (_stylesPattern = InitializeStylesPattern());
        IAutomationPattern<ISynchronizedInputPattern> IFrameworkPatterns.SynchronizedInput => _synchronizedInputPattern ?? (_synchronizedInputPattern = InitializeSynchronizedInputPattern());
        IAutomationPattern<ITableItemPattern> IFrameworkPatterns.TableItem => _tableItemPattern ?? (_tableItemPattern = InitializeTableItemPattern());
        IAutomationPattern<ITablePattern> IFrameworkPatterns.Table => _tablePattern ?? (_tablePattern = InitializeTablePattern());
        IAutomationPattern<ITextChildPattern> IFrameworkPatterns.TextChild => _textChildPattern ?? (_textChildPattern = InitializeTextChildPattern());
        IAutomationPattern<ITextEditPattern> IFrameworkPatterns.TextEdit => _textEditPattern ?? (_textEditPattern = InitializeTextEditPattern());
        IAutomationPattern<IText2Pattern> IFrameworkPatterns.Text2 => _text2Pattern ?? (_text2Pattern = InitializeText2Pattern());
        IAutomationPattern<ITextPattern> IFrameworkPatterns.Text => _textPattern ?? (_textPattern = InitializeTextPattern());
        IAutomationPattern<ITogglePattern> IFrameworkPatterns.Toggle => _togglePattern ?? (_togglePattern = InitializeTogglePattern());
        IAutomationPattern<ITransform2Pattern> IFrameworkPatterns.Transform2 => _transform2Pattern ?? (_transform2Pattern = InitializeTransform2Pattern());
        IAutomationPattern<ITransformPattern> IFrameworkPatterns.Transform => _transformPattern ?? (_transformPattern = InitializeTransformPattern());
        IAutomationPattern<IValuePattern> IFrameworkPatterns.Value => _valuePattern ?? (_valuePattern = InitializeValuePattern());
        IAutomationPattern<IVirtualizedItemPattern> IFrameworkPatterns.VirtualizedItem => _virtualizedItemPattern ?? (_virtualizedItemPattern = InitializeVirtualizedItemPattern());
        IAutomationPattern<IWindowPattern> IFrameworkPatterns.Window => _windowPattern ?? (_windowPattern = InitializeWindowPattern());

        protected abstract IAutomationPattern<IAnnotationPattern> InitializeAnnotationPattern();
        protected abstract IAutomationPattern<IDockPattern> InitializeDockPattern();
        protected abstract IAutomationPattern<IDragPattern> InitializeDragPattern();
        protected abstract IAutomationPattern<IDropTargetPattern> InitializeDropTargetPattern();
        protected abstract IAutomationPattern<IExpandCollapsePattern> InitializeExpandCollapsePattern();
        protected abstract IAutomationPattern<IGridItemPattern> InitializeGridItemPattern();
        protected abstract IAutomationPattern<IGridPattern> InitializeGridPattern();
        protected abstract IAutomationPattern<IInvokePattern> InitializeInvokePattern();
        protected abstract IAutomationPattern<IItemContainerPattern> InitializeItemContainerPattern();
        protected abstract IAutomationPattern<ILegacyIAccessiblePattern> InitializeLegacyIAccessiblePattern();
        protected abstract IAutomationPattern<IMultipleViewPattern> InitializeMultipleViewPattern();
        protected abstract IAutomationPattern<IObjectModelPattern> InitializeObjectModelPattern();
        protected abstract IAutomationPattern<IRangeValuePattern> InitializeRangeValuePattern();
        protected abstract IAutomationPattern<IScrollItemPattern> InitializeScrollItemPattern();
        protected abstract IAutomationPattern<IScrollPattern> InitializeScrollPattern();
        protected abstract IAutomationPattern<ISelectionItemPattern> InitializeSelectionItemPattern();
        protected abstract IAutomationPattern<ISelection2Pattern> InitializeSelection2Pattern();
        protected abstract IAutomationPattern<ISelectionPattern> InitializeSelectionPattern();
        protected abstract IAutomationPattern<ISpreadsheetItemPattern> InitializeSpreadsheetItemPattern();
        protected abstract IAutomationPattern<ISpreadsheetPattern> InitializeSpreadsheetPattern();
        protected abstract IAutomationPattern<IStylesPattern> InitializeStylesPattern();
        protected abstract IAutomationPattern<ISynchronizedInputPattern> InitializeSynchronizedInputPattern();
        protected abstract IAutomationPattern<ITableItemPattern> InitializeTableItemPattern();
        protected abstract IAutomationPattern<ITablePattern> InitializeTablePattern();
        protected abstract IAutomationPattern<ITextChildPattern> InitializeTextChildPattern();
        protected abstract IAutomationPattern<ITextEditPattern> InitializeTextEditPattern();
        protected abstract IAutomationPattern<IText2Pattern> InitializeText2Pattern();
        protected abstract IAutomationPattern<ITextPattern> InitializeTextPattern();
        protected abstract IAutomationPattern<ITogglePattern> InitializeTogglePattern();
        protected abstract IAutomationPattern<ITransform2Pattern> InitializeTransform2Pattern();
        protected abstract IAutomationPattern<ITransformPattern> InitializeTransformPattern();
        protected abstract IAutomationPattern<IValuePattern> InitializeValuePattern();
        protected abstract IAutomationPattern<IVirtualizedItemPattern> InitializeVirtualizedItemPattern();
        protected abstract IAutomationPattern<IWindowPattern> InitializeWindowPattern();

        public interface IFrameworkPatterns
        {
            IAutomationPattern<IAnnotationPattern> Annotation { get; }
            IAutomationPattern<IDockPattern> Dock { get; }
            IAutomationPattern<IDragPattern> Drag { get; }
            IAutomationPattern<IDropTargetPattern> DropTarget { get; }
            IAutomationPattern<IExpandCollapsePattern> ExpandCollapse { get; }
            IAutomationPattern<IGridItemPattern> GridItem { get; }
            IAutomationPattern<IGridPattern> Grid { get; }
            IAutomationPattern<IInvokePattern> Invoke { get; }
            IAutomationPattern<IItemContainerPattern> ItemContainer { get; }
            IAutomationPattern<ILegacyIAccessiblePattern> LegacyIAccessible { get; }
            IAutomationPattern<IMultipleViewPattern> MultipleView { get; }
            IAutomationPattern<IObjectModelPattern> ObjectModel { get; }
            IAutomationPattern<IRangeValuePattern> RangeValue { get; }
            IAutomationPattern<IScrollItemPattern> ScrollItem { get; }
            IAutomationPattern<IScrollPattern> Scroll { get; }
            IAutomationPattern<ISelectionItemPattern> SelectionItem { get; }
            IAutomationPattern<ISelection2Pattern> Selection2 { get; }
            IAutomationPattern<ISelectionPattern> Selection { get; }
            IAutomationPattern<ISpreadsheetItemPattern> SpreadsheetItem { get; }
            IAutomationPattern<ISpreadsheetPattern> Spreadsheet { get; }
            IAutomationPattern<IStylesPattern> Styles { get; }
            IAutomationPattern<ISynchronizedInputPattern> SynchronizedInput { get; }
            IAutomationPattern<ITableItemPattern> TableItem { get; }
            IAutomationPattern<ITablePattern> Table { get; }
            IAutomationPattern<ITextChildPattern> TextChild { get; }
            IAutomationPattern<ITextEditPattern> TextEdit { get; }
            IAutomationPattern<IText2Pattern> Text2 { get; }
            IAutomationPattern<ITextPattern> Text { get; }
            IAutomationPattern<ITogglePattern> Toggle { get; }
            IAutomationPattern<ITransform2Pattern> Transform2 { get; }
            IAutomationPattern<ITransformPattern> Transform { get; }
            IAutomationPattern<IValuePattern> Value { get; }
            IAutomationPattern<IVirtualizedItemPattern> VirtualizedItem { get; }
            IAutomationPattern<IWindowPattern> Window { get; }
        }
    }
}
