using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
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

        public AnnotationPattern GetAnnotationPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationAnnotationPattern>(AnnotationPattern.Pattern);
            return nativePattern == null ? null : new AnnotationPattern(_automationElement, nativePattern);
        }

        public DockPattern GetDockPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationDockPattern>(DockPattern.Pattern);
            return nativePattern == null ? null : new DockPattern(_automationElement, nativePattern);
        }

        public DragPattern GetDragPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationDragPattern>(DragPattern.Pattern);
            return nativePattern == null ? null : new DragPattern(_automationElement, nativePattern);
        }

        public DropTargetPattern GetDropTargetPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationDropTargetPattern>(DropTargetPattern.Pattern);
            return nativePattern == null ? null : new DropTargetPattern(_automationElement, nativePattern);
        }

        public ExpandCollapsePattern GetExpandCollapsePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationExpandCollapsePattern>(ExpandCollapsePattern.Pattern);
            return nativePattern == null ? null : new ExpandCollapsePattern(_automationElement, nativePattern);
        }

        public GridItemPattern GetGridItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationGridItemPattern>(GridItemPattern.Pattern);
            return nativePattern == null ? null : new GridItemPattern(_automationElement, nativePattern);
        }

        public GridPattern GetGridPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationGridPattern>(GridPattern.Pattern);
            return nativePattern == null ? null : new GridPattern(_automationElement, nativePattern);
        }

        public InvokePattern GetInvokePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationInvokePattern>(InvokePattern.Pattern);
            return nativePattern == null ? null : new InvokePattern(_automationElement, nativePattern);
        }

        public ItemContainerPattern GetItemContainerPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationItemContainerPattern>(ItemContainerPattern.Pattern);
            return nativePattern == null ? null : new ItemContainerPattern(_automationElement, nativePattern);
        }

        public LegacyIAccessiblePattern GetLegacyIAccessiblePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationLegacyIAccessiblePattern>(LegacyIAccessiblePattern.Pattern);
            return nativePattern == null ? null : new LegacyIAccessiblePattern(_automationElement, nativePattern);
        }

        public MultipleViewPattern GetMultipleViewPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationMultipleViewPattern>(MultipleViewPattern.Pattern);
            return nativePattern == null ? null : new MultipleViewPattern(_automationElement, nativePattern);
        }

        public ObjectModelPattern GetObjectModelPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationObjectModelPattern>(ObjectModelPattern.Pattern);
            return nativePattern == null ? null : new ObjectModelPattern(_automationElement, nativePattern);
        }

        public RangeValuePattern GetRangeValuePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationRangeValuePattern>(RangeValuePattern.Pattern);
            return nativePattern == null ? null : new RangeValuePattern(_automationElement, nativePattern);
        }

        public ScrollItemPattern GetScrollItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationScrollItemPattern>(ScrollItemPattern.Pattern);
            return nativePattern == null ? null : new ScrollItemPattern(_automationElement, nativePattern);
        }

        public ScrollPattern GetScrollPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationScrollPattern>(ScrollPattern.Pattern);
            return nativePattern == null ? null : new ScrollPattern(_automationElement, nativePattern);
        }

        public SelectionItemPattern GetSelectionItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSelectionItemPattern>(SelectionItemPattern.Pattern);
            return nativePattern == null ? null : new SelectionItemPattern(_automationElement, nativePattern);
        }

        public SelectionPattern GetSelectionPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSelectionPattern>(SelectionPattern.Pattern);
            return nativePattern == null ? null : new SelectionPattern(_automationElement, nativePattern);
        }

        public SpreadsheetItemPattern GetSpreadsheetItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSpreadsheetItemPattern>(SpreadsheetItemPattern.Pattern);
            return nativePattern == null ? null : new SpreadsheetItemPattern(_automationElement, nativePattern);
        }

        public SpreadsheetPattern GetSpreadsheetPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSpreadsheetPattern>(SpreadsheetPattern.Pattern);
            return nativePattern == null ? null : new SpreadsheetPattern(_automationElement, nativePattern);
        }

        public StylesPattern GetStylesPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationStylesPattern>(StylesPattern.Pattern);
            return nativePattern == null ? null : new StylesPattern(_automationElement, nativePattern);
        }

        public SynchronizedInputPattern GetSynchronizedInputPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationSynchronizedInputPattern>(SynchronizedInputPattern.Pattern);
            return nativePattern == null ? null : new SynchronizedInputPattern(_automationElement, nativePattern);
        }

        public TableItemPattern GetTableItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTableItemPattern>(TableItemPattern.Pattern);
            return nativePattern == null ? null : new TableItemPattern(_automationElement, nativePattern);
        }

        public TablePattern GetTablePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTablePattern>(TablePattern.Pattern);
            return nativePattern == null ? null : new TablePattern(_automationElement, nativePattern);
        }

        public TextChildPattern GetTextChildPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTextChildPattern>(TextChildPattern.Pattern);
            return nativePattern == null ? null : new TextChildPattern(_automationElement, nativePattern);
        }

        public TextEditPattern GetTextEditPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTextEditPattern>(TextEditPattern.Pattern);
            return nativePattern == null ? null : new TextEditPattern(_automationElement, nativePattern);
        }

        public Text2Pattern GetText2Pattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTextPattern2>(Text2Pattern.Pattern);
            return nativePattern == null ? null : new Text2Pattern(_automationElement, nativePattern);
        }

        public TextPattern GetTextPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTextPattern>(TextPattern.Pattern);
            return nativePattern == null ? null : new TextPattern(_automationElement, nativePattern);
        }

        public TogglePattern GetTogglePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTogglePattern>(TogglePattern.Pattern);
            return nativePattern == null ? null : new TogglePattern(_automationElement, nativePattern);
        }

        public Transform2Pattern GetTransform2Pattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTransformPattern2>(Transform2Pattern.Pattern);
            return nativePattern == null ? null : new Transform2Pattern(_automationElement, nativePattern);
        }

        public TransformPattern GetTransformPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationTransformPattern>(TransformPattern.Pattern);
            return nativePattern == null ? null : new TransformPattern(_automationElement, nativePattern);
        }

        public ValuePattern GetValuePattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationValuePattern>(ValuePattern.Pattern);
            return nativePattern == null ? null : new ValuePattern(_automationElement, nativePattern);
        }

        public VirtualizedItemPattern GetVirtualizedItemPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationVirtualizedItemPattern>(VirtualizedItemPattern.Pattern);
            return nativePattern == null ? null : new VirtualizedItemPattern(_automationElement, nativePattern);
        }

        public WindowPattern GetWindowPattern()
        {
            var nativePattern = GetNativePatternAs<IUIAutomationWindowPattern>(WindowPattern.Pattern);
            return nativePattern == null ? null : new WindowPattern(_automationElement, nativePattern);
        }

        /// <summary>
        /// Generic method to get any native pattern and cast it to the desired type
        /// </summary>
        public T GetNativePatternAs<T>(PatternId pattern) where T : class
        {
            var nativePattern = _automationElement.NativeElement.GetCurrentPattern(pattern.Id);
            return (T)nativePattern;
        }
    }
}
