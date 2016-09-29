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

        public override IElementProperties CreateProperties()
        {
            return new UIA3ElementProperties();
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
    }
}
