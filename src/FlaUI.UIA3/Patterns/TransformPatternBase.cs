using FlaUI.Core;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public abstract class TransformPatternBase<TNativePattern, TInfo> : PatternBaseWithInformation<TNativePattern, TInfo>, ITransformPattern
         where TNativePattern : UIA.IUIAutomationTransformPattern
         where TInfo : ITransformPatternInformation
    {
        protected TransformPatternBase(AutomationObjectBase automationObject, TNativePattern nativePattern) : base(automationObject, nativePattern)
        {
            Properties = new Transform2PatternProperties();
        }

        ITransformPatternInformation IPatternWithInformation<ITransformPatternInformation>.Cached => Cached;

        ITransformPatternInformation IPatternWithInformation<ITransformPatternInformation>.Current => Current;

        public ITransformPatternProperties Properties { get; }

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
