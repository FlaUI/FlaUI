using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlaUI.WebDriver
{
    public class Session : IDisposable
    {
        public Session(Application? app)
        {
            App = app;
            SessionId = Guid.NewGuid().ToString();
            Automation = new UIA3Automation();
            InputState = new InputState();
            TimeoutsConfiguration = new TimeoutsConfiguration();

            if (app != null)
            {
                // We have to capture the initial window handle to be able to keep it stable
                CurrentWindowWithHandle = GetOrAddKnownWindow(app.GetMainWindow(Automation, PageLoadTimeout));
            }
        }

        public string SessionId { get; }
        public UIA3Automation Automation { get; }
        public Application? App { get; }
        public InputState InputState { get; }
        private Dictionary<string, KnownElement> KnownElementsByElementReference { get; } = new Dictionary<string, KnownElement>();
        private Dictionary<string, KnownWindow> KnownWindowsByWindowHandle { get; } = new Dictionary<string, KnownWindow>();
        public TimeSpan ImplicitWaitTimeout => TimeSpan.FromMilliseconds(TimeoutsConfiguration.ImplicitWaitTimeoutMs);
        public TimeSpan PageLoadTimeout => TimeSpan.FromMilliseconds(TimeoutsConfiguration.PageLoadTimeoutMs);
        public TimeSpan? ScriptTimeout => TimeoutsConfiguration.ScriptTimeoutMs.HasValue ? TimeSpan.FromMilliseconds(TimeoutsConfiguration.ScriptTimeoutMs.Value) : null;

        public TimeoutsConfiguration TimeoutsConfiguration { get; set; }

        private KnownWindow? CurrentWindowWithHandle { get; set; }

        public Window CurrentWindow
        {
            get
            {
                if (App == null || CurrentWindowWithHandle == null)
                {
                    throw WebDriverResponseException.UnsupportedOperation("This operation is not supported for Root app");
                }
                if (CurrentWindowWithHandle.Window.IsMainWindow)
                {
                    // When expanding menus, calling `GetMainWindow` again is necessary to be able to find the expanded menu items
                    // This seems to be a bug (it isn't solved by using `CacheRequest.ForceNoCache()`)
                    return App.GetMainWindow(Automation);
                }
                return CurrentWindowWithHandle.Window;
            }
            set
            {
                CurrentWindowWithHandle = GetOrAddKnownWindow(value);
            }
        }

        public string CurrentWindowHandle
        {
            get
            {
                if (App == null || CurrentWindowWithHandle == null)
                {
                    throw WebDriverResponseException.UnsupportedOperation("This operation is not supported for Root app");
                }
                return CurrentWindowWithHandle.WindowHandle;
            }
        }

        public KnownElement GetOrAddKnownElement(AutomationElement element)
        {
            var result = KnownElementsByElementReference.Values.FirstOrDefault(knownElement => knownElement.Element.Equals(element));
            if (result == null)
            {
                result = new KnownElement(element);
                KnownElementsByElementReference.Add(result.ElementReference, result);
            }
            return result;
        }

        public AutomationElement? FindKnownElementById(string elementId)
        {
            if (!KnownElementsByElementReference.TryGetValue(elementId, out var knownElement))
            {
                return null;
            }
            return knownElement.Element;
        }

        public KnownWindow GetOrAddKnownWindow(Window window)
        {
            var result = KnownWindowsByWindowHandle.Values.FirstOrDefault(knownElement => knownElement.Window.Equals(window));
            if (result == null)
            {
                result = new KnownWindow(window);
                KnownWindowsByWindowHandle.Add(result.WindowHandle, result);
            }
            return result;
        }

        public Window? FindKnownWindowByWindowHandle(string windowHandle)
        {
            if (!KnownWindowsByWindowHandle.TryGetValue(windowHandle, out var knownWindow))
            {
                return null;
            }
            return knownWindow.Window;
        }

        public void RemoveKnownWindow(Window window)
        {
            var item = KnownWindowsByWindowHandle.Values.FirstOrDefault(knownElement => knownElement.Window.Equals(window));
            if (item != null)
            {
                KnownWindowsByWindowHandle.Remove(item.WindowHandle);
            }
        }

        public void Dispose()
        {
            if (App != null && !App.HasExited)
            {
                App.Close();
            }
            Automation.Dispose();
            App?.Dispose();
        }
    }
}
