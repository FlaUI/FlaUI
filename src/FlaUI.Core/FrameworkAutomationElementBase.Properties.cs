using System;
using System.Globalization;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;

namespace FlaUI.Core
{
    public abstract partial class FrameworkAutomationElementBase : FrameworkAutomationElementBase.IProperties
    {
        private AutomationProperty<string> _acceleratorKey;
        private AutomationProperty<string> _accessKey;
        private AutomationProperty<int[]> _annotationObjects;
        private AutomationProperty<int[]> _annotationTypes;
        private AutomationProperty<string> _ariaProperties;
        private AutomationProperty<string> _ariaRole;
        private AutomationProperty<string> _automationId;
        private AutomationProperty<Rectangle> _boundingRectangle;
        private AutomationProperty<Point> _centerPoint;
        private AutomationProperty<string> _className;
        private AutomationProperty<Point> _clickablePoint;
        private AutomationProperty<AutomationElement[]> _controllerFor;
        private AutomationProperty<ControlType> _controlType;
        private AutomationProperty<CultureInfo> _culture;
        private AutomationProperty<AutomationElement[]> _describedBy;
        private AutomationProperty<int> _fillColor;
        private AutomationProperty<int> _fillType;
        private AutomationProperty<AutomationElement[]> _flowsFrom;
        private AutomationProperty<AutomationElement[]> _flowsTo;
        private AutomationProperty<string> _frameworkId;
        private AutomationProperty<string> _fullDescription;
        private AutomationProperty<bool> _hasKeyboardFocus;
        private AutomationProperty<string> _helpText;
        private AutomationProperty<bool> _isContentElement;
        private AutomationProperty<bool> _isControlElement;
        private AutomationProperty<bool> _isDataValidForForm;
        private AutomationProperty<bool> _isEnabled;
        private AutomationProperty<bool> _isKeyboardFocusable;
        private AutomationProperty<bool> _isOffscreen;
        private AutomationProperty<bool> _isPassword;
        private AutomationProperty<bool> _isPeripheral;
        private AutomationProperty<bool> _isRequiredForForm;
        private AutomationProperty<string> _itemStatus;
        private AutomationProperty<string> _itemType;
        private AutomationProperty<AutomationElement> _labeledBy;
        private AutomationProperty<int> _landmarkType;
        private AutomationProperty<int> _level;
        private AutomationProperty<LiveSetting> _liveSetting;
        private AutomationProperty<string> _localizedControlType;
        private AutomationProperty<string> _localizedLandmarkType;
        private AutomationProperty<string> _name;
        private AutomationProperty<IntPtr> _nativeWindowHandle;
        private AutomationProperty<bool> _optimizeForVisualContent;
        private AutomationProperty<OrientationType> _orientation;
        private AutomationProperty<int[]> _outlineColor;
        private AutomationProperty<int[]> _outlineThickness;
        private AutomationProperty<int> _positionInSet;
        private AutomationProperty<int> _processId;
        private AutomationProperty<string> _providerDescription;
        private AutomationProperty<int> _rotation;
        private AutomationProperty<int[]> _runtimeId;
        private AutomationProperty<int[]> _size;
        private AutomationProperty<int> _sizeOfSet;
        private AutomationProperty<VisualEffects> _visualEffects;

        /// <summary>
        /// Provides access to all properties.
        /// </summary>
        public IProperties Properties => this;

        /// <summary>
        /// Gets a string containing the accelerator key combinations for the element.
        /// </summary>
        public AutomationProperty<string> AcceleratorKey => GetOrCreate(ref _acceleratorKey, PropertyIdLibrary.AcceleratorKey);

        /// <summary>
        /// Gets a string containing the access key character for the element.
        /// </summary>
        public AutomationProperty<string> AccessKey => GetOrCreate(ref _accessKey, PropertyIdLibrary.AccessKey);

        public AutomationProperty<int[]> AnnotationObjects => GetOrCreate(ref _annotationObjects, PropertyIdLibrary.AnnotationObjects);

        public AutomationProperty<int[]> AnnotationTypes => GetOrCreate(ref _annotationTypes, PropertyIdLibrary.AnnotationTypes);

        /// <summary>
        /// Gets a formatted string containing the Accessible Rich Internet Application (ARIA) property information for the element.
        /// </summary>
        public AutomationProperty<string> AriaProperties => GetOrCreate(ref _ariaProperties, PropertyIdLibrary.AriaProperties);

        /// <summary>
        /// Gets a string containing the Accessible Rich Internet Application (ARIA) role information for the element.
        /// </summary>
        public AutomationProperty<string> AriaRole => GetOrCreate(ref _ariaRole, PropertyIdLibrary.AriaRole);

