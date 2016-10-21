using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Patterns;
using FlaUI.UIA2.Patterns;

namespace FlaUI.UIA2
{
    public class UIA2EventLibrary : IEventLibrary
    {
        public UIA2EventLibrary()
        {
            Element = new UIA2AutomationElementEvents();
            Invoke = new InvokePatternEvents();
            SelectionItem = new SelectionItemPatternEvents();
            Selection = new SelectionPatternEvents();
            SynchronizedInput = new SynchronizedInputPatternEvents();
            Text = new TextPatternEvents();
            Window = new WindowPatternEvents();
        }

        public IAutomationElementEvents Element { get; }
        public IDragPatternEvents Drag { get {throw new NotSupportedByUIA2Exception();} }
        public IDropTargetPatternEvents DropTarget { get { throw new NotSupportedByUIA2Exception(); } }
        public IInvokePatternEvents Invoke { get; }
        public ISelectionItemPatternEvents SelectionItem { get; }
        public ISelectionPatternEvents Selection { get; }
        public ISynchronizedInputPatternEvents SynchronizedInput { get; }
        public ITextEditPatternEvents TextEdit { get { throw new NotSupportedByUIA2Exception(); } }
        public ITextPatternEvents Text { get; }
        public IWindowPatternEvents Window { get; }
    }
}
