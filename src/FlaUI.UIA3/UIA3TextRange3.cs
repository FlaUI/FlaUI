using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Extensions;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3
{
    public class UIA3TextRange3 : UIA3TextRange2, ITextRange3
    {
        public UIA.IUIAutomationTextRange3 NativeRange3 { get; }

        public UIA3TextRange3(UIA3Automation automation, UIA.IUIAutomationTextRange3 nativeRange)
            : base(automation, nativeRange)
        {
            NativeRange3 = nativeRange;
        }

        public AutomationElement GetEnclosingElementBuildCache(CacheRequest cacheRequest)
        {
            var nativeCacheRequest = cacheRequest.ToNative(Automation);
            var nativeElement = Com.Call(() => NativeRange3.GetEnclosingElementBuildCache(nativeCacheRequest));
            return AutomationElementConverter.NativeToManaged(Automation, nativeElement);
        }

        public AutomationElement[] GetChildrenBuildCache(CacheRequest cacheRequest)
        {
            var nativeCacheRequest = cacheRequest.ToNative(Automation);
            var nativeElements = Com.Call(() => NativeRange3.GetChildrenBuildCache(nativeCacheRequest));
            return AutomationElementConverter.NativeArrayToManaged(Automation, nativeElements);
        }

        public object[] GetAttributeValues(TextAttributeId[] attributeIds)
        {
            throw new NotImplementedException("Currently not done as the parameter of the interop is wrong.");
        }
    }
}
