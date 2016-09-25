using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
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
            Properties = new Transform2PatternProperties();
        }

        ITransformPatternInformation IPatternWithInformation<ITransformPatternInformation>.Cached
        {
            get { return Cached; }
        }

        ITransformPatternInformation IPatternWithInformation<ITransformPatternInformation>.Current
        {
            get { return Current; }
        }

        public ITransformPatternProperties Properties { get; private set; }

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

    public class TransformPatternInformation : ElementInformationBase, ITransformPatternInformation
    {
        public TransformPatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool CanMove
        {
            get { return Get<bool>(TransformPatternIds.CanMoveProperty); }
        }

        public bool CanResize
        {
            get { return Get<bool>(TransformPatternIds.CanResizeProperty); }
        }

        public bool CanRotate
        {
            get { return Get<bool>(TransformPatternIds.CanRotateProperty); }
        }
    }
}
