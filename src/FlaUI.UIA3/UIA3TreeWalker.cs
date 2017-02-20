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

        public AutomationElement GetParent(AutomationElement element)
        {
            var parent = CacheRequest.Current == null ?
                NativeTreeWalker.GetParentElement(element.ToNative()) :
                NativeTreeWalker.GetParentElementBuildCache(element.ToNative(), CacheRequest.Current.ToNative());
            return Automation.WrapNativeElement(parent);
        }

        public AutomationElement GetFirstChild(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetFirstChildElement(element.ToNative()) :
                NativeTreeWalker.GetFirstChildElementBuildCache(element.ToNative(), CacheRequest.Current.ToNative());
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetLastChild(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetLastChildElement(element.ToNative()) :
                NativeTreeWalker.GetLastChildElementBuildCache(element.ToNative(), CacheRequest.Current.ToNative());
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetNextSibling(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetNextSiblingElement(element.ToNative()) :
                NativeTreeWalker.GetNextSiblingElementBuildCache(element.ToNative(), CacheRequest.Current.ToNative());
            return Automation.WrapNativeElement(child);
        }

        public AutomationElement GetPreviousSibling(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetPreviousSiblingElement(element.ToNative()) :
                NativeTreeWalker.GetPreviousSiblingElementBuildCache(element.ToNative(), CacheRequest.Current.ToNative());
            return Automation.WrapNativeElement(child);
        }
    }
}
