using System.Diagnostics;
using Interop.UIAutomationCore;

namespace ManagedUiaCustomizationCore
{
    /// <summary>
    ///     Base class for a custom pattern's client instance.
    ///     Responsible for hiding some of the details of marshalling client-side custom calls;
    ///     this is mostly syntactic sugar to keep the custom pattern instance neat.
    /// </summary>
    public class CustomClientInstanceBase
    {
        protected IUIAutomationPatternInstance PatternInstance;

        protected CustomClientInstanceBase(IUIAutomationPatternInstance patternInstance)
        {
            PatternInstance = patternInstance;
        }

        // Get a current property value for this custom property
        protected object GetCurrentPropertyValue(UiaPropertyInfoHelper propInfo)
        {
            var param = new UiaParameterHelper(propInfo.UiaType);
            PatternInstance.GetProperty(propInfo.Index, 0 /* fCached */, param.GetUiaType(), param.Data);
            return param.Value;
        }

        // Get a current property value by calling a method, rather than by using GetProperty
        protected object GetCurrentPropertyValueViaMethod(UiaMethodInfoHelper methodInfo)
        {
            // Create and init a parameter list
            var paramList = new UiaParameterListHelper(methodInfo);
            Debug.Assert(paramList.Count == 1);

            // Call through
            PatternInstance.CallMethod(methodInfo.Index, paramList.Data, paramList.Count);

            // Return the out-parameter
            return paramList[0];
        }

        // Get a cached property value for this custom property
        protected object GetCachedPropertyValue(UiaPropertyInfoHelper propInfo)
        {
            var param = new UiaParameterHelper(propInfo.UiaType);
            PatternInstance.GetProperty(propInfo.Index, 1 /* fCached */, param.GetUiaType(), param.Data);
            return param.Value;
        }

        // Call a pattern instance method with this parameter list
        protected void CallMethod(UiaMethodInfoHelper methodInfo, UiaParameterListHelper paramList)
        {
            PatternInstance.CallMethod(methodInfo.Index, paramList.Data, paramList.Count);
        }

        // Call a pattern instance method with only in-params
        protected void CallMethod(UiaMethodInfoHelper methodInfo, params object[] methodParams)
        {
            // Create and init a parameter list
            var paramList = new UiaParameterListHelper(methodInfo);
            paramList.Initialize(methodParams);

            // Call through
            PatternInstance.CallMethod(methodInfo.Index, paramList.Data, paramList.Count);
        }
    }
}
