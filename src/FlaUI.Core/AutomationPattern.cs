using System;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;
#if NET35
using FlaUI.Core.Tools;
#endif

namespace FlaUI.Core
{
    public interface IAutomationPattern<T> where T : IPattern
    {
        T Pattern { get; }

        T PatternOrDefault { get; }

        bool TryGetPattern(out T pattern);

        bool IsSupported { get; }
    }

    public class AutomationPattern<T, TNative> : IAutomationPattern<T>
        where T : IPattern
    {
        private readonly Func<BasicAutomationElementBase, TNative, T> _patternCreateFunc;
        private readonly Lazy<PatternId> _patternIdLazy;

        public AutomationPattern(Func<PatternId> patternFunc, BasicAutomationElementBase basicAutomationElement, Func<BasicAutomationElementBase, TNative, T> patternCreateFunc)
        {
            _patternCreateFunc = patternCreateFunc;
            BasicAutomationElement = basicAutomationElement;
            _patternIdLazy = new Lazy<PatternId>(patternFunc);
        }

        protected PatternId PatternId => _patternIdLazy.Value;

        protected BasicAutomationElementBase BasicAutomationElement { get; }

        public T Pattern
        {
            get
            {
                var nativePattern = BasicAutomationElement.GetNativePattern<TNative>(PatternId);
                return _patternCreateFunc(BasicAutomationElement, nativePattern);
            }
        }

        public T PatternOrDefault
        {
            get
            {
                T pattern;
                TryGetPattern(out pattern);
                return pattern;
            }
        }

        public bool TryGetPattern(out T pattern)
        {
            TNative nativePattern;
            if (BasicAutomationElement.TryGetNativePattern(PatternId, out nativePattern))
            {
                pattern = _patternCreateFunc(BasicAutomationElement, nativePattern);
                return true;
            }
            pattern = default(T);
            return false;
        }

        public bool IsSupported
        {
            get
            {
                T pattern;
                return TryGetPattern(out pattern);
            }
        }
    }
}
