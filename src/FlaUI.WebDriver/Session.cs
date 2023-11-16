using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FlaUI.WebDriver
{
    public class Session
    {
        public Session(Application? app)
        {
            App = app;
            SessionId = Guid.NewGuid().ToString();
            Automation = new UIA3Automation();
            InputState = new InputState();
            TimeoutsConfiguration = new TimeoutsConfiguration();
        }

        public string SessionId { get; }
        public UIA3Automation Automation { get; }
        public Application? App { get; }
        public InputState InputState { get; }
        private Dictionary<string, KnownElement> KnownElementsByElementReference { get; } = new Dictionary<string, KnownElement>();
        public TimeSpan ImplicitWaitTimeout => TimeSpan.FromMilliseconds(TimeoutsConfiguration.ImplicitWaitTimeoutMs);
        public TimeSpan? ScriptTimeout => TimeoutsConfiguration.ScriptTimeoutMs.HasValue ? TimeSpan.FromMilliseconds(TimeoutsConfiguration.ScriptTimeoutMs.Value) : null;

        public TimeoutsConfiguration TimeoutsConfiguration { get; set; }

        public KnownElement AddKnownElement(AutomationElement element)
        {
            var result = new KnownElement(element);
            KnownElementsByElementReference.Add(result.ElementReference, result);
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
    }
}
