using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.UIA2.Tools;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    public class UIA2AutomationObject : AutomationObjectBase
    {
        public UIA2AutomationObject(UIA2Automation automation, UIA.AutomationElement nativeElement) : base(automation)
        {
            Automation = automation;
            NativeElement = nativeElement;
        }

        /// <summary>
        /// Concrete implementation of the automation object
        /// </summary>
        public new UIA2Automation Automation { get; private set; }

        /// <summary>
        /// Native object for the ui element
        /// </summary>
        public UIA.AutomationElement NativeElement { get; private set; }

        public override void SetFocus()
        {
            NativeElement.SetFocus();
        }

        public override IElementInformation CreateInformation(bool cached)
        {
            return new UIA2ElementInformation(this, cached);
        }

        public override IPatternFactory CreatePatternFactory()
        {
            return new UIA2PatternFactory(this);
        }

        protected override object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported)
        {
            var ignoreDefaultValue = !useDefaultIfNotSupported;
            var property = UIA.AutomationProperty.LookupById(propertyId);
            var returnValue = cached ?
                NativeElement.GetCachedPropertyValue(property, ignoreDefaultValue) :
                NativeElement.GetCurrentPropertyValue(property, ignoreDefaultValue);
            return returnValue;
        }

        public override Element[] FindAll(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElements = NativeElement.FindAll((UIA.TreeScope) treeScope, NativeConditionConverter.ToNative(condition));
            return NativeValueConverter.NativeArrayToManaged(Automation, nativeFoundElements);
        }

        public override Element FindFirst(TreeScope treeScope, ConditionBase condition)
        {
            var nativeFoundElement = NativeElement.FindFirst((UIA.TreeScope)treeScope, NativeConditionConverter.ToNative(condition));
            return NativeValueConverter.NativeToManaged(Automation, nativeFoundElement);
        }

        public override bool TryGetClickablePoint(out Point point)
        {
            System.Windows.Point outPoint;
            var success =  NativeElement.TryGetClickablePoint(out outPoint);
            point = success ? new Point(outPoint.X, outPoint.Y) : null;
            return success;
        }

        #region Properties
        public override PropertyId AcceleratorKeyProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId AccessKeyProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId AriaPropertiesProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId AriaRoleProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId AutomationIdProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId BoundingRectangleProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId ClassNameProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId ClickablePointProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId ControllerForProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId ControlTypeProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId CultureProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId DescribedByProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId FlowsFromProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId FlowsToProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId FrameworkIdProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId HasKeyboardFocusProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId HelpTextProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId IsContentElementProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId IsControlElementProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId IsDataValidForFormProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId IsEnabledProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId IsKeyboardFocusableProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId IsOffscreenProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId IsPasswordProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId IsPeripheralProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId IsRequiredForFormProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId ItemStatusProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId ItemTypeProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId LabeledByProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId LiveSettingProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId LocalizedControlTypeProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId NameProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId NativeWindowHandleProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId OptimizeForVisualContentProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId OrientationProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId ProcessIdProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId ProviderDescriptionProperty
        {
            get { throw new System.NotImplementedException(); }
        }

        public override PropertyId RuntimeIdProperty
        {
            get { throw new System.NotImplementedException(); }
        }
        #endregion Properties
    }
}
