using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.Core
{
    public interface ITreeWalker
    {
        AutomationElement GetParent(AutomationElement element);

        AutomationElement GetFirstChild(AutomationElement element);

        AutomationElement GetLastChild(AutomationElement element);

        AutomationElement GetNextSibling(AutomationElement element);

        AutomationElement GetPreviousSibling(AutomationElement element);
    }
}
