using System;
using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Converters;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public class UIA2CacheRequest : ICacheRequest
    {
        public UIA.CacheRequest NativeCacheRequest { get; }

        public UIA2Automation Automation { get; }

        public UIA2CacheRequest(UIA2Automation automation)
        {
            Automation = automation;
            NativeCacheRequest = new UIA.CacheRequest();
        }

        public AutomationElementMode AutomationElementMode
        {
            get { return (AutomationElementMode)NativeCacheRequest.AutomationElementMode; }
            set { NativeCacheRequest.AutomationElementMode = (UIA.AutomationElementMode)value; }
        }

        public ConditionBase TreeFilter
        {
            get { throw new NotImplementedException(); }
            set { NativeCacheRequest.TreeFilter = ConditionConverter.ToNative(value); }
        }

        public TreeScope TreeScope
        {
            get { return (TreeScope)NativeCacheRequest.TreeScope; }
            set { NativeCacheRequest.TreeScope = (UIA.TreeScope)value; }
        }

        public void AddPattern(PatternId pattern)
        {
            NativeCacheRequest.Add(UIA.AutomationPattern.LookupById(pattern.Id));
        }

        public void AddProperty(PropertyId property)
        {
            NativeCacheRequest.Add(UIA.AutomationProperty.LookupById(property.Id));
        }

        public ICacheRequest Clone()
        {
            var clone = new UIA2CacheRequest(Automation)
            {
                AutomationElementMode = AutomationElementMode,
                TreeScope = TreeScope
            };
            clone.NativeCacheRequest.TreeFilter = NativeCacheRequest.TreeFilter;
            return clone;
        }
    }
}
