using System;
using System.Collections.Generic;
using Interop.UIAutomationClient;
using Interop.UIAutomationCore;
using IRawElementProviderSimple = Interop.UIAutomationCore.IRawElementProviderSimple;

namespace ManagedUiaCustomizationCore
{
    public static class UiaTypesHelper
    {
        public const string RetParamUnspeakableName = "<>retValue";

        private static readonly Dictionary<Type, UIAutomationType> _typeMapping
            = new Dictionary<Type, UIAutomationType>
              {
                  {typeof(int), UIAutomationType.UIAutomationType_Int},
                  {typeof(bool), UIAutomationType.UIAutomationType_Bool},
                  {typeof(string), UIAutomationType.UIAutomationType_String},
                  {typeof(double), UIAutomationType.UIAutomationType_Double},
              };

        public static UIAutomationType TypeToAutomationType(Type type)
        {
            if (IsElementOnServerSide(type))
                return UIAutomationType.UIAutomationType_Element;
            if (type.IsEnum && type.GetEnumUnderlyingType() == typeof(int))
                type = typeof(int);
            UIAutomationType res;
            if (_typeMapping.TryGetValue(type, out res))
                return res;
            throw new NotSupportedException("Provided type is not supported");
        }

        public static UIAutomationType TypeToOutAutomationType(Type type)
        {
            return TypeToAutomationType(type) | UIAutomationType.UIAutomationType_Out;
        }

        public static bool IsElementOnServerSide(Type type)
        {
            // strip ref/out modifier if needed, because it doesn't have GUID of underlying element type
            if (type.IsByRef) 
                type = type.GetElementType();
            return type.GUID == typeof(IRawElementProviderSimple).GUID;
        }

        public static bool IsElementOnClientSide(Type type)
        {
            // strip ref/out modifier if needed, because it doesn't have GUID of underlying element type
            if (type.IsByRef)
                type = type.GetElementType();
            return type.GUID == typeof(IUIAutomationElement).GUID;
        }

        public static bool IsInType(UIAutomationType type)
        {
            return !IsOutType(type);
        }

        public static bool IsOutType(UIAutomationType type)
        {
            return (type & UIAutomationType.UIAutomationType_Out) != 0;
        }
    }
}
