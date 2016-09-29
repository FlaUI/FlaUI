using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
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
            var nativeFoundElements = NativeElement.FindAll((UIA.TreeScope)treeScope, NativeConditionConverter.ToNative(condition));
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
            var success = NativeElement.TryGetClickablePoint(out outPoint);
            point = success ? new Point(outPoint.X, outPoint.Y) : null;
            return success;
        }

        public override IElementProperties CreateProperties()
        {
            return new UIA2ElementProperties();
        }
    }
}
