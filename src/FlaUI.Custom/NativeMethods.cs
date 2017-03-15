using System;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using Interop.UIAutomationCore;

namespace ManagedUiaCustomizationCore
{
    // P/Invoke declarations
    public class NativeMethods
    {
        [DllImport("UIAutomationCore.dll", EntryPoint = "UiaHostProviderFromHwnd", CharSet = CharSet.Unicode)]
        public static extern int UiaHostProviderFromHwnd(IntPtr hwnd, [MarshalAs(UnmanagedType.Interface)] out IRawElementProviderSimple provider);

        [DllImport("UIAutomationCore.dll", EntryPoint = "UiaReturnRawElementProvider", CharSet = CharSet.Unicode)]
        public static extern IntPtr UiaReturnRawElementProvider(IntPtr hwnd, IntPtr wParam, IntPtr lParam, IRawElementProviderSimple el);

        [DllImport("UIAutomationCore.dll", EntryPoint = "UiaRaiseAutomationEvent", CharSet = CharSet.Unicode)]
        public static extern int UiaRaiseAutomationEvent(IRawElementProviderSimple el, int eventId);

        [DllImport("UIAutomationCore.dll", EntryPoint = "UiaRaiseAutomationPropertyChangedEvent", CharSet = CharSet.Unicode)]
        public static extern int UiaRaiseAutomationPropertyChangedEvent(IRawElementProviderSimple el, int propertyId, object oldValue, object newValue);

        public static void WrapUiaComCall(Func<int> preservesigCall)
        {
            try
            {
                var hr = preservesigCall();
                if (hr != 0)
                    throw Marshal.GetExceptionForHR(hr);
            }
            catch (COMException e)
            {
                Exception newEx;
                if (ConvertException(e, out newEx))
                    throw newEx;
                throw;
            }
            catch (Exception e)
            {
                throw new UiaCallFailedException("Automation call failure", e);
            }
            catch
            {
                throw new UiaCallFailedException("Automation call failure");
            }
        }

        #region Taken from UIAComWrapper - exception wrapping

        private const int UIA_E_ELEMENTNOTAVAILABLE = -2147220991;
        private const int UIA_E_ELEMENTNOTENABLED = -2147220992;
        private const int UIA_E_NOCLICKABLEPOINT = -2147220990;
        private const int UIA_E_PROXYASSEMBLYNOTLOADED = -2147220989;

        private static bool ConvertException(COMException e, out Exception uiaException)
        {
            bool handled = true;
            switch (e.ErrorCode)
            {
                case UIA_E_ELEMENTNOTAVAILABLE:
                    uiaException = new ElementNotAvailableException(e);
                    break;

                case UIA_E_ELEMENTNOTENABLED:
                    uiaException = new ElementNotEnabledException(e);
                    break;

                case UIA_E_NOCLICKABLEPOINT:
                    uiaException = new NoClickablePointException(e);
                    break;

                case UIA_E_PROXYASSEMBLYNOTLOADED:
                    uiaException = new ProxyAssemblyNotLoadedException(e);
                    break;

                default:
                    uiaException = null;
                    handled = false;
                    break;
            }
            return handled;
        }

        #endregion
    }
}
