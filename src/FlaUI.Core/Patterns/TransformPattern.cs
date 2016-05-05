using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using interop.UIAutomationCore;
using System;

namespace FlaUI.Core.Patterns
{
    public abstract class TransformPattern<TProp> : PatternBaseWithInformation<IUIAutomationTransformPattern, TProp>
        where TProp : InformationBase
    {
        protected TransformPattern(AutomationElement automationElement, IUIAutomationTransformPattern nativePattern, Func<AutomationElement, bool, TProp> createFunc)
            : base(automationElement, nativePattern, createFunc)
        {
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

    public class TransformPattern : TransformPattern<TransformPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_TransformPatternId, "Transform");
        public static readonly PropertyId CanMoveProperty = PropertyId.Register(UIA_PropertyIds.UIA_TransformCanMovePropertyId, "CanMove");
        public static readonly PropertyId CanResizeProperty = PropertyId.Register(UIA_PropertyIds.UIA_TransformCanResizePropertyId, "CanResize");
        public static readonly PropertyId CanRotateProperty = PropertyId.Register(UIA_PropertyIds.UIA_TransformCanRotatePropertyId, "CanRotate");

        public TransformPattern(AutomationElement automationElement, IUIAutomationTransformPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new TransformPatternInformation(element, cached))
        {
        }
    }

    public class TransformPatternInformation : InformationBase
    {
        public TransformPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public bool CanMove
        {
            get { return Get<bool>(TransformPattern.CanMoveProperty); }
        }

        public bool CanResize
        {
            get { return Get<bool>(TransformPattern.CanResizeProperty); }
        }

        public bool CanRotate
        {
            get { return Get<bool>(TransformPattern.CanRotateProperty); }
        }
    }
}
