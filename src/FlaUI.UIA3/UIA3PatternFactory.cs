using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Patterns;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3PatternFactory : IPatternFactory
    {
        public UIA3AutomationObject AutomationObject { get; private set; }

        internal UIA3PatternFactory(UIA3AutomationObject automationObject)
        {
            AutomationObject = automationObject;
        }

        //public AnnotationPattern GetAnnotationPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationAnnotationPattern>(AnnotationPattern.Pattern);
        //    return nativePattern == null ? null : new AnnotationPattern(AutomationObject, nativePattern);
        //}

        //public DockPattern GetDockPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationDockPattern>(DockPattern.Pattern);
        //    return nativePattern == null ? null : new DockPattern(AutomationObject, nativePattern);
        //}

        //public DragPattern GetDragPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationDragPattern>(DragPattern.Pattern);
        //    return nativePattern == null ? null : new DragPattern(AutomationObject, nativePattern);
        //}

        //public DropTargetPattern GetDropTargetPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationDropTargetPattern>(DropTargetPattern.Pattern);
        //    return nativePattern == null ? null : new DropTargetPattern(AutomationObject, nativePattern);
        //}

        //public ExpandCollapsePattern GetExpandCollapsePattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationExpandCollapsePattern>(ExpandCollapsePattern.Pattern);
        //    return nativePattern == null ? null : new ExpandCollapsePattern(AutomationObject, nativePattern);
        //}

        //public GridItemPattern GetGridItemPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationGridItemPattern>(GridItemPattern.Pattern);
        //    return nativePattern == null ? null : new GridItemPattern(AutomationObject, nativePattern);
        //}

        //public GridPattern GetGridPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationGridPattern>(GridPattern.Pattern);
        //    return nativePattern == null ? null : new GridPattern(AutomationObject, nativePattern);
        //}

        public IInvokePattern GetInvokePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationInvokePattern>(InvokePattern.Pattern);
            return nativePattern == null ? null : new InvokePattern(AutomationObject, nativePattern);
        }

        //public ItemContainerPattern GetItemContainerPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationItemContainerPattern>(ItemContainerPattern.Pattern);
        //    return nativePattern == null ? null : new ItemContainerPattern(AutomationObject, nativePattern);
        //}

        //public LegacyIAccessiblePattern GetLegacyIAccessiblePattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationLegacyIAccessiblePattern>(LegacyIAccessiblePattern.Pattern);
        //    return nativePattern == null ? null : new LegacyIAccessiblePattern(AutomationObject, nativePattern);
        //}

        //public MultipleViewPattern GetMultipleViewPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationMultipleViewPattern>(MultipleViewPattern.Pattern);
        //    return nativePattern == null ? null : new MultipleViewPattern(AutomationObject, nativePattern);
        //}

        //public ObjectModelPattern GetObjectModelPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationObjectModelPattern>(ObjectModelPattern.Pattern);
        //    return nativePattern == null ? null : new ObjectModelPattern(AutomationObject, nativePattern);
        //}

        //public RangeValuePattern GetRangeValuePattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationRangeValuePattern>(RangeValuePattern.Pattern);
        //    return nativePattern == null ? null : new RangeValuePattern(AutomationObject, nativePattern);
        //}

        //public ScrollItemPattern GetScrollItemPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationScrollItemPattern>(ScrollItemPattern.Pattern);
        //    return nativePattern == null ? null : new ScrollItemPattern(AutomationObject, nativePattern);
        //}

        //public ScrollPattern GetScrollPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationScrollPattern>(ScrollPattern.Pattern);
        //    return nativePattern == null ? null : new ScrollPattern(AutomationObject, nativePattern);
        //}

        //public SelectionItemPattern GetSelectionItemPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationSelectionItemPattern>(SelectionItemPattern.Pattern);
        //    return nativePattern == null ? null : new SelectionItemPattern(AutomationObject, nativePattern);
        //}

        //public SelectionPattern GetSelectionPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationSelectionPattern>(SelectionPattern.Pattern);
        //    return nativePattern == null ? null : new SelectionPattern(AutomationObject, nativePattern);
        //}

        //public SpreadsheetItemPattern GetSpreadsheetItemPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationSpreadsheetItemPattern>(SpreadsheetItemPattern.Pattern);
        //    return nativePattern == null ? null : new SpreadsheetItemPattern(AutomationObject, nativePattern);
        //}

        //public SpreadsheetPattern GetSpreadsheetPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationSpreadsheetPattern>(SpreadsheetPattern.Pattern);
        //    return nativePattern == null ? null : new SpreadsheetPattern(AutomationObject, nativePattern);
        //}

        //public StylesPattern GetStylesPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationStylesPattern>(StylesPattern.Pattern);
        //    return nativePattern == null ? null : new StylesPattern(AutomationObject, nativePattern);
        //}

        //public SynchronizedInputPattern GetSynchronizedInputPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationSynchronizedInputPattern>(SynchronizedInputPattern.Pattern);
        //    return nativePattern == null ? null : new SynchronizedInputPattern(AutomationObject, nativePattern);
        //}

        //public TableItemPattern GetTableItemPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationTableItemPattern>(TableItemPattern.Pattern);
        //    return nativePattern == null ? null : new TableItemPattern(AutomationObject, nativePattern);
        //}

        //public TablePattern GetTablePattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationTablePattern>(TablePattern.Pattern);
        //    return nativePattern == null ? null : new TablePattern(AutomationObject, nativePattern);
        //}

        //public TextChildPattern GetTextChildPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationTextChildPattern>(TextChildPattern.Pattern);
        //    return nativePattern == null ? null : new TextChildPattern(AutomationObject, nativePattern);
        //}

        //public TextEditPattern GetTextEditPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationTextEditPattern>(TextEditPattern.Pattern);
        //    return nativePattern == null ? null : new TextEditPattern(AutomationObject, nativePattern);
        //}

        //public Text2Pattern GetText2Pattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationTextPattern2>(Text2Pattern.Pattern);
        //    return nativePattern == null ? null : new Text2Pattern(AutomationObject, nativePattern);
        //}

        //public TextPattern GetTextPattern()
        //{
        //    var nativePattern = GetNativePatternAs<UIA.IUIAutomationTextPattern>(TextPattern.Pattern);
        //    return nativePattern == null ? null : new TextPattern(AutomationObject, nativePattern);
        //}

        public ITogglePattern GetTogglePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTogglePattern>(TogglePattern.Pattern);
            return nativePattern == null ? null : new TogglePattern(AutomationObject, nativePattern);
        }

        public ITransform2Pattern GetTransform2Pattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTransformPattern2>(Transform2PatternIds.Pattern);
            return nativePattern == null ? null : new Transform2Pattern(AutomationObject, nativePattern);
        }

        public ITransformPattern GetTransformPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationTransformPattern>(TransformPatternIds.Pattern);
            return nativePattern == null ? null : new TransformPattern(AutomationObject, nativePattern);
        }

        public IValuePattern GetValuePattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationValuePattern>(ValuePatternIds.Pattern);
            return nativePattern == null ? null : new ValuePattern(AutomationObject, nativePattern);
        }

        public IVirtualizedItemPattern GetVirtualizedItemPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationVirtualizedItemPattern>(VirtualizedItemPattern.Pattern);
            return nativePattern == null ? null : new VirtualizedItemPattern(AutomationObject, nativePattern);
        }

        public IWindowPattern GetWindowPattern()
        {
            var nativePattern = GetNativePatternAs<UIA.IUIAutomationWindowPattern>(WindowPatternIds.Pattern);
            return nativePattern == null ? null : new WindowPattern(AutomationObject, nativePattern);
        }

        /// <summary>
        /// Generic method to get any native pattern and cast it to the desired type
        /// </summary>
        public T GetNativePatternAs<T>(PatternId pattern) where T : class
        {
            var nativePattern = AutomationObject.NativeElement.GetCurrentPattern(pattern.Id);
            return (T)nativePattern;
        }
    }
}
