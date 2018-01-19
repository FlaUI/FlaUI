using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.Core
{
    public interface IEventLibrary
    {
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
    }
}
