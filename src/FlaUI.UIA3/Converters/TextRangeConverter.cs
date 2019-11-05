using FlaUI.Core;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Converters
{
    /// <summary>
    /// A class for converting text ranges between native and FlaUIs implementation.
    /// </summary>
    public static class TextRangeConverter
    {
        /// <summary>
        /// Converts a native text range array to a managed text range array.
        /// </summary>
        /// <param name="automation">The automation to use for the conversion.</param>
        /// <param name="nativeTextRangeArray">The native text range array to convert.</param>
        /// <returns>The converted managed text range array.</returns>
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

        /// <summary>
        /// Converts a native text range to a managed text range.
        /// </summary>
        /// <param name="automation">The automation to use for the conversion.</param>
        /// <param name="nativeTextRange">The native text range to convert.</param>
        /// <returns>The converted managed text range.</returns>
        public static UIA3TextRange NativeToManaged(UIA3Automation automation, UIA.IUIAutomationTextRange nativeTextRange)
        {
            return nativeTextRange == null ? null : new UIA3TextRange(automation, nativeTextRange);
        }

        /// <summary>
        /// Converts a native text range 2 to a managed text range 2.
        /// </summary>
        /// <param name="automation">The automation to use for the conversion.</param>
        /// <param name="nativeTextRange2">The native text range 2 to convert.</param>
        /// <returns>The converted managed text range 2.</returns>
        public static UIA3TextRange2 NativeToManaged(UIA3Automation automation, UIA.IUIAutomationTextRange2 nativeTextRange2)
        {
            return nativeTextRange2 == null ? null : new UIA3TextRange2(automation, nativeTextRange2);
        }

        /// <summary>
        /// Converts a native text range 3 to a managed text range 3.
        /// </summary>
        /// <param name="automation">The automation to use for the conversion.</param>
        /// <param name="nativeTextRange3">The native text range 3 to convert.</param>
        /// <returns>The converted managed text range 3.</returns>
        public static UIA3TextRange3 NativeToManaged(UIA3Automation automation, UIA.IUIAutomationTextRange3 nativeTextRange3)
        {
            return nativeTextRange3 == null ? null : new UIA3TextRange3(automation, nativeTextRange3);
        }
    }
}
