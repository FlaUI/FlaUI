using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Interop.UIAutomationCore;

namespace ManagedUiaCustomizationCore
{
    public class AttributeDrivenPatternSchema : CustomPatternSchemaBase
    {
        private readonly Type _patternProviderInterface;
        private readonly Type _patternClientInterface;
        private readonly Guid _patternGuid;
        private readonly string _patternName;
        private readonly UiaMethodInfoHelper[] _methods;
        private readonly UiaPropertyInfoHelper[] _properties;
        private readonly AttributeDrivenPatternHandler _handler;

        public AttributeDrivenPatternSchema(Type patternProviderInterface, Type patternClientInterface)
        {
            if (!patternProviderInterface.IsInterface)
                throw new ArgumentException("Provided pattern provider type should be an interface", "patternProviderInterface");
            if (!patternClientInterface.IsInterface)
                throw new ArgumentException("Provided pattern client type should be an interface", "patternClientInterface");
            _patternProviderInterface = patternProviderInterface;
            _patternClientInterface = patternClientInterface;

            var patternClientName = _patternClientInterface.Name;
            if (!patternClientName.EndsWith("Pattern") || !patternClientName.StartsWith("I"))
                throw new ArgumentException("Pattern client interface named incorrectly, should be IXxxPattern", "patternClientInterface");
            var baseName = patternClientName.Substring(1, patternClientName.Length - "I".Length - "Pattern".Length);
            if (_patternProviderInterface.Name != string.Format("I{0}Provider", baseName))
                throw new ArgumentException(string.Format("Pattern provider interface named incorrectly, should be I{0}Provider", baseName));
            _patternName = string.Format("{0}Pattern", baseName);

            var patternGuidAttr = _patternProviderInterface.GetAttribute<PatternGuidAttribute>();
            if (patternGuidAttr == null) throw new ArgumentException("Provided type should be marked with PatternGuid attribute");
            _patternGuid = patternGuidAttr.Value;

            _methods = patternProviderInterface.GetMethodsMarkedWith<PatternMethodAttribute>().Select(GetMethodHelper).ToArray();
            _properties = patternProviderInterface.GetPropertiesMarkedWith<PatternPropertyAttribute>().Select(GetPropertyHelper).ToArray();
            ValidateClientInterface();
            _handler = new AttributeDrivenPatternHandler(this);
        }

        private void ValidateClientInterface()
        {
            var mErrors = GetMethodErrorsMsg();
            var pErrors = GetPropertyErrosMsg();
            if (!string.IsNullOrEmpty(mErrors) || !string.IsNullOrEmpty(pErrors))
                throw new Exception(mErrors + pErrors);
        }

        private UiaPropertyInfoHelper GetPropertyHelper(PropertyInfo pInfo)
        {
            var propertyAttr = pInfo.GetAttribute<PatternPropertyAttribute>(); // can'be null as otherwise it wouldn't get into this method
            var guid = propertyAttr.Guid;
            var programmaticName = pInfo.Name;
            var uiaType = UiaTypesHelper.TypeToAutomationType(pInfo.PropertyType);
            return new UiaPropertyInfoHelper(guid, programmaticName, uiaType, pInfo.GetPropertyGetter());
        }

        private UiaMethodInfoHelper GetMethodHelper(MethodInfo mInfo)
        {
            var methodAttr = mInfo.GetAttribute<PatternMethodAttribute>(); // can'be null as otherwise it wouldn't get into this method
            var doSetFocus = methodAttr.DoSetFocus;
            return new UiaMethodInfoHelper(mInfo, doSetFocus);
        }

        public override string PatternName
        {
            get { return _patternName; }
        }

        public override Type PatternProviderInterface
        {
            get { return _patternProviderInterface; }
        }

        public override Type PatternClientInterface
        {
            get { return _patternClientInterface; }
        }

        public override Guid PatternGuid
        {
            get { return _patternGuid; }
        }

        public override UiaPropertyInfoHelper[] Properties
        {
            get { return _properties; }
        }

        public override UiaMethodInfoHelper[] Methods
        {
            get { return _methods; }
        }

        public override UiaEventInfoHelper[] Events
        {
            // not supported for now
            get { return new UiaEventInfoHelper[0]; }
        }

        public override IUIAutomationPatternHandler Handler
        {
            get { return _handler; }
        }

        private string GetPropertyErrosMsg()
        {
            var propsWithErrors = new List<string>();
            foreach (PropertyInfo providerPropInfo in _patternProviderInterface.GetProperties())
            {
                string providerPropName = providerPropInfo.Name;
                var currentPropName = "Current" + providerPropName;
                var cachedPropName = "Cached" + providerPropName;
                var currentPropInfo = _patternClientInterface.GetProperty(currentPropName);
                var cachedPropInfo = _patternClientInterface.GetProperty(cachedPropName);
                if (currentPropInfo == null || cachedPropInfo == null)
                    propsWithErrors.Add(string.Format("{0} -- doesn't have one or both matching properties in client-side pattern interface", providerPropName));
                else if (currentPropInfo.PropertyType != cachedPropInfo.PropertyType)
                    propsWithErrors.Add(string.Format("{0} -- Current{0} and Cached{0} properties from client-side pattern interface have different types", providerPropName));
                else if (!ProviderPatternMatcher.ParametersMatch(providerPropInfo.PropertyType, currentPropInfo.PropertyType)) 
                    propsWithErrors.Add(string.Format("{0} -- types of provider and client interfaces' properties don't match", providerPropName));
            }
            if (propsWithErrors.Count > 0)
                return string.Format("These properties from provider interface have issues:\n{0}",
                                     string.Join("\n", propsWithErrors));
            return null;
        }

        private string GetMethodErrorsMsg()
        {
            var methodsWithErrors = (from methodInfoHelper in _methods
                                     select methodInfoHelper.ProviderMethodInfo
                                     into providerMethodInfo
                                     where ProviderPatternMatcher.GetMatchingPatternMethod(_patternClientInterface, providerMethodInfo) == null
                                     select providerMethodInfo.Name)
                .ToList();

            if (methodsWithErrors.Count > 0)
                return string.Format("These methods from provider interface do not have matching methods in client-side pattern interface:\n{0}",
                                     string.Join(", ", methodsWithErrors));
            return string.Empty;
        }
    }
}
