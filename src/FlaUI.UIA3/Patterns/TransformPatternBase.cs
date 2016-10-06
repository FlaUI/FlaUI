using System;
using FlaUI.Core;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public abstract class TransformPatternBase<TNativePattern, TInfo, TProp> : PatternBaseWithInformation<TNativePattern, TInfo>, ITransformPattern
         where TNativePattern : UIA.IUIAutomationTransformPattern
         where TInfo : ITransformPatternInformation
         where TProp : ITransformPatternProperties
    {
        protected TransformPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        ITransformPatternInformation IPatternWithInformation<ITransformPatternInformation>.Cached => Cached;

        ITransformPatternInformation IPatternWithInformation<ITransformPatternInformation>.Current => Current;

        ITransformPatternProperties ITransformPattern.Properties { get { return Properties; } }

        public abstract TProp Properties { get; }

        public void Move(double x, double y)
        {
            ComCallWrapper.Call(() => NativePattern.Move(x, y));
        }

        public void Resize(double width, double height)
        {
            ComCallWrapper.Call(() => NativePattern.Resize(width, height));
        }

        public void Rotate(double degrees)
        {
            ComCallWrapper.Call(() => NativePattern.Rotate(degrees));
        }
    }
}
