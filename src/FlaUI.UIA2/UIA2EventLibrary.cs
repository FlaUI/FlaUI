using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Patterns;

namespace FlaUI.UIA2
{
    public class UIA2EventLibrary : IEventLibrary
    {
        public UIA2EventLibrary()
        {
            Element = new UIA2AutomationElementEventIds();
            Drag = new DragPatternEventIds();
            DropTarget = new DropTargetPatternEventIds();
            Invoke = new InvokePatternEventIds();
            SelectionItem = new SelectionItemPatternEventIds();
            Selection = new SelectionPatternEventIds();
            SynchronizedInput = new SynchronizedInputPatternEventIds();
            TextEdit = new TextEditPatternEventIdIds();
            Text = new TextPatternEventIds();
            Window = new WindowPatternEventIds();
        }

        public IAutomationElementEventIds Element { get; }
        public IDragPatternEventIds Drag { get; }
        public IDropTargetPatternEventIds DropTarget { get; }
        public IInvokePatternEventIds Invoke { get; }
        public ISelectionItemPatternEventIds SelectionItem { get; }
        public ISelectionPatternEventIds Selection { get; }
        public ISynchronizedInputPatternEventIds SynchronizedInput { get; }
        public ITextEditPatternEventIds TextEdit { get; }
        public ITextPatternEventIds Text { get; }
        public IWindowPatternEventIds Window { get; }
    }
}
