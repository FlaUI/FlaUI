using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Tools;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class UIA3AutomationObject : AutomationObjectBase
    {
        public UIA3AutomationObject(UIA3Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation)
        {
            Automation = automation;
            NativeElement = nativeElement;
        }

        /// <summary>
        /// Concrete implementation of the automation object
        /// </summary>
        public new UIA3Automation Automation { get; private set; }

        /// <summary>
        /// Native object for the ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement { get; private set; }

        /// <summary>
        /// Native object for Windows 8 ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement2
        {
            get { return GetAutomationElementAs<UIA.IUIAutomationElement2>(); }
        }

        /// <summary>
        /// Native object for Windows 8.1 ui element
        /// </summary>
        public UIA.IUIAutomationElement NativeElement3
        {
            get { return GetAutomationElementAs<UIA.IUIAutomationElement3>(); }
        }

        public override void SetFocus()
        {
            NativeElement.SetFocus();
        }

        public override IElementInformation CreateInformation(bool cached)
        {
            return new UIA3ElementInformation(this, cached);
        }

        public override IPatternFactory CreatePatternFactory()
        {
            return new UIA3PatternFactory(this);
        }

        protected override object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported)
        {
            var ignoreDefaultValue = useDefaultIfNotSupported ? 0 : 1;
            var returnValue = cached ?
                NativeElement.GetCachedPropertyValueEx(propertyId, ignoreDefaultValue) :
                NativeElement.GetCurrentPropertyValueEx(propertyId, ignoreDefaultValue);
            return returnValue;
        }

        public override Element[] FindAll(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElements = NativeElement.FindAll((UIA.TreeScope)treeScope, NativeConditionConverter.ToNative(Automation, condition));
            return NativeValueConverter.NativeArrayToManaged(Automation, nativeFoundElements);
        }

        public override Element FindFirst(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElement = NativeElement.FindFirst((UIA.TreeScope)treeScope, NativeConditionConverter.ToNative(Automation, condition));
            return NativeValueConverter.NativeToManaged(Automation, nativeFoundElement);
        }

        public override bool TryGetClickablePoint(out Point point)
        {
            var tagPoint = new UIA.tagPOINT { x = 0, y = 0 };
            var success = ComCallWrapper.Call(() => NativeElement.GetClickablePoint(out tagPoint)) != 0;
            point = success ? new Point(tagPoint.x, tagPoint.y) : null;
            return success;
        }

        /// <summary>
        /// Tries to cast the automation element to a specific interface.
        /// Throws an exception if that is not possible.
        /// </summary>
        private T GetAutomationElementAs<T>() where T : class, UIA.IUIAutomationElement
        {
            var element = NativeElement as T;
            if (element == null)
            {
                throw new NotSupportedException(String.Format("OS does not have {0} support.", typeof(T).Name));
            }
            return element;
        }

        #region Properties
        public override PropertyId AcceleratorKeyProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId AccessKeyProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId AriaPropertiesProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId AriaRoleProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId AutomationIdProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId BoundingRectangleProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId ClassNameProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId ClickablePointProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId ControllerForProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId ControlTypeProperty
        {
            get { return AutomationObjectIds.ControlTypeProperty; }
        }

        public override PropertyId CultureProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId DescribedByProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId FlowsFromProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId FlowsToProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId FrameworkIdProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId HasKeyboardFocusProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId HelpTextProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId IsContentElementProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId IsControlElementProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId IsDataValidForFormProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId IsEnabledProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId IsKeyboardFocusableProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId IsOffscreenProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId IsPasswordProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId IsPeripheralProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId IsRequiredForFormProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId ItemStatusProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId ItemTypeProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId LabeledByProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId LiveSettingProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId LocalizedControlTypeProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId NameProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId NativeWindowHandleProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId OptimizeForVisualContentProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId OrientationProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId ProcessIdProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId ProviderDescriptionProperty
        {
            get { throw new NotImplementedException(); }
        }

        public override PropertyId RuntimeIdProperty
        {
            get { throw new NotImplementedException(); }
        }

        #endregion Properties
    }
}
