using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.Core
{
    /// <summary>
    /// Interface for an event library.
    /// </summary>
    public interface IEventLibrary
    {
#pragma warning disable 1591
        IAutomationElementEventIds Element { get; }
        IDragPatternEventIds Drag { get; }
        IDropTargetPatternEventIds DropTarget { get; }
        IInvokePatternEventIds Invoke { get; }
        ISelectionItemPatternEventIds SelectionItem { get; }
        ISelectionPatternEventIds Selection { get; }
        ISynchronizedInputPatternEventIds SynchronizedInput { get; }
        ITextEditPatternEventIds TextEdit { get; }
        ITextPatternEventIds Text { get; }
        IWindowPatternEventIds Window { get; }
#pragma warning restore 1591
    }
}
