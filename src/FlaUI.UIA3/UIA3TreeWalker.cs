using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Extensions;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3
{
    /// <summary>
    /// Class for a UIA3 tree walker.
    /// </summary>
    public class UIA3TreeWalker : ITreeWalker
    {
        /// <summary>
        /// Creates a UIA3 tree walker.
        /// </summary>
        public UIA3TreeWalker(UIA3Automation automation, UIA.IUIAutomationTreeWalker nativeTreeWalker)
        {
            Automation = automation;
            NativeTreeWalker = nativeTreeWalker;
        }

        /// <summary>
        /// The current <see cref="AutomationBase"/> object.
        /// </summary>
        public UIA3Automation Automation { get; }

        /// <summary>
        /// The native tree walker object.
        /// </summary>
        public UIA.IUIAutomationTreeWalker NativeTreeWalker { get; }

        /// <inheritdoc />
        public AutomationElement GetParent(AutomationElement element)
        {
            var parent = CacheRequest.Current == null ?
                NativeTreeWalker.GetParentElement(element.ToNative()) :
                NativeTreeWalker.GetParentElementBuildCache(element.ToNative(), CacheRequest.Current.ToNative(Automation));
            return Automation.WrapNativeElement(parent);
        }

        /// <inheritdoc />
        public AutomationElement GetFirstChild(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetFirstChildElement(element.ToNative()) :
                NativeTreeWalker.GetFirstChildElementBuildCache(element.ToNative(), CacheRequest.Current.ToNative(Automation));
            return Automation.WrapNativeElement(child);
        }

        /// <inheritdoc />
        public AutomationElement GetLastChild(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetLastChildElement(element.ToNative()) :
                NativeTreeWalker.GetLastChildElementBuildCache(element.ToNative(), CacheRequest.Current.ToNative(Automation));
            return Automation.WrapNativeElement(child);
        }

        /// <inheritdoc />
        public AutomationElement GetNextSibling(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetNextSiblingElement(element.ToNative()) :
                NativeTreeWalker.GetNextSiblingElementBuildCache(element.ToNative(), CacheRequest.Current.ToNative(Automation));
            return Automation.WrapNativeElement(child);
        }

        /// <inheritdoc />
        public AutomationElement GetPreviousSibling(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetPreviousSiblingElement(element.ToNative()) :
                NativeTreeWalker.GetPreviousSiblingElementBuildCache(element.ToNative(), CacheRequest.Current.ToNative(Automation));
            return Automation.WrapNativeElement(child);
        }
    }
}
