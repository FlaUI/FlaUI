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

        public FrameworkType FrameworkType
        {
            get
            {
                string currentFrameworkId;
                var hasProperty = Properties.FrameworkId.TryGetValue(out currentFrameworkId);
                return hasProperty ? FrameworkIds.ConvertToFrameworkType(currentFrameworkId) : FrameworkType.Unknown;
            }
        }

        public AutomationType AutomationType => BasicAutomationElement.Automation.AutomationType;

        /// <summary>
        /// Standard UIA patterns of this element
        /// </summary>
        public AutomationElementPatternValuesBase Patterns => BasicAutomationElement.Patterns;

        /// <summary>
        /// Standard UIA properties of this element
        /// </summary>
        public AutomationElementPropertyValues Properties => BasicAutomationElement.Properties;

        /// <summary>
        /// Gets the cached children for this element
        /// </summary>
        public AutomationElement[] CachedChildren => BasicAutomationElement.GetCachedChildren();

        /// <summary>
        /// Gets the cached parent for this element
        /// </summary>
        public AutomationElement CachedParent => BasicAutomationElement.GetCachedParent();

        public void Click(bool moveMouse = false)
        {
            PerformMouseAction(moveMouse, Mouse.LeftClick);
        }

        public void DoubleClick(bool moveMouse = false)
        {
            PerformMouseAction(moveMouse, Mouse.LeftDoubleClick);
        }

        public void RightClick(bool moveMouse = false)
        {
            PerformMouseAction(moveMouse, Mouse.RightClick);
        }

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
            var windowHandle = Properties.NativeWindowHandle;
            if (windowHandle != new IntPtr(0))
            {
                User32.SetFocus(windowHandle);
                Helpers.WaitUntilResponsive(this);
            }
            else
            {
                // Fallback to the UIA Version
                Focus();
            }
        }

        /// <summary>
        /// Brings the element to the foreground
        /// </summary>
        public void SetForeground()
        {
            var windowHandle = Properties.NativeWindowHandle;
            if (windowHandle != new IntPtr(0))
            {
                User32.SetForegroundWindow(windowHandle);
                Helpers.WaitUntilResponsive(this);
            }
            else
            {
                // Fallback to the UIA Version
                Focus();
            }
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
            var rectangle = Properties.BoundingRectangle.Value;
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
            return ScreenCapture.CaptureArea(Properties.BoundingRectangle);
        }

        /// <summary>
        /// Captures the object as screenshot in WPF format
        /// </summary>
        public BitmapImage CaptureWpf()
        {
            return ScreenCapture.CaptureAreaWpf(Properties.BoundingRectangle);
        }

        public void CaptureToFile(string filePath)
        {
            ScreenCapture.CaptureAreaToFile(Properties.BoundingRectangle, filePath);
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
        /// Finds for the first item which matches the given xpath
        /// </summary>
        public AutomationElement FindFirstByXPath(string xPath)
        {
            var xPathNavigator = new AutomationElementXPathNavigator(this);
            var nodeItem = xPathNavigator.SelectSingleNode(xPath);
            return (AutomationElement)nodeItem?.UnderlyingObject;
        }

        /// <summary>
        /// Finds all items which match the given xpath
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
            if (Equals(@event, EventId.NotSupportedByFramework))
            {
                throw new NotSupportedByFrameworkException();
            }
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
            bool isPatternAvailable;
            var success = BasicAutomationElement.TryGetPropertyValue(pattern.AvailabilityProperty, out isPatternAvailable);
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
        /// Compares two UIA elements
        /// </summary>
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
                Properties.AutomationId.ValueOrDefault, Properties.Name.ValueOrDefault, Properties.LocalizedControlType.ValueOrDefault, Properties.FrameworkId.ValueOrDefault);
        }

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

        #region Conversion Methods
        public Button AsButton()
        {
            return new Button(BasicAutomationElement);
        }

        public CheckBox AsCheckBox()
        {
           return new CheckBox(BasicAutomationElement);
        }

        public ComboBox AsComboBox()
        {
           return new ComboBox(BasicAutomationElement);
        }

        public Label AsLabel()
        {
           return new Label(BasicAutomationElement);
        }

        public Grid AsGrid()
        {
           return new Grid(BasicAutomationElement);
        }

        public GridRow AsGridRow()
        {
           return new GridRow(BasicAutomationElement);
        }

        public GridCell AsGridCell()
        {
           return new GridCell(BasicAutomationElement);
        }

        public GridHeader AsGridHeader()
        {
           return new GridHeader(BasicAutomationElement);
        }

        public GridHeaderItem AsGridHeaderItem()
        {
           return new GridHeaderItem(BasicAutomationElement);
        }

        public HScrollBar AsHScrollBar()
        {
           return new HScrollBar(BasicAutomationElement);
        }

        public Menu AsMenu()
        {
           return new Menu(BasicAutomationElement);
        }

        public MenuItem AsMenuItem()
        {
           return new MenuItem(BasicAutomationElement);
        }

        public ProgressBar AsProgressBar()
        {
           return new ProgressBar(BasicAutomationElement);
        }

        public RadioButton AsRadioButton()
        {
           return new RadioButton(BasicAutomationElement);
        }

        public Slider AsSlider()
        {
           return new Slider(BasicAutomationElement);
        }

        public Tab AsTab()
        {
           return new Tab(BasicAutomationElement);
        }

        public TabItem AsTabItem()
        {
           return new TabItem(BasicAutomationElement);
        }

        public TextBox AsTextBox()
        {
           return new TextBox(BasicAutomationElement);
        }

        public Thumb AsThumb()
        {
           return new Thumb(BasicAutomationElement);
        }

        public TitleBar AsTitleBar()
        {
           return new TitleBar(BasicAutomationElement);
        }

        public Tree AsTree()
        {
           return new Tree(BasicAutomationElement);
        }

        public TreeItem AsTreeItem()
        {
           return new TreeItem(BasicAutomationElement);
        }

        public VScrollBar AsVScrollBar()
        {
           return new VScrollBar(BasicAutomationElement);
        }

        public Window AsWindow()
        {
           return new Window(BasicAutomationElement);
        }
        #endregion Conversion Methods

        #region Convenience methods
        public AutomationElement FindFirstChild()
        {
            return FindFirst(TreeScope.Children, new TrueCondition());
        }

        public AutomationElement FindFirstChild(ConditionBase condition)
        {
            return FindFirst(TreeScope.Children, condition);
        }

        public AutomationElement FindFirstChild(Func<ConditionFactory, ConditionBase> newConditionFunc)
        {
            var condition = newConditionFunc(ConditionFactory);
            return FindFirstChild(condition);
        }

        public AutomationElement[] FindAllChildren()
        {
            return FindAll(TreeScope.Children, new TrueCondition());
        }

        public AutomationElement[] FindAllChildren(ConditionBase condition)
        {
            return FindAll(TreeScope.Children, condition);
        }

        public AutomationElement[] FindAllChildren(Func<ConditionFactory, ConditionBase> newConditionFunc)
        {
            var condition = newConditionFunc(ConditionFactory);
            return FindAllChildren(condition);
        }

        public AutomationElement FindFirstDescendant()
        {
            return FindFirst(TreeScope.Descendants, new TrueCondition());
        }

        public AutomationElement FindFirstDescendant(ConditionBase condition)
        {
            return FindFirst(TreeScope.Descendants, condition);
        }

        public AutomationElement FindFirstDescendant(Func<ConditionFactory, ConditionBase> newConditionFunc)
        {
            var condition = newConditionFunc(ConditionFactory);
            return FindFirstDescendant(condition);
        }

        public AutomationElement[] FindAllDescendants()
        {
            return FindAll(TreeScope.Descendants, new TrueCondition());
        }

        public AutomationElement[] FindAllDescendants(ConditionBase condition)
        {
            return FindAll(TreeScope.Descendants, condition);
        }

        public AutomationElement[] FindAllDescendants(Func<ConditionFactory, ConditionBase> newConditionFunc)
        {
            var condition = newConditionFunc(ConditionFactory);
            return FindAllDescendants(condition);
        }

        public AutomationElement FindFirstNested(Func<ConditionFactory, IList<ConditionBase>> nestedConditionsFunc)
        {
            var conditions = nestedConditionsFunc(ConditionFactory);
            return FindFirstNested(conditions.ToArray());
        }

        public AutomationElement[] FindAllNested(Func<ConditionFactory, IList<ConditionBase>> nestedConditionsFunc)
        {
            var conditions = nestedConditionsFunc(ConditionFactory);
            return FindAllNested(conditions.ToArray());
        }
        #endregion Convenience methods
    }
}
