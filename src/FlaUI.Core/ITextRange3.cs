using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core
{
    public interface ITextRange3 : ITextRange2
    {
        AutomationElement GetEnclosingElementBuildCache(CacheRequest cacheRequest);
        AutomationElement[] GetChildrenBuildCache(CacheRequest cacheRequest);
        object[] GetAttributeValues(TextAttributeId[] attributeIds);
    }
}
