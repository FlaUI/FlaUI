using FlaUI.Core;
using FlaUI.Core.Patterns;

namespace FlaUI.UIA3.Patterns
{
    public class Transform2PatternInformation : TransformPatternInformation, ITransform2PatternInformation
    {
        public Transform2PatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool CanZoom
        {
            get { return Get<bool>(Transform2PatternIds.CanZoomProperty); }
        }

        public double ZoomLevel
        {
            get { return Get<double>(Transform2PatternIds.ZoomLevelProperty); }
        }

        public double ZoomMaximum
        {
            get { return Get<double>(Transform2PatternIds.ZoomMaximumProperty); }
        }

        public double ZoomMinimum
        {
            get { return Get<double>(Transform2PatternIds.ZoomMinimumProperty); }
        }
    }
}
