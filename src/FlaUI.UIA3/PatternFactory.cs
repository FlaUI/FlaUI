using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Patterns;
using interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    /// <summary>
    /// Factory for the various patterns
    /// </summary>
    public class PatternFactory
    {
        private readonly AutomationElement _automationAutomationElement;

        internal PatternFactory(AutomationElement automationAutomationElement)
        {
            _automationAutomationElement = automationAutomationElement;
        }

        public AnnotationPattern GetAnnotationPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationAnnotationPattern>(AnnotationPattern.Pattern);
            return nativePattern == null ? null : new AnnotationPattern(_automationAutomationElement, nativePattern);
        }

        public DockPattern GetDockPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationDockPattern>(DockPattern.Pattern);
            return nativePattern == null ? null : new DockPattern(_automationAutomationElement, nativePattern);
        }

        public DragPattern GetDragPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationDragPattern>(DragPattern.Pattern);
            return nativePattern == null ? null : new DragPattern(_automationAutomationElement, nativePattern);
        }

        public DropTargetPattern GetDropTargetPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationDropTargetPattern>(DropTargetPattern.Pattern);
            return nativePattern == null ? null : new DropTargetPattern(_automationAutomationElement, nativePattern);
        }

        public ExpandCollapsePattern GetExpandCollapsePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationExpandCollapsePattern>(ExpandCollapsePattern.Pattern);
            return nativePattern == null ? null : new ExpandCollapsePattern(_automationAutomationElement, nativePattern);
        }

        public GridItemPattern GetGridItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationGridItemPattern>(GridItemPattern.Pattern);
            return nativePattern == null ? null : new GridItemPattern(_automationAutomationElement, nativePattern);
        }

        public GridPattern GetGridPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationGridPattern>(GridPattern.Pattern);
            return nativePattern == null ? null : new GridPattern(_automationAutomationElement, nativePattern);
        }

        public InvokePattern GetInvokePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationInvokePattern>(InvokePattern.Pattern);
            return nativePattern == null ? null : new InvokePattern(_automationAutomationElement, nativePattern);
        }

        public ItemContainerPattern GetItemContainerPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationItemContainerPattern>(ItemContainerPattern.Pattern);
            return nativePattern == null ? null : new ItemContainerPattern(_automationAutomationElement, nativePattern);
        }

        public LegacyIAccessiblePattern GetLegacyIAccessiblePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationLegacyIAccessiblePattern>(LegacyIAccessiblePattern.Pattern);
            return nativePattern == null ? null : new LegacyIAccessiblePattern(_automationAutomationElement, nativePattern);
        }

        public MultipleViewPattern GetMultipleViewPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationMultipleViewPattern>(MultipleViewPattern.Pattern);
            return nativePattern == null ? null : new MultipleViewPattern(_automationAutomationElement, nativePattern);
        }

        public ObjectModelPattern GetObjectModelPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationObjectModelPattern>(ObjectModelPattern.Pattern);
            return nativePattern == null ? null : new ObjectModelPattern(_automationAutomationElement, nativePattern);
        }

        public RangeValuePattern GetRangeValuePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationRangeValuePattern>(RangeValuePattern.Pattern);
            return nativePattern == null ? null : new RangeValuePattern(_automationAutomationElement, nativePattern);
        }

        public ScrollItemPattern GetScrollItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationScrollItemPattern>(ScrollItemPattern.Pattern);
            return nativePattern == null ? null : new ScrollItemPattern(_automationAutomationElement, nativePattern);
        }

        public ScrollPattern GetScrollPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationScrollPattern>(ScrollPattern.Pattern);
            return nativePattern == null ? null : new ScrollPattern(_automationAutomationElement, nativePattern);
        }

        public SelectionItemPattern GetSelectionItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSelectionItemPattern>(SelectionItemPattern.Pattern);
            return nativePattern == null ? null : new SelectionItemPattern(_automationAutomationElement, nativePattern);
        }

        public SelectionPattern GetSelectionPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSelectionPattern>(SelectionPattern.Pattern);
            return nativePattern == null ? null : new SelectionPattern(_automationAutomationElement, nativePattern);
        }

        public SpreadsheetItemPattern GetSpreadsheetItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSpreadsheetItemPattern>(SpreadsheetItemPattern.Pattern);
            return nativePattern == null ? null : new SpreadsheetItemPattern(_automationAutomationElement, nativePattern);
        }

        public SpreadsheetPattern GetSpreadsheetPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSpreadsheetPattern>(SpreadsheetPattern.Pattern);
            return nativePattern == null ? null : new SpreadsheetPattern(_automationAutomationElement, nativePattern);
        }

        public StylesPattern GetStylesPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationStylesPattern>(StylesPattern.Pattern);
            return nativePattern == null ? null : new StylesPattern(_automationAutomationElement, nativePattern);
        }

        public SynchronizedInputPattern GetSynchronizedInputPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSynchronizedInputPattern>(SynchronizedInputPattern.Pattern);
            return nativePattern == null ? null : new SynchronizedInputPattern(_automationAutomationElement, nativePattern);
        }

        public TableItemPattern GetTableItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTableItemPattern>(TableItemPattern.Pattern);
            return nativePattern == null ? null : new TableItemPattern(_automationAutomationElement, nativePattern);
        }

        public TablePattern GetTablePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTablePattern>(TablePattern.Pattern);
            return nativePattern == null ? null : new TablePattern(_automationAutomationElement, nativePattern);
        }

        public TextChildPattern GetTextChildPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTextChildPattern>(TextChildPattern.Pattern);
            return nativePattern == null ? null : new TextChildPattern(_automationAutomationElement, nativePattern);
        }

        public TextEditPattern GetTextEditPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTextEditPattern>(TextEditPattern.Pattern);
            return nativePattern == null ? null : new TextEditPattern(_automationAutomationElement, nativePattern);
        }

        public Text2Pattern GetText2Pattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTextPattern2>(Text2Pattern.Pattern);
            return nativePattern == null ? null : new Text2Pattern(_automationAutomationElement, nativePattern);
        }

        public TextPattern GetTextPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTextPattern>(TextPattern.Pattern);
            return nativePattern == null ? null : new TextPattern(_automationAutomationElement, nativePattern);
        }

        public TogglePattern GetTogglePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTogglePattern>(TogglePattern.Pattern);
            return nativePattern == null ? null : new TogglePattern(_automationAutomationElement, nativePattern);
        }

        public Transform2Pattern GetTransform2Pattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTransformPattern2>(Transform2Pattern.Pattern);
            return nativePattern == null ? null : new Transform2Pattern(_automationAutomationElement, nativePattern);
        }

        public TransformPattern GetTransformPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTransformPattern>(TransformPattern.Pattern);
            return nativePattern == null ? null : new TransformPattern(_automationAutomationElement, nativePattern);
        }

        public ValuePattern GetValuePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationValuePattern>(ValuePattern.Pattern);
            return nativePattern == null ? null : new ValuePattern(_automationAutomationElement, nativePattern);
        }

        public VirtualizedItemPattern GetVirtualizedItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationVirtualizedItemPattern>(VirtualizedItemPattern.Pattern);
            return nativePattern == null ? null : new VirtualizedItemPattern(_automationAutomationElement, nativePattern);
        }

        public WindowPattern GetWindowPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationWindowPattern>(WindowPattern.Pattern);
            return nativePattern == null ? null : new WindowPattern(_automationAutomationElement, nativePattern);
        }

        /// <summary>
        /// Generic method to get any native pattern and cast it to the desired type
        /// </summary>
        public T GetNativePatternAs<T>(PatternId pattern) where T : class
        {
            var nativePattern = _automationAutomationElement.NativeElement.GetCurrentPattern(pattern.Id);
            return (T)nativePattern;
        }
    }
}
