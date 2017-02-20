using FlaUI.Core;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Tools
{
    public static class CacheRequestExtensions
    {
        public static UIA.IUIAutomationCacheRequest ToNative(this IBasicCacheRequest cacheRequest)
        {
            return ((UIA3BasicCacheRequest)cacheRequest)?.NativeCacheRequest;
        }
    }
}
