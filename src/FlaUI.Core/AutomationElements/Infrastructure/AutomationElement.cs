using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FlaUI.Core.AutomationElements.Scrolling;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Exceptions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using GdiColor = System.Drawing.Color;
using Rectangle = FlaUI.Core.Shapes.Rectangle;
using WpfColor = System.Windows.Media.Color;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    /// <summary>
    /// Wrapper object for each ui element which is automatable.
    /// </summary>
    public class AutomationElement : IEquatable<AutomationElement>
    {
        /// <summary>
        /// Creates a new instance which wraps around the given <see cref="BasicAutomationElement"/>.
        /// </summary>
        /// <param name="basicAutomationElement">The <see cref="BasicAutomationElement"/> to wrap.</param>
        public AutomationElement(BasicAutomationElementBase basicAutomationElement)
        {
            BasicAutomationElement = basicAutomationElement ?? throw new ArgumentNullException(nameof(basicAutomationElement));
        }

        /// <summary>
        /// Creates a new instance which wraps the <see cref="BasicAutomationElement"/> of the given <see cref="AutomationElement"/>.
        /// </summary>
        /// <param name="automationElement">The <see cref="AutomationElement"/> which <see cref="BasicAutomationElement"/> should be wrapped.</param>
        public AutomationElement(AutomationElement automationElement)
            : this(automationElement?.BasicAutomationElement)
        {
        }

        /// <summary>
        /// Object which contains the native wrapper element (UIA2 or UIA3) for this element.
        /// </summary>
        public BasicAutomationElementBase BasicAutomationElement { get; }

        /// <summary>
        /// Get the parent <see cref="AutomationElement"/>.
        /// </summary>
        public AutomationElement Parent => Automation.TreeWalkerFactory.GetRawViewWalker().GetParent(this);

        /// <summary>
        /// The current used automation object.
        /// </summary>
        public AutomationBase Automation => BasicAutomationElement.Automation;

        /// <summary>
        /// Shortcut to the condition factory for the current automation.
        /// </summary>
        public ConditionFactory ConditionFactory => BasicAutomationElement.Automation.ConditionFactory;

        /// <summary>
        /// The current <see cref="AutomationType" /> for this element.
        /// </summary>
        public AutomationType AutomationType => BasicAutomationElement.Automation.AutomationType;

        /// <summary>
        /// Standard UIA patterns of this element.
        /// </summary>
        public AutomationElementPatternValuesBase Patterns => BasicAutomationElement.Patterns;

        /// <summary>
        /// Standard UIA properties of this element.
        /// </summary>
        public AutomationElementPropertyValues Properties => BasicAutomationElement.Properties;

        /// <summary>
        /// Gets the cached children for this element.
        /// </summary>
        public AutomationElement[] CachedChildren => BasicAutomationElement.GetCachedChildren();

        /// <summary>
        /// Gets the cached parent for this element.
        /// </summary>
        public AutomationElement CachedParent => BasicAutomationElement.GetCachedParent();

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
                return hasProperty ? FrameworkIds.ConvertToFrameworkType(currentFrameworkId) : FrameworkType.Unknown;
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
        public Rectangle BoundingRectangle => Properties.BoundingRectangle.ValueOrDefault ?? Rectangle.Empty;

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
                if (windowHandle != new IntPtr(0))
                {
                    User32.SetFocus(windowHandle);
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
                if (windowHandle != new IntPtr(0))
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
        /// Draws a red highlight around the element.
        /// </summary>
        public AutomationElement DrawHighlight()
        {
            return DrawHighlight(Colors.Red);
        }

        /// <summary>
        /// Draws a manually colored highlight around the element.
        /// </summary>
        public AutomationElement DrawHighlight(WpfColor color)
        {
            return DrawHighlight(true, color);
        }

        /// <summary>
        /// Draws a manually colored highlight around the element.
        /// </summary>
        public AutomationElement DrawHighlight(GdiColor color)
        {
            return DrawHighlight(true, color);
        }

        /// <summary>
        /// Draw a highlight around the element with the given settings.
        /// </summary>
        /// <param name="blocking">Flag to indicate if further execution waits until the highlight is removed.</param>
        /// <param name="color">The color to draw the highlight.</param>
        /// <param name="duration">The duration how long the highlight is shown.</param>
        /// <remarks>Override for winforms color.</remarks>
        public AutomationElement DrawHighlight(bool blocking, GdiColor color, TimeSpan? duration = null)
        {
            return DrawHighlight(blocking, WpfColor.FromArgb(color.A, color.R, color.G, color.B), duration);
        }

        /// <summary>
        /// Draw a highlight around the element with the given settings.
        /// </summary>
        /// <param name="blocking">Flag to indicate if further execution waits until the highlight is removed.</param>
        /// <param name="color">The color to draw the highlight.</param>
        /// <param name="duration">The duration how long the highlight is shown.</param>
        public AutomationElement DrawHighlight(bool blocking, WpfColor color, TimeSpan? duration = null)
        {
            var rectangle = Properties.BoundingRectangle.Value;
            if (!rectangle.IsEmpty)
            {
                var durationInMs = (int)(duration ?? TimeSpan.FromSeconds(2)).TotalMilliseconds;
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
        /// Captures the object as screenshot in <see cref="Bitmap"/> format.
        /// </summary>
        public Bitmap Capture()
        {
            return Core.Capture.Element(this).Bitmap;
        }

        /// <summary>
        /// Captures the object as screenshot in a WPF friendly <see cref="BitmapImage"/> format.
        /// </summary>
        public BitmapImage CaptureWpf()
        {
            return Core.Capture.Element(this).BitmapImage;
        }

        /// <summary>
        /// Captures the object as screenshot directly into the given file.
        /// </summary>
        /// <param name="filePath">The filepath where the screenshot should be saved.</param>
        public void CaptureToFile(string filePath)
        {
            Core.Capture.Element(this).ToFile(filePath);
        }

        /// <summary>
        /// Finds all elements in the given treescope and with the given condition.
        /// </summary>
        public AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition)
        {
            return FindAll(treeScope, condition, Retry.DefaultRetryFor);
        }

        /// <summary>
        /// Finds all elements in the given treescope and with the given condition within the given timeout.
        /// </summary>
        public AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition, TimeSpan timeOut)
        {
            Predicate<AutomationElement[]> whilePredicate = elements => elements.Length == 0;
            Func<AutomationElement[]> retryMethod = () => BasicAutomationElement.FindAll(treeScope, condition);
            return Retry.While(retryMethod, whilePredicate, timeOut);
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition.
        /// </summary>
        public AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition)
        {
            return FindFirst(treeScope, condition, Retry.DefaultRetryFor);
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition within the given timeout period.
        /// </summary>
        public AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition, TimeSpan timeOut)
        {
            Predicate<AutomationElement> whilePredicate = element => element == null;
            Func<AutomationElement> retryMethod = () => BasicAutomationElement.FindFirst(treeScope, condition);
            return Retry.While(retryMethod, whilePredicate, timeOut);
        }

        /// <summary>
        /// Finds the first element by iterating thru all conditions.
        /// </summary>
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

        /// <summary>
        /// Finds all elements by iterating thru all conditions.
        /// </summary>
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
        /// Finds for the first item which matches the given xpath.
        /// </summary>
        public AutomationElement FindFirstByXPath(string xPath)
        {
            var xPathNavigator = new AutomationElementXPathNavigator(this);
            var nodeItem = xPathNavigator.SelectSingleNode(xPath);
            return (AutomationElement)nodeItem?.UnderlyingObject;
        }

        /// <summary>
        /// Finds all items which match the given xpath.
        /// </summary>
        public AutomationElement[] FindAllByXPath(string xPath)
        {
            var xPathNavigator = new AutomationElementXPathNavigator(this);
            var itemNodeIterator = xPathNavigator.Select(xPath);
            var itemList = new List<AutomationElement>();
            while (itemNodeIterator.MoveNext())
            {
                var automationItem = (AutomationElement)itemNodeIterator.Current.UnderlyingObject;
                itemList.Add(automationItem);
            }
            return itemList.ToArray();
        }

        /// <summary>
        /// Finds the element which is in the given treescope with the given condition and the given index.
        /// </summary>
        public AutomationElement FindAt(TreeScope treeScope, int index, ConditionBase condition)
        {
            Predicate<AutomationElement> whilePredicate = element => element == null;
            Func<AutomationElement> retryMethod = () => BasicAutomationElement.FindIndexed(treeScope, index, condition);
            return Retry.While(retryMethod, whilePredicate, Retry.DefaultRetryFor);
        }

        /// <summary>
        /// Finds the element which is in the given treescope with the given condition and the given index within the given timeout period.
        /// </summary>
        public AutomationElement FindAt(TreeScope treeScope, ConditionBase condition, int index, TimeSpan timeOut)
        {
            Predicate<AutomationElement> whilePredicate = element => element == null;
            Func<AutomationElement> retryMethod = () => BasicAutomationElement.FindIndexed(treeScope, index, condition);
            return Retry.While(retryMethod, whilePredicate, timeOut);
        }

        /// <summary>
        /// Gets a clickable point of the element.
        /// </summary>
        /// <exception cref="Exceptions.NoClickablePointException">Thrown when no clickable point was found</exception>
        public Shapes.Point GetClickablePoint()
        {
            return BasicAutomationElement.GetClickablePoint();
        }

        /// <summary>
        /// Tries to get a clickable point of the element.
        /// </summary>
        /// <param name="point">The clickable point or null, if no point was found</param>
        /// <returns>True if a point was found, false otherwise</returns>
        public bool TryGetClickablePoint(out Shapes.Point point)
        {
            return BasicAutomationElement.TryGetClickablePoint(out point);
        }

        /// <summary>
        /// Registers the given event
        /// </summary>
        public IAutomationEventHandler RegisterEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action)
        {
            if (Equals(@event, EventId.NotSupportedByFramework))
            {
                throw new NotSupportedByFrameworkException();
            }
            return BasicAutomationElement.RegisterEvent(@event, treeScope, action);
        }

        /// <summary>
        /// Registers a property changed event with the given property
        /// </summary>
        public IAutomationPropertyChangedEventHandler RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, params PropertyId[] properties)
        {
            return BasicAutomationElement.RegisterPropertyChangedEvent(treeScope, action, properties);
        }

        /// <summary>
        /// Registers a structure changed event
        /// </summary>
        public IAutomationStructureChangedEventHandler RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action)
        {
            return BasicAutomationElement.RegisterStructureChangedEvent(treeScope, action);
        }

        /// <summary>
        /// Removes the given event handler for the event
        /// </summary>
        public void RemoveAutomationEventHandler(EventId @event, IAutomationEventHandler eventHandler)
        {
            BasicAutomationElement.RemoveAutomationEventHandler(@event, eventHandler);
        }

        /// <summary>
        /// Removes the given property changed event handler
        /// </summary>
        public void RemovePropertyChangedEventHandler(IAutomationPropertyChangedEventHandler eventHandler)
        {
            BasicAutomationElement.RemovePropertyChangedEventHandler(eventHandler);
        }

        /// <summary>
        /// Removes the given structure changed event handler
        /// </summary>
        public void RemoveStructureChangedEventHandler(IAutomationStructureChangedEventHandler eventHandler)
        {
            BasicAutomationElement.RemoveStructureChangedEventHandler(eventHandler);
        }

        /// <summary>
        /// Gets the available patterns for an element via properties
        /// </summary>
        public PatternId[] GetSupportedPatterns()
        {
            return Automation.PatternLibrary.AllForCurrentFramework.Where(IsPatternSupported).ToArray();
        }

        /// <summary>
        /// Checks if the given pattern is available for the element via properties
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
            var success = BasicAutomationElement.TryGetPropertyValue(pattern.AvailabilityProperty, out bool isPatternAvailable);
            return success && isPatternAvailable;
        }

        /// <summary>
        /// Gets the available patterns for an element via UIA method.
        /// Does not work with cached elements and might be unreliable.
        /// </summary>
        public PatternId[] GetSupportedPatternsDirect()
        {
            return BasicAutomationElement.GetSupportedPatterns();
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
            return BasicAutomationElement.GetSupportedProperties();
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
            return BasicAutomationElement?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Overrides the string representation of the element with something usefull
        /// </summary>
        public override string ToString()
        {
            return String.Format("AutomationId:{0}, Name:{1}, ControlType:{2}, FrameworkId:{3}",
                Properties.AutomationId.ValueOrDefault, Properties.Name.ValueOrDefault, Properties.LocalizedControlType.ValueOrDefault, Properties.FrameworkId.ValueOrDefault);
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
            return default(TRet);
        }

        /// <summary>
        /// Sets focus onto control using UIA native element
        /// </summary>
        protected virtual void SetFocus()
        {
            BasicAutomationElement.SetFocus();
        } 

        #region Conversion Methods
        /// <summary>
        /// Converts the element to a <see cref="Button"/>.
        /// </summary>
        public Button AsButton()
        {
            return new Button(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="CheckBox"/>.
        /// </summary>
        public CheckBox AsCheckBox()
        {
            return new CheckBox(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ComboBox"/>.
        /// </summary>
        public ComboBox AsComboBox()
        {
            return new ComboBox(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="DataGridView"/>.
        /// </summary>
        public DataGridView AsDataGridView()
        {
            return new DataGridView(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Label"/>.
        /// </summary>
        public Label AsLabel()
        {
            return new Label(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Grid"/>.
        /// </summary>
        public Grid AsGrid()
        {
            return new Grid(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridRow"/>.
        /// </summary>
        public GridRow AsGridRow()
        {
            return new GridRow(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridCell"/>.
        /// </summary>
        public GridCell AsGridCell()
        {
            return new GridCell(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridHeader"/>.
        /// </summary>
        public GridHeader AsGridHeader()
        {
            return new GridHeader(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="GridHeaderItem"/>.
        /// </summary>
        public GridHeaderItem AsGridHeaderItem()
        {
            return new GridHeaderItem(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="HorizontalScrollBar"/>.
        /// </summary>
        public HorizontalScrollBar AsHorizontalScrollBar()
        {
            return new HorizontalScrollBar(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ListBox"/>.
        /// </summary>
        public ListBox AsListBox()
        {
            return new ListBox(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ListBoxItem"/>.
        /// </summary>
        public ListBoxItem AsListBoxItem()
        {
            return new ListBoxItem(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Menu"/>.
        /// </summary>
        public Menu AsMenu()
        {
            return new Menu(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="MenuItem"/>.
        /// </summary>
        public MenuItem AsMenuItem()
        {
            return new MenuItem(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ProgressBar"/>.
        /// </summary>
        public ProgressBar AsProgressBar()
        {
            return new ProgressBar(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="RadioButton"/>.
        /// </summary>
        public RadioButton AsRadioButton()
        {
            return new RadioButton(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Slider"/>.
        /// </summary>
        public Slider AsSlider()
        {
            return new Slider(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Tab"/>.
        /// </summary>
        public Tab AsTab()
        {
            return new Tab(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TabItem"/>.
        /// </summary>
        public TabItem AsTabItem()
        {
            return new TabItem(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TextBox"/>.
        /// </summary>
        public TextBox AsTextBox()
        {
            return new TextBox(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Thumb"/>.
        /// </summary>
        public Thumb AsThumb()
        {
            return new Thumb(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TitleBar"/>.
        /// </summary>
        public TitleBar AsTitleBar()
        {
            return new TitleBar(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="ToggleButton"/>.
        /// </summary>
        public ToggleButton AsToggleButton()
        {
            return new ToggleButton(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Tree"/>.
        /// </summary>
        public Tree AsTree()
        {
            return new Tree(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="TreeItem"/>.
        /// </summary>
        public TreeItem AsTreeItem()
        {
            return new TreeItem(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="VerticalScrollBar"/>.
        /// </summary>
        public VerticalScrollBar AsVerticalScrollBar()
        {
            return new VerticalScrollBar(BasicAutomationElement);
        }

        /// <summary>
        /// Converts the element to a <see cref="Window"/>.
        /// </summary>
        public Window AsWindow()
        {
            return new Window(BasicAutomationElement);
        }
        #endregion Conversion Methods

        #region Convenience methods
        /// <summary>
        /// Finds the first child.
        /// </summary>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindFirstChild()
        {
            return FindFirst(TreeScope.Children, TrueCondition.Default);
        }

        /// <summary>
        /// Finds the first child with the given automation id.
        /// </summary>
        /// <param name="automationId">The automation id.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindFirstChild(string automationId)
        {
            return FindFirst(TreeScope.Children, ConditionFactory.ByAutomationId(automationId));
        }

        /// <summary>
        /// Finds the first child with the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindFirstChild(ConditionBase condition)
        {
            return FindFirst(TreeScope.Children, condition);
        }

        /// <summary>
        /// Finds the first child with the condition.
        /// </summary>
        /// <param name="conditionFunc">The condition method.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindFirstChild(Func<ConditionFactory, ConditionBase> conditionFunc)
        {
            var condition = conditionFunc(ConditionFactory);
            return FindFirstChild(condition);
        }

        /// <summary>
        /// Finds all children.
        /// </summary>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllChildren()
        {
            return FindAll(TreeScope.Children, TrueCondition.Default);
        }

        /// <summary>
        /// Finds all children with the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllChildren(ConditionBase condition)
        {
            return FindAll(TreeScope.Children, condition);
        }

        /// <summary>
        /// Finds all children with the condition.
        /// </summary>
        /// <param name="conditionFunc">The condition mehtod.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllChildren(Func<ConditionFactory, ConditionBase> conditionFunc)
        {
            var condition = conditionFunc(ConditionFactory);
            return FindAllChildren(condition);
        }

        /// <summary>
        /// Finds the first descendant.
        /// </summary>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindFirstDescendant()
        {
            return FindFirst(TreeScope.Descendants, TrueCondition.Default);
        }

        /// <summary>
        /// Finds the first descendant with the given automation id.
        /// </summary>
        /// <param name="automationId">The automation id.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindFirstDescendant(string automationId)
        {
            return FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId(automationId));
        }

        /// <summary>
        /// Finds the first descendant with the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindFirstDescendant(ConditionBase condition)
        {
            return FindFirst(TreeScope.Descendants, condition);
        }

        /// <summary>
        /// Finds the first descendant with the condition.
        /// </summary>
        /// <param name="conditionFunc">The condition method.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindFirstDescendant(Func<ConditionFactory, ConditionBase> conditionFunc)
        {
            var condition = conditionFunc(ConditionFactory);
            return FindFirstDescendant(condition);
        }

        /// <summary>
        /// Finds all descendants.
        /// </summary>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllDescendants()
        {
            return FindAll(TreeScope.Descendants, TrueCondition.Default);
        }

        /// <summary>
        /// Finds all descendants with the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllDescendants(ConditionBase condition)
        {
            return FindAll(TreeScope.Descendants, condition);
        }

        /// <summary>
        /// Finds all descendants with the condition.
        /// </summary>
        /// <param name="conditionFunc">The condition mehtod.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllDescendants(Func<ConditionFactory, ConditionBase> conditionFunc)
        {
            var condition = conditionFunc(ConditionFactory);
            return FindAllDescendants(condition);
        }

        /// <summary>
        /// Finds the first element by iterating thru all conditions.
        /// </summary>
        /// <param name="conditionFunc">The condition method.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindFirstNested(Func<ConditionFactory, IList<ConditionBase>> conditionFunc)
        {
            var conditions = conditionFunc(ConditionFactory);
            return FindFirstNested(conditions.ToArray());
        }

        /// <summary>
        /// Finds all elements by iterating thru all conditions.
        /// </summary>
        /// <param name="conditionFunc">The condition method.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllNested(Func<ConditionFactory, IList<ConditionBase>> conditionFunc)
        {
            var conditions = conditionFunc(ConditionFactory);
            return FindAllNested(conditions.ToArray());
        }

        /// <summary>
        /// Finds the child at the given position.
        /// </summary>
        /// <param name="index">The index of the child to find.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindChildAt(int index)
        {
            return FindChildAt(index, TrueCondition.Default);
        }

        /// <summary>
        /// Finds the child at the given position with the condition.
        /// </summary>
        /// <param name="index">The index of the child to find.</param>
        /// <param name="condition">The condition.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindChildAt(int index, ConditionBase condition)
        {
            return FindAt(TreeScope.Children, index, condition);
        }

        /// <summary>
        /// Finds the child at the given position with the condition.
        /// </summary>
        /// <param name="index">The index of the child to find.</param>
        /// <param name="conditionFunc">The condition mehtod.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement FindChildAt(int index, Func<ConditionFactory, ConditionBase> conditionFunc)
        {
            var condition = conditionFunc(ConditionFactory);
            return FindChildAt(index, condition);
        }
        #endregion Convenience methods
    }
}