        /// <summary>
        /// Gets a string containing the UI Automation identifier (ID) for the element.
        /// </summary>
        public AutomationProperty<string> AutomationId => GetOrCreate(ref _automationId, PropertyIdLibrary.AutomationId);

        /// <summary>
        /// Gets the coordinates of the rectangle that completely encloses the element.
        /// </summary>
        public AutomationProperty<Rectangle> BoundingRectangle => GetOrCreate(ref _boundingRectangle, PropertyIdLibrary.BoundingRectangle);

        public AutomationProperty<Point> CenterPoint => GetOrCreate(ref _centerPoint, PropertyIdLibrary.CenterPoint);

        /// <summary>
        /// Gets a string containing the class name of the element as assigned by the control developer.
        /// </summary>
        public AutomationProperty<string> ClassName => GetOrCreate(ref _className, PropertyIdLibrary.ClassName);

        /// <summary>
        /// Gets a point on the element that can be clicked. An element cannot be clicked if it is completely or partially obscured by another window.
        /// </summary>
        public AutomationProperty<Point> ClickablePoint => GetOrCreate(ref _clickablePoint, PropertyIdLibrary.ClickablePoint);

        /// <summary>
        /// Gets an array of elements that are manipulated by the current element.
        /// </summary>
        public AutomationProperty<AutomationElement[]> ControllerFor => GetOrCreate(ref _controllerFor, PropertyIdLibrary.ControllerFor);

        /// <summary>
        /// Gets the <see cref="ControlType"/> of the element.
        /// </summary>
        public AutomationProperty<ControlType> ControlType => GetOrCreate(ref _controlType, PropertyIdLibrary.ControlType);

        /// <summary>
        /// Gets the locale identifier of the element.
        /// </summary>
        public AutomationProperty<CultureInfo> Culture => GetOrCreate(ref _culture, PropertyIdLibrary.Culture);

        /// <summary>
        /// Gets an array of elements that provide more information about the current element.
        /// </summary>
        public AutomationProperty<AutomationElement[]> DescribedBy => GetOrCreate(ref _describedBy, PropertyIdLibrary.DescribedBy);

        public AutomationProperty<int> FillColor => GetOrCreate(ref _fillColor, PropertyIdLibrary.FillColor);

        public AutomationProperty<int> FillType => GetOrCreate(ref _fillType, PropertyIdLibrary.FillType);

        /// <summary>
        /// Gets an array of elements that suggests the reading order before the current element.
        /// </summary>
        public AutomationProperty<AutomationElement[]> FlowsFrom => GetOrCreate(ref _flowsFrom, PropertyIdLibrary.FlowsFrom);

        /// <summary>
        /// Gets an array of elements that suggests the reading order after the current element.
        /// </summary>
        public AutomationProperty<AutomationElement[]> FlowsTo => GetOrCreate(ref _flowsTo, PropertyIdLibrary.FlowsTo);

        /// <summary>
        /// Gets the name of the underlying UI framework.
        /// </summary>
        public AutomationProperty<string> FrameworkId => GetOrCreate(ref _frameworkId, PropertyIdLibrary.FrameworkId);

        public AutomationProperty<string> FullDescription => GetOrCreate(ref _fullDescription, PropertyIdLibrary.FullDescription);

        /// <summary>
        /// Gets a value that indicates whether the element has keyboard focus.
        /// </summary>
        public AutomationProperty<bool> HasKeyboardFocus => GetOrCreate(ref _hasKeyboardFocus, PropertyIdLibrary.HasKeyboardFocus);

        /// <summary>
        /// Gets the help text associated with the element.
        /// </summary>
        public AutomationProperty<string> HelpText => GetOrCreate(ref _helpText, PropertyIdLibrary.HelpText);

        /// <summary>
        /// Gets a value that specifies whether the element is a content element.
        /// </summary>
        public AutomationProperty<bool> IsContentElement => GetOrCreate(ref _isContentElement, PropertyIdLibrary.IsContentElement);

        /// <summary>
        /// Gets a value that indicates whether the element is viewed as a control.
        /// </summary>
        public AutomationProperty<bool> IsControlElement => GetOrCreate(ref _isControlElement, PropertyIdLibrary.IsControlElement);

        /// <summary>
        /// Gets a value that indicates whether the entered or selected value is valid for the form rule associated with the element.
        /// </summary>
        public AutomationProperty<bool> IsDataValidForForm => GetOrCreate(ref _isDataValidForForm, PropertyIdLibrary.IsDataValidForForm);

        /// <summary>
        /// Gets a value that indicates whether the user interface (UI) item referenced by the element is enabled.
        /// </summary>
        public AutomationProperty<bool> IsEnabled => GetOrCreate(ref _isEnabled, PropertyIdLibrary.IsEnabled);

