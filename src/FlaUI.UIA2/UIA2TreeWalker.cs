using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.UIA2.Converters;
using FlaUI.UIA2.Tools;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public class UIA2TreeWalker : ITreeWalker
    {
        public UIA2Automation Automation { get; }
        public UIA.TreeWalker NativeTreeWalker { get; }

        public UIA2TreeWalker(UIA2Automation automation, UIA.TreeWalker nativeTreeWalker)
        {
            Automation = automation;
            NativeTreeWalker = nativeTreeWalker;
        }

        public AutomationElement GetParent(AutomationElement element, ICacheRequest cacheRequest = null)
        {
            var parent = cacheRequest == null ?
                NativeTreeWalker.GetParent(element.ToNative()) :
                NativeTreeWalker.GetParent(element.ToNative(), cacheRequest.ToNative());
            return Automation.WrapNativeElement(parent);
        }

        public AutomationElement GetFirstChild(AutomationElement element, ICacheRequest cacheRequest = null)
        {
            var child = cacheRequest == null ?
                NativeTreeWalker.GetFirstChild(element.ToNative()) :
                NativeTreeWalker.GetFirstChild(element.ToNative(), cacheRequest.ToNative());
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetLastChild(AutomationElement element, ICacheRequest cacheRequest = null)
        {
            var child = cacheRequest == null ?
                NativeTreeWalker.GetLastChild(element.ToNative()) :
                NativeTreeWalker.GetLastChild(element.ToNative(), cacheRequest.ToNative());
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetNextSibling(AutomationElement element, ICacheRequest cacheRequest = null)
        {
            var child = cacheRequest == null ?
                NativeTreeWalker.GetNextSibling(element.ToNative()) :
                NativeTreeWalker.GetNextSibling(element.ToNative(), cacheRequest.ToNative());
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetPreviousSibling(AutomationElement element, ICacheRequest cacheRequest = null)
        {
            var child = cacheRequest == null ?
                NativeTreeWalker.GetPreviousSibling(element.ToNative()) :
                NativeTreeWalker.GetPreviousSibling(element.ToNative(), cacheRequest.ToNative());
            return Automation.WrapNativeElement(child);
        }
    }
}
