using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Patterns;

namespace FlaUI.UIA3
{
    public class UIA3EventLibrary : IEventLibrary
    {
        public UIA3EventLibrary()
        {
            Element = new UIA3AutomationElementEvents();
            Drag = new DragPatternEvents();
            DropTarget = new DropTargetPatternEvents();
            Invoke = new InvokePatternEvents();
            SelectionItem = new SelectionItemPatternEvents();
            Selection = new SelectionPatternEvents();
            SynchronizedInput = new SynchronizedInputPatternEvents();
            TextEdit = new TextEditPatternEvents();
            Text = new TextPatternEvents();
            Window = new WindowPatternEvents();
        }

        public IAutomationElementEvents Element { get; }
        public IDragPatternEvents Drag { get; }
        public IDropTargetPatternEvents DropTarget { get; }
        public IInvokePatternEvents Invoke { get; }
        public ISelectionItemPatternEvents SelectionItem { get; }
        public ISelectionPatternEvents Selection { get; }
        public ISynchronizedInputPatternEvents SynchronizedInput { get; }
        public ITextEditPatternEvents TextEdit { get; }
        public ITextPatternEvents Text { get; }
        public IWindowPatternEvents Window { get; }
    }
}
