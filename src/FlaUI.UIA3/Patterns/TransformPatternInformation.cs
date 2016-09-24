using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.UIA3.Patterns
{
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
