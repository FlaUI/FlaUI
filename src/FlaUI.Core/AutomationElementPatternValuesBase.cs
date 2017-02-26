using FlaUI.Core.Patterns;

namespace FlaUI.Core
{
    public abstract class AutomationElementPatternValuesBase
    {
        public abstract IAutomationPattern<IAnnotationPattern> Annotation { get; }
        public abstract IAutomationPattern<IDockPattern> Dock { get; }
        public abstract IAutomationPattern<IDragPattern> Drag { get; }
        public abstract IAutomationPattern<IDropTargetPattern> DropTarget { get; }
        public abstract IAutomationPattern<IExpandCollapsePattern> ExpandCollapse { get; }
        public abstract IAutomationPattern<IGridItemPattern> GridItem { get; }
        public abstract IAutomationPattern<IGridPattern> Grid { get; }
        public abstract IAutomationPattern<IInvokePattern> Invoke { get; }
        public abstract IAutomationPattern<IItemContainerPattern> ItemContainer { get; }
        public abstract IAutomationPattern<ILegacyIAccessiblePattern> LegacyIAccessible { get; }
        public abstract IAutomationPattern<IMultipleViewPattern> MultipleView { get; }
        public abstract IAutomationPattern<IObjectModelPattern> ObjectModel { get; }
        public abstract IAutomationPattern<IRangeValuePattern> RangeValue { get; }
        public abstract IAutomationPattern<IScrollItemPattern> ScrollItem { get; }
        public abstract IAutomationPattern<IScrollPattern> Scroll { get; }
        public abstract IAutomationPattern<ISelectionItemPattern> SelectionItem { get; }
        public abstract IAutomationPattern<ISelectionPattern> Selection { get; }
        public abstract IAutomationPattern<ISpreadsheetItemPattern> SpreadsheetItem { get; }
        public abstract IAutomationPattern<ISpreadsheetPattern> Spreadsheet { get; }
        public abstract IAutomationPattern<IStylesPattern> Styles { get; }
        public abstract IAutomationPattern<ISynchronizedInputPattern> SynchronizedInput { get; }
        public abstract IAutomationPattern<ITableItemPattern> TableItem { get; }
        public abstract IAutomationPattern<ITablePattern> Table { get; }
        public abstract IAutomationPattern<ITextChildPattern> TextChild { get; }
        public abstract IAutomationPattern<ITextEditPattern> TextEdit { get; }
        public abstract IAutomationPattern<IText2Pattern> Text2 { get; }
        public abstract IAutomationPattern<ITextPattern> Text { get; }
        public abstract IAutomationPattern<ITogglePattern> Toggle { get; }
        public abstract IAutomationPattern<ITransform2Pattern> Transform2 { get; }
        public abstract IAutomationPattern<ITransformPattern> Transform { get; }
        public abstract IAutomationPattern<IValuePattern> Value { get; }
        public abstract IAutomationPattern<IVirtualizedItemPattern> VirtualizedItem { get; }
        public abstract IAutomationPattern<IWindowPattern> Window { get; }
    }
}
