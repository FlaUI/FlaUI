using FlaUI.Core;
using FlaUI.UIA3.Converters;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Extensions
{
    public static class CacheRequestExtensions
    {
        public static UIA.IUIAutomationCacheRequest ToNative(this CacheRequest cacheRequest, UIA3Automation automation)
        {
            var nativeCacheRequest = automation.NativeAutomation.CreateCacheRequest();
            nativeCacheRequest.AutomationElementMode = (UIA.AutomationElementMode)cacheRequest.AutomationElementMode;
            nativeCacheRequest.TreeFilter = ConditionConverter.ToNative(automation, cacheRequest.TreeFilter);
            nativeCacheRequest.TreeScope = (UIA.TreeScope)cacheRequest.TreeScope;
            foreach (var pattern in cacheRequest.Patterns)
            {
                nativeCacheRequest.AddPattern(pattern.Id);
            }
            foreach (var property in cacheRequest.Properties)
            {
                nativeCacheRequest.AddProperty(property.Id);
            }
            return nativeCacheRequest;
        }
    }
}
