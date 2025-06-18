using FlaUI.Core.AutomationElements;

namespace Inspector
{
    public class AutomationElementSelectedEventArgs(AutomationElement element) : EventArgs
    {
        public AutomationElement Element { get; } = element ?? throw new ArgumentNullException(nameof(element));
    }
}
