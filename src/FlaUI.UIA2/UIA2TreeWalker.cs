using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA2.Converters;
using FlaUI.UIA2.Extensions;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    /// <summary>
    /// Class for a UIA2 tree walker.
    /// </summary>
    public class UIA2TreeWalker : ITreeWalker
    {
        /// <summary>
        /// Creates a UIA2 tree walker.
        /// </summary>
        public UIA2TreeWalker(UIA2Automation automation, UIA.TreeWalker nativeTreeWalker)
        {
            Automation = automation;
            NativeTreeWalker = nativeTreeWalker;
        }

        /// <summary>
        /// The current <see cref="AutomationBase"/> object.
        /// </summary>
        public UIA2Automation Automation { get; }

        /// <summary>
        /// The native tree walker object.
        /// </summary>
        public UIA.TreeWalker NativeTreeWalker { get; }

        /// <inheritdoc />
        public AutomationElement GetParent(AutomationElement element)
        {
            var parent = CacheRequest.Current == null ?
                NativeTreeWalker.GetParent(element.ToNative()) :
                NativeTreeWalker.GetParent(element.ToNative(), CacheRequest.Current.ToNative());
            return Automation.WrapNativeElement(parent);
        }

        /// <inheritdoc />
        public AutomationElement GetFirstChild(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetFirstChild(element.ToNative()) :
                NativeTreeWalker.GetFirstChild(element.ToNative(), CacheRequest.Current.ToNative());
            return Automation.WrapNativeElement(child);
        }

        /// <inheritdoc />
        public AutomationElement GetLastChild(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetLastChild(element.ToNative()) :
                NativeTreeWalker.GetLastChild(element.ToNative(), CacheRequest.Current.ToNative());
            return Automation.WrapNativeElement(child);
        }

        /// <inheritdoc />
        public AutomationElement GetNextSibling(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetNextSibling(element.ToNative()) :
                NativeTreeWalker.GetNextSibling(element.ToNative(), CacheRequest.Current.ToNative());
            return Automation.WrapNativeElement(child);
        }

        /// <inheritdoc />
        public AutomationElement GetPreviousSibling(AutomationElement element)
        {
            var child = CacheRequest.Current == null ?
                NativeTreeWalker.GetPreviousSibling(element.ToNative()) :
                NativeTreeWalker.GetPreviousSibling(element.ToNative(), CacheRequest.Current.ToNative());
            return Automation.WrapNativeElement(child);
        }
    }
}
