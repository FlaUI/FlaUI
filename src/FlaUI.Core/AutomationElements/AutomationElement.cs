using System;
using System.Drawing;
using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Wrapper object for each ui element which is should be automated.
    /// </summary>
    public partial class AutomationElement : IEquatable<AutomationElement>, IAutomationElementEventSubscriber
    {
        /// <summary>
        /// Creates a new instance which wraps around the given <see cref="FrameworkAutomationElement"/>.
        /// </summary>
        /// <param name="frameworkAutomationElement">The <see cref="FrameworkAutomationElement"/> to wrap.</param>
        public AutomationElement(FrameworkAutomationElementBase frameworkAutomationElement)
        {
            FrameworkAutomationElement = frameworkAutomationElement ?? throw new ArgumentNullException(nameof(frameworkAutomationElement));
        }

        /// <summary>
        /// Creates a new instance which wraps the <see cref="FrameworkAutomationElement"/> of the given <see cref="AutomationElement"/>.
        /// </summary>
        /// <param name="automationElement">The <see cref="AutomationElement"/> which <see cref="FrameworkAutomationElement"/> should be wrapped.</param>
        public AutomationElement(AutomationElement automationElement)
            : this(automationElement?.FrameworkAutomationElement)
        {
        }

        /// <summary>
        /// Object which contains the native wrapper element (UIA2 or UIA3) for this element.
        /// </summary>
        public FrameworkAutomationElementBase FrameworkAutomationElement { get; }

        /// <summary>
        /// Get the parent <see cref="AutomationElement"/>.
        /// </summary>
        public AutomationElement Parent => Automation.TreeWalkerFactory.GetRawViewWalker().GetParent(this);

        /// <summary>
        /// The current used automation object.
        /// </summary>
        public AutomationBase Automation => FrameworkAutomationElement.Automation;

        /// <summary>
        /// Shortcut to the condition factory for the current automation.
        /// </summary>
        public ConditionFactory ConditionFactory => FrameworkAutomationElement.Automation.ConditionFactory;

        /// <summary>
        /// The current <see cref="AutomationType" /> for this element.
        /// </summary>
        public AutomationType AutomationType => FrameworkAutomationElement.Automation.AutomationType;

        /// <summary>
        /// Standard UIA patterns of this element.
        /// </summary>
        public FrameworkAutomationElementBase.IFrameworkPatterns Patterns => FrameworkAutomationElement.Patterns;

        /// <summary>
        /// Standard UIA properties of this element.
        /// </summary>
        public FrameworkAutomationElementBase.IProperties Properties => FrameworkAutomationElement.Properties;

        /// <summary>
        /// Gets the cached children for this element.
        /// </summary>
        public AutomationElement[] CachedChildren => FrameworkAutomationElement.GetCachedChildren();

        /// <summary>
        /// Gets the cached parent for this element.
        /// </summary>
        public AutomationElement CachedParent => FrameworkAutomationElement.GetCachedParent();

        /// <summary>
        /// A flag that indicates if the element is still available. Can be false if the element is already unloaded from the ui.
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                try
                {
                    // ReSharper disable once UnusedVariable
                    var processId = Properties.ProcessId.Value;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        #region Convenience properties
        /// <summary>
        /// The direct framework type of the element.
        /// Results in "FrameworkType.Unknown" if it couldn't be resolved.
        /// </summary>
        public FrameworkType FrameworkType
        {
            get
            {
                var hasProperty = Properties.FrameworkId.TryGetValue(out string currentFrameworkId);
                return hasProperty ? FrameworkIds.Convert(currentFrameworkId) : FrameworkType.Unknown;
            }
        }

        /// <summary>
        /// The automation id of the element.
        /// </summary>
        public string AutomationId => Properties.AutomationId.Value;

        /// <summary>
        /// The name of the element.
        /// </summary>
        public string Name => Properties.Name.Value;

        /// <summary>
        /// The class name of the element.
        /// </summary>
        public string ClassName => Properties.ClassName.Value;

        /// <summary>
        /// The control type of the element.
        /// </summary>
        public ControlType ControlType => Properties.ControlType.Value;

        /// <summary>
        /// Flag if the element is enabled or not.
        /// </summary>
        public bool IsEnabled => Properties.IsEnabled.Value;

        /// <summary>
        /// Flag if the element off-screen or on-screen(visible).
        /// </summary>
        public bool IsOffscreen => Properties.IsOffscreen.Value;

        /// <summary>
        /// The bounding rectangle of this element.
        /// </summary>
        public Rectangle BoundingRectangle => Properties.BoundingRectangle.ValueOrDefault;

        /// <summary>
        /// The width of this element.
        /// </summary>
        public double ActualWidth => BoundingRectangle.Width;

        /// <summary>
        /// The height of this element.
        /// </summary>
        public double ActualHeight => BoundingRectangle.Height;

        /// <summary>
        /// The item status of this element.
        /// </summary>
        public string ItemStatus => Properties.ItemStatus.Value;

        /// <summary>
        /// The help text of this element.
        /// </summary>
        public string HelpText => Properties.HelpText.Value;
        #endregion Convenience properties

        /// <summary>
        /// Performs a left click on the element.
        /// </summary>
        /// <param name="moveMouse">Flag to indicate, if the mouse should move slowly (true) or instantly (false).</param>
        public void Click(bool moveMouse = false)
        {
            PerformMouseAction(moveMouse, Mouse.LeftClick);
        }

        /// <summary>
        /// Performs a double left click on the element.
        /// </summary>
        /// <param name="moveMouse">Flag to indicate, if the mouse should move slowly (true) or instantly (false).</param>
        public void DoubleClick(bool moveMouse = false)
        {
            PerformMouseAction(moveMouse, Mouse.LeftDoubleClick);
        }

        /// <summary>
        /// Performs a right click on the element.
        /// </summary>
        /// <param name="moveMouse">Flag to indicate, if the mouse should move slowly (true) or instantly (false).</param>
        public void RightClick(bool moveMouse = false)
        {
            PerformMouseAction(moveMouse, Mouse.RightClick);
        }

        /// <summary>
        /// Performs a double right click on the element.
        /// </summary>
        /// <param name="moveMouse">Flag to indicate, if the mouse should move slowly (true) or instantly (false).</param>
        public void RightDoubleClick(bool moveMouse = false)
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
            Wait.UntilInputIsProcessed();
        }

        /// <summary>
        /// Sets the focus to a control. If the control is a window, brings it to the foreground.
        /// </summary>
        public void Focus()
        {
            if (ControlType == ControlType.Window)
            {
                SetForeground();
            }
            else
            {
                FocusNative();
            }
        }

        /// <summary>
        /// Sets the focus by using the Win32 SetFocus() method.
        /// </summary>
        public void FocusNative()
        {
            if (Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != Win32Constants.FALSE)
                {
                    uint windowThreadId = User32.GetWindowThreadProcessId(windowHandle, out _);
                    uint currentThreadId = Kernel32.GetCurrentThreadId();

                    // attach window to the calling thread's message queue
                    User32.AttachThreadInput(currentThreadId, windowThreadId, true);
                    User32.SetFocus(windowHandle);
                    // detach the window from the calling thread's message queue
                    User32.AttachThreadInput(currentThreadId, windowThreadId, false);

                    Wait.UntilResponsive(this);
                    return;
                }
            }
            // Fallback to the UIA Version
            SetFocus();
        }

        /// <summary>
        /// Brings a window to the foreground.
        /// </summary>
        public void SetForeground()
        {
            if (Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != Win32Constants.FALSE)
                {
                    User32.SetForegroundWindow(windowHandle);
                    Wait.UntilResponsive(this);
                    return;
                }
            }
            // Fallback to the UIA Version
            SetFocus();
        }

        /// <summary>
        /// Captures the object as screenshot in <see cref="Bitmap"/> format.
        /// </summary>
        public Bitmap Capture()
        {
            return Capturing.Capture.Element(this).Bitmap;
        }