        /// <summary>
        /// Gets a value that indicates whether the element can accept keyboard focus.
        /// </summary>
        public AutomationProperty<bool> IsKeyboardFocusable => GetOrCreate(ref _isKeyboardFocusable, PropertyIdLibrary.IsKeyboardFocusable);

        /// <summary>
        /// Gets a value that indicates whether the element is visible on the screen.
        /// </summary>
        public AutomationProperty<bool> IsOffscreen => GetOrCreate(ref _isOffscreen, PropertyIdLibrary.IsOffscreen);

        /// <summary>
        /// Gets a value that indicates whether the element contains protected content.
        /// </summary>
        public AutomationProperty<bool> IsPassword => GetOrCreate(ref _isPassword, PropertyIdLibrary.IsPassword);

        /// <summary>
        /// Gets a value that indicates whether the element represents peripheral UI.
        /// Peripheral UI appears and supports user interaction, but does not take keyboard focus when it appears.
        /// Examples of peripheral UI includes popups, flyouts, context menus, or floating notifications.
        /// </summary>
        public AutomationProperty<bool> IsPeripheral => GetOrCreate(ref _isPeripheral, PropertyIdLibrary.IsPeripheral);

        /// <summary>
        /// Gets a value that indicates whether the element is required to be filled out on a form.
        /// </summary>
        public AutomationProperty<bool> IsRequiredForForm => GetOrCreate(ref _isRequiredForForm, PropertyIdLibrary.IsRequiredForForm);

        /// <summary>
        /// Gets a description of the status of an item within an element.
        /// </summary>
        public AutomationProperty<string> ItemStatus => GetOrCreate(ref _itemStatus, PropertyIdLibrary.ItemStatus);

        /// <summary>
        /// Gets a description of the type of an item.
        /// </summary>
        public AutomationProperty<string> ItemType => GetOrCreate(ref _itemType, PropertyIdLibrary.ItemType);

        /// <summary>
        /// Gets the element that contains the text label for this element.
        /// </summary>
        public AutomationProperty<AutomationElement> LabeledBy => GetOrCreate(ref _labeledBy, PropertyIdLibrary.LabeledBy);

        public AutomationProperty<int> LandmarkType => GetOrCreate(ref _landmarkType, PropertyIdLibrary.LandmarkType);

        public AutomationProperty<int> Level => GetOrCreate(ref _level, PropertyIdLibrary.Level);

        /// <summary>
        /// Gets a value which indicates the "politeness" level that a client should use to notify the user of changes to the live region.
        /// </summary>
        public AutomationProperty<LiveSetting> LiveSetting => GetOrCreate(ref _liveSetting, PropertyIdLibrary.LiveSetting);

        /// <summary>
        /// Gets a description of the control type.
        /// </summary>
        public AutomationProperty<string> LocalizedControlType => GetOrCreate(ref _localizedControlType, PropertyIdLibrary.LocalizedControlType);

        public AutomationProperty<string> LocalizedLandmarkType => GetOrCreate(ref _localizedLandmarkType, PropertyIdLibrary.LocalizedLandmarkType);

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        public AutomationProperty<string> Name => GetOrCreate(ref _name, PropertyIdLibrary.Name);

        /// <summary>
        /// Gets the handle of the element's window.
        /// </summary>
        public AutomationProperty<IntPtr> NativeWindowHandle => GetOrCreate(ref _nativeWindowHandle, PropertyIdLibrary.NativeWindowHandle);

        /// <summary>
        /// Gets a value that indicates whether the provider exposes only elements that are visible.
        /// A provider can use this property to optimize performance when working with very large pieces of content.
        /// For example, as the user pages through a large piece of content, the provider can destroy content elements that are no longer visible.
        /// </summary>
        public AutomationProperty<bool> OptimizeForVisualContent => GetOrCreate(ref _optimizeForVisualContent, PropertyIdLibrary.OptimizeForVisualContent);

        /// <summary>
        /// Gets the orientation of the control.
        /// </summary>
        public AutomationProperty<OrientationType> Orientation => GetOrCreate(ref _orientation, PropertyIdLibrary.Orientation);

        public AutomationProperty<int[]> OutlineColor => GetOrCreate(ref _outlineColor, PropertyIdLibrary.OutlineColor);

        public AutomationProperty<int[]> OutlineThickness => GetOrCreate(ref _outlineThickness, PropertyIdLibrary.OutlineThickness);

        public AutomationProperty<int> PositionInSet => GetOrCreate(ref _positionInSet, PropertyIdLibrary.PositionInSet);

