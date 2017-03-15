using System;
using System.Linq;
using System.Reflection;
using System.Windows.Automation;

namespace ManagedUiaCustomizationCore
{
    internal class ProviderPatternMatcher
    {
        internal static MethodInfo GetMatchingPatternMethod(Type patternInterface, MethodInfo providerMethodInfo)
        {
            return patternInterface.GetMethods()
                                   .Where(m => m.Name == providerMethodInfo.Name)
                                   .FirstOrDefault(mi => MethodsMatch(providerMethodInfo, mi));
        }

        private static bool MethodsMatch(MethodInfo providerMethod, MethodInfo patternMethod)
        {
            var providerParamTypes = providerMethod.GetParameters().Select(param => param.ParameterType).ToArray();
            var patternParamTypes = patternMethod.GetParameters().Select(param => param.ParameterType).ToArray();
            
            if (patternParamTypes.Length != providerParamTypes.Length) 
                return false;
            return Enumerable.Range(0, patternParamTypes.Length)
                             .All(idx => ParametersMatch(providerParamTypes[idx], patternParamTypes[idx]));
        }

        internal static bool ParametersMatch(Type serverParamType, Type clientParamType)
        {
            if (serverParamType.IsByRef != clientParamType.IsByRef)
                return false;

            if (UiaTypesHelper.IsElementOnServerSide(serverParamType))
            {
                if (clientParamType.IsByRef)
                    clientParamType = clientParamType.GetElementType();
                return UiaTypesHelper.IsElementOnClientSide(clientParamType)
                       || clientParamType == typeof(AutomationElement);
            }

            return serverParamType == clientParamType;
        }
    }
}