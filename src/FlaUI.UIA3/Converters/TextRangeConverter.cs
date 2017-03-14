using FlaUI.Core;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Converters
{
    public static class TextRangeConverter
    {
        public static ITextRange[] NativeArrayToManaged(UIA3Automation automation, UIA.IUIAutomationTextRangeArray nativeTextRangeArray)
        {
            if (nativeTextRangeArray == null)
            {
                return new ITextRange[0];
            }
            var retArray = new ITextRange[nativeTextRangeArray.Length];
            for (var i = 0; i < nativeTextRangeArray.Length; i++)
            {
                retArray[i] = NativeToManaged(automation, nativeTextRangeArray.GetElement(i));
            }
            return retArray;
        }
        
        public static UIA3TextRange NativeToManaged(UIA3Automation automation, UIA.IUIAutomationTextRange nativeTextRange)
        {
            return nativeTextRange == null ? null : new UIA3TextRange(automation, nativeTextRange);
        }

        public static UIA3TextRange2 NativeToManaged(UIA3Automation automation, UIA.IUIAutomationTextRange2 nativeTextRange2)
        {
            return nativeTextRange2 == null ? null : new UIA3TextRange2(automation, nativeTextRange2);
        }
    }
}
