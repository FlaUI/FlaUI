using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Interop.UIAutomationCore;

namespace ManagedUiaCustomizationCore
{
    /// <summary>
    ///     Helper class to assemble information about a custom method
    ///     Corresponds to UIAutomationMethodInfo.
    /// </summary>
    public class UiaMethodInfoHelper : ISchemaMember
    {
        private readonly MethodInfo _providerMethodInfo;
        private readonly Dictionary<string, int> _providerMethodInfoIndicies;
        private readonly string _programmaticName;
        private readonly bool _doSetFocus;
        private readonly List<IntPtr> _inParamNames = new List<IntPtr>();
        private readonly List<UIAutomationType> _inParamTypes = new List<UIAutomationType>();
        private readonly List<IntPtr> _outParamNames = new List<IntPtr>();
        private readonly List<UIAutomationType> _outParamTypes = new List<UIAutomationType>();
        private bool _built;
        private UIAutomationMethodInfo _data;

        public UiaMethodInfoHelper(string programmaticName, bool doSetFocus, IEnumerable<UiaParameterDescription> uiaParams)
            : this(programmaticName, doSetFocus, uiaParams, null)
        {
        }

        /// <summary>
        ///     You have to use this ctor if you need ISchemaMember.DispatchCallToProvider
        /// </summary>
        public UiaMethodInfoHelper(MethodInfo providerMethodInfo, bool doSetFocus)
            : this(providerMethodInfo.Name, doSetFocus, BuildParamsFromProviderMethodInfo(providerMethodInfo), providerMethodInfo)
        {
        }

        private UiaMethodInfoHelper(string programmaticName, bool doSetFocus, IEnumerable<UiaParameterDescription> uiaParams, MethodInfo providerMethodInfo)
        {
            _programmaticName = programmaticName;
            _doSetFocus = doSetFocus;
            _providerMethodInfo = providerMethodInfo;
            if (ProviderMethodInfo != null)
            {
                _providerMethodInfoIndicies = new Dictionary<string, int>();
                var args = ProviderMethodInfo.GetParameters();
                for (int i = 0; i < args.Length; i++)
                    _providerMethodInfoIndicies.Add(args[i].Name, i);
            }

            PatternMethodParamDescriptions = new List<UiaParameterDescription>();
            foreach (var param in uiaParams)
                AddParameter(param);
        }

        ~UiaMethodInfoHelper()
        {
            foreach (var marshalledName in _inParamNames)
            {
                Marshal.FreeCoTaskMem(marshalledName);
            }
            foreach (var marshalledName in _outParamNames)
            {
                Marshal.FreeCoTaskMem(marshalledName);
            }

            Marshal.FreeCoTaskMem(_data.pParameterNames);
            Marshal.FreeCoTaskMem(_data.pParameterTypes);
        }

        public List<UiaParameterDescription> PatternMethodParamDescriptions { get; private set; }

        /// <summary>
        ///     Get a marshalled UIAutomationMethodInfo struct for this Helper.
        /// </summary>
        public UIAutomationMethodInfo Data
        {
            get
            {
                if (!_built)
                {
                    Build();
                }
                return _data;
            }
        }

        /// <summary>
        ///     The array of in-parameter types.
        /// </summary>
        public UIAutomationType[] InParamTypes
        {
            get { return _inParamTypes.ToArray(); }
        }

        /// <summary>
        ///     The array of out-parameter types.
        /// </summary>
        public UIAutomationType[] OutParamTypes
        {
            get { return _outParamTypes.ToArray(); }
        }

        /// <summary>
        ///     The index of this method.
        ///     In a UIA custom pattern, every method (and pattern property)
        ///     has an assigned index.
        /// </summary>
        public uint Index { get; set; }

        public void AddParameter(UiaParameterDescription param)
        {
            if (PatternMethodParamDescriptions.Count > 0 && UiaTypesHelper.IsOutType(PatternMethodParamDescriptions.Last().UiaType) && UiaTypesHelper.IsInType(param.UiaType))
                throw new ArgumentException("In param can't go after an out one. Please, ensure the correct order");
            if (ProviderMethodInfo != null
                && param.Name != UiaTypesHelper.RetParamUnspeakableName
                && !_providerMethodInfoIndicies.ContainsKey(param.Name))
            {
                throw new ArgumentException("Provided provider's method info does not have argument with this name");
            }

            UIAutomationType type = param.UiaType;
            var marshalledName = Marshal.StringToCoTaskMemUni(param.Name);
            if (UiaTypesHelper.IsInType(type))
            {
                _inParamNames.Add(marshalledName);
                _inParamTypes.Add(type);
            }
            else
            {
                _outParamNames.Add(marshalledName);
                _outParamTypes.Add(type);
            }
            PatternMethodParamDescriptions.Add(param);
        }

