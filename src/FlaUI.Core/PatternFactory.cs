using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Patterns;
using interop.UIAutomationCore;

namespace FlaUI.Core
{
    /// <summary>
    /// Factory for the various patterns
    /// </summary>
    public class PatternFactory
    {
        private readonly AutomationElement _automationElement;

        internal PatternFactory(AutomationElement automationElement)
        {
            _automationElement = automationElement;
        }

        /// <summary>
        /// Generic method to get any pattern and cast it to the desired type
        /// </summary>
        public T GetPatternAs<T>(PatternType patternType)
        {
            var pattern = _automationElement.NativeElement.GetCurrentPattern((int)patternType);
            return (T)pattern;
        }

        public AnnotationPattern GetAnnotationPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationAnnotationPattern>(AnnotationPattern.Pattern);
            return new AnnotationPattern(_automationElement, nativePattern);
        }

        public DockPattern GetDockPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationDockPattern>(DockPattern.Pattern);
            return new DockPattern(_automationElement, nativePattern);
        }

        public DragPattern GetDragPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationDragPattern>(DragPattern.Pattern);
            return new DragPattern(_automationElement, nativePattern);
        }

        public DropTargetPattern GetDropTargetPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationDropTargetPattern>(DropTargetPattern.Pattern);
            return new DropTargetPattern(_automationElement, nativePattern);
        }

        public ExpandCollapsePattern GetExpandCollapsePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationExpandCollapsePattern>(ExpandCollapsePattern.Pattern);
            return new ExpandCollapsePattern(_automationElement, nativePattern);
        }

        public GridItemPattern GetGridItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationGridItemPattern>(GridItemPattern.Pattern);
            return new GridItemPattern(_automationElement, nativePattern);
        }

        public GridPattern GetGridPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationGridPattern>(GridPattern.Pattern);
            return new GridPattern(_automationElement, nativePattern);
        }

        public InvokePattern GetInvokePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationInvokePattern>(InvokePattern.Pattern);
            return new InvokePattern(_automationElement, nativePattern);
        }

        public ItemContainerPattern GetItemContainerPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationItemContainerPattern>(ItemContainerPattern.Pattern);
            return new ItemContainerPattern(_automationElement, nativePattern);
        }

        public LegacyIAccessiblePattern GetLegacyIAccessiblePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationLegacyIAccessiblePattern>(LegacyIAccessiblePattern.Pattern);
            return new LegacyIAccessiblePattern(_automationElement, nativePattern);
        }

        public MultipleViewPattern GetMultipleViewPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationMultipleViewPattern>(MultipleViewPattern.Pattern);
            return new MultipleViewPattern(_automationElement, nativePattern);
        }

        public ObjectModelPattern GetObjectModelPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationObjectModelPattern>(ObjectModelPattern.Pattern);
            return new ObjectModelPattern(_automationElement, nativePattern);
        }

        public RangeValuePattern GetRangeValuePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationRangeValuePattern>(RangeValuePattern.Pattern);
            return new RangeValuePattern(_automationElement, nativePattern);
        }

        public ScrollItemPattern GetScrollItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationScrollItemPattern>(ScrollItemPattern.Pattern);
            return new ScrollItemPattern(_automationElement, nativePattern);
        }

        public ScrollPattern GetScrollPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationScrollPattern>(ScrollPattern.Pattern);
            return new ScrollPattern(_automationElement, nativePattern);
        }

        public SelectionItemPattern GetSelectionItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSelectionItemPattern>(SelectionItemPattern.Pattern);
            return new SelectionItemPattern(_automationElement, nativePattern);
        }

        public SelectionPattern GetSelectionPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSelectionPattern>(SelectionPattern.Pattern);
            return new SelectionPattern(_automationElement, nativePattern);
        }

        public SpreadsheetItemPattern GetSpreadsheetItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSpreadsheetItemPattern>(SpreadsheetItemPattern.Pattern);
            return new SpreadsheetItemPattern(_automationElement, nativePattern);
        }

        public SpreadsheetPattern GetSpreadsheetPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSpreadsheetPattern>(SpreadsheetPattern.Pattern);
            return new SpreadsheetPattern(_automationElement, nativePattern);
        }

        public StylesPattern GetStylesPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationStylesPattern>(StylesPattern.Pattern);
            return new StylesPattern(_automationElement, nativePattern);
        }

        public SynchronizedInputPattern GetSynchronizedInputPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSynchronizedInputPattern>(SynchronizedInputPattern.Pattern);
            return new SynchronizedInputPattern(_automationElement, nativePattern);
        }

        public TableItemPattern GetTableItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTableItemPattern>(TableItemPattern.Pattern);
            return new TableItemPattern(_automationElement, nativePattern);
        }

        public TablePattern GetTablePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTablePattern>(TablePattern.Pattern);
            return new TablePattern(_automationElement, nativePattern);
        }

        public TextChildPattern GetTextChildPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTextChildPattern>(TextChildPattern.Pattern);
            return new TextChildPattern(_automationElement, nativePattern);
        }

        public IUIAutomationTextEditPattern GetTextEditPattern()
        {
            return GetPatternAs<IUIAutomationTextEditPattern>(PatternType.TextEdit);
        }

        public IUIAutomationTextPattern2 GetText2Pattern()
        {
            return GetPatternAs<IUIAutomationTextPattern2>(PatternType.Text2);
        }

        public IUIAutomationTextPattern GetTextPattern()
        {
            return GetPatternAs<IUIAutomationTextPattern>(PatternType.Text);
        }

        public IUIAutomationTogglePattern GetTogglePattern()
        {
            return GetPatternAs<IUIAutomationTogglePattern>(PatternType.Toggle);
        }

        public IUIAutomationTransformPattern2 GetTransform2Pattern()
        {
            return GetPatternAs<IUIAutomationTransformPattern2>(PatternType.Transform2);
        }

        public IUIAutomationTransformPattern GetTransformPattern()
        {
            return GetPatternAs<IUIAutomationTransformPattern>(PatternType.Transform);
        }

        public IUIAutomationValuePattern GetValuePattern()
        {
            return GetPatternAs<IUIAutomationValuePattern>(PatternType.Value);
        }

        public IUIAutomationVirtualizedItemPattern GetVirtualizedItemPattern()
        {
            return GetPatternAs<IUIAutomationVirtualizedItemPattern>(PatternType.VirtualizedItem);
        }

        public IUIAutomationWindowPattern GetWindowPattern()
        {
            return GetPatternAs<IUIAutomationWindowPattern>(PatternType.Window);
        }

        /// <summary>
        /// Generic method to get any native pattern and cast it to the desired type
        /// </summary>
        private T GetNativePatternAs<T>(AutomationPattern pattern)
        {
            var nativePattern = _automationElement.NativeElement.GetCurrentPattern(pattern.Id);
            return (T)nativePattern;
        }
    }
}
