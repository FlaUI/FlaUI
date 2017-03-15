using System;
using System.Runtime.InteropServices;
using Interop.UIAutomationClient;
using Interop.UIAutomationCore;
using IRawElementProviderSimple = Interop.UIAutomationCore.IRawElementProviderSimple;

namespace ManagedUiaCustomizationCore
{
    /// <summary>
    /// Helper class to marshal parameters for UIA custom method calls
    /// Corresponds to UIAutomationParameter
    /// </summary>
    public class UiaParameterHelper
    {
        private readonly UIAutomationType _uiaType;
        private readonly Type _clrType;
        private readonly IntPtr _marshalledData;
        private readonly bool _ownsData;
        private readonly bool _onClientSide;

        public UiaParameterHelper(UIAutomationType type)
        {
            _uiaType = type;
            _clrType = ClrTypeFromUiaType(type);
            _marshalledData = Marshal.AllocCoTaskMem(GetSizeOfMarshalledData());
            _ownsData = true;

            // It is a safe assumption that if we are initialized without incoming data,
            // we are on the client side.  If this changes, we can make this an explicit parameter.
            _onClientSide = true;
        }

        public UiaParameterHelper(UIAutomationType type, IntPtr marshalledData)
        {
            _uiaType = type;
            _clrType = ClrTypeFromUiaType(type);
            _marshalledData = marshalledData;
            _ownsData = false;
            GC.SuppressFinalize(this);

            // It is a safe assumption that if we are initialized with incoming data,
            // we are on the provider side.  If this changes, we can make this an explicit parameter.
            _onClientSide = false;
        }

        /// <summary>
        /// Clean up any marshalled data attached to this object
        /// </summary>
        ~UiaParameterHelper()
        {
            if (_ownsData)
            {
                var basicType = _uiaType & ~UIAutomationType.UIAutomationType_Out;
                if (basicType == UIAutomationType.UIAutomationType_String)
                {
                    var bstr = Marshal.ReadIntPtr(_marshalledData);
                    Marshal.FreeBSTR(bstr);
                }
                else if (basicType == UIAutomationType.UIAutomationType_Element)
                {
                    var elementAsIntPtr = Marshal.ReadIntPtr(_marshalledData);
                    if (elementAsIntPtr != IntPtr.Zero)
                        Marshal.Release(elementAsIntPtr);
                }

                Marshal.FreeCoTaskMem(_marshalledData);
            }
        }

