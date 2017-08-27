using System;
using System.Collections.Generic;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core
{
    public partial class CacheRequest
    {
        public AutomationElementMode AutomationElementMode { get; set; }

        public ConditionBase TreeFilter { get; set; } = TrueCondition.Default;

        public TreeScope TreeScope { get; set; }

        public HashSet<PatternId> Patterns { get; } = new HashSet<PatternId>();

        public HashSet<PropertyId> Properties { get; } = new HashSet<PropertyId>();

        public void Add(PatternId pattern)
        {
            Patterns.Add(pattern);
        }

        public void Add(PropertyId property)
        {
            Properties.Add(property);
        }

        public IDisposable Activate()
        {
            Push(this);
            return new CacheRequestActivation();
        }
    }

    public partial class CacheRequest
    {
        [ThreadStatic]
        private static Stack<CacheRequest> _cacheStack;
        [ThreadStatic]
        private static Stack<bool> _forceNoCacheStack;

        public static bool IsCachingActive => (_forceNoCacheStack == null || _forceNoCacheStack.Count == 0) && Current != null;

        public static CacheRequest Current
        {
            get
            {
                if ((_cacheStack != null) && (_cacheStack.Count != 0))
                {
                    return _cacheStack.Peek();
                }
                return null;
            }
        }

        public static void Push(CacheRequest cacheRequest)
        {
            if (_cacheStack == null)
            {
                _cacheStack = new Stack<CacheRequest>();
            }
            _cacheStack.Push(cacheRequest);
        }

        public static void Pop()
        {
            if ((_cacheStack == null) || (_cacheStack.Count == 0))
            {
                throw new InvalidOperationException("No cache request available to pop");
            }
            _cacheStack.Pop();
        }

        public static IDisposable ForceNoCache()
        {
            return new ForceNoCacheActivation();
        }

        private class CacheRequestActivation : IDisposable
        {
            public void Dispose()
            {
                Pop();
            }
        }

        private class ForceNoCacheActivation : IDisposable
        {
            public ForceNoCacheActivation()
            {
                if (_forceNoCacheStack == null)
                {
                    _forceNoCacheStack = new Stack<bool>();
                }
                _forceNoCacheStack.Push(true);
            }

            public void Dispose()
            {
                _forceNoCacheStack.Pop();
            }
        }
    }
}
