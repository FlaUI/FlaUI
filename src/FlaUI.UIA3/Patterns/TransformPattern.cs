using FlaUI.Core;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public abstract class TransformPattern<TNativePattern, TInfo> : PatternBaseWithInformation<TNativePattern, TInfo>, ITransformPattern
        where TNativePattern : UIA.IUIAutomationTransformPattern
        where TInfo : ITransformPatternInformation
    {
        protected TransformPattern(AutomationObjectBase automationObject, TNativePattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        ITransformPatternInformation IPatternWithInformation<ITransformPatternInformation>.Cached
        {
            get { return Cached; }
        }

        ITransformPatternInformation IPatternWithInformation<ITransformPatternInformation>.Current
        {
            get { return Current; }
        }

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

    public class TransformPattern : TransformPattern<UIA.IUIAutomationTransformPattern, TransformPatternInformation>
    {
        public TransformPattern(AutomationObjectBase automationObject, UIA.IUIAutomationTransformPattern nativePattern) : base(automationObject, nativePattern)
        {
        }

        protected override TransformPatternInformation CreateInformation(bool cached)
        {
            return new TransformPatternInformation(AutomationObject, cached);
        }
    }
}
