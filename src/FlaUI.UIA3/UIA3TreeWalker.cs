using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3TreeWalker : ITreeWalker
    {
        public UIA3Automation Automation { get; }
        public UIA.IUIAutomationTreeWalker NativeTreeWalker { get; }

        public UIA3TreeWalker(UIA3Automation automation, UIA.IUIAutomationTreeWalker nativeTreeWalker)
        {
            Automation = automation;
            NativeTreeWalker = nativeTreeWalker;
        }

        public AutomationElement GetParent(AutomationElement element, ICacheRequest cacheRequest = null)
        {
            var parent = cacheRequest == null ?
                NativeTreeWalker.GetParentElement(element.ToNative()) :
                NativeTreeWalker.GetParentElementBuildCache(element.ToNative(), cacheRequest.ToNative());
            return Automation.WrapNativeElement(parent);
        }

        public AutomationElement GetFirstChild(AutomationElement element, ICacheRequest cacheRequest = null)
        {
            var child = cacheRequest == null ?
                NativeTreeWalker.GetFirstChildElement(element.ToNative()) :
                NativeTreeWalker.GetFirstChildElementBuildCache(element.ToNative(), cacheRequest.ToNative());
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetLastChild(AutomationElement element, ICacheRequest cacheRequest = null)
        {
            var child = cacheRequest == null ?
                NativeTreeWalker.GetLastChildElement(element.ToNative()) :
                NativeTreeWalker.GetLastChildElementBuildCache(element.ToNative(), cacheRequest.ToNative());
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetNextSibling(AutomationElement element, ICacheRequest cacheRequest = null)
        {
            var child = cacheRequest == null ?
                NativeTreeWalker.GetNextSiblingElement(element.ToNative()) :
                NativeTreeWalker.GetNextSiblingElementBuildCache(element.ToNative(), cacheRequest.ToNative());
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetPreviousSibling(AutomationElement element, ICacheRequest cacheRequest = null)
        {
            var child = cacheRequest == null ?
                NativeTreeWalker.GetPreviousSiblingElement(element.ToNative()) :
                NativeTreeWalker.GetPreviousSiblingElementBuildCache(element.ToNative(), cacheRequest.ToNative());
            return Automation.WrapNativeElement(child);
        }
    }
}
