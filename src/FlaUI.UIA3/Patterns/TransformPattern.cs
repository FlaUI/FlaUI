using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TransformPattern : TransformPatternBase<UIA.IUIAutomationTransformPattern, TransformPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TransformPatternId, "Transform");
        public static readonly PropertyId CanMoveProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TransformCanMovePropertyId, "CanMove");
        public static readonly PropertyId CanResizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TransformCanResizePropertyId, "CanResize");
        public static readonly PropertyId CanRotateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TransformCanRotatePropertyId, "CanRotate");

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

        public bool CanMove => Get<bool>(TransformPattern.CanMoveProperty);

        public bool CanResize => Get<bool>(TransformPattern.CanResizeProperty);

        public bool CanRotate => Get<bool>(TransformPattern.CanRotateProperty);
    }

    public class TransformPatternProperties : ITransformPatternProperties
    {
        public PropertyId CanMoveProperty => TransformPattern.CanMoveProperty;

        public PropertyId CanResizeProperty => TransformPattern.CanResizeProperty;

        public PropertyId CanRotateProperty => TransformPattern.CanRotateProperty;
    }
}