        /// <summary>
        /// Marshal the parameter's value to/from unmanaged code structures
        /// </summary>
        public object Value
        {
            get
            {
                // Get the type without the Out flag
                var basicType = _uiaType & ~UIAutomationType.UIAutomationType_Out;

                switch (basicType)
                {
                    case UIAutomationType.UIAutomationType_String:
                        // Strings are held as BSTRs
                        var bstr = Marshal.ReadIntPtr(_marshalledData);
                        return Marshal.PtrToStringBSTR(bstr);
                    case UIAutomationType.UIAutomationType_Bool:
                        return 0 != (int) Marshal.PtrToStructure(_marshalledData, typeof (int));
                    case UIAutomationType.UIAutomationType_Element:
                        // Elements need to be copied as COM pointers
                        var elementAsIntPtr = Marshal.ReadIntPtr(_marshalledData);
                        return elementAsIntPtr != IntPtr.Zero ? Marshal.GetObjectForIUnknown(elementAsIntPtr) : null;
                    default:
                        return Marshal.PtrToStructure(_marshalledData, GetClrType());
                }
            }
            set
            {
                // Get the type without the Out flag
                var basicType = _uiaType & ~UIAutomationType.UIAutomationType_Out;

                // Sanity check
                if (value != null)
                {
                    Type valueType = value.GetType();
                    if (valueType.IsEnum)
                    {
                        if (basicType != UIAutomationType.UIAutomationType_Int)
                            throw new ArgumentException("Enum values should be passed as int");
                    }
                    else if (valueType != GetClrType() &&
                             basicType != UIAutomationType.UIAutomationType_Bool &&
                             basicType != UIAutomationType.UIAutomationType_Element)
                    {
                        throw new ArgumentException("Value is the wrong type for this parameter");
                    }
                }

                switch (basicType)
                {
                    case UIAutomationType.UIAutomationType_String:
                        // Strings are stored as BSTRs
                        var bstr = Marshal.StringToBSTR((string) value);
                        Marshal.WriteIntPtr(_marshalledData, bstr);
                        break;
                    case UIAutomationType.UIAutomationType_Bool:
                        // Bools are stored as integers in UIA custom parameters
                        var boolAsInt = ((bool) value) ? 1 : 0;
                        Marshal.StructureToPtr(boolAsInt, _marshalledData, true);
                        break;
                    case UIAutomationType.UIAutomationType_Element:
                        if (value == null)
                        {
                            Marshal.WriteIntPtr(_marshalledData, IntPtr.Zero);
                            break;
                        }

                        // Elements are stored as COM pointers
                        var interfaceType = (_onClientSide) ?
                            typeof (IUIAutomationElement) :
                            typeof (IRawElementProviderSimple);

                        // Now we have one of interop types in the interfaceType. The problem is,
                        // due to multiple interop assemblies (e.g. for IRawElementProviderSimple:
                        // WPF uses its own type from UIAutomationProvider, UIAComWrapper uses its 
                        // own type from Interop.AutomationClient, this code mostly uses one from
                        // Interop.AutomationCore) we can't just cast managed object from one type
                        // to another. While they represent types with same GUID, they're still
                        // different .NET types. Thus we have to get RCW for the managed object
                        // and ask it query through COM's IUnknown.
                        var refiid = interfaceType.GUID;
                        var iUnknown = Marshal.GetIUnknownForObject(value);
                        IntPtr resultIntPtr;
                        Marshal.QueryInterface(iUnknown, ref refiid, out resultIntPtr);
                        Marshal.Release(iUnknown);
                        Marshal.WriteIntPtr(_marshalledData, resultIntPtr);
                        break;
                    default:
                        if (value != null && value.GetType().IsEnum)
                            Marshal.StructureToPtr((int)value, _marshalledData, true);
                        else
                            Marshal.StructureToPtr(value, _marshalledData, true);
                        break;
                }
            }
        }

        /// <summary>
        /// Get the marshalled data for this helper
        /// </summary>
        public IntPtr Data
        {
            get { return _marshalledData; }
        }

        // Retrieve a UIAutomationParameter structure for this parameter
        public UIAutomationParameter ToUiaParam()
        {
            UIAutomationParameter uiaParam;
            uiaParam.type = _uiaType;
            uiaParam.pData = _marshalledData;
            return uiaParam;
        }

        // Get the UIA type for this parameter
        public UIAutomationType GetUiaType()
        {
            return _uiaType;
        }

        // Get the CLR type for this parameter
        public Type GetClrType()
        {
            return _clrType;
        }

        // Calculate how much marshalled data we'll need for this
        private int GetSizeOfMarshalledData()
        {
            var basicType = _uiaType & ~UIAutomationType.UIAutomationType_Out;
            if (basicType == UIAutomationType.UIAutomationType_String ||
                basicType == UIAutomationType.UIAutomationType_Element)
                return IntPtr.Size;
            return Marshal.SizeOf(_clrType);
        }

        // Compute a CLR type from its UIA type
        private Type ClrTypeFromUiaType(UIAutomationType uiaType)
        {
            // Mask off the out flag, which we don't care about.
            uiaType = (UIAutomationType) ((int) uiaType & (int) ~UIAutomationType.UIAutomationType_Out);

            switch (uiaType)
            {
                case UIAutomationType.UIAutomationType_Int:
                    return typeof (int);
                case UIAutomationType.UIAutomationType_Bool:
                    return typeof (int); // These are BOOL, not bool
                case UIAutomationType.UIAutomationType_String:
                    return typeof (string);
                case UIAutomationType.UIAutomationType_Double:
                    return typeof (double);
                case UIAutomationType.UIAutomationType_Element:
                    return (_onClientSide) ? typeof (IUIAutomationElement) : typeof (IRawElementProviderSimple);
                default:
                    throw new ArgumentException("Type not supported by UIAutomationType");
            }
        }
    }
}