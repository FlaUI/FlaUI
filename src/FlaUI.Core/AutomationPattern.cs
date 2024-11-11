﻿using System;
using System.Diagnostics.CodeAnalysis;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core
{
    /// <summary>
    /// Interface for an automation pattern object.
    /// </summary>
    /// <typeparam name="T">The type of the pattern.</typeparam>
    public interface IAutomationPattern<T> where T : IPattern
    {
        /// <summary>
        /// Gets the pattern. Throws if the pattern is not supported.
        /// </summary>
        T Pattern { get; }

        /// <summary>
        /// Gets the pattern or null if it is not supported.
        /// </summary>
        T? PatternOrDefault { get; }

        /// <summary>
        /// Tries getting the pattern.
        /// </summary>
        /// <param name="pattern">The found pattern or null if it is not supported.</param>
        /// <returns>True if the pattern is supported, false otherwise.</returns>
        bool TryGetPattern([NotNullWhen(true)] out T? pattern);

        /// <summary>
        /// Gets a boolean value which indicates, if the pattern is supported.
        /// </summary>
        bool IsSupported { get; }
    }

    /// <summary>
    /// Automation pattern object which is used to get automation patterns.
    /// </summary>
    /// <typeparam name="T">The type of the pattern.</typeparam>
    /// <typeparam name="TNative">The type of the native pattern.</typeparam>
    public class AutomationPattern<T, TNative> : IAutomationPattern<T>
        where T : IPattern
    {
        private readonly Func<FrameworkAutomationElementBase, TNative, T> _patternCreateFunc;
        private readonly PatternId _patternId;

        /// <summary>
        /// Creates a new pattern object.
        /// </summary>
        public AutomationPattern(PatternId patternId, FrameworkAutomationElementBase frameworkAutomationElement, Func<FrameworkAutomationElementBase, TNative, T> patternCreateFunc)
        {
            _patternId = patternId;
            FrameworkAutomationElement = frameworkAutomationElement;
            _patternCreateFunc = patternCreateFunc;
        }

        /// <summary>
        /// The element which owns this pattern.
        /// </summary>
        protected FrameworkAutomationElementBase FrameworkAutomationElement { get; }

        /// <inheritdoc />
        public T Pattern
        {
            get
            {
                var nativePattern = FrameworkAutomationElement.GetNativePattern<TNative>(_patternId);
                return _patternCreateFunc(FrameworkAutomationElement, nativePattern);
            }
        }

        /// <inheritdoc />
        public T? PatternOrDefault
        {
            get
            {
                TryGetPattern(out var pattern);
                return pattern;
            }
        }

        /// <inheritdoc />
        public bool TryGetPattern([NotNullWhen(true)] out T? pattern)
        {
            if (FrameworkAutomationElement.TryGetNativePattern(_patternId, out TNative? nativePattern))
            {
                pattern = _patternCreateFunc(FrameworkAutomationElement, nativePattern);
                return true;
            }
            pattern = default;
            return false;
        }

        /// <inheritdoc />
        public bool IsSupported => TryGetPattern(out T _);
    }
}
