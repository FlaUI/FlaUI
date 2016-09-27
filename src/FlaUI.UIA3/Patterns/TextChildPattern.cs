﻿using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TextChildPattern : PatternBase
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TextChildPatternId, "TextChild");

        internal TextChildPattern(Element automationElement, UIA.IUIAutomationTextChildPattern nativePattern)
            : base(automationElement, nativePattern)
        {
        }

        public new UIA.IUIAutomationTextChildPattern NativePattern
        {
            get { return (UIA.IUIAutomationTextChildPattern)base.NativePattern; }
        }

        public Element TextContainer
        {
            get
            {
                var nativeElement = ComCallWrapper.Call(() => NativePattern.TextContainer);
                return ToAutomationElement(nativeElement);
            }
        }

        public TextRange TextRange
        {
            get
            {
                var nativeRange = ComCallWrapper.Call(() => NativePattern.TextRange);
                return NativeValueConverter.NativeToManaged(Automation, nativeRange);
            }
        }
    }
}
