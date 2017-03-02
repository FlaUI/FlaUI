using FlaUI.Core.Patterns;

namespace FlaUI.Core
{
    public abstract class AutomationElementPatternValuesBase
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

        protected AutomationElementPatternValuesBase(BasicAutomationElementBase basicAutomationElement)
        {
            BasicAutomationElement = basicAutomationElement;
        }

        protected BasicAutomationElementBase BasicAutomationElement { get; }

        public IAutomationPattern<IAnnotationPattern> Annotation => _annotationPattern ?? (_annotationPattern = InitializeAnnotationPattern());
        public IAutomationPattern<IDockPattern> Dock => _dockPattern ?? (_dockPattern = InitializeDockPattern());
        public IAutomationPattern<IDragPattern> Drag => _dragPattern ?? (_dragPattern = InitializeDragPattern());
        public IAutomationPattern<IDropTargetPattern> DropTarget => _dropTargetPattern ?? (_dropTargetPattern = InitializeDropTargetPattern());
        public IAutomationPattern<IExpandCollapsePattern> ExpandCollapse => _expandCollapsePattern ?? (_expandCollapsePattern = InitializeExpandCollapsePattern());
        public IAutomationPattern<IGridItemPattern> GridItem => _gridItemPattern ?? (_gridItemPattern = InitializeGridItemPattern());
        public IAutomationPattern<IGridPattern> Grid => _gridPattern ?? (_gridPattern = InitializeGridPattern());
        public IAutomationPattern<IInvokePattern> Invoke => _invokePattern ?? (_invokePattern = InitializeInvokePattern());
        public IAutomationPattern<IItemContainerPattern> ItemContainer => _itemContainerPattern ?? (_itemContainerPattern = InitializeItemContainerPattern());
        public IAutomationPattern<ILegacyIAccessiblePattern> LegacyIAccessible => _legacyIAccessiblePattern ?? (_legacyIAccessiblePattern = InitializeLegacyIAccessiblePattern());
        public IAutomationPattern<IMultipleViewPattern> MultipleView => _multipleViewPattern ?? (_multipleViewPattern = InitializeMultipleViewPattern());
        public IAutomationPattern<IObjectModelPattern> ObjectModel => _objectModelPattern ?? (_objectModelPattern = InitializeObjectModelPattern());
        public IAutomationPattern<IRangeValuePattern> RangeValue => _rangeValuePattern ?? (_rangeValuePattern = InitializeRangeValuePattern());
        public IAutomationPattern<IScrollItemPattern> ScrollItem => _scrollItemPattern ?? (_scrollItemPattern = InitializeScrollItemPattern());
        public IAutomationPattern<IScrollPattern> Scroll => _scrollPattern ?? (_scrollPattern = InitializeScrollPattern());
        public IAutomationPattern<ISelectionItemPattern> SelectionItem => _selectionItemPattern ?? (_selectionItemPattern = InitializeSelectionItemPattern());
        public IAutomationPattern<ISelectionPattern> Selection => _selectionPattern ?? (_selectionPattern = InitializeSelectionPattern());
        public IAutomationPattern<ISpreadsheetItemPattern> SpreadsheetItem => _spreadsheetItemPattern ?? (_spreadsheetItemPattern = InitializeSpreadsheetItemPattern());
        public IAutomationPattern<ISpreadsheetPattern> Spreadsheet => _spreadsheetPattern ?? (_spreadsheetPattern = InitializeSpreadsheetPattern());
        public IAutomationPattern<IStylesPattern> Styles => _stylesPattern ?? (_stylesPattern = InitializeStylesPattern());
        public IAutomationPattern<ISynchronizedInputPattern> SynchronizedInput => _synchronizedInputPattern ?? (_synchronizedInputPattern = InitializeSynchronizedInputPattern());
        public IAutomationPattern<ITableItemPattern> TableItem => _tableItemPattern ?? (_tableItemPattern = InitializeTableItemPattern());
        public IAutomationPattern<ITablePattern> Table => _tablePattern ?? (_tablePattern = InitializeTablePattern());
        public IAutomationPattern<ITextChildPattern> TextChild => _textChildPattern ?? (_textChildPattern = InitializeTextChildPattern());
        public IAutomationPattern<ITextEditPattern> TextEdit => _textEditPattern ?? (_textEditPattern = InitializeTextEditPattern());
        public IAutomationPattern<IText2Pattern> Text2 => _text2Pattern ?? (_text2Pattern = InitializeText2Pattern());
        public IAutomationPattern<ITextPattern> Text => _textPattern ?? (_textPattern = InitializeTextPattern());
        public IAutomationPattern<ITogglePattern> Toggle => _togglePattern ?? (_togglePattern = InitializeTogglePattern());
        public IAutomationPattern<ITransform2Pattern> Transform2 => _transform2Pattern ?? (_transform2Pattern = InitializeTransform2Pattern());
        public IAutomationPattern<ITransformPattern> Transform => _transformPattern ?? (_transformPattern = InitializeTransformPattern());
        public IAutomationPattern<IValuePattern> Value => _valuePattern ?? (_valuePattern = InitializeValuePattern());
        public IAutomationPattern<IVirtualizedItemPattern> VirtualizedItem => _virtualizedItemPattern ?? (_virtualizedItemPattern = InitializeVirtualizedItemPattern());
        public IAutomationPattern<IWindowPattern> Window => _windowPattern ?? (_windowPattern = InitializeWindowPattern());

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
    }
}
