using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;

namespace FlaUI.UIA3.Patterns
{
    public class WindowPatternInformation : ElementInformationBase, IWindowPatternInformation
    {
        public WindowPatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool CanMaximize { get { return Get<bool>(WindowPatternIds.CanMaximizeProperty); } }
        public bool CanMinimize { get { return Get<bool>(WindowPatternIds.CanMinimizeProperty); } }
        public bool IsModal { get { return Get<bool>(WindowPatternIds.IsModalProperty); } }
        public bool IsTopmost { get { return Get<bool>(WindowPatternIds.IsTopmostProperty); } }
        public WindowInteractionState WindowInteractionState { get { return Get<WindowInteractionState>(WindowPatternIds.WindowInteractionStateProperty); } }
        public WindowVisualState WindowVisualState { get { return Get<WindowVisualState>(WindowPatternIds.WindowVisualStateProperty); } }
    }
}
