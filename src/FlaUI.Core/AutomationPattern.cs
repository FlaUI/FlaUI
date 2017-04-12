using System;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

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
        private readonly PatternId _patternId;

        public AutomationPattern(PatternId patternId, BasicAutomationElementBase basicAutomationElement, Func<BasicAutomationElementBase, TNative, T> patternCreateFunc)
        {
            _patternId = patternId;
            BasicAutomationElement = basicAutomationElement;
            _patternCreateFunc = patternCreateFunc;
        }

        protected BasicAutomationElementBase BasicAutomationElement { get; }

        public T Pattern
        {
            get
            {
                var nativePattern = BasicAutomationElement.GetNativePattern<TNative>(_patternId);
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
            if (BasicAutomationElement.TryGetNativePattern(_patternId, out nativePattern))
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
