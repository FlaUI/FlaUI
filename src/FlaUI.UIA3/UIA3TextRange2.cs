using FlaUI.Core;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3TextRange2 : UIA3TextRange, ITextRange2
    {
        public UIA.IUIAutomationTextRange2 NativeRange2 { get; }

        public UIA3TextRange2(UIA3Automation automation, UIA.IUIAutomationTextRange2 nativeRange)
            : base(automation, nativeRange)
        {
            NativeRange2 = nativeRange;
        }

        public void ShowContextMenu()
        {
            ComCallWrapper.Call(() => NativeRange2.ShowContextMenu());
        }
    }
}
