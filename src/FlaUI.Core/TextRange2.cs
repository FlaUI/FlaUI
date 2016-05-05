using FlaUI.Core.Tools;
using interop.UIAutomationCore;

namespace FlaUI.Core
{
    public class TextRange2 : TextRange
    {
        public IUIAutomationTextRange2 NativeRange2 { get; private set; }

        internal TextRange2(Automation automation, IUIAutomationTextRange2 nativeRange)
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