#if NETFRAMEWORK
        /// <summary>
        /// Captures the object as screenshot in a WPF friendly <see cref="System.Windows.Media.Imaging.BitmapImage"/> format.
        /// </summary>
        System.Windows.Media.Imaging.BitmapImage CaptureWpf()
        {
            return Capturing.Capture.Element(this).BitmapImage;
        }
#endif

        /// <summary>
        /// Captures the object as screenshot directly into the given file.
        /// </summary>
        /// <param name="filePath">The filepath where the screenshot should be saved.</param>
        public void CaptureToFile(string filePath)
        {
            Capturing.Capture.Element(this).ToFile(filePath);
        }

        /// <summary>
        /// Gets a clickable point of the element.
        /// </summary>
        /// <exception cref="Exceptions.NoClickablePointException">Thrown when no clickable point was found</exception>
        public Point GetClickablePoint()
        {
            return FrameworkAutomationElement.GetClickablePoint();
        }

        /// <summary>
        /// Tries to get a clickable point of the element.
        /// </summary>
        /// <param name="point">The clickable point or null, if no point was found</param>
        /// <returns>True if a point was found, false otherwise</returns>
        public bool TryGetClickablePoint(out Point point)
        {
            return FrameworkAutomationElement.TryGetClickablePoint(out point);
        }

        /// <inheritdoc />
        public ActiveTextPositionChangedEventHandlerBase RegisterActiveTextPositionChangedEvent(TreeScope treeScope, Action<AutomationElement, ITextRange> action)
        {
            return FrameworkAutomationElement.RegisterActiveTextPositionChangedEvent(treeScope, action);
        }

        /// <inheritdoc />
        public AutomationEventHandlerBase RegisterAutomationEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action)
        {
            if (Equals(@event, EventId.NotSupportedByFramework))
            {
                throw new NotSupportedByFrameworkException();
            }
            return FrameworkAutomationElement.RegisterAutomationEvent(@event, treeScope, action);
        }

        /// <inheritdoc />
        public PropertyChangedEventHandlerBase RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, params PropertyId[] properties)
        {
            return FrameworkAutomationElement.RegisterPropertyChangedEvent(treeScope, action, properties);
        }

        /// <inheritdoc />
        public StructureChangedEventHandlerBase RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action)
        {
            return FrameworkAutomationElement.RegisterStructureChangedEvent(treeScope, action);
        }

        /// <inheritdoc />
        public NotificationEventHandlerBase RegisterNotificationEvent(TreeScope treeScope, Action<AutomationElement, NotificationKind, NotificationProcessing, string, string> action)
        {
            return FrameworkAutomationElement.RegisterNotificationEvent(treeScope, action);
        }

        /// <inheritdoc />
        public TextEditTextChangedEventHandlerBase RegisterTextEditTextChangedEventHandler(TreeScope treeScope, TextEditChangeType textEditChangeType, Action<AutomationElement, TextEditChangeType, string[]> action)
        {
            return FrameworkAutomationElement.RegisterTextEditTextChangedEventHandler(treeScope, textEditChangeType, action);
        }

        /// <summary>
        /// Gets the available patterns for an element via properties.
        /// </summary>
        public PatternId[] GetSupportedPatterns()
        {
            return Automation.PatternLibrary.AllForCurrentFramework.Where(IsPatternSupported).ToArray();
        }

        /// <summary>
        /// Checks if the given pattern is available for the element via properties.
        /// </summary>
        public bool IsPatternSupported(PatternId pattern)
        {
            if (Equals(pattern, PatternId.NotSupportedByFramework))
            {
                return false;
            }
            if (pattern.AvailabilityProperty == null)
            {
                throw new ArgumentException("Pattern doesn't have an AvailabilityProperty");
            }
            var success = FrameworkAutomationElement.TryGetPropertyValue(pattern.AvailabilityProperty, out bool isPatternAvailable);
            return success && isPatternAvailable;
        }

        /// <summary>
        /// Gets the available patterns for an element via UIA method.
        /// Does not work with cached elements and might be unreliable.
        /// </summary>
        public PatternId[] GetSupportedPatternsDirect()
        {
            return FrameworkAutomationElement.GetSupportedPatterns();
        }

        /// <summary>
        /// Checks if the given pattern is available for the element via UIA method.
        /// Does not work with cached elements and might be unreliable.
        /// </summary>
        public bool IsPatternSupportedDirect(PatternId pattern)
        {
            return GetSupportedPatternsDirect().Contains(pattern);
        }

        /// <summary>
        /// Gets the available properties for an element via UIA method.
        /// Does not work with cached elements and might be unreliable.
        /// </summary>
        public PropertyId[] GetSupportedPropertiesDirect()
        {
            return FrameworkAutomationElement.GetSupportedProperties();
        }

        /// <summary>
        /// Method to check if the element supports the given property via UIA method.
        /// Does not work with cached elements and might be unreliable.
        /// </summary>
        public bool IsPropertySupportedDirect(PropertyId property)
        {
            return GetSupportedPropertiesDirect().Contains(property);
        }

        /// <summary>
        /// Gets metadata from the UI Automation element that indicates how the information should be interpreted.
        /// </summary>
        /// <param name="targetId">The property to retrieve.</param>
        /// <param name="metadataId">Specifies the type of metadata to retrieve.</param>
        /// <returns>The metadata.</returns>
        public object GetCurrentMetadataValue(PropertyId targetId, int metadataId)
        {
            return FrameworkAutomationElement.GetCurrentMetadataValue(targetId, metadataId);
        }

        /// <summary>
        /// Compares two elements.
        /// </summary>
        public bool Equals(AutomationElement other)
        {
            return other != null && Automation.Compare(this, other);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return Equals(obj as AutomationElement);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return FrameworkAutomationElement?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Overrides the string representation of the element with something useful.
        /// </summary>
        public override string ToString()
        {
            return String.Format("AutomationId:{0}, Name:{1}, ControlType:{2}, FrameworkId:{3}",
                Properties.AutomationId.ValueOrDefault, Properties.Name.ValueOrDefault,
                Properties.LocalizedControlType.ValueOrDefault, Properties.FrameworkId.ValueOrDefault);
        }

        /// <summary>
        /// Executes the given action on the given pattern.
        /// </summary>
        /// <typeparam name="TPattern">The type of the pattern.</typeparam>
        /// <param name="pattern">The pattern.</param>
        /// <param name="throwIfNotSupported">Flag to indicate if an exception should be thrown if the pattern is not supported.</param>
        /// <param name="action">The action to execute on the pattern</param>
        protected internal void ExecuteInPattern<TPattern>(TPattern pattern, bool throwIfNotSupported, Action<TPattern> action)
        {
            if (pattern != null)
            {
                action(pattern);
            }
            else if (throwIfNotSupported)
            {
                throw new System.NotSupportedException();
            }
        }

        /// <summary>
        /// Executes the given func on the given pattern returning the received value.
        /// </summary>
        /// <typeparam name="TPattern">The type of the pattern.</typeparam>
        /// <typeparam name="TRet">The type of the return value.</typeparam>
        /// <param name="pattern">Zhe pattern.</param>
        /// <param name="throwIfNotSupported">Flag to indicate if an exception should be thrown if the pattern is not supported.</param>
        /// <param name="func">The function to execute on the pattern.</param>
        /// <returns>The value received from the pattern or the default if the pattern is not supported.</returns>
        protected internal TRet ExecuteInPattern<TPattern, TRet>(TPattern pattern, bool throwIfNotSupported, Func<TPattern, TRet> func)
        {
            if (pattern != null)
            {
                return func(pattern);
            }
            if (throwIfNotSupported)
            {
                throw new System.NotSupportedException();
            }
            return default;
        }

        /// <summary>
        /// Sets focus onto control using UIA native element
        /// </summary>
        protected virtual void SetFocus()
        {
            FrameworkAutomationElement.SetFocus();
        }
    }
}