        public void DispatchCallToProvider(object provider, UiaParameterListHelper paramList)
        {
            if (ProviderMethodInfo == null)
                throw new InvalidOperationException("You need to pass providerMethodInfo if you want to call ISchemaMember.DispatchCallToProvider");
            if (paramList.Count != PatternMethodParamDescriptions.Count)
            {
                var message = string.Format("Provided paramList has unexpected number of elements. Expected {0} but was {1}",
                                            PatternMethodParamDescriptions.Count,
                                            paramList.Count);
                throw new ArgumentException(message, "paramList");
            }

            var providerCallParameters = new object[ProviderMethodInfo.GetParameters().Length];
            // fill in params
            for (int i = 0; i < PatternMethodParamDescriptions.Count; i++)
            {
                var desc = PatternMethodParamDescriptions[i];
                if (UiaTypesHelper.IsInType(desc.UiaType))
                {
                    var providerMethodParamIdx = _providerMethodInfoIndicies[desc.Name];
                    providerCallParameters[providerMethodParamIdx] = paramList[i];
                }
            }

            // call provider
            object result = null;
            try
            {
                result = ProviderMethodInfo.Invoke(provider, providerCallParameters);
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException != null)
                    throw e.InnerException;
                throw;
            }

            // write back out params
            for (int i = 0; i < PatternMethodParamDescriptions.Count; i++)
            {
                var desc = PatternMethodParamDescriptions[i];
                if (desc.Name == UiaTypesHelper.RetParamUnspeakableName)
                {
                    paramList[i] = result;
                    continue;
                }
                if (UiaTypesHelper.IsOutType(desc.UiaType))
                {
                    var providerMethodParamIdx = _providerMethodInfoIndicies[desc.Name];
                    paramList[i] = providerCallParameters[providerMethodParamIdx];
                }
            }
        }

        public bool SupportsDispatch
        {
            get { return ProviderMethodInfo != null; }
        }

        public MethodInfo ProviderMethodInfo
        {
            get { return _providerMethodInfo; }
        }

        public int GetProviderMethodArgumentIndex(string argumentName)
        {
            if (_providerMethodInfo == null)
                throw new InvalidOperationException("You need to pass providerMethodInfo if you want to use this method");

            int res;
            if (!_providerMethodInfoIndicies.TryGetValue(argumentName, out res))
                res = -1;
            return res;
        }

        /// <summary>
        ///     Marshal our data to the UIAutomationMethodInfo struct.
        /// </summary>
        private void Build()
        {
            // Copy basic data
            _data = new UIAutomationMethodInfo
                    {
                        pProgrammaticName = _programmaticName,
                        doSetFocus = _doSetFocus ? 1 : 0,
                        cInParameters = (uint)_inParamNames.Count,
                        cOutParameters = (uint)_outParamNames.Count
                    };
            var cTotalParameters = _data.cInParameters + _data.cOutParameters;

            // Allocate parameter lists and populate them
            if (cTotalParameters > 0)
            {
                _data.pParameterNames = Marshal.AllocCoTaskMem((int)(cTotalParameters*Marshal.SizeOf(typeof(IntPtr))));
                _data.pParameterTypes = Marshal.AllocCoTaskMem((int)(cTotalParameters*Marshal.SizeOf(typeof(Int32))));

                var namePointer = _data.pParameterNames;
                var typePointer = _data.pParameterTypes;
                for (var i = 0; i < _data.cInParameters; ++i)
                {
                    Marshal.WriteIntPtr(namePointer, _inParamNames[i]);
                    namePointer = (IntPtr)(namePointer.ToInt64() + Marshal.SizeOf(typeof(IntPtr)));
                    Marshal.WriteInt32(typePointer, (int)_inParamTypes[i]);
                    typePointer = (IntPtr)(typePointer.ToInt64() + Marshal.SizeOf(typeof(Int32)));
                }

                for (var i = 0; i < _data.cOutParameters; ++i)
                {
                    Marshal.WriteIntPtr(namePointer, _outParamNames[i]);
                    namePointer = (IntPtr)(namePointer.ToInt64() + Marshal.SizeOf(typeof(IntPtr)));
                    Marshal.WriteInt32(typePointer, (int)_outParamTypes[i]);
                    typePointer = (IntPtr)(typePointer.ToInt64() + Marshal.SizeOf(typeof(Int32)));
                }
            }
            else
            {
                _data.pParameterNames = IntPtr.Zero;
                _data.pParameterTypes = IntPtr.Zero;
            }

            _built = true;
        }

        private static IEnumerable<UiaParameterDescription> BuildParamsFromProviderMethodInfo(MethodInfo mInfo)
        {
            // Accordingly to UIA docs, In params should go before any Out params

            var inParams = from parameterInfo in mInfo.GetParameters()
                           where !parameterInfo.IsOut
                           let uiaType = UiaTypesHelper.TypeToAutomationType(parameterInfo.ParameterType)
                           select new UiaParameterDescription(parameterInfo.Name, uiaType);

            var outParams = from parameterInfo in mInfo.GetParameters()
                            where parameterInfo.IsOut
                            let uiaType = UiaTypesHelper.TypeToOutAutomationType(parameterInfo.ParameterType.GetElementType())
                            select new UiaParameterDescription(parameterInfo.Name, uiaType);

            var retParam = Enumerable.Empty<UiaParameterDescription>();
            if (mInfo.ReturnType != typeof(void))
            {
                var uiaRetType = UiaTypesHelper.TypeToOutAutomationType(mInfo.ReturnType);
                var retParamDescr = new UiaParameterDescription(UiaTypesHelper.RetParamUnspeakableName, uiaRetType);
                retParam = new[] {retParamDescr};
            }

            return inParams.Concat(outParams).Concat(retParam);
        }
    }
}
