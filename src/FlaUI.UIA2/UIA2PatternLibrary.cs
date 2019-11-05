using FlaUI.Core;
using FlaUI.Core.Identifiers;

namespace FlaUI.UIA2
{
    /// <summary>
    /// Implements a pattern library for the UIA2 patterns.
    /// </summary>
    public class UIA2PatternLibrary : IPatternLibrary
    {
#pragma warning disable 1591
        public PatternId AnnotationPattern => PatternId.NotSupportedByFramework;
        public PatternId DockPattern => Patterns.DockPattern.Pattern;
        public PatternId DragPattern => PatternId.NotSupportedByFramework;
        public PatternId DropTargetPattern => PatternId.NotSupportedByFramework;
        public PatternId ExpandCollapsePattern => Patterns.ExpandCollapsePattern.Pattern;
        public PatternId GridItemPattern => Patterns.GridItemPattern.Pattern;
        public PatternId GridPattern => Patterns.GridPattern.Pattern;
        public PatternId InvokePattern => Patterns.InvokePattern.Pattern;
#if NET35
        public PatternId ItemContainerPattern => PatternId.NotSupportedByFramework;
#else
        public PatternId ItemContainerPattern => Patterns.ItemContainerPattern.Pattern;
#endif
        public PatternId LegacyIAccessiblePattern => PatternId.NotSupportedByFramework;
        public PatternId MultipleViewPattern => Patterns.MultipleViewPattern.Pattern;
        public PatternId ObjectModelPattern => PatternId.NotSupportedByFramework;
        public PatternId RangeValuePattern => Patterns.RangeValuePattern.Pattern;
        public PatternId ScrollItemPattern => Patterns.ScrollItemPattern.Pattern;
        public PatternId ScrollPattern => Patterns.ScrollPattern.Pattern;
        public PatternId SelectionItemPattern => Patterns.SelectionItemPattern.Pattern;
        public PatternId SelectionPattern => Patterns.SelectionPattern.Pattern;
        public PatternId SpreadsheetItemPattern => PatternId.NotSupportedByFramework;
        public PatternId SpreadsheetPattern => PatternId.NotSupportedByFramework;
        public PatternId StylesPattern => PatternId.NotSupportedByFramework;
#if NET35
        public PatternId SynchronizedInputPattern => PatternId.NotSupportedByFramework;
#else
        public PatternId SynchronizedInputPattern => Patterns.SynchronizedInputPattern.Pattern;
#endif
        public PatternId TableItemPattern => Patterns.TableItemPattern.Pattern;
        public PatternId TablePattern => Patterns.TablePattern.Pattern;
        public PatternId TextChildPattern => PatternId.NotSupportedByFramework;
        public PatternId TextEditPattern => PatternId.NotSupportedByFramework;
        public PatternId Text2Pattern => PatternId.NotSupportedByFramework;
        public PatternId TextPattern => Patterns.TextPattern.Pattern;
        public PatternId TogglePattern => Patterns.TogglePattern.Pattern;
        public PatternId Transform2Pattern => PatternId.NotSupportedByFramework;
        public PatternId TransformPattern => Patterns.TransformPattern.Pattern;
        public PatternId ValuePattern => Patterns.ValuePattern.Pattern;
#if NET35
        public PatternId VirtualizedItemPattern => PatternId.NotSupportedByFramework;
#else
        public PatternId VirtualizedItemPattern => Patterns.VirtualizedItemPattern.Pattern;
#endif
        public PatternId WindowPattern => Patterns.WindowPattern.Pattern;
#pragma warning restore 1591

        /// <inheritdoc />
        public PatternId[] AllForCurrentFramework => new[] {
            DockPattern,
            ExpandCollapsePattern,
            GridItemPattern,
            GridPattern,
            InvokePattern,
#if !NET35
            ItemContainerPattern,
#endif
            MultipleViewPattern,
            RangeValuePattern,
            ScrollItemPattern,
            ScrollPattern,
            SelectionItemPattern,
            SelectionPattern,
#if !NET35
            SynchronizedInputPattern,
#endif
            TableItemPattern,
            TablePattern,
            TextPattern,
            TogglePattern,
            TransformPattern,
            ValuePattern,
#if !NET35
            VirtualizedItemPattern,
#endif
            WindowPattern
        };
    }
}
