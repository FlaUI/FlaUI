using System;
using System.Collections.Generic;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core
{
    /// <summary>
    /// A class which handles the cache requests.
    /// </summary>
    public partial class CacheRequest
    {
        /// <summary>
        /// Defines the reference mode of automation elements in the cache.
        /// </summary>
        public AutomationElementMode AutomationElementMode { get; set; }

        /// <summary>
        /// Defines the tree filter that is used to filter the items to cache.
        /// </summary>
        public ConditionBase TreeFilter { get; set; } = TrueCondition.Default;

        /// <summary>
        /// The tree scope used for searching items for caching.
        /// </summary>
        public TreeScope TreeScope { get; set; }

        /// <summary>
        /// The list of patterns to cache.
        /// </summary>
        public HashSet<PatternId> Patterns { get; } = new HashSet<PatternId>();

        /// <summary>
        /// The list of properties to cache.
        /// </summary>
        public HashSet<PropertyId> Properties { get; } = new HashSet<PropertyId>();

        /// <summary>
        /// Adds a pattern to the list of patterns to cache.
        /// </summary>
        public void Add(PatternId pattern)
        {
            Patterns.Add(pattern);
        }

        /// <summary>
        /// Adds a property to the list of properties to cache.
        /// </summary>
        public void Add(PropertyId property)
        {
            Properties.Add(property);
        }

        /// <summary>
        /// Activate the cache request.
        /// </summary>
        public IDisposable Activate()
        {
            Push(this);
            return new CacheRequestActivation();
        }
    }

    public partial class CacheRequest
    {
        [ThreadStatic]
        private static Stack<CacheRequest>? _cacheStack;
        [ThreadStatic]
        private static Stack<bool>? _forceNoCacheStack;

        /// <summary>
        /// Checks if a caching is currently active in the current context.
        /// </summary>
        public static bool IsCachingActive => (_forceNoCacheStack == null || _forceNoCacheStack.Count == 0) && Current != null;

        /// <summary>
        /// Gets the current cache request object.
        /// </summary>
        public static CacheRequest? Current
        {
            get
            {
                if (_cacheStack != null && _cacheStack.Count != 0)
                {
                    return _cacheStack.Peek();
                }
                return null;
            }
        }

        /// <summary>
        /// Pushes a stack request onto the stack.
        /// </summary>
        public static void Push(CacheRequest cacheRequest)
        {
            if (_cacheStack == null)
            {
                _cacheStack = new Stack<CacheRequest>();
            }
            _cacheStack.Push(cacheRequest);
        }

        /// <summary>
        /// Pops a cache request from the stack.
        /// </summary>
        public static void Pop()
        {
            if (_cacheStack == null || _cacheStack.Count == 0)
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
                _forceNoCacheStack!.Pop();
            }
        }
    }
}
