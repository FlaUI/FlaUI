using System;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;

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

        public IAutomationPattern<IAnnotationPattern> Annotation => GetOrCreate(ref _annotationPattern, InitializeAnnotationPattern);
        public IAutomationPattern<IDockPattern> Dock => GetOrCreate(ref _dockPattern, InitializeDockPattern);
        public IAutomationPattern<IDragPattern> Drag => GetOrCreate(ref _dragPattern, InitializeDragPattern);
        public IAutomationPattern<IDropTargetPattern> DropTarget => GetOrCreate(ref _dropTargetPattern, InitializeDropTargetPattern);
        public IAutomationPattern<IExpandCollapsePattern> ExpandCollapse => GetOrCreate(ref _expandCollapsePattern, InitializeExpandCollapsePattern);
        public IAutomationPattern<IGridItemPattern> GridItem => GetOrCreate(ref _gridItemPattern, InitializeGridItemPattern);
        public IAutomationPattern<IGridPattern> Grid => GetOrCreate(ref _gridPattern, InitializeGridPattern);
        public IAutomationPattern<IInvokePattern> Invoke => GetOrCreate(ref _invokePattern, InitializeInvokePattern);
        public IAutomationPattern<IItemContainerPattern> ItemContainer => GetOrCreate(ref _itemContainerPattern, InitializeItemContainerPattern);
        public IAutomationPattern<ILegacyIAccessiblePattern> LegacyIAccessible => GetOrCreate(ref _legacyIAccessiblePattern, InitializeLegacyIAccessiblePattern);
        public IAutomationPattern<IMultipleViewPattern> MultipleView => GetOrCreate(ref _multipleViewPattern, InitializeMultipleViewPattern);
        public IAutomationPattern<IObjectModelPattern> ObjectModel => GetOrCreate(ref _objectModelPattern, InitializeObjectModelPattern);
        public IAutomationPattern<IRangeValuePattern> RangeValue => GetOrCreate(ref _rangeValuePattern, InitializeRangeValuePattern);
        public IAutomationPattern<IScrollItemPattern> ScrollItem => GetOrCreate(ref _scrollItemPattern, InitializeScrollItemPattern);
        public IAutomationPattern<IScrollPattern> Scroll => GetOrCreate(ref _scrollPattern, InitializeScrollPattern);
        public IAutomationPattern<ISelectionItemPattern> SelectionItem => GetOrCreate(ref _selectionItemPattern, InitializeSelectionItemPattern);
        public IAutomationPattern<ISelectionPattern> Selection => GetOrCreate(ref _selectionPattern, InitializeSelectionPattern);
        public IAutomationPattern<ISpreadsheetItemPattern> SpreadsheetItem => GetOrCreate(ref _spreadsheetItemPattern, InitializeSpreadsheetItemPattern);
        public IAutomationPattern<ISpreadsheetPattern> Spreadsheet => GetOrCreate(ref _spreadsheetPattern, InitializeSpreadsheetPattern);
        public IAutomationPattern<IStylesPattern> Styles => GetOrCreate(ref _stylesPattern, InitializeStylesPattern);
        public IAutomationPattern<ISynchronizedInputPattern> SynchronizedInput => GetOrCreate(ref _synchronizedInputPattern, InitializeSynchronizedInputPattern);
        public IAutomationPattern<ITableItemPattern> TableItem => GetOrCreate(ref _tableItemPattern, InitializeTableItemPattern);
        public IAutomationPattern<ITablePattern> Table => GetOrCreate(ref _tablePattern, InitializeTablePattern);
        public IAutomationPattern<ITextChildPattern> TextChild => GetOrCreate(ref _textChildPattern, InitializeTextChildPattern);
        public IAutomationPattern<ITextEditPattern> TextEdit => GetOrCreate(ref _textEditPattern, InitializeTextEditPattern);
        public IAutomationPattern<IText2Pattern> Text2 => GetOrCreate(ref _text2Pattern, InitializeText2Pattern);
        public IAutomationPattern<ITextPattern> Text => GetOrCreate(ref _textPattern, InitializeTextPattern);
        public IAutomationPattern<ITogglePattern> Toggle => GetOrCreate(ref _togglePattern, InitializeTogglePattern);
        public IAutomationPattern<ITransform2Pattern> Transform2 => GetOrCreate(ref _transform2Pattern, InitializeTransform2Pattern);
        public IAutomationPattern<ITransformPattern> Transform => GetOrCreate(ref _transformPattern, InitializeTransformPattern);
        public IAutomationPattern<IValuePattern> Value => GetOrCreate(ref _valuePattern, InitializeValuePattern);
        public IAutomationPattern<IVirtualizedItemPattern> VirtualizedItem => GetOrCreate(ref _virtualizedItemPattern, InitializeVirtualizedItemPattern);
        public IAutomationPattern<IWindowPattern> Window => GetOrCreate(ref _windowPattern, InitializeWindowPattern);

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

        private IAutomationPattern<T> GetOrCreate<T>(ref IAutomationPattern<T> val, Func<IAutomationPattern<T>> initFunc) where T : IPattern
        {
            return val ?? (val = initFunc());
        }
    }
}
