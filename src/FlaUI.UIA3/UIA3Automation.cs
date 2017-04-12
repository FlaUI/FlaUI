using System;
using System.Runtime.InteropServices;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.EventHandlers;
using FlaUI.UIA3.Extensions;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3
{
    /// <summary>
    /// Automation implementation for UIA3
    /// </summary>
    public class UIA3Automation : AutomationBase
    {
        public UIA3Automation() : base(new UIA3PropertyLibrary(), new UIA3EventLibrary(), new UIA3PatternLibrary())
        {
            NativeAutomation = InitializeAutomation();
            TreeWalkerFactory = new UIA3TreeWalkerFactory(this);
        }

        public override ITreeWalkerFactory TreeWalkerFactory { get; }

        public override AutomationType AutomationType => AutomationType.UIA3;

        public override object NotSupportedValue => NativeAutomation.ReservedNotSupportedValue;

        /// <summary>
        /// Native object for the ui automation
        /// </summary>
        public UIA.IUIAutomation NativeAutomation { get; }

        /// <summary>
        /// Native object for Windows 8 automation
        /// </summary>
        public UIA.IUIAutomation2 NativeAutomation2 => GetAutomationAs<UIA.IUIAutomation2>();

        /// <summary>
        /// Native object for Windows 8.1 automation
        /// </summary>
        public UIA.IUIAutomation3 NativeAutomation3 => GetAutomationAs<UIA.IUIAutomation3>();

        public override AutomationElement GetDesktop()
        {
            return ComCallWrapper.Call(() =>
            {
                var desktop = CacheRequest.IsCachingActive
                    ? NativeAutomation.GetRootElementBuildCache(CacheRequest.Current.ToNative(this))
                    : NativeAutomation.GetRootElement();
                return WrapNativeElement(desktop);
            });
        }

        /// <summary>
        /// Creates an <see cref="AutomationElement" /> from a given point
        /// </summary>
        public override AutomationElement FromPoint(Point point)
        {
            return ComCallWrapper.Call(() =>
            {
                var nativePoint = point.ToTagPoint();
                var nativeElement = CacheRequest.IsCachingActive
                    ? NativeAutomation.ElementFromPointBuildCache(nativePoint, CacheRequest.Current.ToNative(this))
                    : NativeAutomation.ElementFromPoint(nativePoint);
                return WrapNativeElement(nativeElement);
            });
        }

        /// <summary>
        /// Creates an <see cref="AutomationElement" /> from a given windows handle (HWND)
        /// </summary>
        public override AutomationElement FromHandle(IntPtr hwnd)
        {
            return ComCallWrapper.Call(() =>
            {
                var nativeElement = CacheRequest.IsCachingActive
                    ? NativeAutomation.ElementFromHandleBuildCache(hwnd, CacheRequest.Current.ToNative(this))
                    : NativeAutomation.ElementFromHandle(hwnd);
                return WrapNativeElement(nativeElement);
            });
        }

        public override AutomationElement FocusedElement()
        {
            return ComCallWrapper.Call(() =>
            {
                var nativeElement = CacheRequest.IsCachingActive
                    ? NativeAutomation.GetFocusedElementBuildCache(CacheRequest.Current.ToNative(this))
                    : NativeAutomation.GetFocusedElement();
                return WrapNativeElement(nativeElement);
            });
        }

        public override IAutomationFocusChangedEventHandler RegisterFocusChangedEvent(Action<AutomationElement> action)
        {
            var eventHandler = new UIA3FocusChangedEventHandler(this, action);
            ComCallWrapper.Call(() => NativeAutomation.AddFocusChangedEventHandler(null, eventHandler));
            return eventHandler;
        }

        public override void UnRegisterFocusChangedEvent(IAutomationFocusChangedEventHandler eventHandler)
        {
            NativeAutomation.RemoveFocusChangedEventHandler((UIA3FocusChangedEventHandler)eventHandler);
        }

        public override void UnregisterAllEvents()
        {
            try
            {
                NativeAutomation.RemoveAllEventHandlers();
            }
            catch
            {
                // Noop
            }
        }

        public override bool Compare(AutomationElement element1, AutomationElement element2)
        {
            return NativeAutomation.CompareElements(element1.ToNative(), element2.ToNative()) != 0;
        }

        /// <summary>
        /// Initializes the automation object with the correct instance
        /// </summary>
        private UIA.IUIAutomation InitializeAutomation()
        {
            UIA.IUIAutomation nativeAutomation;
            // Try CUIAutomation8 (Windows 8)
            try
            {
                nativeAutomation = new UIA.CUIAutomation8();
            }
            catch (COMException)
            {
                // Fall back to CUIAutomation
                nativeAutomation = new UIA.CUIAutomation();
            }
            return nativeAutomation;
        }

        /// <summary>
        /// Tries to cast the automation to a specific interface.
        /// Throws an exception if that is not possible.
        /// </summary>
        private T GetAutomationAs<T>() where T : class, UIA.IUIAutomation
        {
            var element = NativeAutomation as T;
            if (element == null)
            {
                throw new NotSupportedException($"OS does not have {typeof(T).Name} support.");
            }
            return element;
        }

        public AutomationElement WrapNativeElement(UIA.IUIAutomationElement nativeElement)
        {
            return nativeElement == null ? null : new AutomationElement(new UIA3BasicAutomationElement(this, nativeElement));
        }
    }
}