        /// <summary>
        /// Gets the process identifier (ID) of this element.
        /// </summary>
        public AutomationProperty<int> ProcessId => GetOrCreate(ref _processId, PropertyIdLibrary.ProcessId);

        /// <summary>
        /// Gets a formatted string containing the source information of the UI Automation provider for the element, including proxy information.
        /// </summary>
        public AutomationProperty<string> ProviderDescription => GetOrCreate(ref _providerDescription, PropertyIdLibrary.ProviderDescription);

        public AutomationProperty<int> Rotation => GetOrCreate(ref _rotation, PropertyIdLibrary.Rotation);

        /// <summary>
        /// Gets the unique identifier assigned to the user interface (UI) item.
        /// </summary>
        public AutomationProperty<int[]> RuntimeId => GetOrCreate(ref _runtimeId, PropertyIdLibrary.RuntimeId);

        public AutomationProperty<int[]> Size => GetOrCreate(ref _size, PropertyIdLibrary.Size);

        public AutomationProperty<int> SizeOfSet => GetOrCreate(ref _sizeOfSet, PropertyIdLibrary.SizeOfSet);

        public AutomationProperty<VisualEffects> VisualEffects => GetOrCreate(ref _visualEffects, PropertyIdLibrary.VisualEffects);

        private AutomationProperty<T> GetOrCreate<T>(ref AutomationProperty<T> val, PropertyId propertyId)
        {
            return val ?? (val = new AutomationProperty<T>(propertyId, this));
        }

        public interface IProperties
        {
            AutomationProperty<string> AcceleratorKey { get; }
            AutomationProperty<string> AccessKey { get; }
            AutomationProperty<int[]> AnnotationObjects { get; }
            AutomationProperty<int[]> AnnotationTypes { get; }
            AutomationProperty<string> AriaProperties { get; }
            AutomationProperty<string> AriaRole { get; }
            AutomationProperty<string> AutomationId { get; }
            AutomationProperty<Rectangle> BoundingRectangle { get; }
            AutomationProperty<Point> CenterPoint { get; }
            AutomationProperty<string> ClassName { get; }
            AutomationProperty<Point> ClickablePoint { get; }
            AutomationProperty<AutomationElement[]> ControllerFor { get; }
            AutomationProperty<ControlType> ControlType { get; }
            AutomationProperty<CultureInfo> Culture { get; }
            AutomationProperty<AutomationElement[]> DescribedBy { get; }
            AutomationProperty<int> FillColor { get; }
            AutomationProperty<int> FillType { get; }
            AutomationProperty<AutomationElement[]> FlowsFrom { get; }
            AutomationProperty<AutomationElement[]> FlowsTo { get; }
            AutomationProperty<string> FrameworkId { get; }
            AutomationProperty<string> FullDescription { get; }
            AutomationProperty<bool> HasKeyboardFocus { get; }
            AutomationProperty<string> HelpText { get; }
            AutomationProperty<bool> IsContentElement { get; }
            AutomationProperty<bool> IsControlElement { get; }
            AutomationProperty<bool> IsDataValidForForm { get; }
            AutomationProperty<bool> IsEnabled { get; }
            AutomationProperty<bool> IsKeyboardFocusable { get; }
            AutomationProperty<bool> IsOffscreen { get; }
            AutomationProperty<bool> IsPassword { get; }
            AutomationProperty<bool> IsPeripheral { get; }
            AutomationProperty<bool> IsRequiredForForm { get; }
            AutomationProperty<string> ItemStatus { get; }
            AutomationProperty<string> ItemType { get; }
            AutomationProperty<AutomationElement> LabeledBy { get; }
            AutomationProperty<int> LandmarkType { get; }
            AutomationProperty<int> Level { get; }
            AutomationProperty<LiveSetting> LiveSetting { get; }
            AutomationProperty<string> LocalizedControlType { get; }
            AutomationProperty<string> LocalizedLandmarkType { get; }
            AutomationProperty<string> Name { get; }
            AutomationProperty<IntPtr> NativeWindowHandle { get; }
            AutomationProperty<bool> OptimizeForVisualContent { get; }
            AutomationProperty<OrientationType> Orientation { get; }
            AutomationProperty<int[]> OutlineColor { get; }
            AutomationProperty<int[]> OutlineThickness { get; }
            AutomationProperty<int> PositionInSet { get; }
            AutomationProperty<int> ProcessId { get; }
            AutomationProperty<string> ProviderDescription { get; }
            AutomationProperty<int> Rotation { get; }
            AutomationProperty<int[]> RuntimeId { get; }
            AutomationProperty<int[]> Size { get; }
            AutomationProperty<int> SizeOfSet { get; }
            AutomationProperty<VisualEffects> VisualEffects { get; }
        }
    }
}
