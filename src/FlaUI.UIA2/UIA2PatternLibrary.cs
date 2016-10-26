using FlaUI.Core;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;

namespace FlaUI.UIA2
{
    public class UIA2PatternLibrary : IPatternLibrary
    {
        public PatternId AnnotationPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId DockPattern => Patterns.DockPattern.Pattern;
        public PatternId DragPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId DropTargetPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId ExpandCollapsePattern => Patterns.ExpandCollapsePattern.Pattern;
        public PatternId GridItemPattern => Patterns.GridItemPattern.Pattern;
        public PatternId GridPattern => Patterns.GridPattern.Pattern;
        public PatternId InvokePattern => Patterns.InvokePattern.Pattern;
        public PatternId ItemContainerPattern => Patterns.ItemContainerPattern.Pattern;
        public PatternId LegacyIAccessiblePattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId MultipleViewPattern => Patterns.MultipleViewPattern.Pattern;
        public PatternId ObjectModelPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId RangeValuePattern => Patterns.RangeValuePattern.Pattern;
        public PatternId ScrollItemPattern => Patterns.ScrollItemPattern.Pattern;
        public PatternId ScrollPattern => Patterns.ScrollPattern.Pattern;
        public PatternId SelectionItemPattern => Patterns.SelectionItemPattern.Pattern;
        public PatternId SelectionPattern => Patterns.SelectionPattern.Pattern;
        public PatternId SpreadsheetItemPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId SpreadsheetPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId StylesPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId SynchronizedInputPattern => Patterns.SynchronizedInputPattern.Pattern;
        public PatternId TableItemPattern => Patterns.TableItemPattern.Pattern;
        public PatternId TablePattern => Patterns.TablePattern.Pattern;
        public PatternId TextChildPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId TextEditPattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId Text2Pattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId TextPattern => Patterns.TextPattern.Pattern;
        public PatternId TogglePattern => Patterns.TogglePattern.Pattern;
        public PatternId Transform2Pattern { get { throw new NotSupportedByUIA2Exception(); } }
        public PatternId TransformPattern => Patterns.TransformPattern.Pattern;
        public PatternId ValuePattern => Patterns.ValuePattern.Pattern;
        public PatternId VirtualizedItemPattern => Patterns.VirtualizedItemPattern.Pattern;
        public PatternId WindowPattern => Patterns.WindowPattern.Pattern;

        public PatternId[] AllSupportedPatterns => new[] {
            DockPattern,
            ExpandCollapsePattern,
            GridItemPattern,
            GridPattern,
            InvokePattern,
            ItemContainerPattern,
            MultipleViewPattern,
            RangeValuePattern,
            ScrollItemPattern,
            ScrollPattern,
            SelectionItemPattern,
            SelectionPattern,
            SynchronizedInputPattern,
            TableItemPattern,
            TablePattern,
            TextPattern,
            TogglePattern,
            TransformPattern,
            ValuePattern,
            VirtualizedItemPattern,
            WindowPattern
        };
    }
}
