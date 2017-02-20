using FlaUI.Core.Identifiers;

namespace FlaUI.Core
{
    public interface IPatternLibrary
    {
        PatternId AnnotationPattern { get; }
        PatternId DockPattern { get; }
        PatternId DragPattern { get; }
        PatternId DropTargetPattern { get; }
        PatternId ExpandCollapsePattern { get; }
        PatternId GridItemPattern { get; }
        PatternId GridPattern { get; }
        PatternId InvokePattern { get; }
        PatternId ItemContainerPattern { get; }
        PatternId LegacyIAccessiblePattern { get; }
        PatternId MultipleViewPattern { get; }
        PatternId ObjectModelPattern { get; }
        PatternId RangeValuePattern { get; }
        PatternId ScrollItemPattern { get; }
        PatternId ScrollPattern { get; }
        PatternId SelectionItemPattern { get; }
        PatternId SelectionPattern { get; }
        PatternId SpreadsheetItemPattern { get; }
        PatternId SpreadsheetPattern { get; }
        PatternId StylesPattern { get; }
        PatternId SynchronizedInputPattern { get; }
        PatternId TableItemPattern { get; }
        PatternId TablePattern { get; }
        PatternId TextChildPattern { get; }
        PatternId TextEditPattern { get; }
        PatternId Text2Pattern { get; }
        PatternId TextPattern { get; }
        PatternId TogglePattern { get; }
        PatternId Transform2Pattern { get; }
        PatternId TransformPattern { get; }
        PatternId ValuePattern { get; }
        PatternId VirtualizedItemPattern { get; }
        PatternId WindowPattern { get; }

        PatternId[] AllForCurrentFramework { get; }
    }
}
