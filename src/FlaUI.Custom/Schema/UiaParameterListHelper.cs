using System.Collections.Generic;
using System.Linq;
using Interop.UIAutomationCore;

namespace ManagedUiaCustomizationCore
{
    /// <summary>
    /// Helper class to assemble information about a parameter list
    /// </summary>
    public class UiaParameterListHelper
    {
        private readonly List<UiaParameterHelper> _uiaParams = new List<UiaParameterHelper>();

        // Construct a parameter list from a method info structure
        public UiaParameterListHelper(UiaMethodInfoHelper methodInfo)
        {
            foreach (var inParamType in methodInfo.InParamTypes)
            {
                _uiaParams.Add(new UiaParameterHelper(inParamType));
            }
            foreach (var outParamType in methodInfo.OutParamTypes)
            {
                _uiaParams.Add(new UiaParameterHelper(outParamType));
            }
        }

        // Construct a parameter list from a given in-memory structure
        public UiaParameterListHelper(UIAutomationParameter[] pParams)
        {
            // Construct the parameter list from the marshalled data
            for (uint i = 0; i < pParams.Length; ++i)
            {
                _uiaParams.Add(new UiaParameterHelper(pParams[i].type, pParams[i].pData));
            }
        }

        // Get a pointer to the whole parameter list marshalled into a block of memory
        public UIAutomationParameter[] Data
        {
            get
            {
                return _uiaParams.Select(p => p.ToUiaParam()).ToArray();
            }
        }

        /// <summary>
        /// The count of parameters in this list
        /// </summary>
        public uint Count
        {
            get { return (uint) _uiaParams.Count; }
        }

        // Helper method to initialize the incoming parameters list.
        public void Initialize(params object[] inParams)
        {
            for (var i = 0; i < inParams.Length; ++i)
            {
                this[i] = inParams[i];
            }
        }

        /// <summary>
        /// The value of the specified parameter in this list
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public object this[int i]
        {
            get { return _uiaParams[i].Value; }
            set { _uiaParams[i].Value = value; }
        }
    }
}