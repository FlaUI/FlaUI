using System;
using System.Drawing;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using GdiColor = System.Drawing.Color;
using WpfColor = System.Windows.Media.Color;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    public class AutomationElement : IEquatable<AutomationElement>
    {
        public AutomationElement(BasicAutomationElementBase basicAutomationElement)
        {
            BasicAutomationElement = basicAutomationElement;
        }

        public BasicAutomationElementBase BasicAutomationElement { get; }

        public AutomationBase Automation => BasicAutomationElement.Automation;

        public ConditionFactory ConditionFactory => BasicAutomationElement.Automation.ConditionFactory;

        public IAutomationElementProperties Properties => Automation.PropertyLibrary.Element;

        public IAutomationElementEvents Events => Automation.EventLibrary.Element;

        public FrameworkType FrameworkType => FrameworkIds.ConvertToFrameworkType(Current.FrameworkId);

        public AutomationType AutomationType => BasicAutomationElement.Automation.AutomationType;

        public IPatternFactory PatternFactory => BasicAutomationElement.PatternFactory;

        /// <summary>
        /// Basic information about this element (cached)
        /// </summary>
        public IAutomationElementInformation Cached => BasicAutomationElement.Cached;

        /// <summary>
        /// Basic information about this element (realtime)
        /// </summary>
        public IAutomationElementInformation Current => BasicAutomationElement.Current;

        public void Click(bool moveMouse = true)
        {
            PerformMouseAction(moveMouse, Mouse.LeftClick);
        }

        public void DoubleClick(bool moveMouse = true)
        {
            PerformMouseAction(moveMouse, Mouse.LeftDoubleClick);
        }

        public void RightClick(bool moveMouse = true)
        {
            PerformMouseAction(moveMouse, Mouse.RightClick);
        }

        public void RightDoubleClick(bool moveMouse = true)
        {
            PerformMouseAction(moveMouse, Mouse.RightDoubleClick);
        }

        private void PerformMouseAction(bool moveMouse, Action action)
        {
            var clickablePoint = GetClickablePoint();
            if (moveMouse)
            {
                Mouse.MoveTo(clickablePoint);
            }
            else
            {
                Mouse.Position = clickablePoint;
            }
            action();
            Helpers.WaitUntilInputIsProcessed();
        }

        /// <summary>
        /// Sets the focus to this element
        /// Warning: This can be unreliable! <see cref="SetForeground" /> should be more reliable
        /// </summary>
        public virtual void Focus()
        {
            BasicAutomationElement.SetFocus();
        }

        public void FocusNative()
        {
            User32.SetFocus(Current.NativeWindowHandle);
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
            return DrawHighlight(Colors.Red);
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
                    BasicAutomationElement.Automation.OverlayManager.ShowBlocking(rectangle, color, durationInMs);
                }
                else
                {
                    BasicAutomationElement.Automation.OverlayManager.Show(rectangle, color, durationInMs);
                }
            }
            return this;
        }

        /// <summary>
        /// Captures the object as screenshot in WinForms format
        /// </summary>
        public Bitmap Capture()
        {
            return ScreenCapture.CaptureArea(Current.BoundingRectangle);
        }

        /// <summary>
        /// Captures the object as screenshot in WPF format
        /// </summary>
        public BitmapImage CaptureWpf()
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
            Predicate<AutomationElement[]> whilePredicate = elements => elements.Length == 0;
            Func<AutomationElement[]> retryMethod = () => BasicAutomationElement.FindAll(treeScope, condition);
            return Retry.While(retryMethod, whilePredicate, timeOut);
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
            Predicate<AutomationElement> whilePredicate = element => element == null;
            Func<AutomationElement> retryMethod = () => BasicAutomationElement.FindFirst(treeScope, condition);
            return Retry.While(retryMethod, whilePredicate, timeOut);
        }

        public AutomationElement FindFirstNested(params ConditionBase[] nestedConditions)
        {
            var currentElement = this;
            foreach (var condition in nestedConditions)
            {
                currentElement = currentElement.FindFirstChild(condition);
                if (currentElement == null)
                {
                    return null;
                }
            }
            return currentElement;
        }

        public AutomationElement[] FindAllNested(params ConditionBase[] nestedConditions)
        {
            var currentElement = this;
            for (var i = 0; i < nestedConditions.Length - 1; i++)
            {
                var condition = nestedConditions[i];
                currentElement = currentElement.FindFirstChild(condition);
                if (currentElement == null)
                {
                    return null;
                }
            }
            return currentElement.FindAllChildren(nestedConditions.Last());
        }

        /// <summary>
        /// Gets a clickable point of the element
        /// </summary>
        /// <exception cref="Exceptions.NoClickablePointException">Thrown when no clickable point was found</exception>
        public Shapes.Point GetClickablePoint()
        {
            return BasicAutomationElement.GetClickablePoint();
        }

        /// <summary>
        /// Tries to get a clickable point of the element
        /// </summary>
        /// <param name="point">The clickable point or null, if no point was found</param>
        /// <returns>True if a point was found, false otherwise</returns>
        public bool TryGetClickablePoint(out Shapes.Point point)
        {
            return BasicAutomationElement.TryGetClickablePoint(out point);
        }

        public IAutomationEventHandler RegisterEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action)
        {
            return BasicAutomationElement.RegisterEvent(@event, treeScope, action);
        }

        public IAutomationPropertyChangedEventHandler RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, params PropertyId[] properties)
        {
            return BasicAutomationElement.RegisterPropertyChangedEvent(treeScope, action, properties);
        }

        public IAutomationStructureChangedEventHandler RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action)
        {
            return BasicAutomationElement.RegisterStructureChangedEvent(treeScope, action);
        }

        public void RemoveAutomationEventHandler(EventId @event, IAutomationEventHandler eventHandler)
        {
            BasicAutomationElement.RemoveAutomationEventHandler(@event, eventHandler);
        }

        public void RemovePropertyChangedEventHandler(IAutomationPropertyChangedEventHandler eventHandler)
        {
            BasicAutomationElement.RemovePropertyChangedEventHandler(eventHandler);
        }

        public void RemoveStructureChangedEventHandler(IAutomationStructureChangedEventHandler eventHandler)
        {
            BasicAutomationElement.RemoveStructureChangedEventHandler(eventHandler);
        }

        public bool Equals(AutomationElement other)
        {
            return other != null && Automation.Compare(this, other);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AutomationElement);
        }

        public override int GetHashCode()
        {
            return BasicAutomationElement?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Overrides the string representation of the element with something usefull
        /// </summary>
        public override string ToString()
        {
            return String.Format("AutomationId:{0}, Name:{1}, ControlType:{2}, FrameworkId:{3}",
                Current.AutomationId, Current.Name, Current.LocalizedControlType, Current.FrameworkId);
        }

        protected internal void ExecuteInPattern<TPattern>(TPattern pattern, bool throwIfNotSupported, Action<TPattern> action)
        {
            if (pattern != null)
            {
                action(pattern);
            }
            else if (throwIfNotSupported)
            {
                throw new NotSupportedException();
            }
        }

        protected internal TRet ExecuteInPattern<TPattern, TRet>(TPattern pattern, bool throwIfNotSupported, Func<TPattern, TRet> func)
        {
            if (pattern != null)
            {
                return func(pattern);
            }
            if (throwIfNotSupported)
            {
                throw new NotSupportedException();
            }
            return default(TRet);
        }

        #region Convenience methods
        public AutomationElement[] FindAllChildren(ConditionBase condition)
        {
            return FindAll(TreeScope.Children, condition);
        }

        public AutomationElement FindFirstChild(ConditionBase condition)
        {
            return FindFirst(TreeScope.Children, condition);
        }

        public AutomationElement[] FindAllDescendants(ConditionBase condition)
        {
            return FindAll(TreeScope.Descendants, condition);
        }

        public AutomationElement FindFirstDescendant(ConditionBase condition)
        {
            return FindFirst(TreeScope.Descendants, condition);
        }
        #endregion Convenience methods
    }
}
