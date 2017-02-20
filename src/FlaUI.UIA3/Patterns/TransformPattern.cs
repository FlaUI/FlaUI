using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TransformPattern : TransformPatternBase<UIA.IUIAutomationTransformPattern, TransformPatternInformation, TransformPatternProperties>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TransformPatternId, "Transform", AutomationObjectIds.IsTransformPatternAvailableProperty);
        public static readonly PropertyId CanMoveProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TransformCanMovePropertyId, "CanMove");
        public static readonly PropertyId CanResizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TransformCanResizePropertyId, "CanResize");
        public static readonly PropertyId CanRotateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TransformCanRotatePropertyId, "CanRotate");

        public TransformPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTransformPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public override TransformPatternProperties Properties => (TransformPatternProperties)Automation.PropertyLibrary.Transform;

        protected override TransformPatternInformation CreateInformation(bool cached)
        {
            return new TransformPatternInformation(BasicAutomationElement, cached);
        }
    }

    public class TransformPatternInformation : InformationBase, ITransformPatternInformation
    {
        public TransformPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
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
