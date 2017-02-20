using System;
using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
  public class UIA3BasicCacheRequest : IBasicCacheRequest
    {
        public UIA.IUIAutomationCacheRequest NativeCacheRequest { get; }

        public UIA3Automation Automation { get; }

        public UIA3BasicCacheRequest(UIA3Automation automation)
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

        public void Add(PatternId pattern)
        {
            NativeCacheRequest.AddPattern(pattern.Id);
        }

        public void Add(PropertyId property)
        {
            NativeCacheRequest.AddProperty(property.Id);
        }

        public IBasicCacheRequest Clone()
        {
            var clone = new UIA3BasicCacheRequest(Automation)
            {
                AutomationElementMode = AutomationElementMode,
                TreeScope = TreeScope
            };
            clone.NativeCacheRequest.TreeFilter = NativeCacheRequest.TreeFilter;
            return clone;
        }
    }
}
