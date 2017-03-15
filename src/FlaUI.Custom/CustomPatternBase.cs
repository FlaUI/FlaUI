using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Automation;

namespace ManagedUiaCustomizationCore
{
    public abstract class CustomPatternBase<TProviderInterface, TPatternClientInterface> : AttributeDrivenPatternSchema
    {
        private readonly bool _usedInWpf;
        private UiaPropertyInfoHelper[] _standaloneProperties;

        protected CustomPatternBase(bool usedInWpf)
            : base(typeof(TProviderInterface), typeof(TPatternClientInterface))
        {
            _usedInWpf = usedInWpf;
            ReflectStandaloneProperties();
            Register();
            if (_usedInWpf)
                AutomationPeerAugmentationHelper.Register(this);
            FillRegistrationInfo();
        }

        public override UiaPropertyInfoHelper[] StandaloneProperties
        {
            get { return _standaloneProperties; }
        }

        private void ReflectStandaloneProperties()
        {
            var t = GetType();
            var fs = t.GetStaticFieldsMarkedWith<StandalonePropertyAttribute>();
            var standaloneProps = new List<UiaPropertyInfoHelper>();
            foreach (var fieldInfo in fs)
            {
                if (!fieldInfo.Name.EndsWith("Property"))
                    throw new ArgumentException("Field {0} marked with StandalonePropertyAttribute but named incorrectly. Should be XxxProperty, where Xxx is the programmatic name of the property being registered");
                var programmaticName = fieldInfo.Name.Remove(fieldInfo.Name.Length - "Property".Length);
                var attr = fieldInfo.GetAttribute<StandalonePropertyAttribute>();
                var uiaType = UiaTypesHelper.TypeToAutomationType(attr.Type);
                standaloneProps.Add(new UiaPropertyInfoHelper(attr.Guid, programmaticName, uiaType));
            }
            if (standaloneProps.Count > 0)
                _standaloneProperties = standaloneProps.ToArray();
        }

        private void FillRegistrationInfo()
        {
            var t = GetType();
            if (t.Name != PatternName)
                throw new ArgumentException(string.Format("Type is named incorrectly. Should be {0}", PatternName));

            SetPatternRegistrationInfo();

            foreach (var prop in Properties)
                SetPropertyRegistrationInfo(prop);
            if (StandaloneProperties != null)
            {
                foreach (var prop in StandaloneProperties)
                SetPropertyRegistrationInfo(prop);
            }
        }

        private void SetPatternRegistrationInfo()
        {
            var pri = GetType().GetField("Pattern", BindingFlags.Static | BindingFlags.Public);
            if (pri == null)
                throw new ArgumentException("Field Pattern not found on the type");

            if (pri.FieldType == typeof(int))
                pri.SetValue(null, PatternId);
            else if (pri.FieldType == typeof(AutomationPattern))
            {
                if (!_usedInWpf)
                    throw new ArgumentException("You can't use AutomationPattern registration info because you passed usedInWpf: false in constructor");
                pri.SetValue(null, AutomationPattern.LookupById(PatternId));
            }
            else
                throw new ArgumentException("Field Pattern should be either of type int of AutomationPattern");
        }

        private void SetPropertyRegistrationInfo(UiaPropertyInfoHelper prop)
        {
            var propFieldName = prop.Data.pProgrammaticName + "Property";
            var field = GetType().GetField(propFieldName, BindingFlags.Static | BindingFlags.Public);
            if (field == null)
                throw new ArgumentException(string.Format("Field {0} not found on the type", propFieldName));
            if (field.FieldType == typeof(int))
                field.SetValue(null, prop.PropertyId);
            else if (field.FieldType == typeof(AutomationProperty))
            {
                if (!_usedInWpf)
                    throw new ArgumentException("You can't use AutomationPattern registration info because you passed usedInWpf: false in constructor");
                field.SetValue(null, AutomationProperty.LookupById(prop.PropertyId));
            }
            else
                throw new ArgumentException("Fields for properties should be either of type int of AutomationProperty");
        }
    }
}
