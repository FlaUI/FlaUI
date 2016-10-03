using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class TextRange2 : TextRange
    {
        public UIA.IUIAutomationTextRange2 NativeRange2 { get; }

        internal TextRange2(UIA3Automation automation, UIA.IUIAutomationTextRange2 nativeRange)
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
