using System;
using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3CacheRequest : ICacheRequest
    {
        public UIA.IUIAutomationCacheRequest NativeCacheRequest { get; }

        public UIA3Automation Automation { get; }

        public UIA3CacheRequest(UIA3Automation automation)
        {
            Automation = automation;
            NativeCacheRequest = Automation.NativeAutomation.CreateCacheRequest();
        }

        public AutomationElementMode AutomationElementMode
        {
            get { return (AutomationElementMode)NativeCacheRequest.AutomationElementMode; }
            set { NativeCacheRequest.AutomationElementMode = (UIA.AutomationElementMode)value; }
        }

        public ConditionBase TreeFilter
        {
            get { throw new NotImplementedException(); }
            set { NativeCacheRequest.TreeFilter = ConditionConverter.ToNative(Automation, value); }
        }

        public TreeScope TreeScope
        {
            get { return (TreeScope)NativeCacheRequest.TreeScope; }
            set { NativeCacheRequest.TreeScope = (UIA.TreeScope)value; }
        }

        public void AddPattern(PatternId pattern)
        {
            NativeCacheRequest.AddPattern(pattern.Id);
        }

        public void AddProperty(PropertyId property)
        {
            NativeCacheRequest.AddProperty(property.Id);
        }

        public ICacheRequest Clone()
        {
            var clone = new UIA3CacheRequest(Automation)
            {
                AutomationElementMode = AutomationElementMode,
                TreeScope = TreeScope
            };
            clone.NativeCacheRequest.TreeFilter = NativeCacheRequest.TreeFilter;
            return clone;
        }
    }
}
