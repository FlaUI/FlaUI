using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUI.Core
{
    public interface ITreeWalker
    {
        AutomationElement GetParent(AutomationElement element, ICacheRequest cacheRequest = null);

        AutomationElement GetFirstChild(AutomationElement element, ICacheRequest cacheRequest = null);

        AutomationElement GetLastChild(AutomationElement element, ICacheRequest cacheRequest = null);

        AutomationElement GetNextSibling(AutomationElement element, ICacheRequest cacheRequest = null);

        AutomationElement GetPreviousSibling(AutomationElement element, ICacheRequest cacheRequest = null);
    }
}
