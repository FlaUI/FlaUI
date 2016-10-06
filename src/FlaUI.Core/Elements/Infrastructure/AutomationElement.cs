using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using System;
using GdiColor = System.Drawing.Color;
using WpfColor = System.Windows.Media.Color;

namespace FlaUI.Core.Elements.Infrastructure
{
    public class AutomationElement
    {
        public AutomationElement(AutomationObjectBase automationObject)
        {
            AutomationObject = automationObject;
            PatternFactory = AutomationObject.CreatePatternFactory();
            Cached = AutomationObject.CreateInformation(true);
            Current = AutomationObject.CreateInformation(false);
            Properties = AutomationObject.CreateProperties();
        }

        public AutomationObjectBase AutomationObject { get; }

        public ConditionFactory ConditionFactory => AutomationObject.Automation.ConditionFactory;

        public IElementProperties Properties { get; private set; }

        public FrameworkType FrameworkType => FrameworkIds.ConvertToFrameworkType(Current.FrameworkId);

        public IPatternFactory PatternFactory { get; private set; }

        /// <summary>
        /// Basic information about this element (cached)
        /// </summary>
        public IElementInformation Cached { get; }

        /// <summary>
        /// Basic information about this element (realtime)
        /// </summary>
        public IElementInformation Current { get; }

        /// <summary>
        /// Sets the focus to this element
        /// Warning: This can be unreliable! <see cref="SetForeground"/> should be more reliable
        /// </summary>
        public void Focus()
        {
            AutomationObject.SetFocus();
        }

        /// <summary>
        /// Brings the element to the foreground
        /// </summary>
        public void SetForeground()
        {
            User32.SetForegroundWindow(Current.NativeWindowHandle);
        }

        /// <summary>
        /// Draws a red highlight around the element
        /// </summary>
        public AutomationElement DrawHighlight()
        {
            return DrawHighlight(System.Windows.Media.Colors.Red);
        }

        /// <summary>
        /// Draws a manually colored highlight around the element
        /// </summary>
        public AutomationElement DrawHighlight(WpfColor color)
        {
            return DrawHighlight(true, color, 2000);
        }

        /// <summary>
        /// Draws a manually colored highlight around the element
        /// </summary>
        public AutomationElement DrawHighlight(GdiColor color)
        {
            return DrawHighlight(true, color, 2000);
        }

        /// <summary>
        /// Draw a highlight around the element with the given settings 
        /// </summary>
        /// <param name="blocking">Flag to indicate if further execution waits until the highlight is removed</param>
        /// <param name="color">The color to draw the highlight</param>
        /// <param name="durationInMs">The duration (im ms) how long the highlight is shown</param>
        /// <remarks>Override for winforms color</remarks>
        public AutomationElement DrawHighlight(bool blocking, GdiColor color, int durationInMs)
        {
            return DrawHighlight(blocking, WpfColor.FromArgb(color.A, color.R, color.G, color.B), durationInMs);
        }

        /// <summary>
        /// Draw a highlight around the element with the given settings
        /// </summary>
        /// <param name="blocking">Flag to indicate if further execution waits until the highlight is removed</param>
        /// <param name="color">The color to draw the highlight</param>
        /// <param name="durationInMs">The duration (im ms) how long the highlight is shown</param>
        public AutomationElement DrawHighlight(bool blocking, WpfColor color, int durationInMs)
        {
            var rectangle = Current.BoundingRectangle;
            if (!rectangle.IsEmpty)
            {
                if (blocking)
                {
                    AutomationObject.Automation.OverlayManager.ShowBlocking(rectangle, color, durationInMs);
                }
                else
                {
                    AutomationObject.Automation.OverlayManager.Show(rectangle, color, durationInMs);
                }
            }
            return this;
        }

        /// <summary>
        /// Captures the object as screenshot in WinForms format
        /// </summary>
        public System.Drawing.Bitmap Capture()
        {
            return ScreenCapture.CaptureArea(Current.BoundingRectangle);
        }

        /// <summary>
        /// Captures the object as screenshot in WPF format
        /// </summary>
        public System.Windows.Media.Imaging.BitmapImage CaptureWpf()
        {
            return ScreenCapture.CaptureAreaWpf(Current.BoundingRectangle);
        }

        public void CaptureToFile(string filePath)
        {
            ScreenCapture.CaptureAreaToFile(Current.BoundingRectangle, filePath);
        }

        /// <summary>
        /// Finds all elements in the given treescope and condition
        /// </summary>
        public AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition)
        {
            return FindAll(treeScope, condition, Retry.DefaultRetryFor);
        }

        /// <summary> 
        /// Finds all elements in the given treescope and condition within the given timeout.
        /// </summary> 
        public AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition, TimeSpan timeOut)
        {
            Predicate<AutomationElement[]> shouldRetry = elements => elements.Length > 0;
            Func<AutomationElement[]> func = () => AutomationObject.FindAll(treeScope, condition);

            return Retry.For(func, shouldRetry, timeOut);
        }

        /// <summary>
        /// Finds the first element which is in the given treescope and matches the condition
        /// </summary>
        public AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition)
        {
            return FindFirst(treeScope, condition, Retry.DefaultRetryFor);
        }

        /// <summary> 
        /// Finds the first element which is in the given treescope and matches the condition within the given timeout period. 
        /// </summary> 
        public AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition, TimeSpan timeOut)
        {
            Predicate<AutomationElement> shouldRetry = element => element == null;
            Func<AutomationElement> func = () => AutomationObject.FindFirst(treeScope, condition);

            return Retry.For(func, shouldRetry, timeOut);
        }

        /// <summary>
        /// Gets a clickable point of the element
        /// </summary>
        /// <exception cref="NoClickablePointException">Thrown when no clickable point was found</exception>
        public Point GetClickablePoint()
        {
            return AutomationObject.GetClickablePoint();
        }

        /// <summary>
        /// Tries to get a clickable point of the element
        /// </summary>
        /// <param name="point">The clickable point or null, if no point was found</param>
        /// <returns>True if a point was found, false otherwise</returns>
        public bool TryGetClickablePoint(out Point point)
        {
            return AutomationObject.TryGetClickablePoint(out point);
        }

        public IAutomationEventHandler RegisterEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action)
        {
            return AutomationObject.RegisterEvent(@event, treeScope, action);
        }

        public IAutomationPropertyChangedEventHandler RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, params PropertyId[] properties)
        {
            return AutomationObject.RegisterPropertyChangedEvent(treeScope, action, properties);
        }

        public IAutomationStructureChangedEventHandler RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action)
        {
            return AutomationObject.RegisterStructureChangedEvent(treeScope, action);
        }

        public void RemoveAutomationEventHandler(EventId @event, IAutomationEventHandler eventHandler)
        {
            AutomationObject.RemoveAutomationEventHandler(@event, eventHandler);
        }

        public void RemovePropertyChangedEventHandler(IAutomationPropertyChangedEventHandler eventHandler)
        {
            AutomationObject.RemovePropertyChangedEventHandler(eventHandler);
        }

        public void RemoveStructureChangedEventHandler(IAutomationStructureChangedEventHandler eventHandler)
        {
            AutomationObject.RemoveStructureChangedEventHandler(eventHandler);
        }

        /// <summary>
        /// Overrides the string representation of the element with something usefull
        /// </summary>
        public override string ToString()
        {
            return String.Format("AutomationId:{0}, Name:{1}, ControlType:{2}, FrameworkId:{3}",
                Current.AutomationId, Current.Name, Current.LocalizedControlType, Current.FrameworkId);
        }
    }
}
