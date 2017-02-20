using System;
using System.Collections.Generic;

namespace FlaUI.Core
{
    public static class CacheRequest
    {
        [ThreadStatic]
        private static Stack<IBasicCacheRequest> _cacheStack;

        public static IBasicCacheRequest Current
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

        public static void Push(IBasicCacheRequest cacheRequest)
        {
            if (_cacheStack == null)
            {
                _cacheStack = new Stack<IBasicCacheRequest>();
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

        public static IDisposable Activate(IBasicCacheRequest cacheRequest)
        {
            Push(cacheRequest);
            return new CacheRequestActivation();
        }

        private class CacheRequestActivation : IDisposable
        {
            public void Dispose()
            {
                Pop();
            }
        }
    }
}
