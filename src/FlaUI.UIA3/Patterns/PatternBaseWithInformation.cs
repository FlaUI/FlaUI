﻿using FlaUI.UIA3.Elements;
using System;

namespace FlaUI.UIA3.Patterns
{
    /// <summary>
    /// Base pattern for patterns which have information (properties)
    /// </summary>
    /// <typeparam name="TProp">Type of the information object</typeparam>
    public abstract class PatternBaseWithInformation<TProp> : PatternBase where TProp : InformationBase
    {
        /// <summary>
        /// Cached information for this pattern
        /// </summary>
        public TProp Cached { get; private set; }

        /// <summary>
        /// Current information for this pattern
        /// </summary>
        public TProp Current { get; private set; }

        protected PatternBaseWithInformation(Element automationElement, object nativePattern, Func<Element, bool, TProp> createFunc)
            : base(automationElement, nativePattern)
        {
            Cached = createFunc(AutomationElement, true);
            Current = createFunc(AutomationElement, false);
        }
    }
}